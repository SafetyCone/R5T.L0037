using System;
using System.Threading.Tasks;

using R5T.F0124.Extensions;
using R5T.L0031.Extensions;
using R5T.L0032.T000;
using R5T.L0032.T000.Extensions;
using R5T.L0033;
using R5T.L0036.N001;
using R5T.L0037.N001;
using R5T.L0038;
using R5T.T0141;
using R5T.T0161.Extensions;
using R5T.T0172;
using R5T.T0172.Extensions;
using R5T.T0187.Extensions;


namespace R5T.L0037.Construction
{
    [DemonstrationsMarker]
    public partial interface IDemonstrations : IDemonstrationsMarker
    {
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
                        Instances.RepositoryContextOperations.Verify_DoesNotAlreadyExist,
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
                    Instances.SolutionContextOperations.In_CreateProjectContext(
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
                    Instances.ProjectContextOperations.Create_ProjectPlanFile(
                        projectName,
                        projectDescription),
                    Instances.ProjectContextOperations.Create_InstancesFile(
                        projectNamespaceName),
                    Instances.ProjectContextOperations.Create_DocumentationFile(
                        projectNamespaceName,
                        projectDescription),
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
                                    Instances.RepositoryContextOperations.Verify_DoesNotAlreadyExist,
                                    Instances.RepositoryContextOperations.In_GitHubRepositoryContext(
                                        async gitHubRepositoryContext =>
                                        {
                                            await gitHubRepositoryContext.Run(
                                                Instances.GitHubRepositoryContextOperations.Create_RemoteRepository(description),
                                                Instances.GitHubRepositoryContextOperations.Clone_Repository_ProvideContext(
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
                                                                Instances.SolutionContextOperations.In_CreateProjectContext(
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

            Instances.WindowsExplorerOperator.OpenDirectoryInExplorer(
                consoleRepositoryCreationOutput.SolutionFilePath.Get_DirectoryPath().Value);

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
                                Instances.GitHubRepositoryContextOperations.Verify_RepositoryDoesNotExist_N001,
                                Instances.GitHubRepositoryContextOperations.Create_RemoteRepository(description),
                                Instances.GitHubRepositoryContextOperations.Clone_Repository_ProvideContext(
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
            var repositoryName = Instances.RepositoryNames.Test;
            var ownerName = Instances.OwnerNames.SafetyCone;


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
                    Instances.GitHubRepositoryContextOperations.Verify_RepositoryDoesNotExist_N001,
                    Instances.GitHubRepositoryContextOperations.Create_RemoteRepository(description),
                    Instances.GitHubRepositoryContextOperations.Clone_Repository_ProvideContext(
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
                    Instances.GitHubRepositoryContextOperations.Verify_RepositoryDoesNotExist_N001,
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
