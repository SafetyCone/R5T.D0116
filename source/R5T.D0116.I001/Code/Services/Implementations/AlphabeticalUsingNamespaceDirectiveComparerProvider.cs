using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.D0116.I001
{
    [ServiceImplementationMarker]
    public class AlphabeticalUsingNamespaceDirectiveComparerProvider : IUsingNamespaceDirectiveComparerProvider, IServiceImplementation
    {
        public Task<IComparer<string>> GetComparer(string _)
        {
            var output = AlphabeticalNamespaceDirectiveComparer.Instance;

            return Task.FromResult(output as IComparer<string>);
        }
    }
}
