using System;


namespace R5T.L0037.Construction
{
    public class Operations : IOperations
    {
        #region Infrastructure

        public static IOperations Instance { get; } = new Operations();


        private Operations()
        {
        }

        #endregion
    }
}
