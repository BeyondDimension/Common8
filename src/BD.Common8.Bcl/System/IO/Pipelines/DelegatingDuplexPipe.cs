// https://github.com/dotnetcore/FastGithub/blob/2.1.4/FastGithub.FlowAnalyze/DelegatingDuplexPipe.cs

#if !DEL_SYS_IO_PIPELINES && NET6_0_OR_GREATER
#pragma warning disable SA1600 // Elements should be documented

namespace System.IO.Pipelines;

public class DelegatingDuplexPipe<TDelegatingStream> : IDuplexPipe, IAsyncDisposable where TDelegatingStream : DelegatingStream
{
    bool disposed;
    readonly object syncRoot = new();

    public PipeReader Input { get; }

    public PipeWriter Output { get; }

    public DelegatingDuplexPipe(IDuplexPipe duplexPipe, Func<Stream, TDelegatingStream> delegatingStreamFactory) : this(duplexPipe, new StreamPipeReaderOptions(leaveOpen: true), new StreamPipeWriterOptions(leaveOpen: true), delegatingStreamFactory)
    {
    }

    public DelegatingDuplexPipe(IDuplexPipe duplexPipe, StreamPipeReaderOptions readerOptions, StreamPipeWriterOptions writerOptions, Func<Stream, TDelegatingStream> delegatingStreamFactory)
    {
        var delegatingStream = delegatingStreamFactory(duplexPipe.AsStream());
        Input = PipeReader.Create(delegatingStream, readerOptions);
        Output = PipeWriter.Create(delegatingStream, writerOptions);
    }

    public virtual async ValueTask DisposeAsync()
    {
        lock (syncRoot)
        {
            if (disposed == true)
            {
                return;
            }
            disposed = true;
        }

        await Input.CompleteAsync();
        await Output.CompleteAsync();

        GC.SuppressFinalize(this);
    }
}
#endif