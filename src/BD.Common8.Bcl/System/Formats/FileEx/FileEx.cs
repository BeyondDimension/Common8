#pragma warning disable IDE0079 // 请删除不必要的忽略
#pragma warning disable IDE0130 // 命名空间与文件夹结构不匹配
namespace System.Formats;
#pragma warning restore IDE0079 // 请删除不必要的忽略

/// <summary>
/// 文件扩展名(FileExtensions)
/// </summary>
public static partial class FileEx
{
#pragma warning disable SA1600 // Elements should be documented

    public const string JSON = ".json";

    public const string BMP = ".bmp";

    public const string GIF = ".gif";

    public const string TXT = ".txt";

    public const string JPG = ".jpg";

    public const string JPEG = ".jpeg";

    public const string PNG = ".png";

    public const string ICO = ".ico";

    public const string WEBP = ".webp";

    public const string HTML = ".html";

    public const string HTM = ".htm";

    public const string CSS = ".css";

    public const string SCSS = ".scss";

    public const string LESS = ".less";

    public const string JS = ".js";

    public const string SVG = ".svg";

    public const string HEIF = ".heif";

    public const string HEIC = ".heic";

    public const string AMR = ".amr";

    public const string WAV = ".wav";

    public const string CAF = ".caf";

    public const string MP3 = ".mp3";

    public const string APK = ".apk";

    public const string ImageSource = ".imgsrc";

    public const string LOG = ".log";

    public const string TAR_GZ = ".tgz";

    public const string TAR_BR = ".tbr";

    public const string TAR_BR_LONG = ".tar.br";

    public const string BIN = ".bin";

    public const string APNG = ".apng";

    public const string EXE = ".exe";

    public const string DMG = ".dmg";

    public const string _7Z = ".7z";

    public const string APPX = ".appx";

    public const string MSIX = ".msix";

    public const string APPX_Bundle = ".appxbundle";

    public const string MSIX_Bundle = ".msixbundle";

    public const string AppInstaller = ".appinstaller";

    public const string MPO = ".mpo";

    public const string DownloadCache = ".download_cache";

    public const string RPM = ".rpm";

    public const string CPIO = ".cpio";

    public const string DEB = ".deb";

    public const string DEB_TAR = ".deb.tar";

    public const string DEB_TAR_XZ = ".deb.tar.xz";

    public const string PKG = ".pkg";

    public const string MSI = ".msi";

    public const string TAR_XZ = ".tar.xz";

    public const string TAR_ZST = ".tar.zst";

    public const string CMD = ".cmd";

    public const string BAT = ".bat";

    public const string XML = ".xml";

    public const string PFX = ".pfx";

    public const string CER = ".cer";

    public const string DAT = ".dat";

    public const string maFile = ".maFile";

    public const string PDF = ".pdf";

    public const string Pdf = PDF;

    public const string Txt = TXT;

    /// <summary>
    /// 导入注册条目 （.reg） 文件是 Regedit.exe 的功能，Regedt32.exe 不支持。您可以使用 Regedit.exe 对基于 Windows NT 4.0 或基于 Windows 2000 的计算机上注册表进行一些更改，但某些更改需要 Regedt32.exe。
    /// </summary>
    public const string Reg = ".reg";

    public const string SQLite = ".sqlite";

    public const string Database = ".db";

#pragma warning restore SA1600 // Elements should be documented

    /// <summary>
    /// 是否支持使用文本阅读器打开的扩展名
    /// </summary>
    /// <param name="extension"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsSupportedTextReader(string extension) =>
        string.Equals(extension, JSON, StringComparison.OrdinalIgnoreCase) ||
        string.Equals(extension, TXT, StringComparison.OrdinalIgnoreCase) ||
        string.Equals(extension, LOG, StringComparison.OrdinalIgnoreCase) ||
        string.Equals(extension, HTML, StringComparison.OrdinalIgnoreCase) ||
        string.Equals(extension, HTM, StringComparison.OrdinalIgnoreCase) ||
        string.Equals(extension, JS, StringComparison.OrdinalIgnoreCase) ||
        string.Equals(extension, CSS, StringComparison.OrdinalIgnoreCase) ||
        string.Equals(extension, SCSS, StringComparison.OrdinalIgnoreCase) ||
        string.Equals(extension, LESS, StringComparison.OrdinalIgnoreCase) ||
        string.Equals(extension, CMD, StringComparison.OrdinalIgnoreCase) ||
        string.Equals(extension, BAT, StringComparison.OrdinalIgnoreCase) ||
        string.Equals(extension, XML, StringComparison.OrdinalIgnoreCase);
}
