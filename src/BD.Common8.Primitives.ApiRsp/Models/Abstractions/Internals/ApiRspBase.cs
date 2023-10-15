namespace BD.Common8.Primitives.ApiRsp.Models.Abstractions.Internals;

/// <summary>
/// <see cref="IApiRsp"/> 的默认实现基类
/// </summary>
[DebuggerDisplay("Code={Code}, Message={Message}, Content={GetContent()}, Url={Url}")]
public abstract partial class ApiRspBase : IApiRspBase, IApiRsp
{
    ApiRspCode mCode;
    bool mIsSuccess;

#pragma warning disable SA1600 // Elements should be documented

    public const string JsonPropertyName_Code = "🦄";
    public const string JsonPropertyName_Message = "🐴";
    public const string JsonPropertyName_Content = "🦓";

#if (!DEL_MESSAGEPACK && !SOURCE_GENERATOR && !(NETFRAMEWORK && !NET462_OR_GREATER) && !(NETSTANDARD && !NETSTANDARD2_0_OR_GREATER)) || USINGS_MESSAGEPACK
    [MPKey(0)]
#endif
#if (!DEL_MEMORYPACK && !SOURCE_GENERATOR && !NETFRAMEWORK && !(NETSTANDARD && !NETSTANDARD2_1_OR_GREATER)) || USINGS_MEMORYPACK
    [MP2Key(0)]
#endif
#if !DEL_NEWTONSOFTJSON
    [NewtonsoftJsonProperty(JsonPropertyName_Code)]
#endif
#if (!DEL_SYSTEMTEXTJSON && !(NETFRAMEWORK && !NET462_OR_GREATER) && !(NETSTANDARD && !NETSTANDARD2_0_OR_GREATER) && !SOURCE_GENERATOR) || USINGS_SYSTEMTEXTJSON
    [SystemTextJsonProperty(JsonPropertyName_Code)]
#endif
    public ApiRspCode Code
    {
        get => mCode;
        set
        {
            mCode = value;
            // https://github.com/dotnet/corefx/blob/v3.1.6/src/System.Net.Http/src/System/Net/Http/HttpResponseMessage.cs#L143
            mIsSuccess = mCode >= ApiRspCode.OK && mCode <= (ApiRspCode)299;
        }
    }

    /// <summary>
    /// <see cref="IApiRspBase.Message"/> 的内部值
    /// </summary>
#if (!DEL_MESSAGEPACK && !SOURCE_GENERATOR && !(NETFRAMEWORK && !NET462_OR_GREATER) && !(NETSTANDARD && !NETSTANDARD2_0_OR_GREATER)) || USINGS_MESSAGEPACK
    [MPKey(LastMKeyIndex)]
#endif
#if (!DEL_MEMORYPACK && !SOURCE_GENERATOR && !NETFRAMEWORK && !(NETSTANDARD && !NETSTANDARD2_1_OR_GREATER)) || USINGS_MEMORYPACK
    [MP2Key(LastMKeyIndex)]
#endif
#if !DEL_NEWTONSOFTJSON
    [NewtonsoftJsonProperty(JsonPropertyName_Message)]
#endif
#if (!DEL_SYSTEMTEXTJSON && !(NETFRAMEWORK && !NET462_OR_GREATER) && !(NETSTANDARD && !NETSTANDARD2_0_OR_GREATER) && !SOURCE_GENERATOR) || USINGS_SYSTEMTEXTJSON
    [SystemTextJsonProperty(JsonPropertyName_Message)]
#endif
    public string? InternalMessage { get; set; }

    [IgnoreDataMember]
#if (!DEL_MESSAGEPACK && !SOURCE_GENERATOR && !(NETFRAMEWORK && !NET462_OR_GREATER) && !(NETSTANDARD && !NETSTANDARD2_0_OR_GREATER)) || USINGS_MESSAGEPACK
    [MPIgnore]
#endif
#if (!DEL_MEMORYPACK && !SOURCE_GENERATOR && !NETFRAMEWORK && !(NETSTANDARD && !NETSTANDARD2_1_OR_GREATER)) || USINGS_MEMORYPACK
    [MP2Ignore]
#endif
#if !DEL_NEWTONSOFTJSON
    [NewtonsoftJsonIgnore]
#endif
#if (!DEL_SYSTEMTEXTJSON && !(NETFRAMEWORK && !NET462_OR_GREATER) && !(NETSTANDARD && !NETSTANDARD2_0_OR_GREATER) && !SOURCE_GENERATOR) || USINGS_SYSTEMTEXTJSON
    [SystemTextJsonIgnore]
#endif
    public string Message => InternalMessage ?? string.Empty;

