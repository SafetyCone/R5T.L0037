using System;
using System.Threading.Tasks;

using R5T.T0132;
using R5T.T0172;
using R5T.T0172.Extensions;
using R5T.T0187;


namespace R5T.L0037.Internal
{
    [FunctionalityMarker]
    public partial interface ISolutionContextOperator : IFunctionalityMarker
    {
        public Task Create_SolutionFile_N001(N001.ISolutionContext solutionContext)
        {
            var solutionFileName = Instances.SolutionFileNameOperator.GetSolutionFileName_FromSolutionName(
                solutionContext.SolutionName.Value);

            var solutionFilePath = Instances.PathOperator.Combine(
                solutionContext.DirectoryPath.Value,
                solutionFileName);

            Instances.SolutionFileGenerator.Create_New(
                solutionFilePath);

            return Task.CompletedTask;
        }

        public Task Create_SolutionFile(ISolutionContext solutionContext)
        {
            Instances.SolutionFileGenerator.Create_New(
                solutionContext.SolutionFilePath.Value);

            return Task.CompletedTask;
        }

        /// <summary>
        /// Creates the project context, but not the project file.
        /// </summary>
        public Task In_CreateProjectContext(
            ISolutionContext solutionContext,
            IProjectName projectName,
            params Func<IProjectContext, Task>[] operations)
        {
            var projectFilePath = Instances.ProjectPathsOperator.GetProjectFilePath_FromSolutionDirectoryPath(
                Instances.PathOperator.GetParentDirectoryPath_ForFile(solutionContext.SolutionFilePath.Value),
                projectName.Value)
                .ToProjectFilePath();

            var projectContext = new ProjectContext
            {
                ProjectName = projectName,
                ProjectFilePath = projectFilePath,
            };

            return Instances.ActionOperator.Run(
                projectContext,
                operations);
        }

        public Task Set_SolutionDirectoryPath(
            ISolutionContext context,
            IHasSolutionDirectoryPath hasSolutionDirectoryPath)
        {
            var solutionDirectoryPath = Instances.PathOperator.GetParentDirectoryPath_ForFile(
                context.SolutionFilePath.Value)
                .ToSolutionDirectoryPath();

            hasSolutionDirectoryPath.SolutionDirectoryPath = solutionDirectoryPath;

            return Task.CompletedTask;
        }

        public Task Set_SolutionFilePath(
            ISolutionContext context,
            IHasSolutionFilePath hasSolutionFilePath)
        {
            hasSolutionFilePath.SolutionFilePath = context.SolutionFilePath;

            return Task.CompletedTask;
        }
    }
}
