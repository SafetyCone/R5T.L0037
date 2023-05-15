using System;


namespace R5T.L0037.Construction
{
    public class ExampleProjectDirectoryPaths : IExampleProjectDirectoryPaths
    {
        #region Infrastructure

        public static IExampleProjectDirectoryPaths Instance { get; } = new ExampleProjectDirectoryPaths();


        private ExampleProjectDirectoryPaths()
        {
        }

        #endregion
    }
}
