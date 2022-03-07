using System;
using System.Threading.Tasks;

using R5T.T0064;

using R5T.D0116.T000;


namespace R5T.D0116
{
    [ServiceDefinitionMarker]
    public interface IUsingNamespaceDirectiveBlockSortOrderProvider : IServiceDefinition
    {
        Task<UsingDirectiveBlockSortOrder> GetUsingNamespaceDirectiveBlockSortOrder();
    }
}
