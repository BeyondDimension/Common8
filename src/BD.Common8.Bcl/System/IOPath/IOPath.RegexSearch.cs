#pragma warning disable IDE0079 // 请删除不必要的忽略
#pragma warning disable IDE0130 // 命名空间与文件夹结构不匹配
namespace System;
#pragma warning restore IDE0079 // 请删除不必要的忽略

public static partial class IOPath
{
    /// <summary>
    /// 根据文件路径读取所有文本匹配正则表达式
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="pattern"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string RegexSearchFile(string filePath, string pattern)
    {
        var t = ReadAllText(filePath);
        var m = Regex.Match(t, pattern);
        return m.Success ? m.Value : "";
    }

    /// <summary>
    /// 遍历文件夹下的文件，使用正则表达式匹配出字符串
    /// </summary>
    /// <param name="dirPath"></param>
    /// <param name="pattern"></param>
    /// <param name="searchPattern"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string RegexSearchFolder(string dirPath, string pattern, string searchPattern = "")
    {
        // Foreach file in folder (until match):
        foreach (var f in Directory.EnumerateFiles(dirPath, searchPattern))
        {
            var result = RegexSearchFile(f, pattern);
            if (result == "")
                continue;
            return result;
        }

        return "";
    }
}