using System;


namespace R5T.L0037
{
    public class ProjectNamespaceNamesOperator : IProjectNamespaceNamesOperator
    {
        #region Infrastructure

        public static IProjectNamespaceNamesOperator Instance { get; } = new ProjectNamespaceNamesOperator();


        private ProjectNamespaceNamesOperator()
        {
        }

        #endregion
    }
}
