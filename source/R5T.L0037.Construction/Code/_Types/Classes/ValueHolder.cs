using System;

using R5T.T0142;


namespace R5T.L0037.Construction
{
    /// <summary>
    /// Allows indirection to a value.
    /// Useful, for example, when creating closures, but you need a local reference to a variable.
    /// </summary>
    [UtilityTypeMarker]
    public class ValueHolder<T>
    {
        public T Value { get; set; }
    }
}
