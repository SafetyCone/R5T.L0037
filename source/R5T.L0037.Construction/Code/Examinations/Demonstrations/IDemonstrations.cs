using System;
using System.Threading.Tasks;

using R5T.F0000;
using R5T.F0124.Extensions;
using R5T.L0031.Extensions;
using R5T.L0033.T000;
using R5T.L0036.T000.N001;
using R5T.L0039.T000;
using R5T.L0038;
using R5T.L0040.T000;
using R5T.L0047.T000;
using R5T.T0141;
using R5T.T0161.Extensions;
using R5T.T0172.Extensions;
using R5T.T0184.Extensions;
using R5T.T0187.Extensions;
using R5T.T0198;
using R5T.T0200.Extensions;


namespace R5T.L0037.Construction
{
    [DemonstrationsMarker]
    public partial interface IDemonstrations : IDemonstrationsMarker
    {
        /// <summary>
        /// Creates a new library project inside an existing solution, and adds it to the solution.
        /// </summary>
        public async Task Add_LibraryProject_ToSolution()
        {
            /// Inputs.
            var solutionFilePath =
                @"C:\Code\DEV\Git\GitHub\SafetyCone\R5T.L0070\source\R5T.L0070.sln"
                .ToSolutionFilePath()
                ;
            var projectName =
                "R5T.L0070.F001"
                .ToProjectName()
                ;
            var projectDescription =
                "MemberDocumentation instance generation from .NET XML documentation file functionality library."
                .ToProjectDescription()
                ;
            var repositoryUrl = new IsSet<IRepositoryUrl>();


            /// Run.
            var projectNamespaceName = Instances.ProjectNamespaceNamesOperator.Get_DefaultProjectNamespaceName(projectName);

            var (humanOutputTextFilePath, logFilePath) = await Instances.ApplicationContextOperator.In_ApplicationContext_Undated(
                Instances.Values.ApplicationName,
                ApplicationContextOperation
            );

            async Task ApplicationContextOperation(
                IApplicationContext applicationContext)
            {
                await Instances.SolutionContextOperator.In_Modify_SolutionContext(
                    solutionFilePath,
                    applicationContext.TextOutput,
                    SolutionContextOperation);
            }

            async Task SolutionContextOperation(ISolutionContext solutionContext)
            {
                await solutionContext.Run(
                    Instances.SolutionContextOperations.In_Add_New_ProjectContext(
                        projectName,
                        Create_LibraryProjectOperation
                    )
                );
            }

            async Task Create_LibraryProjectOperation(IProjectContext projectContext)
            {
                await projectContext.Run(
                    Instances.ProjectContextOperations.Create_New_Project(
                        Instances.ProjectFileContextOperations.Setup_LibraryProjectFile(
                            projectDescription,
                            repositoryUrl
                        ),
                        Instances.ProjectContextOperations.Setup_LibraryProject(
                            projectDescription
                        ),
                        Instances.ActionOperations.DoNothing
                    )
                );
            }

            Instances.NotepadPlusPlusOperator.Open(
                humanOutputTextFilePath,
                logFilePath);
        }

