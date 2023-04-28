using System;

using R5T.F0024.T001;
using R5T.T0137;


namespace R5T.L0037.N001
{
    /// <inheritdoc cref="ISolutionFileContext"/>
    [ContextImplementationMarker]
    public class SolutionFileContext : IContextImplementationMarker,
        ISolutionFileContext
    {
        public SolutionFile SolutionFile { get; set; }
    }
}
