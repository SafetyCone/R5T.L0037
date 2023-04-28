using System;

using R5T.T0131;
using R5T.T0175;
using R5T.T0175.Extensions;


namespace R5T.L0037.Construction
{
    [ValuesMarker]
    public partial interface IValues : IValuesMarker
    {
        public IApplicationName ApplicationName => "R5T.L0037.Construction".ToApplicationName();
    }
}
