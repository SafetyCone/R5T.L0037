using System;

using R5T.T0131;
using R5T.T0195;


namespace R5T.L0037
{
    /// <summary>
    /// Contains groups of project file references grouped by functionality.
    /// See also: see R5T.Z0018.
    /// </summary>
    [ValuesMarker]
    public partial interface IProjectFileReferenceSets : IValuesMarker
    {
        /// <summary>
        /// For creating context text definitions.
        /// </summary>
        public IProjectFileReference[] For_ContextTypeDefinitionLibrary => new[]
        {
            Instances.ProjectFileReferences_Raw.R5T_T0137,
        };

        /// <summary>
        /// For referencing the text output type.
        /// </summary>
        public IProjectFileReference[] For_TextOutput => new[]
        {
            Instances.ProjectFileReferences_Raw.R5T_T0159,
        };

        /// <summary>
        /// References for working with paths in libraries.
        /// </summary>
        public IProjectFileReference[] For_LibraryPaths => new[]
        {
            // For solution and project, file and directory, name and path strong-types.
            Instances.ProjectFileReferences_Raw.R5T_T0172,
            // For solution and project name strong-types.
            Instances.ProjectFileReferences_Raw.R5T_T0187,
        };

        /// <summary>
        /// For creating strong-type definitions.
        /// </summary>
        public IProjectFileReference[] For_StrongTypesDefinitionLibrary => new[]
        {
            Instances.ProjectFileReferences_Raw.R5T_T0179,
        };
    }
}