        /// <summary>
        /// Creates a project, in a solution, in a specified solution directory.
        /// </summary>
        public async Task Create_Project_InSolution_InDirectory()
        {
            /// Inputs.
            var deleteSolutionDirectory_IfExists = true;
            var solutionDirectoryPath =
                //""
                //.ToSolutionDirectoryPath()
                Instances.ExampleSolutionDirectoryPaths.Test_Project
                ;
            var solutionName =
                //""
                //.ToSolutionName()
                Instances.ExampleSolutionNames.Test_Project
                ;
            var projectDescription = "Test project.".ToProjectDescription();
            var repositoryUrl = new IsSet<IRepositoryUrl>();


            /// Run.
            var projectName = Instances.ProjectNameOperator.Get_DefaultProjectName(solutionName);
            var projectNamespaceName = projectName.Value.ToNamespaceName();

            var projectInSolutionCreationOutput = new ProjectInSolutionCreationOutput();

            var (humanOutputTextFilePath, logFilePath) = await Instances.ApplicationContextOperator.In_ApplicationContext_Undated(
                Instances.Values.ApplicationName,
                ApplicationContextOperation
            );

            async Task ApplicationContextOperation(
                IApplicationContext applicationContext)
            {
                await Instances.SolutionContextOperator.In_New_SolutionContext(
                    solutionDirectoryPath,
                    solutionName,
                    applicationContext.TextOutput,
                    deleteSolutionDirectory_IfExists,
                    Create_SolutionOperation);
            }

            async Task Create_SolutionOperation(ISolutionContext solutionContext)
            {
                await solutionContext.Run(
                    Instances.SolutionContextOperations.Create_New_Solution(
                        projectInSolutionCreationOutput,
                        Instances.SolutionContextOperations.In_Add_New_ProjectContext(
                            projectName,
                            Create_ProjectOperation
                        )
                    )
                );
            }

            async Task Create_ProjectOperation(IProjectContext projectContext)
            {
                await projectContext.Run(
                    Instances.ProjectContextOperations.Create_New_Project(
                        //Instances.ProjectFileContextOperations.Create_ConsoleProjectFile(
                        //    projectDescription,
                        //    repositoryUrl
                        //),
                        Instances.ProjectFileContextOperations.Setup_LibraryProjectFile(
                            projectDescription,
                            repositoryUrl
                        ),
                        //Instances.ProjectContextOperations.Create_ConsoleProject(
                        //    projectName,
                        //    projectDescription,
                        //    projectNamespaceName
                        //)
                        Instances.ProjectContextOperations.Setup_LibraryProject(
                            projectDescription
                        ),
                        projectInSolutionCreationOutput
                    )
                );
            }


            Instances.VisualStudioOperator.OpenSolutionFile(
                projectInSolutionCreationOutput.SolutionFilePath.Value);

            Instances.NotepadPlusPlusOperator.Open(
                humanOutputTextFilePath,
                logFilePath);
        }

        /// <summary>
        /// Test bed for project context operations.
        /// Generates a project (project file plus other files) in a given directory.
        /// </summary>
        /// <remarks>
        /// Note: creating a project is less useful than creating a solution with the project
        /// (since you can then open the solution in Visual Studio and see the created project more easily).
        /// </remarks>
        public async Task Create_Project_InDirectory()
        {
            /// Inputs.
            var projectDirectoryPath =
                //""
                //.ToProjectDirectoryPath()
                Instances.ExampleProjectDirectoryPaths.Test_Project
                ;
            var projectName =
                //""
                //.ToProjectName()
                Instances.ExampleProjectNames.Test_Project
                ;
            var projectDescription = "Test project.".ToProjectDescription();
            var repositoryUrl = new IsSet<IRepositoryUrl>();


            /// Run.
            var projectNamespaceName = projectName.Value.ToNamespaceName();

            var (humanOutputTextFilePath, logFilePath) = await Instances.ApplicationContextOperator.In_ApplicationContext(
                Instances.Values.ApplicationName,
                ApplicationContextOperation
            );

            async Task ApplicationContextOperation(
                IApplicationContext applicationContext)
            {
                await Instances.ProjectContextOperator.In_ProjectContext(
                    projectDirectoryPath,
                    projectName,
                    applicationContext.TextOutput,
                    ProjectOperation);
            }

            async Task ProjectOperation(
                IProjectContext projectContext)
            {
                await projectContext.Run(
                    Instances.ProjectContextOperations.In_New_ProjectFileContext(
                        ProjectFileContextOperation),
                    ConsoleProjectCreationOperation
                );
            }

            Task ProjectFileContextOperation(
                IProjectFileContext projectFileContext)
            {
                projectFileContext.Run(
                    Instances.ProjectElementContextOperations.Set_SDK_Default,
                    Instances.ProjectElementContextOperations.Set_TargetFramework_Console,
                    Instances.ProjectElementContextOperations.Set_OutputType_Exe,
                    Instances.ProjectElementContextOperations.Combine(
                        Instances.ProjectElementContextOperations.Set_Version_Default,
                        Instances.ProjectElementContextOperations.Set_Author_DCoats,
                        Instances.ProjectElementContextOperations.Set_Company_Rivet,
                        Instances.ProjectElementContextOperations.Set_Copyright_Rivet,
                        Instances.ProjectElementContextOperations.Set_Description(
                            projectDescription.Value),
                        Instances.ProjectElementContextOperations.Set_PackageLicenseExpression_MIT,
                        Instances.ProjectElementContextOperations.Set_PackageRequireLicenseAcceptance,
                        Instances.ProjectElementContextOperations.Set_RepositoryUrl(
                            repositoryUrl)
                    )
                );

                return Task.CompletedTask;
            }

            Task ConsoleProjectCreationOperation(
                IProjectContext projectContext)
            {
                return projectContext.Run(
                    Instances.ProjectContextOperations_FileGeneration.Create_ProjectPlanFile(
                        projectDescription),
                    Instances.ProjectContextOperations_FileGeneration.Create_InstancesFile(
                        projectNamespaceName),
                    Instances.ProjectContextOperations_FileGeneration.Create_DocumentationFile(
                        projectDescription,
                        projectNamespaceName),
                    Create_ProgramFile
                );

                Task Create_ProgramFile(
                    IProjectContext _)
                {
                    var programFilePath = Instances.ProjectPathsOperator.GetProgramFilePath(
                        projectContext.ProjectFilePath.Value);

                    Instances.CodeFileGenerator.CreateProgramFile(
                        programFilePath,
                        projectNamespaceName.Value);

                    return Task.CompletedTask;
                }
            }

            Instances.WindowsExplorerOperator.Open(
                projectDirectoryPath);
        }

