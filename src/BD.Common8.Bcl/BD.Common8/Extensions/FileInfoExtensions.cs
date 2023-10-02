using System.Text;

namespace BD.Common8.Extensions;

/// <summary>
/// 提供对 <see cref="FileInfo"/> 类型的扩展函数
/// </summary>
public static partial class FileInfoExtensions
{
    public static StreamReader? OpenText(this FileInfo fileInfo, Encoding? encoding = null)
    {
        var f = IOPath.OpenRead(fileInfo.FullName);
        if (f == null)
            return null;
        return new StreamReader(f, encoding ?? EncodingCache.UTF8NoBOM);
    }
}