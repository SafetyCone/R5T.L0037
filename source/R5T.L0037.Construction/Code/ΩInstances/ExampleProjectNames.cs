using System;


namespace R5T.L0037.Construction
{
    public class ExampleProjectNames : IExampleProjectNames
    {
        #region Infrastructure

        public static IExampleProjectNames Instance { get; } = new ExampleProjectNames();


        private ExampleProjectNames()
        {
        }

        #endregion
    }
}
