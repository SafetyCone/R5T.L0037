using System;


namespace R5T.L0037.Extensions
{
    public static class StringExtensions
    {
        public static ILocalRepositoryDirectoryPath ToLocalRepositoryDirectoryPath(this string value)
        {
            return Instances.StringOperator_Extensions.ToLocalRepositoryDirectoryPath(value);
        }

        public static ILocalRepositoryDirectoryPath ToRepositoryDirectoryPath(this string value)
        {
            return Instances.StringOperator_Extensions.ToRepositoryDirectoryPath(value);
        }
    }
}
