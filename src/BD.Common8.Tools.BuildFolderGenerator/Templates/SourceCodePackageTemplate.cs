using static BD.Common8.ProjectUtils;

namespace BD.Common8.Tools.BuildFolderGenerator.Templates;

/// <summary>
/// 源代码包 BuildFolder 模板
/// </summary>
public static partial class SourceCodePackageTemplate
{
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

    static void WriteBuildMultiTargetingProps(string projName)
    {
        var filePath = Path.Combine(ProjPath, "src", "SrcPackage", "buildMultiTargeting", $"{projName}.props");
        using var stream = GetStream(filePath);
        stream.WriteFormat(
"""
<Project>

  <PropertyGroup>
    <MSBuildAllProjects>$(MSBuildAllProjects);$(MSBuildThisFileFullPath)</MSBuildAllProjects>
  </PropertyGroup>

  <Import Project="..\build\{0}.props" />

</Project>
"""u8, projName);
        stream.SetLength(stream.Position);
        stream.Flush();
    }

    static void WriteBuildMultiTargetingTargets(string projName)
    {
        var filePath = Path.Combine(ProjPath, "src", "SrcPackage", "buildMultiTargeting", $"{projName}.targets");
        using var stream = GetStream(filePath);
        stream.WriteFormat(
"""
<Project>

  <PropertyGroup>
    <MSBuildAllProjects>$(MSBuildAllProjects);$(MSBuildThisFileFullPath)</MSBuildAllProjects>
  </PropertyGroup>

  <Import Project="..\build\{0}.targets" />

</Project>
"""u8, projName);
        stream.SetLength(stream.Position);
        stream.Flush();
    }

    static void WriteBuildProps(string projName)
    {
        var filePath = Path.Combine(ProjPath, "src", "SrcPackage", "build", $"{projName}.props");
        using var stream = GetStream(filePath);
        stream.WriteFormat(
"""
<Project>

  <PropertyGroup>
    <MSBuildAllProjects>$(MSBuildAllProjects);$(MSBuildThisFileFullPath)</MSBuildAllProjects>
  </PropertyGroup>

  <ItemGroup>
    <GlobalAnalyzerConfigFiles Include="$(MSBuildThisFileDirectory)..\.editorconfig" />
  </ItemGroup>

</Project>
"""u8, projName);
        stream.SetLength(stream.Position);
        stream.Flush();
    }

    static void WriteBuildTargets(string projName)
    {
        var filePath = Path.Combine(ProjPath, "src", "SrcPackage", "build", $"{projName}.targets");
        var id = projName.Replace('.', '_');
        using var stream = GetStream(filePath);
        stream.WriteFormat(
"""
<Project>

	<PropertyGroup>
		<MSBuildAllProjects>$(MSBuildAllProjects);$(MSBuildThisFileFullPath)</MSBuildAllProjects>
	</PropertyGroup>

	<ItemGroup>
		<Compile Include="$(MSBuildThisFileDirectory)..\src\**\*.cs">
			<LinkBase>_SourceReference\{0}</LinkBase>
		</Compile>
	</ItemGroup>

</Project>
"""u8, id, projName);
        stream.SetLength(stream.Position);
        stream.Flush();
    }

    /// <summary>
    /// 生成用于源代码包的 Build 文件
    /// </summary>
    /// <param name="projName"></param>
    public static void Generator(string projName)
    {
        var tasks = new[]
        {
            Task.Run(() =>
            {
                WriteBuildMultiTargetingProps(projName);
            }),
            Task.Run(() =>
            {
                WriteBuildMultiTargetingTargets(projName);
            }),
            Task.Run(() =>
            {
                WriteBuildProps(projName);
            }),
            Task.Run(() =>
            {
                WriteBuildTargets(projName);
            }),
        };
        Task.WaitAll(tasks);
    }
}