        /// <summary>
        /// Create a solution in an existing repository.
        /// </summary>
        /// <returns></returns>
        public async Task Create_Solution_InExistingRepository()
        {
            /// Inputs.
            var repositoryDirectoryPath = @"C:\Code\DEV\Git\GitHub\SafetyCone\R5T.L0037".ToRepositoryDirectoryPath();
            var repositoryName = "R5T.L0037".ToRepositoryName();
            var solutionName = "R5T.L0037.Q000".ToSolutionName();
            var projectDescription = "Explorations, experiments, and demonstrations from the R5T.L0037 code generation library.".ToProjectDescription();


            /// Run.
            var projectName = Instances.ProjectNameOperator.Get_DefaultProjectName(solutionName);
            var projectNamespaceName = projectName.Value.ToNamespaceName();

            LibraryRepositoryCreationOutput libraryRepositoryCreationOutput = new();

            var (humanOutputTextFilePath, logFilePath) = await Instances.ApplicationContextOperator.In_ApplicationContext(
                Instances.Values.ApplicationName,
                ApplicationContextOperation
            );

            async Task ApplicationContextOperation(
                IApplicationContext applicationContext)
            {
#pragma warning disable CS0618 // Type or member is obsolete
                await Instances.LocalRepositoryContextOperator.In_LocalRepositoryContext(
                    repositoryName,
                    repositoryDirectoryPath,
                    applicationContext.TextOutput,
                    repositoryContext => LocalRepositoryContextOperation(
                        repositoryContext));
#pragma warning restore CS0618 // Type or member is obsolete
            }

            async Task LocalRepositoryContextOperation(
                ILocalGitRepositoryContext localRepositoryContext)
            {
                IRepositoryUrl repositoryUrl = await Instances.LocalRepositoryContextOperations.Get_RepositoryUrl(localRepositoryContext);

                await localRepositoryContext.Run(
                    Instances.LocalGitRepositoryContextOperations.In_CommitContext(
                        Instances.CommitMessages.InitialCommit,
                        Instances.LocalGitRepositoryContextOperations.Add_GitIgnoreFile,
                        Instances.LocalRepositoryContextOperations.In_NewSolutionContext(
                            solutionName,
                            solutionContext => SolutionContextOperation(
                                solutionContext,
                                repositoryUrl))
                    )
                );
            }

            async Task SolutionContextOperation(
                ISolutionContext solutionContext,
                IRepositoryUrl repositoryUrl)
            {
                await solutionContext.Run(
                    Instances.SolutionContextOperations.Set_SolutionFilePath(libraryRepositoryCreationOutput),
                    Instances.SolutionContextOperations.In_New_ProjectContext(
                        projectName,
                        projectContext => LibraryProjectOperation(
                            projectContext,
                            solutionContext,
                            repositoryUrl)
                    )
                );
            }

            async Task LibraryProjectOperation(
                IProjectContext projectContext,
                ISolutionContext solutionContext,
                IRepositoryUrl repositoryUrl)
            {
                libraryRepositoryCreationOutput.LibraryProjectFilePath = projectContext.ProjectFilePath;

                await projectContext.Run(
                    Instances.ProjectContextOperations.In_New_ProjectFileContext(
                        projectFileContext => ProjectFileContextOperation(
                            projectFileContext,
                            solutionContext,
                            repositoryUrl)),
                    ConsoleProjectCreationOperation,
                    Instances.ProjectContextOperations.Add_ToSolution(
                        solutionContext.SolutionFilePath)
                );
            }

            Task ProjectFileContextOperation(
                IProjectFileContext projectFileContext,
                ISolutionContext solutionContext,
                IRepositoryUrl repositoryUrl)
            {
                projectFileContext.Run(
                    Instances.ProjectElementContextOperations.Set_SDK_Default,
                    Instances.ProjectElementContextOperations.Set_TargetFramework_Console,
                    Instances.ProjectElementContextOperations.Set_OutputType_Exe,
                    Instances.ProjectElementContextOperations.Combine(
                        Instances.ProjectElementContextOperations.Set_Version_Default,
                        Instances.ProjectElementContextOperations.Set_Author_DCoats,
                        Instances.ProjectElementContextOperations.Set_Company_Rivet,
                        Instances.ProjectElementContextOperations.Set_Copyright_Rivet,
                        Instances.ProjectElementContextOperations.Set_Description(
                            projectDescription.Value),
                        Instances.ProjectElementContextOperations.Set_PackageLicenseExpression_MIT,
                        Instances.ProjectElementContextOperations.Set_PackageRequireLicenseAcceptance,
                        Instances.ProjectElementContextOperations.Set_RepositoryUrl_Value(
                            repositoryUrl)
                    )
                );

                return Task.CompletedTask;
            }

            Task ConsoleProjectCreationOperation(
                IProjectContext projectContext)
            {
                return projectContext.Run(
                    Instances.ProjectContextOperations_FileGeneration.Create_ProjectPlanFile(
                        projectDescription),
                    Instances.ProjectContextOperations_FileGeneration.Create_InstancesFile(
                        projectNamespaceName),
                    Instances.ProjectContextOperations_FileGeneration.Create_DocumentationFile(
                        projectDescription,
                        projectNamespaceName),
                    Create_ProgramFile
                );

                Task Create_ProgramFile(
                    IProjectContext _)
                {
                    var programFilePath = Instances.ProjectPathsOperator.GetProgramFilePath(
                        projectContext.ProjectFilePath.Value);

                    Instances.CodeFileGenerator.CreateProgramFile(
                        programFilePath,
                        projectNamespaceName.Value);

                    return Task.CompletedTask;
                }
            }

            Instances.VisualStudioOperator.OpenSolutionFile(
                libraryRepositoryCreationOutput.SolutionFilePath.Value);

            Instances.NotepadPlusPlusOperator.Open(
                humanOutputTextFilePath);
        }

