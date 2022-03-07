using System;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.D0116
{
    [ServiceDefinitionMarker]
    public interface IUsingNamespaceDirectiveBlockLabelProvider : IServiceDefinition
    {
        Task<string> GetBlockLabel(
            string namespaceName,
            string localNamespaceName);
    }
}
