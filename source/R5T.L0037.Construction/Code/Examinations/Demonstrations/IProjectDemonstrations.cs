using System;
using System.Threading.Tasks;

using R5T.F0124;
using R5T.L0031.Extensions;
using R5T.L0038;
using R5T.L0040.T000;
using R5T.T0141;
using R5T.T0161.Extensions;
using R5T.T0172;
using R5T.T0172.Extensions;
using R5T.T0187;
using R5T.T0193.Extensions;


namespace R5T.L0037.Construction
{
    [DemonstrationsMarker]
    public partial interface IProjectDemonstrations : IDemonstrationsMarker
    {
        public async Task Add_ContextType()
        {
            /// Inputs.
            var projectFilePath =
                @"C:\Code\DEV\Git\GitHub\SafetyCone\R5T.L0040\source\R5T.L0040.T000\R5T.L0040.T000.csproj"
                .ToProjectFilePath()
                ;
            var contextTypeNameStem =
                "ProjectContext"
                .ToTypeNameStem()
                ;


            /// Run.
            var (humanOutputTextFilePath, logFilePath) = await Instances.ApplicationContextOperator.In_ApplicationContext_Undated(
                Instances.Values.ApplicationName,
                ApplicationContextOperation
            );

            async Task ApplicationContextOperation(
                IApplicationContext applicationContext)
            {
                var namespaceName = Instances.ProjectNamespaceNamesOperator.Get_DefaultProjectNamespaceName(projectFilePath);

                var definitionFilePath = Instances.ProjectPathsOperator.Get_Context_Definition_FilePath(
                    projectFilePath,
                    contextTypeNameStem);

                Instances.CodeFileGenerator.Write_ContextDefinition_Synchronous(
                    definitionFilePath,
                    contextTypeNameStem,
                    namespaceName,
                    FileExistsBehavior.Skip);

                var implementationFilePath = Instances.ProjectPathsOperator.Get_Context_Implementation_FilePath(
                    projectFilePath,
                    contextTypeNameStem);

                Instances.CodeFileGenerator.Write_ContextImplementation_Synchronous(
                    implementationFilePath,
                    contextTypeNameStem,
                    namespaceName,
                    FileExistsBehavior.Skip);

                // Now ensure the project (and containing solutions) have the context type marker attributes library project reference.
                await Instances.ProjectContextOperator.In_Modify_ProjectContext(
                    projectFilePath,
                    applicationContext.TextOutput,
                    Instances.ProjectContextOperations.Add_ProjectFileReferences_AndUpdateContainingSolutions(
                        Instances.ProjectFileReferenceSets.For_ContextTypeDefinitionLibrary));
            }

            Instances.NotepadPlusPlusOperator.Open(
                humanOutputTextFilePath,
                logFilePath);
        }

        public Task Add_StrongType()
        {
            /// Inputs.
            var projectFilePath =
                @"C:\Code\DEV\Git\GitHub\SafetyCone\R5T.T0196\source\R5T.T0196\R5T.T0196.csproj"
                .ToProjectFilePath()
                ;
            var strongTypeTypeNameStem =
                "FormName"
                .ToTypeNameStem()
                ;
            var baseTypeName =
                "string"
                .ToSimpleTypeName()
                ;


            /// Run.
            var namespaceName = Instances.ProjectNamespaceNamesOperator.Get_DefaultProjectNamespaceName(projectFilePath);

            // Interface.
            var interfaceFilePath = Instances.ProjectPathsOperator.Get_StrongTypes_Interface_FilePath(
                projectFilePath,
                strongTypeTypeNameStem);

            Instances.CodeFileGenerator.Write_StrongType_Definition_Synchronous(
                interfaceFilePath,
                strongTypeTypeNameStem,
                namespaceName,
                baseTypeName,
                FileExistsBehavior.Skip);

            // Implementation.
            var implementationFilePath = Instances.ProjectPathsOperator.Get_StrongTypes_Implementation_FilePath(
                projectFilePath,
                strongTypeTypeNameStem);

            Instances.CodeFileGenerator.Write_StrongType_Implementation_Synchronous(
                implementationFilePath,
                strongTypeTypeNameStem,
                namespaceName,
                baseTypeName,
                FileExistsBehavior.Skip);

            // Create a text file containing the ToX() methods.
            var outputTextFilePath = Instances.FilePaths.OutputTextFilePath;

            var stringOperatorCode = Instances.CodeGenerator.Get_StrongType_StringOperator_ToXMethod(
                strongTypeTypeNameStem,
                baseTypeName);

            var stringExtensionsCode = Instances.CodeGenerator.Get_StrongType_StringExtensions_ToXMethod(
                strongTypeTypeNameStem,
                baseTypeName);

            Instances.CodeFileGenerator.Write_Code_Synchronous(
                outputTextFilePath.ToCodeFilePath(),
                (stringOperatorCode.Value + Instances.Strings.NewLine_ForEnvironment + stringExtensionsCode.Value).ToCode(),
                FileExistsBehavior.Overwrite);

            Instances.NotepadPlusPlusOperator.Open(
                outputTextFilePath);

            return Task.CompletedTask;
        }

        public async Task Add_ProjectFileReferences()
        {
            /// Inputs.
            var projectFilePath =
                @"C:\Code\DEV\Git\GitHub\SafetyCone\R5T.O0004\source\R5T.O0004\R5T.O0004.csproj"
                .ToProjectFilePath()
                ;
            var projectFileReferences =
                //Instances.ProjectFileReferenceSets.For_StrongTypesDefinitionLibrary
                new[]
                {
                    Instances.ProjectFileReferences.For_NET_6_FoundationLibrary,
                    Instances.ProjectFileReferences_Raw.R5T_F0131,
                    Instances.ProjectFileReferences_Raw.R5T_T0161,
                    Instances.ProjectFileReferences_Raw.R5T_T0172,
                    Instances.ProjectFileReferences_Raw.R5T_T0193
                }
                ;
            // True, to update the recursive project references of all solutions containg the specified project.
            var modifyContainingSolutions = true;


            /// Run.
            var (humanOutputTextFilePath, logFilePath) = await Instances.ApplicationContextOperator.In_ApplicationContext_Undated(
                Instances.Values.ApplicationName,
                ApplicationContextOperation
            );

            async Task ApplicationContextOperation(
                IApplicationContext applicationContext)
            {
                await Instances.ProjectContextOperator.In_Modify_ProjectContext(
                    projectFilePath,
                    applicationContext.TextOutput,
                    ProjectContextOperation);
            }

            async Task ProjectContextOperation(IProjectContext projectContext)
            {
                var operation = modifyContainingSolutions
                    ? Instances.ProjectContextOperations.Add_ProjectFileReferences_AndUpdateContainingSolutions(
                        projectFileReferences)
                    : Instances.ProjectContextOperations.Add_ProjectFileReferences(
                        projectFileReferences)
                    ;

                await projectContext.Run(operation);
            }

            Instances.NotepadPlusPlusOperator.Open(
                humanOutputTextFilePath,
                logFilePath);
        }
    }
}
