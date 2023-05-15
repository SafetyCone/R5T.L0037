using System;

using R5T.F0131.Extensions;
using R5T.T0132;
using R5T.T0161;
using R5T.T0193;


namespace R5T.L0037
{
    [FunctionalityMarker]
    public partial interface ICodeGenerator : IFunctionalityMarker
    {
        public ICodeFileContent Get_ContextDefinition(
            IInterfaceTypeName interfaceTypeName,
            INamespaceName namespaceName)
        {
            var output =
$@"
using System;

using R5T.T0137;


namespace {namespaceName}
{{
    /// <summary>
    /// %%% DESCRIPTION %%%
    /// </summary>
    [ContextTypeMarker]
    public interface {interfaceTypeName} : IContextDefinitionMarker
    {{
        
    }}
}}
".ToCodeFileContent();

            return output;
        }

        public ICodeFileContent Get_ContextImplemetation(
            IClassTypeName classTypeName,
            IInterfaceTypeName interfaceTypeName,
            INamespaceName namespaceName)
        {
            var output =
$@"
using System;

using R5T.T0137;


namespace {namespaceName}
{{
    /// <inheritdoc cref=""{interfaceTypeName}""/>
    [ContextImplementationMarker]
    public class {classTypeName} : IContextImplementationMarker,
        {interfaceTypeName}
    {{
        
    }}
}}
".ToCodeFileContent();

            return output;
        }

        public ICodeFileContent Get_StrongType_Definition(
            IInterfaceTypeName interfaceTypeName,
            INamespaceName namespaceName,
            ISimpleTypeName baseTypeName)
        {
            var output =
$@"
using System;

using R5T.T0178;
using R5T.T0179;


namespace {namespaceName}
{{
    /// <summary>
    /// Strongly-types a {baseTypeName} as a %%%.
    /// </summary>
    [StrongTypeMarker]
    public interface {interfaceTypeName} : IStrongTypeMarker,
        ITyped<{baseTypeName}>
    {{
    }}
}}
".ToCodeFileContent();

            return output;
        }

        public ICodeFileContent Get_StrongType_Implementation(
            IClassTypeName classTypeName,
            IInterfaceTypeName interfaceTypeName,
            INamespaceName namespaceName,
            ISimpleTypeName baseTypeName)
        {
            var output =
$@"
using System;

using R5T.T0178;
using R5T.T0179;


namespace {namespaceName}
{{
    /// <inheritdoc cref=""{interfaceTypeName}""/>
    [StrongTypeImplementationMarker]
    public class {classTypeName} : TypedBase<{baseTypeName}>, IStrongTypeMarker,
        {interfaceTypeName}
    {{
        public {classTypeName}(string value)
            : base(value)
        {{
        }}
    }}
}}
".ToCodeFileContent();

            return output;
        }

        public ICode Get_StrongType_StringOperator_ToXMethod(
            IInterfaceTypeName interfaceTypeName,
            IClassTypeName classTypeName,
            ISimpleTypeName baseTypeName)
        {
            var output =
$@"
/// <inheritdoc cref=""{interfaceTypeName}""/>
public {interfaceTypeName} To{classTypeName}({baseTypeName} value)
{{
    var output = new {classTypeName}(value);
    return output;
}}
".ToCode();

            return output;
        }

        public ICode Get_StrongType_StringOperator_ToXMethod(
            ITypeNameStem strongTypeNameStem,
            ISimpleTypeName baseTypeName)
        {
            var classTypeName = Instances.TypeNameOperator.Get_ClassTypeName(strongTypeNameStem);
            var interfaceTypeName = Instances.TypeNameOperator.Get_InterfaceTypeName(strongTypeNameStem);

            return this.Get_StrongType_StringOperator_ToXMethod(
                interfaceTypeName,
                classTypeName,
                baseTypeName);
        }

        public ICode Get_StrongType_StringExtensions_ToXMethod(
            IInterfaceTypeName interfaceTypeName,
            IClassTypeName classTypeName,
            ISimpleTypeName baseTypeName)
        {
            var output =
$@"
/// <inheritdoc cref=""IStringOperator.To{classTypeName}(string)""/>
public static {interfaceTypeName} To{classTypeName}(this {baseTypeName} value)
{{
    return Instances.StringOperator_Extensions.To{classTypeName}(value);
}}
".ToCode();

            return output;
        }

        public ICode Get_StrongType_StringExtensions_ToXMethod(
            ITypeNameStem strongTypeNameStem,
            ISimpleTypeName baseTypeName)
        {
            var classTypeName = Instances.TypeNameOperator.Get_ClassTypeName(strongTypeNameStem);
            var interfaceTypeName = Instances.TypeNameOperator.Get_InterfaceTypeName(strongTypeNameStem);

            return this.Get_StrongType_StringExtensions_ToXMethod(
                interfaceTypeName,
                classTypeName,
                baseTypeName);
        }
    }
}
