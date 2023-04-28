using System;


namespace R5T.L0037.Internal
{
    public class ProjectContextOperator : IProjectContextOperator
    {
        #region Infrastructure

        public static IProjectContextOperator Instance { get; } = new ProjectContextOperator();


        private ProjectContextOperator()
        {
        }

        #endregion
    }
}
