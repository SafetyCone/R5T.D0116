using System;

using R5T.T0036;
using R5T.T0098;


namespace R5T.D0116.X001
{
    public static class Instances
    {
        public static IIndentation Indentation { get; } = T0036.Indentation.Instance;
        public static IOperation Operation { get; } = T0098.Operation.Instance;
    }
}
