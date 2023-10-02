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
public sealed partial class ApiRsp : ApiRspBase, IApiRsp<object?>
{
#pragma warning disable SA1600 // Elements should be documented
    object? IApiRsp<object?>.Content => null;
#pragma warning restore SA1600 // Elements should be documented
}