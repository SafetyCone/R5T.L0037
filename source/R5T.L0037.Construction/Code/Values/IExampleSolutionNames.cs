using System;

using R5T.T0131;
using R5T.T0187;
using R5T.T0187.Extensions;


namespace R5T.L0037.Construction
{
    [ValuesMarker]
    public partial interface IExampleSolutionNames : IValuesMarker
    {
        public ISolutionName Test_Project => "Test.Project".ToSolutionName();
    }
}
