using System;

using R5T.T0132;
using R5T.T0161;
using R5T.T0161.Extensions;


namespace R5T.L0037
{
    [FunctionalityMarker]
    public partial interface ITypeNameOperator : IFunctionalityMarker,
        F0000.ITypeNameOperator
    {
        public IInterfaceTypeName Get_InterfaceTypeName(ITypeNameStem typeNameStem)
        {
            var output = this.GetInterfaceTypeName(typeNameStem.Value)
                .ToInterfaceTypeName();

            return output;
        }

        public IClassTypeName Get_ClassTypeName(ITypeNameStem typeNameStem)
        {
            var output = this.GetClassTypeName(typeNameStem.Value)
                .ToClassTypeName();

            return output;
        }
    }
}