        /// <summary>
        /// Creates a new repository, with a solution, with a project, with a program code file.
        /// </summary>
        /// <remarks>
        /// This implementation chunks operations.
        /// </remarks>
        public async Task Create_Repository_Console_Chunked()
        {
            /// Inputs.
            var repositoryName = Instances.RepositoryNames.Test;
            var ownerName = Instances.OwnerNames.SafetyCone;
            var description = Instances.RepositoryDescriptions.ForTest;


            /// Run.
            var solutionName = repositoryName.Value.ToSolutionName();
            var projectName = repositoryName.Value.ToProjectName();
            var projectDescription = description.Value.ToProjectDescription();
            var projectNamespaceName = projectName.Value.ToNamespaceName();

            ConsoleRepositoryCreationOutput consoleRepositoryCreationOutput = new();

            var (humanOutputTextFilePath, logFilePath) = await Instances.ApplicationContextOperator.In_ApplicationContext(
                Instances.Values.ApplicationName,
                ApplicationContextOperation
            );

            async Task ApplicationContextOperation(
                IApplicationContext applicationContext)
            {
                await Instances.RepositoryContextOperator.In_RepositoryContext(
                    repositoryName,
                    ownerName,
                    applicationContext.TextOutput,
                    repositoryContext => RepositoryContextOperation(
                        repositoryContext,
                        applicationContext));
            }

            async Task RepositoryContextOperation(
                IRepositoryContext repositoryContext,
                IApplicationContext applicationContext)
            {
                await repositoryContext.Run(
                    Instances.RepositoryContextOperations.In_CreateRepositoryContext(
                        Instances.RepositoryContextOperations.Verify_DoesNotAlreadyExist(
                            repositoryContext.OwnerName
                        ),
                        Instances.RepositoryContextOperations.In_GitHubRepositoryContext(
                            gitHubrepositoryContext => GitHubRepositoryOperation(
                                gitHubrepositoryContext,
                                applicationContext)),
                        Instances.RepositoryContextOperations.In_LocalGitRepositoryContext(
                            repositoryName,
                            ownerName,
                            LocalGitRepositoryContextOperation)
                    )
                );
            }

            async Task GitHubRepositoryOperation(
                IGitHubRepositoryContext gitHubRepositoryContext,
                IApplicationContext applicationContext)
            {
                await gitHubRepositoryContext.Run(
                    Instances.GitHubRepositoryContextOperations.Create_RemoteRepository(description),
                    Instances.GitHubRepositoryContextOperations.Clone_Repository(
                        localDirectoryPath => applicationContext.TextOutput.WriteInformation($"Cloned to local directory: {localDirectoryPath}.")
                    )
                );
            }

            async Task LocalGitRepositoryContextOperation(
                ILocalGitRepositoryContext localRepositoryContext)
            {
                IRepositoryUrl repositoryUrl = await Instances.LocalRepositoryContextOperations.Get_RepositoryUrl(localRepositoryContext);

                await localRepositoryContext.Run(
                    Instances.LocalGitRepositoryContextOperations.In_CommitContext(
                        Instances.CommitMessages.InitialCommit,
                        Instances.LocalGitRepositoryContextOperations.Add_GitIgnoreFile,
                        Instances.LocalRepositoryContextOperations.In_NewSolutionContext(
                            solutionName,
                            solutionContext => SolutionContextOperation(
                                solutionContext,
                                repositoryUrl))
                    )
                );
            }

            async Task SolutionContextOperation(
                ISolutionContext solutionContext,
                IRepositoryUrl repositoryUrl)
            {
                await solutionContext.Run(
                    Instances.SolutionContextOperations.Set_SolutionFilePath(consoleRepositoryCreationOutput),
                    Instances.SolutionContextOperations.In_New_ProjectContext(
                        projectName,
                        projectContext => ConsoleProjectOperation(
                            projectContext,
                            solutionContext,
                            repositoryUrl)
                    )
                );
            }

            async Task ConsoleProjectOperation(
                IProjectContext projectContext,
                ISolutionContext solutionContext,
                IRepositoryUrl repositoryUrl)
            {
                consoleRepositoryCreationOutput.ConsoleProjectFilePath = projectContext.ProjectFilePath;

                await projectContext.Run(
                    Instances.ProjectContextOperations.In_New_ProjectFileContext(
                        projectFileContext => ProjectFileContextOperation(
                            projectFileContext,
                            solutionContext,
                            repositoryUrl)),
                    ConsoleProjectCreationOperation,
                    Instances.ProjectContextOperations.Add_ToSolution(
                        solutionContext.SolutionFilePath)
                );
            }

            Task ProjectFileContextOperation(
                IProjectFileContext projectFileContext,
                ISolutionContext solutionContext,
                IRepositoryUrl repositoryUrl)
            {
                projectFileContext.Run(
                    Instances.ProjectElementContextOperations.Set_SDK_Default,
                    Instances.ProjectElementContextOperations.Set_TargetFramework_Console,
                    Instances.ProjectElementContextOperations.Set_OutputType_Exe,
                    Instances.ProjectElementContextOperations.Combine(
                        Instances.ProjectElementContextOperations.Set_Version_Default,
                        Instances.ProjectElementContextOperations.Set_Author_DCoats,
                        Instances.ProjectElementContextOperations.Set_Company_Rivet,
                        Instances.ProjectElementContextOperations.Set_Copyright_Rivet,
                        Instances.ProjectElementContextOperations.Set_Description(
                            description.Value),
                        Instances.ProjectElementContextOperations.Set_PackageLicenseExpression_MIT,
                        Instances.ProjectElementContextOperations.Set_PackageRequireLicenseAcceptance,
                        Instances.ProjectElementContextOperations.Set_RepositoryUrl_Value(
                            repositoryUrl)
                    )
                );

                return Task.CompletedTask;
            }

            Task ConsoleProjectCreationOperation(
                IProjectContext projectContext)
            {
                return projectContext.Run(
                    Instances.ProjectContextOperations_FileGeneration.Create_ProjectPlanFile(
                        projectDescription),
                    Instances.ProjectContextOperations_FileGeneration.Create_InstancesFile(
                        projectNamespaceName),
                    Instances.ProjectContextOperations_FileGeneration.Create_DocumentationFile(
                        projectDescription,
                        projectNamespaceName),
                    Create_ProgramFile
                );

                Task Create_ProgramFile(
                    IProjectContext _)
                {
                    var programFilePath = Instances.ProjectPathsOperator.GetProgramFilePath(
                        projectContext.ProjectFilePath.Value);

                    Instances.CodeFileGenerator.CreateProgramFile(
                        programFilePath,
                        projectNamespaceName.Value);

                    return Task.CompletedTask;
                }
            }

            Instances.VisualStudioOperator.OpenSolutionFile(
                consoleRepositoryCreationOutput.SolutionFilePath.Value);

            Instances.NotepadPlusPlusOperator.Open(
                humanOutputTextFilePath);
        }

