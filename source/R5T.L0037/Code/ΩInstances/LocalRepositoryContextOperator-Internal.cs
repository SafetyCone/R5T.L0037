using System;


namespace R5T.L0037.Internal
{
    public class LocalRepositoryContextOperator : ILocalRepositoryContextOperator
    {
        #region Infrastructure

        public static ILocalRepositoryContextOperator Instance { get; } = new LocalRepositoryContextOperator();


        private LocalRepositoryContextOperator()
        {
        }

        #endregion
    }
}
