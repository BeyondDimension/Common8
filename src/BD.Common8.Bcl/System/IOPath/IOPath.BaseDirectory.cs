#pragma warning disable IDE0079 // 请删除不必要的忽略
#pragma warning disable IDE0130 // 命名空间与文件夹结构不匹配
namespace System;
#pragma warning restore IDE0079 // 请删除不必要的忽略

public static partial class IOPath
{
    /// <summary>
    /// 获取当前应用程序的基目录文件夹路径
    /// </summary>
    public static string BaseDirectory => BaseDirectory_._BaseDirectory();

    /// <summary>
    /// 设置当前应用程序的基目录文件夹路径
    /// </summary>
    /// <param name="value"></param>
    public static void SetBaseDirectory(Func<string> value)
        => BaseDirectory_._BaseDirectory = value;

    static class BaseDirectory_
    {
        internal static Func<string> _BaseDirectory;
        internal static readonly Func<string> DefaultBaseDirectory;

        static BaseDirectory_()
        {
            DefaultBaseDirectory = () => AppContext.BaseDirectory;
            _BaseDirectory = DefaultBaseDirectory;
        }
    }
}