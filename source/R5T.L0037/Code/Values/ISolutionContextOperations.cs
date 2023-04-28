using System;
using System.Threading.Tasks;

using R5T.T0131;
using R5T.T0172;
using R5T.T0187;


namespace R5T.L0037
{
    [ValuesMarker]
    public partial interface ISolutionContextOperations : IValuesMarker
    {
        public Func<N001.ISolutionContext, Task> Create_SolutionFile_N001 =>
            context => Instances.SolutionContextOperator_Internal.Create_SolutionFile_N001(context);

        public Func<ISolutionContext, Task> Create_SolutionFile =>
            context => Instances.SolutionContextOperator_Internal.Create_SolutionFile(context);

        public Func<IHasSolutionDirectoryPath, Func<ISolutionContext, Task>> Set_SolutionDirectoryPath =>
            hasSolutionDirectoryPath =>
                context => Instances.SolutionContextOperator_Internal.Set_SolutionDirectoryPath(context, hasSolutionDirectoryPath);

        public Func<IHasSolutionFilePath, Func<ISolutionContext, Task>> Set_SolutionFilePath =>
            hasSolutionFilePath =>
                context => Instances.SolutionContextOperator_Internal.Set_SolutionFilePath(context, hasSolutionFilePath);

        public delegate Func<ISolutionContext, Task> In_CreateProjectContext_Params(
            IProjectName projectName,
            params Func<IProjectContext, Task>[] operations);

        /// <inheritdoc cref="Internal.ISolutionContextOperator.In_CreateProjectContext(ISolutionContext, IProjectName, Func{IProjectContext, Task}[])"/>
        public In_CreateProjectContext_Params In_CreateProjectContext =>
            (projectName, operations) =>
                context => Instances.SolutionContextOperator_Internal.In_CreateProjectContext(
                    context,
                    projectName,
                    operations);
    }
}
