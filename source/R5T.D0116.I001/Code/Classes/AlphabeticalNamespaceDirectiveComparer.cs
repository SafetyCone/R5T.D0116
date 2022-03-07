using System;
using System.Collections.Generic;


namespace R5T.D0116.I001
{
    public class AlphabeticalNamespaceDirectiveComparer : IComparer<string>
    {
        #region Static

        public static AlphabeticalNamespaceDirectiveComparer Instance { get; } = new();

        #endregion


        public int Compare(string xNamespaceName, string yNamespaceName)
        {
            var output = xNamespaceName.CompareTo(yNamespaceName);
            return output;
        }
    }
}
