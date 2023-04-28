using System;

using R5T.T0137;
using R5T.T0172;
using R5T.T0187;


namespace R5T.L0037
{
    /// <summary>
    /// A context for a project.
    /// </summary>
    [ContextDefinitionMarker]
    public interface IProjectContext : IContextDefinitionMarker
    {
        public IProjectName ProjectName { get; }
        public IProjectFilePath ProjectFilePath { get; }
    }
}
