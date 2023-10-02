// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

#if NETFRAMEWORK || NETSTANDARD2_0
namespace System.Diagnostics.CodeAnalysis;

/// <summary>
///     Specifies that the output will be non-<see langword="null"/> if the
///     named parameter is non-<see langword="null"/>.
/// </summary>
[AttributeUsage(
    AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.ReturnValue,
    AllowMultiple = true,
    Inherited = false
)]
internal sealed class NotNullIfNotNullAttribute : Attribute
{
    /// <summary>
    ///     Gets the associated parameter name.
    ///     The output will be non-<see langword="null"/> if the argument to the
    ///     parameter specified is non-<see langword="null"/>.
    /// </summary>
    public string ParameterName { get; }

    /// <summary>
    ///     Initializes the attribute with the associated parameter name.
    /// </summary>
    /// <param name="parameterName">
    ///     The associated parameter name.
    ///     The output will be non-<see langword="null"/> if the argument to the
    ///     parameter specified is non-<see langword="null"/>.
    /// </param>
    public NotNullIfNotNullAttribute(string parameterName)
    {
        ParameterName = parameterName;
    }
}
#endif