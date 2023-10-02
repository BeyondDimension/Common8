using System.Globalization;
using BD.Common8.Resources;
using static BD.Common8.ProjectUtils;
using static BD.Common8.SourceGenerator.Resx.ConsoleTest.Helpers.ResxHelper;

SR.Culture = new CultureInfo("en");
Console.WriteLine(SR.DayOfWeek_S1);
SR.Culture = new CultureInfo("es");
Console.WriteLine(SR.DayOfWeek_S1);
SR.Culture = new CultureInfo("ru");
Console.WriteLine(SR.DayOfWeek_S1);
SR.Culture = new CultureInfo("ja");
Console.WriteLine(SR.DayOfWeek_S1);
SR.Culture = new CultureInfo("zh-CN");
Console.WriteLine(SR.DayOfWeek_S1);
SR.Culture = new CultureInfo("zh-HK");
Console.WriteLine(SR.DayOfWeek_S1);

var i18nPath = Path.Combine(ProjPath, "res", "i18n");
var values = RemoveResxCommentSatelliteAssemblies(i18nPath);
WriteProps(i18nPath, values);

Console.WriteLine("OK");
Console.ReadLine();
