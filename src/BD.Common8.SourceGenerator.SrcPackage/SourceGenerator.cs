using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.Text;

namespace BD.Common8.SourceGenerator.SrcPackage;

[Generator]
public sealed partial class SourceGenerator : ISourceGenerator
{
    /// <summary>
    /// 获取当前包绝对路径(.nupkg)
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    static string GetPackageRootPath(string? path = null)
    {
        path ??= typeof(SourceGenerator).Assembly.Location;
        try
        {
            if (!Directory.EnumerateFiles(path, "*.nupkg").Any())
            {
                var parent = Directory.GetParent(path);
                if (parent == null)
                    return string.Empty;
                return GetPackageRootPath(parent.FullName);
            }
        }
        catch
        {
            return string.Empty;
        }
        return path;
    }

    /// <inheritdoc cref="ISourceGenerator.Execute(GeneratorExecutionContext)"/>
    void ISourceGenerator.Execute(GeneratorExecutionContext context)
    {
        // TODO
        // 将源码包，src 目录下的源码通过源生成引入实现只读
        // 配置参数使用源生成只读或 Link 文件
        // resx 资源文件引入？
        var rootPath = GetPackageRootPath();
        if (string.IsNullOrWhiteSpace(rootPath))
            return;
        var srcDirPath = Path.Combine(rootPath, "src");
        if (!Directory.Exists(srcDirPath))
            return;
        foreach (var item in Directory.EnumerateFiles(srcDirPath, "*.cs"))
        {
            var fileName = Path.GetFileName(item);
            var sourceCode = File.ReadAllBytes(item);
            context.AddSource(fileName, SourceText.From(sourceCode, sourceCode.Length, Encoding.UTF8));
        }
    }

    /// <inheritdoc cref="ISourceGenerator.Initialize(GeneratorInitializationContext)"/>
    void ISourceGenerator.Initialize(GeneratorInitializationContext context)
    {
    }
}
