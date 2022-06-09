using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using R5T.T0064;
using R5T.T0129;


namespace R5T.D0116
{
    [ServiceDefinitionMarker]
    public interface IUsingNameAliasDirectiveComparerProvider : IServiceDefinition
    {
        public Task<IComparer<NameAlias>> GetComparer(string blockLabel);
    }
}
