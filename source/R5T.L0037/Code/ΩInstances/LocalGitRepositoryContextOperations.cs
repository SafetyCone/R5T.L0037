using System;


namespace R5T.L0037
{
    public class LocalGitRepositoryContextOperations : ILocalGitRepositoryContextOperations
    {
        #region Infrastructure

        public static ILocalGitRepositoryContextOperations Instance { get; } = new LocalGitRepositoryContextOperations();


        private LocalGitRepositoryContextOperations()
        {
        }

        #endregion
    }
}
