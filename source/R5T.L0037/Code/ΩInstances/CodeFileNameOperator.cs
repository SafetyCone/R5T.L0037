using System;


namespace R5T.L0037
{
    public class CodeFileNameOperator : ICodeFileNameOperator
    {
        #region Infrastructure

        public static ICodeFileNameOperator Instance { get; } = new CodeFileNameOperator();


        private CodeFileNameOperator()
        {
        }

        #endregion
    }
}
