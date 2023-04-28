using System;

using R5T.T0137;
using R5T.T0172;
using R5T.T0187;


namespace R5T.L0037
{
    /// <summary>
    /// A context for a solution.
    /// </summary>
    [ContextDefinitionMarker]
    public interface ISolutionContext : IContextDefinitionMarker
    {
        public ISolutionName SolutionName { get; }
        public ISolutionFilePath SolutionFilePath { get; }
    }
}
