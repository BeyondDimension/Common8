#if !DEL_SYS_LOG && (!NETFRAMEWORK || (NETSTANDARD && NETSTANDARD2_0_OR_GREATER))

using BD.Common8.Extensions;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace System;

/// <summary>
/// 日志
/// <para>使用说明：</para>
/// <para>在类中定义 const string TAG = 类名(长度小于等于23)</para>
/// <para>使用 Log.Debug(TAG,... / Log.Info(TAG,... / Log.Warn(TAG,... / Log.Error(TAG,...</para>
/// </summary>
public static class Log
{
    /// <inheritdoc cref="ILoggerFactory"/>
    public static Func<ILoggerFactory>? LoggerFactory { private get; set; }

    static ILoggerFactory? factory;

    /// <inheritdoc cref="ILoggerFactory"/>
    public static ILoggerFactory Factory => factory ??= (Ioc.IsConfigured ? Ioc.Get<ILoggerFactory>() : null) ?? LoggerFactory?.Invoke() ?? throw new ArgumentNullException(nameof(LoggerFactory));

    /// <inheritdoc cref="ILoggerFactory.CreateLogger(string)"/>
    public static ILogger CreateLogger(string tag) => Factory.CreateLogger(tag);

#pragma warning disable CA2254 // 模板应为静态表达式

    #region Debug

    /// <inheritdoc cref="LoggerExtensions.LogDebug(ILogger, string?, object?[])"/>
    [Conditional("DEBUG")]
    public static void Debug(string tag, string message)
    {
        var logger = CreateLogger(tag);
        logger.LogDebug(message);
    }

    /// <inheritdoc cref="LoggerExtensions.LogDebug(ILogger, string?, object?[])"/>
    [Conditional("DEBUG")]
    public static void Debug(string tag, string message, params object?[] args)
    {
        var logger = CreateLogger(tag);
        logger.LogDebug(message, args);
    }

    /// <inheritdoc cref="LoggerExtensions.LogDebug(ILogger, Exception?, string?, object?[])"/>
    [Conditional("DEBUG")]
    public static void Debug(string tag, Exception? exception, string message)
    {
        var logger = CreateLogger(tag);
        logger.LogDebug(exception, message);
    }

    /// <inheritdoc cref="LoggerExtensions.LogDebug(ILogger, Exception?, string?, object?[])"/>
    [Conditional("DEBUG")]
    public static void Debug(string tag, Exception? exception, string message, params object?[] args)
    {
        var logger = CreateLogger(tag);
        logger.LogDebug(exception, message, args);
    }

    /// <inheritdoc cref="LoggerExtensions.LogDebug(ILogger, EventId, Exception?, string?, object?[])"/>
    [Conditional("DEBUG")]
    public static void Debug(string tag, EventId eventId, Exception? exception, string message, params object?[] args)
    {
        var logger = CreateLogger(tag);
        logger.LogDebug(eventId, exception, message, args);
    }

    /// <inheritdoc cref="LoggerExtensions.LogDebug(ILogger, EventId, string?, object?[])"/>
    [Conditional("DEBUG")]
    public static void Debug(string tag, EventId eventId, string message, params object?[] args)
    {
        var logger = CreateLogger(tag);
        logger.LogDebug(eventId, message, args);
    }

    #endregion

    #region Error

    /// <inheritdoc cref="LoggerExtensions.LogError(ILogger, string?, object?[])"/>
    public static void Error(string tag, string message)
    {
        var logger = CreateLogger(tag);
        logger.LogError(message);
    }

    /// <inheritdoc cref="LoggerExtensions.LogError(ILogger, string?, object?[])"/>
    public static void Error(string tag, string message, params object?[] args)
    {
        var logger = CreateLogger(tag);
        logger.LogError(message, args);
    }

    /// <inheritdoc cref="LoggerExtensions.LogError(ILogger, Exception?, string?, object?[])"/>
    public static void Error(string tag, Exception? exception, string message)
    {
        var logger = CreateLogger(tag);
        logger.LogError(exception, message);
    }

    /// <inheritdoc cref="LoggerExtensions.LogError(ILogger, Exception?, string?, object?[])"/>
    public static void Error(string tag, Exception? exception, string message, params object?[] args)
    {
        var logger = CreateLogger(tag);
        logger.LogError(exception, message, args);
    }

    /// <inheritdoc cref="LoggerExtensions.LogError(ILogger, EventId, Exception?, string?, object?[])"/>
    public static void Error(string tag, EventId eventId, Exception? exception, string message, params object?[] args)
    {
        var logger = CreateLogger(tag);
        logger.LogError(eventId, exception, message, args);
    }

    /// <inheritdoc cref="LoggerExtensions.LogError(ILogger, EventId, string?, object?[])"/>
    public static void Error(string tag, EventId eventId, string message, params object?[] args)
    {
        var logger = CreateLogger(tag);
        logger.LogError(eventId, message, args);
    }

    #endregion

    #region Info

    /// <inheritdoc cref="LoggerExtensions.LogInformation(ILogger, string?, object?[])"/>
    public static void Info(string tag, string message)
    {
        var logger = CreateLogger(tag);
        logger.LogInformation(message);
    }

    /// <inheritdoc cref="LoggerExtensions.LogInformation(ILogger, string?, object?[])"/>
    public static void Info(string tag, string message, params object?[] args)
    {
        var logger = CreateLogger(tag);
        logger.LogInformation(message, args);
    }

