using System.Reflection;

namespace BD.Common8.Extensions;

/// <summary>
/// 提供对 Reflection（反射）的扩展函数
/// </summary>
public static class ReflectionExtensions
{
    const string TAG = "ReflectionEx";

    /// <summary>
    /// 检索应用于指定程序集的指定类型的自定义特性。
    /// <para>如果发生 <see cref="FileNotFoundException"/> 将返回 <see langword="null"/></para>
    /// </summary>
    /// <param name="assembly"></param>
    /// <param name="attrType"></param>
    /// <returns></returns>
    public static Attribute[]? GetCustomAttributesSafe(this Assembly assembly, Type attrType)
    {
        try
        {
            return assembly.GetCustomAttributes(attrType).ToArray();
        }
        catch (FileNotFoundException)
        {
            // Sometimes the previewer doesn't actually have everything required for these loads to work
            Log.Warn(TAG, "Could not load assembly: {0} for Attribute {1} | Some renderers may not be loaded", assembly.FullName, attrType.FullName);
        }

        return null;
    }

    /// <summary>
    /// 检索应用于指定程序集的指定类型的自定义特性，如果找不到将引发 <see cref="ArgumentNullException"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="assembly"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static T GetRequiredCustomAttribute<T>(this Assembly assembly) where T : Attribute
    {
        var requiredCustomAttribute = assembly.GetCustomAttribute<T>();
        if (requiredCustomAttribute == null)
#pragma warning disable CA2208 // 正确实例化参数异常
            throw new ArgumentNullException(nameof(requiredCustomAttribute));
#pragma warning restore CA2208 // 正确实例化参数异常
        return requiredCustomAttribute;
    }

    static bool IsNullableType(this Type t)
    {
        return t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>);
    }

    /// <summary>
    /// 类型是否为 <see cref="Nullable{T}"/> 可空类型
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    public static bool IsNullable(this Type t)
    {
        if (t.IsValueType) // 值类型(struct)进行可空判断
            return t.IsNullableType();
        return true; // 引用类型(class)都可空
    }

    /// <summary>
    /// 判断类型是否为静态类
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    public static bool IsStatic(this Type t) => t.IsAbstract && t.IsSealed;

    /// <summary>
    /// 获取类型的 <see cref="TypeCode"/>
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static TypeCode GetTypeCode(this Type type) => Type.GetTypeCode(type);
}