        /// <summary>
        /// Creates a new repository, with a solution, with a project.
        /// Note: there are no code files in the project.
        /// </summary>
        /// <remarks>
        /// This implementation follows the explicit-tree methodology.
        /// </remarks>
        public async Task Create_Repository_Console()
        {
            /// Inputs.
            var repositoryName = Instances.RepositoryNames.Test;
            var ownerName = Instances.OwnerNames.SafetyCone;
            var description = Instances.RepositoryDescriptions.ForTest;


            /// Run.
            var solutionName = repositoryName.Value.ToSolutionName();
            var projectName = repositoryName.Value.ToProjectName();

            ConsoleRepositoryCreationOutput consoleRepositoryCreationOutput = new();

            var (humanOutputTextFilePath, logFilePath) = await Instances.ApplicationContextOperator.In_ApplicationContext(
                Instances.Values.ApplicationName,
                async applicationContext =>
                {
                    await Instances.RepositoryContextOperator.In_RepositoryContext(
                        repositoryName,
                        ownerName,
                        applicationContext.TextOutput,
                        async repositoryContext =>
                        {
                            await repositoryContext.Run(
                                Instances.RepositoryContextOperations.In_CreateRepositoryContext(
                                    Instances.RepositoryContextOperations.Verify_DoesNotAlreadyExist(
                                        repositoryContext.OwnerName
                                    ),
                                    Instances.RepositoryContextOperations.In_GitHubRepositoryContext(
                                        async gitHubRepositoryContext =>
                                        {
                                            await gitHubRepositoryContext.Run(
                                                Instances.GitHubRepositoryContextOperations.Create_RemoteRepository(description),
                                                Instances.GitHubRepositoryContextOperations.Clone_Repository(
                                                    (context, localDirectoryPath) => applicationContext.TextOutput.WriteInformation($"Cloned to local directory: {localDirectoryPath}.")
                                                )
                                            );
                                        }
                                    ),
                                    Instances.RepositoryContextOperations.In_LocalGitRepositoryContext(repositoryName, ownerName,
                                        async localRepositoryContext =>
                                        {
                                            IRepositoryUrl repositoryUrl = await Instances.LocalRepositoryContextOperations.Get_RepositoryUrl(localRepositoryContext);

                                            await localRepositoryContext.Run(
                                                Instances.LocalGitRepositoryContextOperations.In_CommitContext(
                                                    Instances.CommitMessages.InitialCommit,
                                                    Instances.LocalGitRepositoryContextOperations.Add_GitIgnoreFile,
                                                    Instances.LocalRepositoryContextOperations.In_NewSolutionContext(
                                                        solutionName,
                                                        async solutionContext =>
                                                        {
                                                            await solutionContext.Run(
                                                                Instances.SolutionContextOperations.Set_SolutionFilePath(consoleRepositoryCreationOutput),
                                                                Instances.SolutionContextOperations.In_New_ProjectContext(
                                                                    projectName,
                                                                    async projectContext =>
                                                                    {
                                                                        consoleRepositoryCreationOutput.ConsoleProjectFilePath = projectContext.ProjectFilePath;

                                                                        await projectContext.Run(
                                                                            Instances.ProjectContextOperations.In_New_ProjectFileContext(
                                                                                projectFileContext =>
                                                                                {
                                                                                    projectFileContext.Run(
                                                                                        Instances.ProjectElementContextOperations.Set_SDK_Default,
                                                                                        Instances.ProjectElementContextOperations.Add_MainPropertyGroup,
                                                                                        Instances.ProjectElementContextOperations.Set_TargetFramework_Library,
                                                                                        Instances.ProjectElementContextOperations.Combine(
                                                                                            Instances.ProjectElementContextOperations.Set_Version_Default,
                                                                                            Instances.ProjectElementContextOperations.Set_Author_DCoats,
                                                                                            Instances.ProjectElementContextOperations.Set_Company_Rivet,
                                                                                            Instances.ProjectElementContextOperations.Set_Copyright_Rivet,
                                                                                            Instances.ProjectElementContextOperations.Set_Description(description.Value),
                                                                                            Instances.ProjectElementContextOperations.Set_PackageLicenseExpression_MIT,
                                                                                            Instances.ProjectElementContextOperations.Set_PackageRequireLicenseAcceptance,
                                                                                            Instances.ProjectElementContextOperations.Set_RepositoryUrl_Value(repositoryUrl)
                                                                                        )
                                                                                    );

                                                                                    return Task.CompletedTask;
                                                                                }
                                                                            ),
                                                                            Instances.ProjectContextOperations.Add_ToSolution(solutionContext.SolutionFilePath)
                                                                        );
                                                                    }
                                                                )
                                                            );
                                                        }
                                                    )
                                                )
                                            );
                                        }
                                    )
                                )
                            );
                        }
                    );
                }
            );

            Instances.VisualStudioOperator.OpenSolutionFile(
                consoleRepositoryCreationOutput.SolutionFilePath.Value);

            var solutionDirectoryPath = consoleRepositoryCreationOutput.SolutionFilePath.Get_DirectoryPath();
            
            Instances.WindowsExplorerOperator.Open(
                solutionDirectoryPath);

            Instances.NotepadPlusPlusOperator.Open(humanOutputTextFilePath);
        }

