using System;


namespace R5T.L0037
{
    public class RepositoryContextDestructors : IRepositoryContextDestructors
    {
        #region Infrastructure

        public static IRepositoryContextDestructors Instance { get; } = new RepositoryContextDestructors();


        private RepositoryContextDestructors()
        {
        }

        #endregion
    }
}
