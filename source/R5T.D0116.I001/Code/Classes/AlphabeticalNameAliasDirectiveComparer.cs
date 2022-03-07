using System;
using System.Collections.Generic;

using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace R5T.D0116.I001
{
    public class AlphabeticalNameAliasDirectiveComparer : IComparer<NameAlias>
    {
        #region Static

        public static AlphabeticalNameAliasDirectiveComparer Instance { get; } = new();

        #endregion


        public int Compare(NameAlias xNameAlias, NameAlias yNameAlias)
        {
            var output = xNameAlias.CompareTo(yNameAlias);
            return output;
        }
    }
}
