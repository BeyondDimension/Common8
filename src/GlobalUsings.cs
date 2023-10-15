// C# 10 定义全局 using

#pragma warning disable IDE0079 // 请删除不必要的忽略
#pragma warning disable IDE0005 // 删除不必要的 using 指令
#pragma warning disable SA1209 // Using alias directives should be placed after other using directives
#pragma warning disable SA1211 // Using alias directives should be ordered alphabetically by alias name

global using Microsoft.Win32;
global using System.Collections.Concurrent;
global using System.Collections.ObjectModel;
global using System.ComponentModel;
#if !NETFRAMEWORK || USINGS_IMMUTABLE
// 不可变集合
// https://learn.microsoft.com/zh-cn/archive/msdn-magazine/2017/march/net-framework-immutable-collections
global using System.Collections.Immutable;
#if !NETSTANDARD || USINGS_DATAANNOTATIONS
// 提供用于为 ASP.NET MVC 和 ASP.NET 数据控件定义元数据的特性类。
// https://learn.microsoft.com/zh-cn/dotnet/api/system.componentmodel.dataannotations
global using System.ComponentModel.DataAnnotations;
global using System.ComponentModel.DataAnnotations.Schema;
global using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;
#endif
#endif
#if (!NETFRAMEWORK && !(NETSTANDARD && !NETSTANDARD2_1_OR_GREATER)) || USINGS_BUFFERS
// 包含用于创建和管理内存缓冲区的类型，如 Span<T> 和 Memory<T> 所表示的类型。
// https://learn.microsoft.com/zh-cn/dotnet/api/system.buffers
global using System.Buffers;
#endif
global using System.Diagnostics;
global using System.Diagnostics.CodeAnalysis;
global using System.Globalization;
global using System.IO.Pipes;
global using System.IO.Compression;
global using System.Linq;
global using System.Linq.Expressions;
global using System.Web;
global using System.Net;
global using System.Net.Security;
#if !(NETFRAMEWORK && !NET45_OR_GREATER) || USINGS_HTTP
// 为现代 HTTP 应用程序提供一个编程接口。
// https://learn.microsoft.com/zh-cn/dotnet/api/system.net.http
global using System.Net.Http;
global using System.Net.Http.Headers;
#endif
#if !SOURCE_GENERATOR || USINGS_SYS_FORMATS
// 包含常用的文件格式的数据的类型。
global using System.Formats;
#endif
global using System.Net.Sockets;
global using System.Reflection;
global using System.Runtime.CompilerServices;
global using System.Runtime.Serialization;
global using System.Security;
global using System.Security.Claims;
global using System.Security.Cryptography;
global using System.Security.Principal;
global using System.Text;
global using System.Text.RegularExpressions;
global using System.Runtime;
global using System.Runtime.InteropServices;
global using System.Runtime.Versioning;
global using System.Windows.Input;

global using System.Xml;
global using System.Xml.Linq;
global using System.Xml.Serialization;
global using System.Security.Cryptography.X509Certificates;
global using IPAddress = System.Net.IPAddress;

#if SOURCE_GENERATOR || USINGS_MS_CODEANALYSIS
global using Microsoft.CodeAnalysis;
global using Microsoft.CodeAnalysis.Diagnostics;
global using Microsoft.CodeAnalysis.Text;
#endif

#if !DEL_SYS_IOC && !SOURCE_GENERATOR && ((NETFRAMEWORK && NET461_OR_GREATER) || (NETSTANDARD && NETSTANDARD2_0_OR_GREATER) || (NETCOREAPP && NETCOREAPP2_0_OR_GREATER))
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.DependencyInjection.Extensions;
#endif

#if !DEL_SYS_LOG && !SOURCE_GENERATOR && ((NETFRAMEWORK && NET461_OR_GREATER) || (NETSTANDARD && NETSTANDARD2_0_OR_GREATER) || (NETCOREAPP && NETCOREAPP2_0_OR_GREATER))
global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.Logging.Abstractions;
#endif

#if !DEL_BD_COMMON8_EX
global using BD.Common8.Extensions;
#endif

#if (!DEL_POLLY && !SOURCE_GENERATOR) || USINGS_POLLY
global using Polly;
#endif

#if !DEL_SERIALIZABLE

#if (!DEL_NEWTONSOFTJSON && !SOURCE_GENERATOR) || USINGS_NEWTONSOFTJSON
global using Newtonsoft.Json;
global using Newtonsoft.Json.Converters;
global using Newtonsoft.Json.Serialization;
global using Newtonsoft.Json.Linq;
global using NewtonsoftJsonConverter = Newtonsoft.Json.JsonConverter;
global using NewtonsoftJsonIgnore = Newtonsoft.Json.JsonIgnoreAttribute;
global using NewtonsoftJsonProperty = Newtonsoft.Json.JsonPropertyAttribute;
global using NewtonsoftJsonSerializer = Newtonsoft.Json.JsonSerializer;
global using NewtonsoftJsonFormatting = Newtonsoft.Json.Formatting;
global using NewtonsoftJsonConvert = Newtonsoft.Json.JsonConvert;
global using NewtonsoftJsonSerializerSettings = Newtonsoft.Json.JsonSerializerSettings;
#endif

#if (!DEL_SYSTEMTEXTJSON && !(NETFRAMEWORK && !NET461_OR_GREATER) && !(NETSTANDARD && !NETSTANDARD2_0_OR_GREATER) && !SOURCE_GENERATOR) || USINGS_SYSTEMTEXTJSON
global using System.Text.Json;
global using System.Text.Json.Nodes;
global using System.Text.Json.Serialization;
global using System.Text.Encodings.Web;
global using System.Text.Unicode;
global using SystemTextJsonIgnore = System.Text.Json.Serialization.JsonIgnoreAttribute;
global using SystemTextJsonProperty = System.Text.Json.Serialization.JsonPropertyNameAttribute;
global using SystemTextJsonSerializer = System.Text.Json.JsonSerializer;
global using SystemTextJsonSerializerOptions = System.Text.Json.JsonSerializerOptions;
global using SystemTextJsonIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition;
#endif

#if (!DEL_MESSAGEPACK && !SOURCE_GENERATOR && !(NETFRAMEWORK && !NET461_OR_GREATER) && !(NETSTANDARD && !NETSTANDARD2_0_OR_GREATER)) || USINGS_MESSAGEPACK
global using MessagePack;
global using MPConstructor = MessagePack.SerializationConstructorAttribute;
global using MPIgnore = MessagePack.IgnoreMemberAttribute;
global using MPKey = MessagePack.KeyAttribute;
global using MPObj = MessagePack.MessagePackObjectAttribute;
global using MPUnion = MessagePack.UnionAttribute;
#endif

#if (!DEL_MEMORYPACK && !SOURCE_GENERATOR && !NETFRAMEWORK && !(NETSTANDARD && !NETSTANDARD2_1_OR_GREATER)) || USINGS_MEMORYPACK
global using MemoryPack;
global using MP2Constructor = MemoryPack.MemoryPackConstructorAttribute;
global using MP2Ignore = MemoryPack.MemoryPackIgnoreAttribute;
global using MP2Key = MemoryPack.MemoryPackOrderAttribute;
global using MP2Obj = MemoryPack.MemoryPackableAttribute;
global using MP2Union = MemoryPack.MemoryPackUnionAttribute;
global using MP2SerializeLayout = MemoryPack.SerializeLayout;
#endif

#endif