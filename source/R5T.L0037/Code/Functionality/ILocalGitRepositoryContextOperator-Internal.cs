using System;
using System.Threading.Tasks;

using R5T.T0132;
using R5T.T0188;


namespace R5T.L0037.Internal
{
    [FunctionalityMarker]
    public partial interface ILocalGitRepositoryContextOperator : IFunctionalityMarker
    {
        public Task Add_GitIgnoreFile(ILocalGitRepositoryContext context)
        {
            Instances.RepositoryFilesOperator.Set_GitIgnoreFile(
                context.DirectoryPath.Value);

            return Task.CompletedTask;
        }

        public Task Delete_LocalDirectory(ILocalGitRepositoryContext context)
        {
            Instances.LocalRepositoryOperator.Delete(
                context.DirectoryPath.Value);

            return Task.CompletedTask;
        }

        public async Task In_CommitContext<TLocalGitHubRepsitoryContext>(
            TLocalGitHubRepsitoryContext context,
            ICommitMessage commitMessage,
            params Func<TLocalGitHubRepsitoryContext, Task>[] operations)
            where TLocalGitHubRepsitoryContext : ILocalGitRepositoryContext
        {
            await Instances.ActionOperator.Run(
                context,
                operations);

            Instances.GitHubOperator.PushAllChanges(
                context.DirectoryPath.Value,
                commitMessage.Value,
                Instances.LoggingOperator.GetNullLogger());
        }

        
    }
}
