using System;
using System.Linq;
using System.Threading.Tasks;

using R5T.T0132;


namespace R5T.L0037.Internal
{
    [FunctionalityMarker]
    public partial interface IRepositoryContextOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Verifies that a repository name is available on both GitHub and in the local file system.
        /// </summary>
        public async Task Verify_DoesNotAlreadyExist(IRepositoryContext context)
        {
            // GitHub.
            var gettingExistsOnGitHub = Instances.GitHubOperator.RepositoryExists(
                context.OwnerName.Value,
                context.RepositoryName.Value);

            // Local.
            var existsInLocal = Instances.LocalRepositoryOperator.RepositoryExists(
                context.OwnerName.Value,
                context.RepositoryName.Value);

            var existsOnGitHub = await gettingExistsOnGitHub;

            var exists = existsOnGitHub || existsInLocal;
            if (exists)
            {
                throw new Exception($"{context.OwnerName.Value}/{context.RepositoryName.Value}: GitHub repository already exists.");
            }
        }

        /// <summary>
        /// Wraps operations in output messages indicating that a repository is being created.
        /// </summary>
        public Task In_CreateRepositoryContext(
            IRepositoryContext repositoryContext,
            params Func<IRepositoryContext, Task>[] operations)
        {
            return Instances.ActionOperator.Run(
                repositoryContext,
                    operations
                    .Prepend(
                        _ =>
                        {
                            repositoryContext.TextOutput.WriteInformation($"Creating repository {repositoryContext.RepositoryName}...");

                            return Task.CompletedTask;
                        })
                    .Append(
                        _ =>
                        {
                            repositoryContext.TextOutput.WriteInformation($"Created repository {repositoryContext.RepositoryName}.");

                            return Task.CompletedTask;
                        }));
        }
    }
}
