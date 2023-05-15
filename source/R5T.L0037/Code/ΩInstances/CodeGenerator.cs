using System;


namespace R5T.L0037
{
    public class CodeGenerator : ICodeGenerator
    {
        #region Infrastructure

        public static ICodeGenerator Instance { get; } = new CodeGenerator();


        private CodeGenerator()
        {
        }

        #endregion
    }
}