        public async Task Create_Repository_WithGitIgnore()
        {
            /// Inputs.
            var repositoryName = Instances.RepositoryNames.Test;
            var ownerName = Instances.OwnerNames.SafetyCone;
            var description = Instances.RepositoryDescriptions.ForTest;


            /// Run.
            var (humanOutputTextFilePath, logFilePath) = await Instances.ApplicationContextOperator.In_ApplicationContext(
                Instances.Values.ApplicationName,
                async applicationContext =>
                {
                    await Instances.RepositoryContextOperator.In_RepositoryContext(
                        repositoryName,
                        ownerName,
                        applicationContext.TextOutput,
                        Instances.RepositoryContextOperations.In_CreateRepositoryContext(
                            Instances.RepositoryContextOperations.In_GitHubRepositoryContext(
                                Instances.GitHubRepositoryContextOperations.Verify_RepositoryDoesNotExist,
                                Instances.GitHubRepositoryContextOperations.Create_RemoteRepository(description),
                                Instances.GitHubRepositoryContextOperations.Clone_Repository(
                                    (context, localDirectoryPath) => applicationContext.TextOutput.WriteInformation($"Cloned to local directory: {localDirectoryPath}."))
                            ),
                            Instances.RepositoryContextOperations.In_LocalGitRepositoryContext(repositoryName, ownerName,
                                Instances.LocalGitRepositoryContextOperations.In_CommitContext(
                                    Instances.CommitMessages.InitialCommit,
                                    Instances.LocalGitRepositoryContextOperations.Add_GitIgnoreFile))));
                });

            Instances.NotepadPlusPlusOperator.Open(humanOutputTextFilePath);
        }

