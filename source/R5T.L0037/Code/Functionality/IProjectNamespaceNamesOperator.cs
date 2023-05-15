using System;

using R5T.T0132;
using R5T.T0161;
using R5T.T0161.Extensions;
using R5T.T0172;
using R5T.T0187;
using R5T.T0187.Extensions;


namespace R5T.L0037
{
    [FunctionalityMarker]
    public partial interface IProjectNamespaceNamesOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Determines if the namespace name is valid.
        /// </summary>
        public bool Is_Valid(string namespaceName)
        {
            // TODO: Assume it is.
            return true;
        }

        public string Ensure_IsValid(string namespaceName)
        {
            var isValid = this.Is_Valid(namespaceName);

            var output = isValid
                ? namespaceName
                : this.Modify_ToBeValid(namespaceName)
                ;

            return output;
        }

        public string Modify_ToBeValid(string namespaceName)
        {
            // TODO: Do nothing at the moment.
            return namespaceName;
        }

        public INamespaceName Get_DefaultProjectNamespaceName(IProjectName projectName)
        {
            // The default namespace name is just the project name.
            var candidate = projectName.Value;

            var output = this.Ensure_IsValid(candidate)
                .ToNamespaceName();

            return output;
        }

        /// <summary>
        /// Get the default project namespace name from the file-name of the project file.
        /// Does not analyze file contents to look for a default namespace specifier.
        /// </summary>
        /// <remarks>
        /// This is useful when a project file does not actually exist yet, or you are trying to set the namespace specifier in a project file to its default value.
        /// </remarks>
        public INamespaceName Get_DefaultProjectNamespaceName(IProjectFilePath projectFilePath)
        {
            var projectName = Instances.ProjectPathsOperator.Get_ProjectName(projectFilePath);

            var output = this.Get_DefaultProjectNamespaceName(projectName);
            return output;
        }
    }
}
