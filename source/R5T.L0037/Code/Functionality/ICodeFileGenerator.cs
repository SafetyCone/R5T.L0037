using System;

using R5T.F0124;
using R5T.T0132;
using R5T.T0161;
using R5T.T0172;
using R5T.T0180;
using R5T.T0193;


namespace R5T.L0037
{
    [FunctionalityMarker]
    public partial interface ICodeFileGenerator : IFunctionalityMarker,
        F0053.ICodeFileGenerator
    {
        /// <returns>
        /// Returns whether or not the file was actually written.
        /// </returns>
        public bool Write_Code_Synchronous(
            ICodeFilePath codeFilePath,
            ICode code,
            FileExistsBehavior fileExistsBehavior = FileExistsBehavior.Error)
        {
            return Instances.FileOperator.Write_Synchronous(
                codeFilePath,
                code,
                fileExistsBehavior);
        }

        /// <inheritdoc cref="Write_Code_Synchronous(ICodeFilePath, ICode, FileExistsBehavior)" path="/returns"/>
        public bool Write_ContextDefinition_Synchronous(
            ICodeFilePath codeFilePath,
            IInterfaceTypeName interfaceTypeName,
            INamespaceName namespaceName,
            FileExistsBehavior fileExistsBehavior)
        {
            var code = Instances.CodeGenerator.Get_ContextDefinition(
                interfaceTypeName,
                namespaceName);

            return this.Write_Code_Synchronous(
                codeFilePath,
                code,
                fileExistsBehavior);
        }

        /// <inheritdoc cref="Write_Code_Synchronous(ICodeFilePath, ICode, FileExistsBehavior)" path="/returns"/>
        public bool Write_ContextDefinition_Synchronous(
            ICodeFilePath codeFilePath,
            ITypeNameStem typeNameStem,
            INamespaceName namespaceName,
            FileExistsBehavior fileExistsBehavior)
        {
            var interfaceTypeName = Instances.TypeNameOperator.Get_InterfaceTypeName(typeNameStem);

            return this.Write_ContextDefinition_Synchronous(
                codeFilePath,
                interfaceTypeName,
                namespaceName,
                fileExistsBehavior);
        }

        /// <inheritdoc cref="Write_Code_Synchronous(ICodeFilePath, ICode, FileExistsBehavior)" path="/returns"/>
        public bool Write_ContextImplementation_Synchronous(
            ICodeFilePath codeFilePath,
            IClassTypeName classTypeName,
            IInterfaceTypeName interfaceTypeName,
            INamespaceName namespaceName,
            FileExistsBehavior fileExistsBehavior)
        {
            var code = Instances.CodeGenerator.Get_ContextImplemetation(
                classTypeName,
                interfaceTypeName,
                namespaceName);

            return this.Write_Code_Synchronous(
                codeFilePath,
                code,
                fileExistsBehavior);
        }

        /// <summary>
        /// Writes a context implementation.
        /// </summary>
        /// <inheritdoc cref="Write_Code_Synchronous(ICodeFilePath, ICode, FileExistsBehavior)" path="/returns"/>
        public bool Write_ContextImplementation_Synchronous(
            ICodeFilePath codeFilePath,
            ITypeNameStem typeNameStem,
            INamespaceName namespaceName,
            FileExistsBehavior fileExistsBehavior)
        {
            var interfaceTypeName = Instances.TypeNameOperator.Get_InterfaceTypeName(typeNameStem);
            var classTypeName = Instances.TypeNameOperator.Get_ClassTypeName(typeNameStem);

            return this.Write_ContextImplementation_Synchronous(
                codeFilePath,
                classTypeName,
                interfaceTypeName,
                namespaceName,
                fileExistsBehavior);
        }

        /// <inheritdoc cref="Write_Code_Synchronous(ICodeFilePath, ICode, FileExistsBehavior)" path="/returns"/>
        public bool Write_StrongType_Definition_Synchronous(
            ICodeFilePath codeFilePath,
            IInterfaceTypeName interfaceTypeName,
            INamespaceName namespaceName,
            ISimpleTypeName baseTypeName,
            FileExistsBehavior fileExistsBehavior)
        {
            var code = Instances.CodeGenerator.Get_StrongType_Definition(
                interfaceTypeName,
                namespaceName,
                baseTypeName);

            return this.Write_Code_Synchronous(
                codeFilePath,
                code,
                fileExistsBehavior);
        }

        /// <inheritdoc cref="Write_Code_Synchronous(ICodeFilePath, ICode, FileExistsBehavior)" path="/returns"/>
        public bool Write_StrongType_Definition_Synchronous(
            ICodeFilePath codeFilePath,
            ITypeNameStem typeNameStem,
            INamespaceName namespaceName,
            ISimpleTypeName baseTypeName,
            FileExistsBehavior fileExistsBehavior)
        {
            var interfaceTypeName = Instances.TypeNameOperator.Get_InterfaceTypeName(typeNameStem);

            return this.Write_StrongType_Definition_Synchronous(
                codeFilePath,
                interfaceTypeName,
                namespaceName,
                baseTypeName,
                fileExistsBehavior);
        }

        /// <inheritdoc cref="Write_Code_Synchronous(ICodeFilePath, ICode, FileExistsBehavior)" path="/returns"/>
        public bool Write_StrongType_Implementation_Synchronous(
            ICodeFilePath codeFilePath,
            IClassTypeName classTypeName,
            IInterfaceTypeName interfaceTypeName,
            INamespaceName namespaceName,
            ISimpleTypeName baseTypeName,
            FileExistsBehavior fileExistsBehavior)
        {
            var code = Instances.CodeGenerator.Get_StrongType_Implementation(
                classTypeName,
                interfaceTypeName,
                namespaceName,
                baseTypeName);

            return this.Write_Code_Synchronous(
                codeFilePath,
                code,
                fileExistsBehavior);
        }

        /// <inheritdoc cref="Write_Code_Synchronous(ICodeFilePath, ICode, FileExistsBehavior)" path="/returns"/>
        public bool Write_StrongType_Implementation_Synchronous(
            ICodeFilePath codeFilePath,
            ITypeNameStem typeNameStem,
            INamespaceName namespaceName,
            ISimpleTypeName baseTypeName,
            FileExistsBehavior fileExistsBehavior)
        {
            var interfaceTypeName = Instances.TypeNameOperator.Get_InterfaceTypeName(typeNameStem);
            var classTypeName = Instances.TypeNameOperator.Get_ClassTypeName(typeNameStem);

            return this.Write_StrongType_Implementation_Synchronous(
                codeFilePath,
                classTypeName,
                interfaceTypeName,
                namespaceName,
                baseTypeName,
                fileExistsBehavior);
        }
    }
}
