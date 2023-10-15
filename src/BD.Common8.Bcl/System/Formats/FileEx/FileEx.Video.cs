#pragma warning disable IDE0079 // 请删除不必要的忽略
#pragma warning disable IDE0130 // 命名空间与文件夹结构不匹配
namespace System.Formats;
#pragma warning restore IDE0079 // 请删除不必要的忽略

public static partial class FileEx
{
#pragma warning disable SA1600 // Elements should be documented
    public const string Mp4 = ".mp4";
    public const string M4v = ".m4v";
    public const string Mpg = ".mpg";
    public const string Mpeg = ".mpeg";
    public const string Mp2 = ".mp2";
    public const string Dat = ".dat";
    public const string Asf = ".asf";
    public const string Avi = ".avi";
    public const string Rm = ".rm";
    public const string Rmvb = ".rmvb";
    public const string Mov = ".mov";
    public const string Wmv = ".wmv";
    public const string Flv = ".flv";
    public const string Gifv = ".gifv";
    public const string Mkv = ".mkv";
    public const string Qt = ".qt";

#pragma warning restore SA1600 // Elements should be documented

    static IEnumerable<string>? _Videos;

    /// <summary>
    /// 视频
    /// </summary>
    public static IEnumerable<string> Videos
    {
        get
        {
            if (_Videos == null) return GetVideos();
            return _Videos;
        }

        set
        {
            _Videos = value;
        }
    }

    static IEnumerable<string> GetVideos()
    {
        yield return Mp4;
        yield return M4v;
        yield return Mpg;
        yield return Mpeg;
        yield return Mp2;
        yield return Dat;
        yield return Asf;
        yield return Avi;
        yield return Rm;
        yield return Rmvb;
        yield return Mov;
        yield return Wmv;
        yield return Flv;
        yield return Gifv;
        yield return Mkv;
        yield return Qt;
    }

    /// <summary>
    /// 判断文件扩展名是否为视频
    /// </summary>
    /// <param name="fileEx"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsVideo(string fileEx)
        => Videos.Any(x
            => string.Equals(x, fileEx, StringComparison.OrdinalIgnoreCase));
}