    [IgnoreDataMember]
#if (!DEL_MESSAGEPACK && !SOURCE_GENERATOR && !(NETFRAMEWORK && !NET462_OR_GREATER) && !(NETSTANDARD && !NETSTANDARD2_0_OR_GREATER)) || USINGS_MESSAGEPACK
    [MPIgnore]
#endif
#if (!DEL_MEMORYPACK && !SOURCE_GENERATOR && !NETFRAMEWORK && !(NETSTANDARD && !NETSTANDARD2_1_OR_GREATER)) || USINGS_MEMORYPACK
    [MP2Ignore]
#endif
#if !DEL_NEWTONSOFTJSON
    [NewtonsoftJsonIgnore]
#endif
#if (!DEL_SYSTEMTEXTJSON && !(NETFRAMEWORK && !NET462_OR_GREATER) && !(NETSTANDARD && !NETSTANDARD2_0_OR_GREATER) && !SOURCE_GENERATOR) || USINGS_SYSTEMTEXTJSON
    [SystemTextJsonIgnore]
#endif
    public bool IsSuccess => mIsSuccess;

    protected object? GetContent() => null;

    object? IApiRspBase.Content => GetContent();

    /// <summary>
    /// 最后一个 MessagePack 序列化 下标，继承自此类，新增需要序列化的字段/属性，标记此值+1，+2
    /// </summary>
    protected const int LastMKeyIndex = 1;

    [IgnoreDataMember]
#if (!DEL_MESSAGEPACK && !SOURCE_GENERATOR && !(NETFRAMEWORK && !NET462_OR_GREATER) && !(NETSTANDARD && !NETSTANDARD2_0_OR_GREATER)) || USINGS_MESSAGEPACK
    [MPIgnore]
#endif
#if (!DEL_MEMORYPACK && !SOURCE_GENERATOR && !NETFRAMEWORK && !(NETSTANDARD && !NETSTANDARD2_1_OR_GREATER)) || USINGS_MEMORYPACK
    [MP2Ignore]
#endif
#if !DEL_NEWTONSOFTJSON
    [NewtonsoftJsonIgnore]
#endif
#if (!DEL_SYSTEMTEXTJSON && !(NETFRAMEWORK && !NET462_OR_GREATER) && !(NETSTANDARD && !NETSTANDARD2_0_OR_GREATER) && !SOURCE_GENERATOR) || USINGS_SYSTEMTEXTJSON
    [SystemTextJsonIgnore]
#endif
    public Exception? ClientException { get; set; }

    [IgnoreDataMember]
#if (!DEL_MESSAGEPACK && !SOURCE_GENERATOR && !(NETFRAMEWORK && !NET462_OR_GREATER) && !(NETSTANDARD && !NETSTANDARD2_0_OR_GREATER)) || USINGS_MESSAGEPACK
    [MPIgnore]
#endif
#if (!DEL_MEMORYPACK && !SOURCE_GENERATOR && !NETFRAMEWORK && !(NETSTANDARD && !NETSTANDARD2_1_OR_GREATER)) || USINGS_MEMORYPACK
    [MP2Ignore]
#endif
#if !DEL_NEWTONSOFTJSON
    [NewtonsoftJsonIgnore]
#endif
#if (!DEL_SYSTEMTEXTJSON && !(NETFRAMEWORK && !NET462_OR_GREATER) && !(NETSTANDARD && !NETSTANDARD2_0_OR_GREATER) && !SOURCE_GENERATOR) || USINGS_SYSTEMTEXTJSON
    [SystemTextJsonIgnore]
#endif
    public string? Url { get; set; }

#pragma warning restore SA1600 // Elements should be documented
}
