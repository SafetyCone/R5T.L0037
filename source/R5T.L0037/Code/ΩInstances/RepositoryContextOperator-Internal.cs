using System;


namespace R5T.L0037.Internal
{
    public class RepositoryContextOperator : IRepositoryContextOperator
    {
        #region Infrastructure

        public static IRepositoryContextOperator Instance { get; } = new RepositoryContextOperator();


        private RepositoryContextOperator()
        {
        }

        #endregion
    }
}
