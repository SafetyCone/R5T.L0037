using System;

using R5T.T0131;
using R5T.T0172;
using R5T.T0172.Extensions;


namespace R5T.L0037
{
    [ValuesMarker]
    public partial interface IProjectDirectoryRelativePaths : IValuesMarker
    {
        public IProjectDirectoryRelativeDirectoryPath Contexts_Definitions_Directory => @"Code\Contexts\Definitions\".ToProjectDirectoryRelativeDirectoryPath();
        public IProjectDirectoryRelativeDirectoryPath Contexts_Implementations_Directory => @"Code\Contexts\Implementations\".ToProjectDirectoryRelativeDirectoryPath();
        public IProjectDirectoryRelativeDirectoryPath StrongTypes_Interfaces_Directory => @"Code\Strong Types\Interfaces\".ToProjectDirectoryRelativeDirectoryPath();
        public IProjectDirectoryRelativeDirectoryPath StrongTypes_Implementations_Directory => @"Code\Strong Types\Implementations\".ToProjectDirectoryRelativeDirectoryPath();
    }
}
