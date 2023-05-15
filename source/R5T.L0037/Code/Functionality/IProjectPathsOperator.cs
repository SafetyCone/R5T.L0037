using System;

using R5T.T0132;
using R5T.T0161;
using R5T.T0172;
using R5T.T0172.Extensions;
using R5T.T0180;
using R5T.T0180.Extensions;
using R5T.T0187;
using R5T.T0187.Extensions;


namespace R5T.L0037
{
    [FunctionalityMarker]
    public partial interface IProjectPathsOperator : IFunctionalityMarker,
        F0052.IProjectPathsOperator,
        F0129.IProjectPathsOperator
    {
        public IDirectoryPath Get_Context_Definitions_DirectoryPath(IProjectDirectoryPath projectDirectoryPath)
        {
            var output = Instances.PathOperator.Combine(
                projectDirectoryPath.Value,
                Instances.ProjectDirectoryRelativePaths.Contexts_Definitions_Directory.Value)
                .ToDirectoryPath();

            return output;
        }

        public IDirectoryPath Get_Context_Definitions_DirectoryPath(IProjectFilePath projectFilePath)
        {
            var projectDirectoryPath = this.Get_ProjectDirectoryPath(projectFilePath);

            var output = this.Get_Context_Definitions_DirectoryPath(projectDirectoryPath);
            return output;
        }

        public ICodeFilePath Get_Context_Definition_FilePath(
            IProjectFilePath projectFilePath,
            IInterfaceTypeName interfaceTypeName)
        {
            var codeFileName = Instances.CodeFileNameOperator.Get_CSharpFileName(interfaceTypeName);

            var directoryPath = this.Get_Context_Definitions_DirectoryPath(projectFilePath);

            var output = Instances.PathOperator.Combine(
                directoryPath.Value,
                codeFileName.Value)
                .ToCodeFilePath();

            return output;
        }

        public ICodeFilePath Get_Context_Definition_FilePath(
            IProjectFilePath projectFilePath,
            ITypeNameStem typeNameStem)
        {
            var interfaceTypeName = Instances.TypeNameOperator.Get_InterfaceTypeName(typeNameStem);

            var output = this.Get_Context_Definition_FilePath(
                projectFilePath,
                interfaceTypeName);

            return output;
        }

        public IDirectoryPath Get_Context_Implementations_DirectoryPath(IProjectDirectoryPath projectDirectoryPath)
        {
            var output = Instances.PathOperator.Combine(
                projectDirectoryPath.Value,
                Instances.ProjectDirectoryRelativePaths.Contexts_Implementations_Directory.Value)
                .ToDirectoryPath();

            return output;
        }

        public IDirectoryPath Get_Context_Implementations_DirectoryPath(IProjectFilePath projectFilePath)
        {
            var projectDirectoryPath = this.Get_ProjectDirectoryPath(projectFilePath);

            var output = this.Get_Context_Implementations_DirectoryPath(projectDirectoryPath);
            return output;
        }

        public ICodeFilePath Get_Context_Implementation_FilePath(
            IProjectFilePath projectFilePath,
            IClassTypeName classTypeName)
        {
            var codeFileName = Instances.CodeFileNameOperator.Get_CSharpFileName(classTypeName);

            var directoryPath = this.Get_Context_Implementations_DirectoryPath(projectFilePath);

            var output = Instances.PathOperator.Combine(
                directoryPath.Value,
                codeFileName.Value)
                .ToCodeFilePath();

            return output;
        }

        public ICodeFilePath Get_Context_Implementation_FilePath(
            IProjectFilePath projectFilePath,
            ITypeNameStem typeNameStem)
        {
            var classTypeName = Instances.TypeNameOperator.Get_ClassTypeName(typeNameStem);

            var output = this.Get_Context_Implementation_FilePath(
                projectFilePath,
                classTypeName);

            return output;
        }

        public IDirectoryPath Get_StrongTypes_Interfaces_DirectoryPath(IProjectDirectoryPath projectDirectoryPath)
        {
            var output = Instances.PathOperator.Combine(
                projectDirectoryPath.Value,
                Instances.ProjectDirectoryRelativePaths.StrongTypes_Interfaces_Directory.Value)
                .ToDirectoryPath();

            return output;
        }

        public IDirectoryPath Get_StrongTypes_Interfaces_DirectoryPath(IProjectFilePath projectFilePath)
        {
            var projectDirectoryPath = this.Get_ProjectDirectoryPath(projectFilePath);

            var output = this.Get_StrongTypes_Interfaces_DirectoryPath(projectDirectoryPath);
            return output;
        }

        public IDirectoryPath Get_StrongTypes_Implementations_DirectoryPath(IProjectDirectoryPath projectDirectoryPath)
        {
            var output = Instances.PathOperator.Combine(
                projectDirectoryPath.Value,
                Instances.ProjectDirectoryRelativePaths.StrongTypes_Implementations_Directory.Value)
                .ToDirectoryPath();

            return output;
        }

        public IDirectoryPath Get_StrongTypes_Implementations_DirectoryPath(IProjectFilePath projectFilePath)
        {
            var projectDirectoryPath = this.Get_ProjectDirectoryPath(projectFilePath);

            var output = this.Get_StrongTypes_Implementations_DirectoryPath(projectDirectoryPath);
            return output;
        }

        public ICodeFilePath Get_StrongTypes_Implementation_FilePath(
            IProjectFilePath projectFilePath,
            IClassTypeName classTypeName)
        {
            var codeFileName = Instances.CodeFileNameOperator.Get_CSharpFileName(classTypeName);

            var directoryPath = this.Get_StrongTypes_Implementations_DirectoryPath(projectFilePath);

            var output = Instances.PathOperator.Combine(
                directoryPath.Value,
                codeFileName.Value)
                .ToCodeFilePath();

            return output;
        }

        public ICodeFilePath Get_StrongTypes_Implementation_FilePath(
            IProjectFilePath projectFilePath,
            ITypeNameStem typeNameStem)
        {
            var classTypeName = Instances.TypeNameOperator.Get_ClassTypeName(typeNameStem);

            var output = this.Get_StrongTypes_Implementation_FilePath(
                projectFilePath,
                classTypeName);

            return output;
        }

        public ICodeFilePath Get_StrongTypes_Interface_FilePath(
            IProjectFilePath projectFilePath,
            IInterfaceTypeName interfaceTypeName)
        {
            var codeFileName = Instances.CodeFileNameOperator.Get_CSharpFileName(interfaceTypeName);

            var directoryPath = this.Get_StrongTypes_Interfaces_DirectoryPath(projectFilePath);

            var output = Instances.PathOperator.Combine(
                directoryPath.Value,
                codeFileName.Value)
                .ToCodeFilePath();

            return output;
        }

        public ICodeFilePath Get_StrongTypes_Interface_FilePath(
            IProjectFilePath projectFilePath,
            ITypeNameStem typeNameStem)
        {
            var interfaceTypeName = Instances.TypeNameOperator.Get_InterfaceTypeName(typeNameStem);

            var output = this.Get_StrongTypes_Interface_FilePath(
                projectFilePath,
                interfaceTypeName);

            return output;
        }
    }
}
