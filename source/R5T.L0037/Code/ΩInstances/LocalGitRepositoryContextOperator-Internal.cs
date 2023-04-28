using System;


namespace R5T.L0037.Internal
{
    public class LocalGitRepositoryContextOperator : ILocalGitRepositoryContextOperator
    {
        #region Infrastructure

        public static ILocalGitRepositoryContextOperator Instance { get; } = new LocalGitRepositoryContextOperator();


        private LocalGitRepositoryContextOperator()
        {
        }

        #endregion
    }
}
