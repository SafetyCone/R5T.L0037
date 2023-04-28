using System;

using R5T.T0137;
using R5T.T0172;


namespace R5T.L0037
{
    /// <summary>
    /// A context for a solution file path.
    /// </summary>
    [ContextDefinitionMarker]
    public interface ISolutionFileContext : IContextDefinitionMarker
    {
        public ISolutionFilePath SolutionFilePath { get; }
    }
}
