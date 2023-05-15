using System;


namespace R5T.L0037.Construction
{
    public class ExampleSolutionNames : IExampleSolutionNames
    {
        #region Infrastructure

        public static IExampleSolutionNames Instance { get; } = new ExampleSolutionNames();


        private ExampleSolutionNames()
        {
        }

        #endregion
    }
}
