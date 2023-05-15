using System;


namespace R5T.L0037
{
    public class ProjectDirectoryRelativePaths : IProjectDirectoryRelativePaths
    {
        #region Infrastructure

        public static IProjectDirectoryRelativePaths Instance { get; } = new ProjectDirectoryRelativePaths();


        private ProjectDirectoryRelativePaths()
        {
        }

        #endregion
    }
}
