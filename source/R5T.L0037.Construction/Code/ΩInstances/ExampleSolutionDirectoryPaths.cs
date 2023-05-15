using System;


namespace R5T.L0037.Construction
{
    public class ExampleSolutionDirectoryPaths : IExampleSolutionDirectoryPaths
    {
        #region Infrastructure

        public static IExampleSolutionDirectoryPaths Instance { get; } = new ExampleSolutionDirectoryPaths();


        private ExampleSolutionDirectoryPaths()
        {
        }

        #endregion
    }
}
