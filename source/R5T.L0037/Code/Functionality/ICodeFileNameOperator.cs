using System;

using R5T.T0132;
using R5T.T0161;
using R5T.T0172;
using R5T.T0172.Extensions;


namespace R5T.L0037
{
    [FunctionalityMarker]
    public partial interface ICodeFileNameOperator : IFunctionalityMarker,
        F0053.ICodeFileNameOperator
    {
        public ICSharpFileName Get_CSharpFileName(ISimpleTypeName typeName)
        {
            var output = this.GetCSharpCodeFileName_ForTypeName(typeName.Value)
                .ToCSharpFileName();

            return output;
        }
    }
}
