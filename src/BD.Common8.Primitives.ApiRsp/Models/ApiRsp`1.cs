using BD.Common8.Primitives.ApiRsp.Models.Abstractions;
using BD.Common8.Primitives.ApiRsp.Models.Abstractions.Internals;

namespace BD.Common8.Primitives.ApiRsp.Models;

/// <inheritdoc cref="ApiRspBase"/>
#if (!DEL_MESSAGEPACK && !SOURCE_GENERATOR && !(NETFRAMEWORK && !NET462_OR_GREATER) && !(NETSTANDARD && !NETSTANDARD2_0_OR_GREATER)) || USINGS_MESSAGEPACK
[MPObj]
#endif
#if (!DEL_MEMORYPACK && !SOURCE_GENERATOR && !NETFRAMEWORK && !(NETSTANDARD && !NETSTANDARD2_1_OR_GREATER)) || USINGS_MEMORYPACK
[MP2Obj(MP2SerializeLayout.Explicit)]
#endif
public sealed partial class ApiRsp<TContent> : ApiRspBase, IApiRsp<TContent?>
{
#pragma warning disable SA1600 // Elements should be documented
#if (!DEL_MESSAGEPACK && !SOURCE_GENERATOR && !(NETFRAMEWORK && !NET462_OR_GREATER) && !(NETSTANDARD && !NETSTANDARD2_0_OR_GREATER)) || USINGS_MESSAGEPACK
    [MPKey(LastMKeyIndex + 1)]
#endif
#if (!DEL_MEMORYPACK && !SOURCE_GENERATOR && !NETFRAMEWORK && !(NETSTANDARD && !NETSTANDARD2_1_OR_GREATER)) || USINGS_MEMORYPACK
    [MP2Key(LastMKeyIndex + 1)]
#endif
#if !DEL_NEWTONSOFTJSON
    [NewtonsoftJsonProperty(JsonPropertyName_Content)]
#endif
#if (!DEL_SYSTEMTEXTJSON && !(NETFRAMEWORK && !NET462_OR_GREATER) && !(NETSTANDARD && !NETSTANDARD2_0_OR_GREATER) && !SOURCE_GENERATOR) || USINGS_SYSTEMTEXTJSON
    [SystemTextJsonProperty(JsonPropertyName_Content)]
#endif
    public TContent? Content { get; set; }
#pragma warning restore SA1600 // Elements should be documented
}