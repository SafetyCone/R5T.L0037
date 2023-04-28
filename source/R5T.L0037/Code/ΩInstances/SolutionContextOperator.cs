using System;


namespace R5T.L0037
{
    public class SolutionContextOperator : ISolutionContextOperator
    {
        #region Infrastructure

        public static ISolutionContextOperator Instance { get; } = new SolutionContextOperator();


        private SolutionContextOperator()
        {
        }

        #endregion
    }
}