    /// <inheritdoc cref="LoggerExtensions.LogInformation(ILogger, Exception?, string?, object?[])"/>
    public static void Info(string tag, Exception? exception, string message)
    {
        var logger = CreateLogger(tag);
        logger.LogInformation(exception, message);
    }

    /// <inheritdoc cref="LoggerExtensions.LogInformation(ILogger, Exception?, string?, object?[])"/>
    public static void Info(string tag, Exception? exception, string message, params object?[] args)
    {
        var logger = CreateLogger(tag);
        logger.LogInformation(exception, message, args);
    }

    /// <inheritdoc cref="LoggerExtensions.LogInformation(ILogger, EventId, Exception?, string?, object?[])"/>
    public static void Info(string tag, EventId eventId, Exception? exception, string message, params object?[] args)
    {
        var logger = CreateLogger(tag);
        logger.LogInformation(eventId, exception, message, args);
    }

    /// <inheritdoc cref="LoggerExtensions.LogInformation(ILogger, EventId, string?, object?[])"/>
    public static void Info(string tag, EventId eventId, string message, params object?[] args)
    {
        var logger = CreateLogger(tag);
        logger.LogInformation(eventId, message, args);
    }

    #endregion

    #region Warn

    /// <inheritdoc cref="LoggerExtensions.LogWarning(ILogger, string?, object?[])"/>
    public static void Warn(string tag, string message)
    {
        var logger = CreateLogger(tag);
        logger.LogWarning(message);
    }

    /// <inheritdoc cref="LoggerExtensions.LogWarning(ILogger, string?, object?[])"/>
    public static void Warn(string tag, string message, params object?[] args)
    {
        var logger = CreateLogger(tag);
        logger.LogWarning(message, args);
    }

    /// <inheritdoc cref="LoggerExtensions.LogWarning(ILogger, Exception?, string?, object?[])"/>
    public static void Warn(string tag, Exception? exception, string message)
    {
        var logger = CreateLogger(tag);
        logger.LogWarning(exception, message);
    }

    /// <inheritdoc cref="LoggerExtensions.LogWarning(ILogger, Exception?, string?, object?[])"/>
    public static void Warn(string tag, Exception? exception, string message, params object?[] args)
    {
        var logger = CreateLogger(tag);
        logger.LogWarning(exception, message, args);
    }

    /// <inheritdoc cref="LoggerExtensions.LogWarning(ILogger, EventId, Exception?, string?, object?[])"/>
    public static void Warn(string tag, EventId eventId, Exception? exception, string message, params object?[] args)
    {
        var logger = CreateLogger(tag);
        logger.LogWarning(eventId, exception, message, args);
    }

    /// <inheritdoc cref="LoggerExtensions.LogWarning(ILogger, EventId, string?, object?[])"/>
    public static void Warn(string tag, EventId eventId, string message, params object?[] args)
    {
        var logger = CreateLogger(tag);
        logger.LogWarning(eventId, message, args);
    }

    #endregion
}

public static partial class ExceptionExtensions
{
    /// <summary>
    /// 通过 <see cref="Exception"/> 纪录日志并在 UI 上显示，传入 <see cref="LogLevel.None"/> 可不写日志
    /// </summary>
    /// <param name="e"></param>
    /// <param name="show"></param>
    /// <param name="tag"></param>
    /// <param name="level"></param>
    /// <param name="memberName"></param>
    /// <param name="message"></param>
    /// <param name="args"></param>
    public static void LogAndShow(Exception? e,
        Action<string>? show,
        string tag, LogLevel level = LogLevel.Error,
        string memberName = "",
        string? message = null,
        params object?[] args) => LogAndShowCore(e, show, tag, logger: null, level, memberName, message, args);

    /// <inheritdoc cref="LogAndShow(Exception?, Action{string}?, string, LogLevel, string, string?, object?[])"/>
    public static void LogAndShow(Exception? e,
        Action<string>? show,
        ILogger? logger, LogLevel level = LogLevel.Error,
        string memberName = "",
        string? message = null, params object?[] args) => LogAndShowCore(e, show, tag: null, logger, level, memberName, message, args);

    static void LogAndShowCore(Exception? e,
        Action<string>? show,
        string? tag = null, ILogger? logger = null, LogLevel level = LogLevel.Error,
        string memberName = "",
        string? message = null, params object?[] args)
    {
        bool has_message = !string.IsNullOrWhiteSpace(message);
        if (!has_message)
        {
            if (!string.IsNullOrWhiteSpace(memberName))
            {
                message = $"{memberName} Error";
                has_message = true;
            }
        }
        var has_args = args.Any_Nullable();
        var has_e = e != null;
        if (has_e)
        {
            var knownType = e!.GetKnownType();
            if (knownType != ExceptionKnownType.Unknown) level = LogLevel.None;
        }
        var has_log_level = level < LogLevel.None;
        if (has_log_level)
        {
            if (logger == null && tag != null)
            {
                logger = Log.CreateLogger(tag);
            }
            if (logger != null)
            {
                if (has_args)
                {
                    logger.Log(level, e, message!, args);
                }
                else
                {
                    logger.Log(level, e, message!);
                }
            }
        }
        try
        {
            show?.Invoke(GetShowMsg());
        }
        catch
        {
        }
        string GetShowMsg()
        {
            if (has_e) return GetAllMessageCore(e!, has_message, has_args, message, args);
            if (has_message)
            {
                if (has_args)
                {
                    return message!.Format(args);
                }
                else
                {
                    return message!;
                }
            }
            return "";
        }
    }
}
#endif