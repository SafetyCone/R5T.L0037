using System;


namespace R5T.L0037
{
    public class LocalRepositoryContextOperations : ILocalRepositoryContextOperations
    {
        #region Infrastructure

        public static ILocalRepositoryContextOperations Instance { get; } = new LocalRepositoryContextOperations();


        private LocalRepositoryContextOperations()
        {
        }

        #endregion
    }
}
