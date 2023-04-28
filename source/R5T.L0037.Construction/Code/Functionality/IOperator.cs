using System;

using R5T.T0132;
using R5T.T0186;


namespace R5T.L0037.Construction
{
    [FunctionalityMarker]
    public partial interface IOperator : IFunctionalityMarker
    {
        public void Write_GitHubRepositoryExists_ToConsole(
            IGitHubRepositoryName repositoryName,
            IGitHubRepositoryOwnerName ownerName,
            bool exists)
        {
            var existsDescription = exists
                ? "exists"
                : "does not exist"
                ;

            Console.WriteLine($"GitHub {ownerName.Value}/{repositoryName.Value}: {existsDescription}");
        }
    }
}
