using static BD.Common8.SourceGenerator.Resx.Constants;
using static BD.Common8.SourceGenerator.Resx.Helpers.ResxSatelliteAssemblyHelper;
using static BD.Common8.SourceGenerator.Resx.Templates.DesignerTemplate;

#pragma warning disable IDE0079 // 请删除不必要的忽略
#pragma warning disable IDE0060 // 删除未使用的参数

namespace BD.Common8.SourceGenerator.Resx;

/// <summary>
/// Resx 增量源生成器
/// </summary>
[Generator]
public sealed class IncrementalGenerator : IIncrementalGenerator
{
    /// <summary>
    /// 从源码中匹配需要执行生成器的判断规则
    /// </summary>
    /// <param name="additionalText"></param>
    /// <param name="optionsProvider"></param>
    /// <returns></returns>
    static bool Match(
        AdditionalText additionalText,
        AnalyzerConfigOptionsProvider optionsProvider)
    {
#if DEBUG
        Console.WriteLine("bool Match(..");
#endif
        var filePath = additionalText.Path;

        if (TryGetCultureNameByResxSatelliteFilePathPath(filePath, out var _))
        {
            return false;
        }

        return true;
    }

    /// <summary>
    /// 将源码数据转换为模型
    /// </summary>
    /// <param name="additionalText"></param>
    /// <param name="optionsProvider"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    static SourceModel Convert(
        AdditionalText additionalText,
        AnalyzerConfigOptionsProvider optionsProvider,
        CancellationToken cancellationToken = default)
    {
#if DEBUG
        Console.WriteLine("SourceModel Convert(..");
#endif

        var sourceText = additionalText.GetText();
        if (sourceText == default)
            return default;

        var isPublic = Default_IsPublic;
        string? @namespace = default, typeName = default, resourceBaseName = default, isPublicString = default;

        //string? dirPath = Path.GetDirectoryName(additionalText.Path);
        //        string? projectPath = string.IsNullOrWhiteSpace(dirPath) ? null :
        //            ProjectUtils.GetProjectPath(dirPath);
        //        if (!string.IsNullOrWhiteSpace(projectPath))
        //        {
        //            var resxPropsFilePath = Path.Combine(projectPath, "src", "Resx.props");
        //#pragma warning disable RS1035 // 不要使用禁用于分析器的 API
        //            if (File.Exists(resxPropsFilePath))
        //            {
        //                var additionalFiles = XDocument.Load(resxPropsFilePath).Root.Elements("ItemGroup").Elements("AdditionalFiles");
        //                foreach (var additionalFile in additionalFiles)
        //                {
        //                    var include = additionalFile.Attribute("Include")?.Value?.TrimStart(@"$(MSBuildThisFileDirectory)\");
        //                    var fileName = Path.GetFileName(additionalText.Path);
        //                    if (fileName == include)
        //                    {
        //                        typeName = additionalFile.Element(Key_CustomCustomTypeName_WithoutPrefix)?.Value;

        //                        isPublicString = additionalFile.Element(Key_IsPublic_WithoutPrefix)?.Value;
        //                        bool.TryParse(isPublicString, out isPublic);

        //                        @namespace = additionalFile.Element(Key_CustomNamespace_WithoutPrefix)?.Value;

        //                        resourceBaseName = additionalFile.Element(Key_CustomResourceBaseName_WithoutPrefix)?.Value;

        //                        break;
        //                    }
        //                }
        //            }
        //#pragma warning restore RS1035 // 不要使用禁用于分析器的 API
        //        }

        AnalyzerConfigOptions? lazyOptions = null;
        AnalyzerConfigOptions GetOptions() => lazyOptions ??= optionsProvider.GetOptions(additionalText);

        if (typeName == default)
        {
            GetOptions().TryGetValue(Key_CustomCustomTypeName, out typeName);
        }

        if (isPublicString == default)
        {
            if (GetOptions().TryGetValue(Key_IsPublic, out isPublicString))
                bool.TryParse(isPublicString, out isPublic);
        }

        if (@namespace == default)
        {
            GetOptions().TryGetValue(Key_CustomNamespace, out @namespace);
        }

        if (resourceBaseName == default)
        {
            GetOptions().TryGetValue(Key_CustomResourceBaseName, out resourceBaseName);
        }

        return new()
        {
            Path = additionalText.Path,
            Text = sourceText,
            Namespace = string.IsNullOrWhiteSpace(@namespace) ? GetDefaultNamespace(additionalText.Path) : @namespace!,
            TypeName = string.IsNullOrWhiteSpace(typeName) ? "SR" : typeName!,
            IsPublic = isPublic,
            ResourceBaseName = string.IsNullOrWhiteSpace(resourceBaseName) ? GetDefaultResourceBaseName(additionalText.Path) : resourceBaseName!,
        };
    }

    /// <summary>
    /// 源生成器执行逻辑
    /// </summary>
    /// <param name="spc"></param>
    /// <param name="m"></param>
    static void Execute(SourceProductionContext spc, SourceModel m)
    {
        using var memoryStream = new MemoryStream();
        WriteFile(memoryStream, m);
        var sourceText = SourceText.From(memoryStream, canBeEmbedded: true);
#if DEBUG
        var sourceTextString = sourceText.ToString();
        Console.WriteLine();
        Console.WriteLine(sourceTextString);
#endif
        spc.AddSource($"{m.Namespace}.{m.TypeName}.Designer.g.cs", sourceText);
    }

    /// <summary>
    /// 编译器调用该函数初始化生成器，并通过上下文回调注册生成步骤
    /// </summary>
    /// <param name="ctx"></param>
    public void Initialize(IncrementalGeneratorInitializationContext ctx)
    {
#if DEBUG
        Console.WriteLine("Initialize(IncrementalGeneratorInitializationContext..");
#endif
        var source = ctx.AdditionalTextsProvider
              .Combine(ctx.AnalyzerConfigOptionsProvider)
              .Where(static x => Match(x.Left, x.Right))
              .Select(static (x, y) => Convert(x.Left, x.Right, y))
              .Where(static x => x != default);
        ctx.RegisterSourceOutput(source, Execute);
    }
}
