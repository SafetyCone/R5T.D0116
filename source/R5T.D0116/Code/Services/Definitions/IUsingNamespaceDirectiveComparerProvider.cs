using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.D0116
{
    [ServiceDefinitionMarker]
    public interface IUsingNamespaceDirectiveComparerProvider : IServiceDefinition
    {
        public Task<IComparer<string>> GetComparer(string blockLabel);
    }
}
