using System;

using R5T.T0131;
using R5T.T0172;
using R5T.T0172.Extensions;


namespace R5T.L0037.Construction
{
    [ValuesMarker]
    public partial interface IExampleProjectDirectoryPaths : IValuesMarker
    {
        public IProjectDirectoryPath Test_Project => @"C:\Temp\Projects\Test.Project\".ToProjectDirectoryPath();
    }
}
