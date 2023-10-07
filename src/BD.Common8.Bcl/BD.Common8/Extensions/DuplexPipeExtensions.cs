#if !DEL_SYS_IO_PIPELINES && (!NETFRAMEWORK || (NETSTANDARD && NETSTANDARD2_0_OR_GREATER))
using System.IO.Pipelines;

namespace BD.Common8.Extensions;

/// <summary>
/// �ṩ�� <see cref="IDuplexPipe"/> ���͵���չ����
/// </summary>
public static partial class DuplexPipeStreamExtensions
{
    /// <summary>
    /// �� <see cref="IDuplexPipe"/> ת��Ϊ <see cref="Stream"/>
    /// </summary>
    /// <param name="duplexPipe"></param>
    /// <param name="throwOnCancelled"></param>
    /// <returns></returns>
    public static Stream AsStream(this IDuplexPipe duplexPipe, bool throwOnCancelled = false)
        => new DuplexPipeStream(duplexPipe, throwOnCancelled);
}
#endif