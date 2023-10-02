using BD.Common8.Tools.BuildFolderGenerator.Templates;

string[] projNames = [
    "BD.Common8.Primitives.ApiRsp",
];

foreach (var item in projNames)
{
    SourceCodePackageTemplate.Generator(item);
    var a = typeof(BD.Common8.Primitives.ApiRsp.Models.ApiRsp);
}

Console.WriteLine("OK");
Console.ReadLine();