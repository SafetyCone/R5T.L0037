using System;
using System.Threading.Tasks;

using R5T.L0033;
using R5T.L0037.N001;
using R5T.T0131;
using R5T.T0161;
using R5T.T0172;
using R5T.T0187;


namespace R5T.L0037
{
    [ValuesMarker]
    public partial interface IProjectContextOperations : IValuesMarker
    {
        public delegate Func<IProjectContext, Task> In_New_ProjectFileContext_Params(
            params Func<IProjectFileContext, Task>[] operations);

        public In_New_ProjectFileContext_Params In_New_ProjectFileContext =>
            operations =>
                context => Instances.ProjectFileContextOperator.In_New_ProjectFileContext(
                context.ProjectFilePath,
                operations);

        public delegate Func<IProjectContext, Task> In_New_ProjectFileContext_Params_Action(
            params Action<IProjectFileContext>[] operations);

        public In_New_ProjectFileContext_Params_Action In_New_ProjectFileContext_Action =>
            operations =>
                context => Instances.ProjectFileContextOperator.In_New_ProjectFileContext_Task(
                context.ProjectFilePath,
                operations);

        public Func<IProjectContext, Task> Add_ToSolution(ISolutionFilePath solutionFilePath)
        {
            Task Internal(IProjectContext context)
            {
                Instances.SolutionFileOperator.AddProject(
                    solutionFilePath.Value,
                    context.ProjectFilePath.Value);

                return Task.CompletedTask;
            }

            return Internal;
        }

        public Func<IProjectContext, Task> Create_ProjectPlanFile(
            IProjectName projectName,
            IProjectDescription projectDescription)
        {
            return context =>
            {
                var projectPlanFilePath = Instances.ProjectPathsOperator.GetProjectPlanMarkdownFilePath(
                    context.ProjectFilePath.Value);

                Instances.TextFileGenerator.CreateProjectPlanMarkdownFile(
                    projectPlanFilePath,
                    projectName.Value,
                    projectDescription.Value);

                return Task.CompletedTask;
            };
        }

        public Func<IProjectContext, Task> Create_InstancesFile(
            INamespaceName projectNamespaceName)
        {
            return context =>
            {
                var instanceFilePath = Instances.ProjectPathsOperator.GetInstancesFilePath(
                    context.ProjectFilePath.Value);

                Instances.CodeFileGenerator.CreateInstancesFile(
                    instanceFilePath,
                    projectNamespaceName.Value);

                return Task.CompletedTask;
            };
        }

        public Func<IProjectContext, Task> Create_DocumentationFile(
            INamespaceName projectNamespaceName,
            IProjectDescription projectDescription)
        {
            return context =>
            {
                var documentationFilePath = Instances.ProjectPathsOperator.GetDocumentationFilePath(
                    context.ProjectFilePath.Value);

                Instances.CodeFileGenerator.CreateDocumentationFile(
                    documentationFilePath,
                    projectNamespaceName.Value,
                    projectDescription.Value);

                return Task.CompletedTask;
            };
        }
    }
}
