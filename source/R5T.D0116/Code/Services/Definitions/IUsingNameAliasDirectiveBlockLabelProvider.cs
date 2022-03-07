using System;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.D0116
{
    [ServiceDefinitionMarker]
    public interface IUsingNameAliasDirectiveBlockLabelProvider : IServiceDefinition
    {
        public Task<string> GetBlockLabel(
            string destinationName,
            string sourceNameExpression,
            string localNamespaceName);
    }
}
