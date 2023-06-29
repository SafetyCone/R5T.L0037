using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.F0000.Extensions;
using R5T.F0124;
using R5T.L0031.Extensions;
using R5T.L0038;
using R5T.L0040.T000;
using R5T.T0141;
using R5T.T0161;
using R5T.T0161.Extensions;
using R5T.T0172;
using R5T.T0172.Extensions;
using R5T.T0187;
using R5T.T0193;
using R5T.T0193.Extensions;
using R5T.T0195.Extensions;


namespace R5T.L0037.Construction
{
    [DemonstrationsMarker]
    public partial interface IProjectDemonstrations : IDemonstrationsMarker
    {
        public async Task Add_ContextType()
        {
            /// Inputs.
            var projectFilePath =
                @"C:\Code\DEV\Git\GitHub\SafetyCone\R5T.O0016\source\R5T.O0016\R5T.O0016.csproj"
                .ToProjectFilePath()
                ;
            var contextTypeNameStem =
                "RepositoryContext"
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

        /// <summary>
        /// Adds one or more strong-types (with a common base type) to a project.
        /// Creates the strong-type interface and implementation code files in the project,
        /// but outputs the ToX() operator and extension methods to a file (since modifying the StringOperator and StringExtensions code using Roslyn is complicated).
        /// </summary>
        /// <remarks>
        /// TODO: modify StringOperator and StringExtensions files to include ToX() methods.
        /// </remarks>
        public async Task Add_StrongTypes()
        {
            /// Inputs.
            var projectFilePath =
                @"C:\Code\DEV\Git\GitHub\SafetyCone\R5T.L0032\source\R5T.L0032.T000\R5T.L0032.T000.csproj"
                .ToProjectFilePath()
                ;
            var strongTypeTypeNameStems =
                new[]
                {
                    "SupportedPlatform",
                }
                .ToTypeNameStems()
                ;
            var baseTypeName =
                "string"
                .ToSimpleTypeName()
                ;


            /// Run.
            var namespaceName = Instances.ProjectNamespaceNamesOperator.Get_DefaultProjectNamespaceName(projectFilePath);

            var stringOperatorMethodsByTypeNameStem = new Dictionary<ITypeNameStem, ICode>();
            var stringExtensionMethodsByTypeNameStem = new Dictionary<ITypeNameStem, ICode>();

            void ProcessStrongTypeTypeNameStem(ITypeNameStem strongTypeTypeNameStem)
            {
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

                var stringOperatorCode = Instances.CodeGenerator.Get_StrongType_StringOperator_ToXMethod(
                    strongTypeTypeNameStem,
                    baseTypeName);

                stringOperatorMethodsByTypeNameStem.Add(
                    strongTypeTypeNameStem,
                    stringOperatorCode);

                var stringExtensionsCode = Instances.CodeGenerator.Get_StrongType_StringExtensions_ToXMethod(
                    strongTypeTypeNameStem,
                    baseTypeName);

                stringExtensionMethodsByTypeNameStem.Add(
                    strongTypeTypeNameStem,
                    stringExtensionsCode);
            }

            var distinct = strongTypeTypeNameStems
                .Distinct()
                .OrderAlphabetically(x => x.Value)
                .Now();

            foreach (var strongTypeTypeNameStem in distinct)
            {
                ProcessStrongTypeTypeNameStem(strongTypeTypeNameStem);
            }

            // Create a text file containing the ToX() methods.
            var outputTextFilePath = Instances.FilePaths.OutputTextFilePath;

            var lines = stringOperatorMethodsByTypeNameStem
                .OrderAlphabetically(x => x.Key.Value)
                .Select(x => x.Value.Value)
                .Append(
                    stringExtensionMethodsByTypeNameStem
                        .OrderAlphabetically(x => x.Key.Value)
                        .Select(x => x.Value.Value)
                )
                .MakeIntoLines()
                // Add separating blank lines.
                .AlternateWith(Instances.Strings.NewLine_ForEnvironment)
                .Now();

            await Instances.FileOperator.Write_Texts(
                outputTextFilePath,
                lines);

            // Ensure project references exist for strong types.
            await Instances.ProjectOperations.Ensure_HasProjectReferences(
                projectFilePath.Value,
                // Add strong-type base types.
                Instances.ProjectFileReferences_Raw.R5T_T0179.Value,
                // Add function marker attributes for operator. (Included as part of R5T.T0179, but make it explicit.)
                Instances.ProjectFileReferences_Raw.R5T_T0132.Value
            );

            Instances.NotepadPlusPlusOperator.Open(
                outputTextFilePath);
        }

        /// <summary>
        /// Adds one or more project file references to a project, and updates solutions containing that project that are found in the project's directory hierarchy.
        /// Project references can be specified as raw paths, predefined sets of references, named references, and instanced paths.
        /// </summary>
        public async Task Add_ProjectFileReferences()
        {
            /// Inputs.
            var projectFilePath =
                @"C:\Code\DEV\Git\GitHub\SafetyCone\R5T.S0081\source\R5T.S0081\R5T.S0081.csproj"
                .ToProjectFilePath()
                ;
            var projectFileReferences =
                //Instances.ProjectFileReferenceSets.For_ContextTypeDefinitionLibrary
                new[]
                {
                    //@"C:\Code\DEV\Git\GitHub\SafetyCone\R5T.F0133\source\R5T.F0133\R5T.F0133.csproj"
                    //.ToProjectFileReference(),
                    //Instances.ProjectFileReferences.For_NET_6_FoundationLibrary,
                    //Instances.ProjectFileReferences.For_NET_Standard_2_1_FoundationLibrary
                    //Instances.ProjectFileReferences.For_RoslynNuGetPackageSelector
                    //Instances.ProjectFileReferences.For_SolutionSpecifications
                    //Instances.ProjectFileReferences.For_RemoteRepositoryContext
                    Instances.ProjectFileReferences_Raw.R5T_O0026,
                    Instances.ProjectFileReferences_Raw.R5T_Z0046
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
