using System;


namespace R5T.L0037
{
    public class ProjectFileReferenceSets : IProjectFileReferenceSets
    {
        #region Infrastructure

        public static IProjectFileReferenceSets Instance { get; } = new ProjectFileReferenceSets();


        private ProjectFileReferenceSets()
        {
        }

        #endregion
    }
}
