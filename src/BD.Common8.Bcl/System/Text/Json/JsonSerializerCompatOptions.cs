#if (!DEL_SYSTEMTEXTJSON && !(NETFRAMEWORK && !NET461_OR_GREATER) && !(NETSTANDARD && !NETSTANDARD2_0_OR_GREATER) && !SOURCE_GENERATOR) || USINGS_SYSTEMTEXTJSON

#pragma warning disable SA1600 // Elements should be documented

namespace System.Text.Json;

public static partial class JsonSerializerCompatOptions
{
    static SystemTextJsonSerializerOptions? _Default;

    public static SystemTextJsonSerializerOptions Default => _Default ??= new()
    {
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
    };

    static SystemTextJsonSerializerOptions? _WriteIndented;

    public static SystemTextJsonSerializerOptions WriteIndented => _WriteIndented ??= new()
    {
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        WriteIndented = true,
    };

    public static partial class Writer
    {
        public static JsonWriterOptions Default => new()
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        };

        public static JsonWriterOptions WriteIndented => new()
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            Indented = true,
        };
    }
}

#endif