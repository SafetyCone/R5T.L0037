using System;

using R5T.T0131;
using R5T.T0186;


namespace R5T.L0037.Construction
{
    [ValuesMarker]
    public partial interface IOperations : IValuesMarker
    {
        public Action<L0036.T000.N001.IGitHubRepositoryContext, bool> Write_GitHubRepositoryExists_ToConsole =>
            (context, exists) => Instances.Operator.Write_GitHubRepositoryExists_ToConsole(
                context.RepositoryName,
                context.OwnerName,
                exists);
    }
}