        public async Task Delete_Repository()
        {
            /// Inputs.
            var repositoryName =
                T0186.Extensions.StringExtensions.ToRepositoryName("R5T.F0144")
                //Instances.RepositoryNames.Test
                ;
            var ownerName =
                Instances.OwnerNames.SafetyCone
                ;


            /// Run.
            var textOutput = Instances.TextOutputOperator.Get_TextOutput(
                @"C:\Temp\Human Output.txt",
                nameof(Delete_Repository),
                @"C:\Temp\Log.txt");

            await Instances.RepositoryContextOperator.In_RepositoryContext(
                repositoryName,
                ownerName,
                textOutput,
                Instances.RepositoryContextOperations.In_GitHubRepositoryContext(
                    Instances.GitHubRepositoryContextOperations.Delete_Repository
                ),
                Instances.RepositoryContextOperations.In_LocalGitRepositoryContext(repositoryName, ownerName,
                    Instances.LocalGitRepositoryContextOperations.Delete_Repository
                ));
        }

        public async Task Create_Repository()
        {
            /// Inputs.
            var repositoryName = Instances.RepositoryNames.Test;
            var ownerName = Instances.OwnerNames.SafetyCone;
            var description = Instances.RepositoryDescriptions.ForTest;


            /// Run.
            await Instances.RepositoryContextOperator.In_RepositoryContext(
                repositoryName,
                ownerName,
                Instances.TextOutputOperator.Get_New_Null(),
                Instances.RepositoryContextOperations.In_GitHubRepositoryContext(
                    Instances.GitHubRepositoryContextOperations.Verify_RepositoryDoesNotExist,
                    Instances.GitHubRepositoryContextOperations.Create_RemoteRepository(description),
                    Instances.GitHubRepositoryContextOperations.Clone_Repository(
                        (context, localDirectoryPath) => Console.WriteLine(localDirectoryPath))
                ));
        }

