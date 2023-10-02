// C# 10 定义全局 using

#pragma warning disable IDE0079 // 请删除不必要的忽略
#pragma warning disable IDE0005 // 删除不必要的 using 指令
#pragma warning disable SA1209 // Using alias directives should be placed after other using directives
#pragma warning disable SA1211 // Using alias directives should be ordered alphabetically by alias name

#if !DEL_GLOBALUSING_BD_COMMON8_EX
global using BD.Common8.Extensions;
#endif

#if !DEL_GLOBALUSING_OSPLATFORMATTRIBUTE
#if NET5_0_OR_GREATER
global using SupportedOSPlatform = System.Runtime.Versioning.SupportedOSPlatformAttribute;
global using UnsupportedOSPlatform = System.Runtime.Versioning.UnsupportedOSPlatformAttribute;
#endif
#if NET6_0_OR_GREATER
global using SupportedOSPlatformGuard = System.Runtime.Versioning.SupportedOSPlatformGuardAttribute;
global using UnsupportedOSPlatformGuard = System.Runtime.Versioning.UnsupportedOSPlatformGuardAttribute;
#endif
#if NET7_0_OR_GREATER
global using ObsoletedOSPlatform = System.Runtime.Versioning.ObsoletedOSPlatformAttribute;
#endif
#endif

#if !DEL_SERIALIZABLE

#if (!DEL_NEWTONSOFTJSON && !SOURCE_GENERATOR) || USINGS_NEWTONSOFTJSON
global using NewtonsoftJsonIgnore = Newtonsoft.Json.JsonIgnoreAttribute;
global using NewtonsoftJsonProperty = Newtonsoft.Json.JsonPropertyAttribute;
#endif

#if (!DEL_SYSTEMTEXTJSON && !(NETFRAMEWORK && !NET462_OR_GREATER) && !(NETSTANDARD && !NETSTANDARD2_0_OR_GREATER) && !SOURCE_GENERATOR) || USINGS_SYSTEMTEXTJSON
global using SystemTextJsonIgnore = System.Text.Json.Serialization.JsonIgnoreAttribute;
global using SystemTextJsonProperty = System.Text.Json.Serialization.JsonPropertyNameAttribute;
#endif

#if (!DEL_MESSAGEPACK && !SOURCE_GENERATOR && !(NETFRAMEWORK && !NET462_OR_GREATER) && !(NETSTANDARD && !NETSTANDARD2_0_OR_GREATER)) || USINGS_MESSAGEPACK
global using MPConstructor = MessagePack.SerializationConstructorAttribute;
global using MPIgnore = MessagePack.IgnoreMemberAttribute;
global using MPKey = MessagePack.KeyAttribute;
global using MPObj = MessagePack.MessagePackObjectAttribute;
global using MPUnion = MessagePack.UnionAttribute;
#endif

#if (!DEL_MEMORYPACK && !SOURCE_GENERATOR && !NETFRAMEWORK && !(NETSTANDARD && !NETSTANDARD2_1_OR_GREATER)) || USINGS_MEMORYPACK
global using MP2Constructor = MemoryPack.MemoryPackConstructorAttribute;
global using MP2Ignore = MemoryPack.MemoryPackIgnoreAttribute;
global using MP2Key = MemoryPack.MemoryPackOrderAttribute;
global using MP2Obj = MemoryPack.MemoryPackableAttribute;
global using MP2Union = MemoryPack.MemoryPackUnionAttribute;
global using MP2SerializeLayout = MemoryPack.SerializeLayout;
#endif

#endif