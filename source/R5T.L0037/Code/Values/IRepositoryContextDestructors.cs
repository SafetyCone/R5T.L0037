using System;

using R5T.T0131;


namespace R5T.L0037
{
    [ValuesMarker]
    public partial interface IRepositoryContextDestructors : IValuesMarker
    {
        public Action<IRepositoryContext> Default =>
            context => Instances.ActionOperations.DoNothing(context);
    }
}
