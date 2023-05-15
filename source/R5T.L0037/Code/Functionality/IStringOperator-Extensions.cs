using System;

using R5T.T0132;


namespace R5T.L0037.Extensions
{
    [FunctionalityMarker]
    public partial interface IStringOperator : IFunctionalityMarker
    {
        public ILocalRepositoryDirectoryPath ToLocalRepositoryDirectoryPath(string value)
        {
            var output = new LocalRepositoryDirectoryPath(value);
            return output;
        }

        public IRepositoryDirectoryPath ToRepositoryDirectoryPath(string value)
        {
            var output = new RepositoryDirectoryPath(value);
            return output;
        }
    }
}
