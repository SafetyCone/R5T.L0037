using System;

using R5T.F0024.T001;
using R5T.T0137;


namespace R5T.L0037.N001
{
    /// <summary>
    /// A context for a <see cref="SolutionFile"/> object.
    /// </summary>
    [ContextDefinitionMarker]
    public interface ISolutionFileContext : IContextDefinitionMarker
    {
        public SolutionFile SolutionFile { get; }
    }
}
