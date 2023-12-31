using static BD.Common8.SourceGenerator.Resx.Helpers.ResxSatelliteAssemblyHelper;

namespace BD.Common8.SourceGenerator.Resx.ConsoleTest.Helpers;

static partial class ResxHelper
{
    /// <summary>
    /// 移除附属资源文件中的 comment 元素
    /// </summary>
    /// <param name="dirPath"></param>
    public static IGrouping<string, string>[] RemoveResxCommentSatelliteAssemblies(string dirPath)
    {
        List<(string key, string fileNameWithoutEx)> list = new();
        var files = Directory.GetFiles(dirPath, "*.resx");
        foreach (var item in files)
        {
            var fileNameWithoutEx = Path.GetFileNameWithoutExtension(item);
            if (!TryGetCultureNameByResxSatelliteFilePathPath(item, out var cultureName))
            {
                list.Add((fileNameWithoutEx, fileNameWithoutEx));
                continue;
            }
            var fileNameWithoutExSplit = fileNameWithoutEx.Split('.');
            list.Add((string.Join('.', fileNameWithoutExSplit.Take(fileNameWithoutExSplit.Length - 1)), fileNameWithoutEx));
            var lines = File.ReadAllLines(item);
            using var fileStream = File.OpenWrite(item);
            using var writer = new StreamWriter(fileStream, Encoding.UTF8);
            foreach (var line in lines)
            {
                if (line.Contains("<comment>", StringComparison.OrdinalIgnoreCase))
                    continue;
                writer.WriteLine(line);
            }
            fileStream.SetLength(fileStream.Position);
            fileStream.Flush();
        }
        var result = list.GroupBy(static x => x.key, static x => x.fileNameWithoutEx).ToArray();
        return result;
    }

    static FileStream GetStream(string filePath)
    {
        var baseDirPath = Path.GetDirectoryName(filePath);
        ArgumentNullException.ThrowIfNull(baseDirPath);
        if (!Directory.Exists(baseDirPath))
            Directory.CreateDirectory(baseDirPath);
        var stream = new FileStream(filePath,
            FileMode.OpenOrCreate,
            FileAccess.Write,
            FileShare.ReadWrite | FileShare.Delete);
        return stream;
    }

    /// <summary>
    /// 写入 .props 文件
    /// </summary>
    /// <param name="dirPath"></param>
    /// <param name="values"></param>
    public static void WriteProps(string dirPath, IGrouping<string, string>[] values)
    {
        foreach (var item in values)
        {
            var filePath = Path.Combine(dirPath, $"{item.Key}.props");
            using var stream = GetStream(filePath);
            stream.Write(
"""
<Project>
	<ItemGroup>
"""u8);
            stream.WriteNewLine();
            var satellites = item.OrderBy(static x => x).ToArray();
            foreach (var satellite in satellites)
            {
                if (satellite == item.Key)
                {
                    string @namespace = satellite switch
                    {
                        "BD.Common8.Bcl" => "BD.Common8",
                        _ => satellite,
                    };
#pragma warning disable format
//                    stream.WriteFormat(
//"""
//                		<AdditionalFiles Include="$(MSBuildThisFileDirectory)\{0}.resx" Visible="false">
//                			<BD_Common8_Resx_IsPublic>false</BD_Common8_Resx_IsPublic>
//                			<BD_Common8_Resx_Namespace>{1}.Resources</BD_Common8_Resx_Namespace>
//                			<BD_Common8_Resx_CustomTypeName>SR</BD_Common8_Resx_CustomTypeName>
//                			<BD_Common8_Resx_CustomResourceBaseName>FxResources.{0}.SR</BD_Common8_Resx_CustomResourceBaseName>
//                		</AdditionalFiles>
//                """u8, satellite, @namespace);
#pragma warning restore format
                    stream.WriteFormat(
"""
                		<AdditionalFiles Include="$(MSBuildThisFileDirectory)\{0}.resx" Visible="false">
                			<!-- 使用 AdditionalFiles 引入主 resx 文件用于源生成器 -->
                		</AdditionalFiles>
                """u8, satellite, @namespace);
                    stream.WriteNewLine();
                }
                stream.WriteFormat(
"""
		<EmbeddedResource Include="$(MSBuildThisFileDirectory)\{0}.resx">
			<Link>Resources\{1}.resx</Link>
			<LogicalName>FxResources.{0}.resources</LogicalName>
		</EmbeddedResource>
"""u8, satellite, satellite.Replace(item.Key, "Strings"));
                stream.WriteNewLine();
            }
            stream.Write(
"""
	</ItemGroup>
</Project>
"""u8);
            stream.SetLength(stream.Position);
            stream.Flush();
        }
    }
}
