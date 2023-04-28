﻿using System;

using R5T.T0137;
using R5T.T0172;
using R5T.T0187;


namespace R5T.L0037
{
    /// <inheritdoc cref="IProjectContext"/>
    [ContextImplementationMarker]
    public class ProjectContext : IContextImplementationMarker,
        IProjectContext
    {
        public IProjectName ProjectName { get; set; }
        public IProjectFilePath ProjectFilePath { get; set; }
    }
}
