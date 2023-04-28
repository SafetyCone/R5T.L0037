using System;


namespace R5T.L0037
{
    public class RepositoryContextConstructors : IRepositoryContextConstructors
    {
        #region Infrastructure

        public static IRepositoryContextConstructors Instance { get; } = new RepositoryContextConstructors();


        private RepositoryContextConstructors()
        {
        }

        #endregion
    }
}
