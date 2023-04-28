using System;

using R5T.T0137;
using R5T.T0172;


namespace R5T.L0037
{
    /// <inheritdoc cref="ISolutionFileContext"/>
    [ContextImplementationMarker]
    public class SolutionFileContext : IContextImplementationMarker,
        ISolutionFileContext
    {
        public ISolutionFilePath SolutionFilePath { get; set; }
    }
}
