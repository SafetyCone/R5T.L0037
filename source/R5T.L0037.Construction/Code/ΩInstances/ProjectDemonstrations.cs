using System;


namespace R5T.L0037.Construction
{
    public class ProjectDemonstrations : IProjectDemonstrations
    {
        #region Infrastructure

        public static IProjectDemonstrations Instance { get; } = new ProjectDemonstrations();


        private ProjectDemonstrations()
        {
        }

        #endregion
    }
}
