#pragma warning disable IDE0079 // 请删除不必要的忽略
#pragma warning disable IDE0130 // 命名空间与文件夹结构不匹配
namespace System;
#pragma warning restore IDE0079 // 请删除不必要的忽略

public static partial class IOPath
{
    /// <summary>
    /// 路径是否为空文件夹
    /// </summary>
    /// <param name="pszPath"></param>
    /// <returns></returns>
#if NETFRAMEWORK
    [DllImport("shlwapi.dll", EntryPoint = "PathIsDirectoryEmptyW", SetLastError = true, CharSet = CharSet.Unicode)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool PathIsDirectoryEmpty([MarshalAs(UnmanagedType.LPTStr)] string pszPath);
#elif NET7_0_OR_GREATER && WINDOWS
    [LibraryImport("shlwapi.dll", EntryPoint = "PathIsDirectoryEmptyW", SetLastError = true, StringMarshalling = StringMarshalling.Utf16)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool PathIsDirectoryEmpty([MarshalAs(UnmanagedType.LPTStr)] string pszPath);
#else
#if NET35 || NET40
    [MethodImpl((MethodImplOptions)0x100)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    public static bool PathIsDirectoryEmpty(string pszPath)
    {
        try
        {
            return !Directory.EnumerateFileSystemEntries(pszPath).Any();
        }
        catch (DirectoryNotFoundException)
        {
            return true;
        }
    }
#endif
}