        public async Task Delete_RemoteRepository_Only()
        {
            /// Inputs.
            var repositoryName = Instances.RepositoryNames.Test;
            var ownerName = Instances.OwnerNames.SafetyCone;


            /// Run.
            await Instances.RepositoryContextOperator.In_RepositoryContext(
                repositoryName,
                ownerName,
                Instances.TextOutputOperator.Get_New_Null(),
                Instances.RepositoryContextOperations.In_GitHubRepositoryContext(
                    Instances.GitHubRepositoryContextOperations.Delete_Repository
                ));
        }

        public async Task Create_RemoteRepository_Only()
        {
            /// Inputs.
            var repositoryName = Instances.RepositoryNames.Test;
            var ownerName = Instances.OwnerNames.SafetyCone;
            var description = Instances.RepositoryDescriptions.ForTest;


            /// Run.
            await Instances.RepositoryContextOperator.In_RepositoryContext(
                repositoryName,
                ownerName,
                Instances.TextOutputOperator.Get_New_Null(),
                Instances.RepositoryContextOperations.In_GitHubRepositoryContext(
                    Instances.GitHubRepositoryContextOperations.Verify_RepositoryDoesNotExist,
                    Instances.GitHubRepositoryContextOperations.Create_RemoteRepository(description)
                ));
        }

        public async Task Check_GitHubRepository_Exists()
        {
            /// Inputs.
            var repositoryName = Instances.RepositoryNames.Test;
            var ownerName = Instances.OwnerNames.SafetyCone;


            /// Run.
            await Instances.RepositoryContextOperator.In_RepositoryContext(
                repositoryName,
                ownerName,
                Instances.TextOutputOperator.Get_New_Null(),
                //async context =>
                //{
                //    var exists = await F0041.GitHubOperator.Instance.RepositoryExists(
                //        ownerName.Value,
                //        repositoryName.Value);

                //    var existsDescription = exists
                //        ? "exists"
                //        : "does not exist"
                //        ;

                //    Console.WriteLine($"GitHub {ownerName.Value}/{repositoryName.Value}: {existsDescription}");
                //}
                Instances.RepositoryContextOperations.In_GitHubRepositoryContext(
                    //new Func<L0036.N001.IGitHubRepositoryContext, Task>[]
                    //{
                    //    //async context =>
                    //    //{
                    //    //    var exists = await F0041.GitHubOperator.Instance.RepositoryExists(
                    //    //        context.OwnerName.Value,
                    //    //        context.RepositoryName.Value);

                    //    //    var existsDescription = exists
                    //    //        ? "exists"
                    //    //        : "does not exist"
                    //    //        ;

                    //    //    Console.WriteLine($"GitHub {ownerName.Value}/{repositoryName.Value}: {existsDescription}");
                    //    //}
                    //    Instances.GitHubRepositoryContextOperations.Check_RepositoryExists(
                    //        //exists =>
                    //        //{
                    //        //    var existsDescription = exists
                    //        //        ? "exists"
                    //        //        : "does not exist"
                    //        //        ;

                    //        //    Console.WriteLine($"GitHub {ownerName.Value}/{repositoryName.Value}: {existsDescription}");
                    //        //}
                    //        Instances.Operations.Write_GitHubRepositoryExists_ToConsole
                    //    )
                    //}
                    Instances.GitHubRepositoryContextOperations.Check_RepositoryExists(
                        Instances.Operations.Write_GitHubRepositoryExists_ToConsole)
                )
                );
        }
    }
}
