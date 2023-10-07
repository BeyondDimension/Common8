using System.Text;

namespace BD.Common8.Extensions;

/// <summary>
/// �ṩ�� <see cref="FileInfo"/> ���͵���չ����
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