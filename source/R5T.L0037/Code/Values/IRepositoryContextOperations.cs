using System;
using System.Threading.Tasks;

using R5T.T0131;
using R5T.T0159;
using R5T.T0186;
using R5T.T0186.Extensions;


namespace R5T.L0037
{
    [ValuesMarker]
    public partial interface IRepositoryContextOperations : IValuesMarker
    {
        public delegate Func<IRepositoryContext, Task> In_GitHubRepositoryContext_Params00(
            IGitHubRepositoryName repositoryName,
            IGitHubRepositoryOwnerName ownerName,
            params Func<L0036.N001.IGitHubRepositoryContext, Task>[] operations);

        //public Func<
        //    IGitHubRepositoryName,
        //    IGitHubRepositoryOwnerName,
        //    Func<L0036.N001.IGitHubRepositoryContext, Task>[],
        //    Func<IRepositoryContext, Task>>
        public In_GitHubRepositoryContext_Params00 In_GitHubRepositoryContext_00 =>
            (repositoryName, ownerName, operations) =>
                context => Instances.GitHubRepositoryContextOperator.In_GitHubRepositoryContext(
                    repositoryName,
                    ownerName,
                    context.TextOutput,
                    operations);

        public delegate Func<IRepositoryContext, Task> In_GitHubRepositoryContext_Params01(
            params Func<L0036.N001.IGitHubRepositoryContext, Task>[] operations);

        public In_GitHubRepositoryContext_Params01 In_GitHubRepositoryContext =>
            operations =>
                context => Instances.GitHubRepositoryContextOperator.In_GitHubRepositoryContext(
                    context.RepositoryName.Value.ToGitHubRepositoryName(),
                    context.OwnerName.Value.ToGitHubRepositoryOwnerName(),
                    context.TextOutput,
                    operations);

        public delegate Func<IRepositoryContext, Task> In_LocalGitRepositoryContext_Params(
            IGitHubRepositoryName repositoryName,
            IGitHubRepositoryOwnerName ownerName,
            params Func<ILocalGitRepositoryContext, Task>[] operations);

        public In_LocalGitRepositoryContext_Params In_LocalGitRepositoryContext =>
            (repositoryName, ownerName, operations) =>
                context => Instances.LocalGitRepositoryContextOperator.In_LocalGitRepositoryContext(
                    repositoryName,
                    ownerName,
                    operations);

        public delegate Func<IRepositoryContext, Task> In_CreateRepositoryContext_Params(
            params Func<IRepositoryContext, Task>[] operations);

        /// <inheritdoc cref="Internal.IRepositoryContextOperator.In_CreateRepositoryContext(IRepositoryContext, Func{IRepositoryContext, Task}[])"/>
        public In_CreateRepositoryContext_Params In_CreateRepositoryContext =>
            operations =>
                context => Instances.RepositoryContextOperator_Internal.In_CreateRepositoryContext(
                    context,
                    operations);

        /// <inheritdoc cref="Internal.IRepositoryContextOperator.Verify_DoesNotAlreadyExist(IRepositoryContext)"/>
        public Func<IRepositoryContext, Task> Verify_DoesNotAlreadyExist =>
            context => Instances.RepositoryContextOperator_Internal.Verify_DoesNotAlreadyExist(context);
    }
}
