using System;

using R5T.T0062;
using R5T.T0063;


namespace R5T.D0116.I001
{
    public static class IServiceActionExtensions
    {
        /// <summary>
        /// Adds the <see cref="AlphabeticalUsingNamespaceDirectiveComparerProvider"/> implementation of <see cref="IUsingNamespaceDirectiveComparerProvider"/> as a <see cref="Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IUsingNamespaceDirectiveComparerProvider> AddAlphabeticalUsingNamespaceDirectiveComparerProviderAction(this IServiceAction _)
        {
            var serviceAction = _.New<IUsingNamespaceDirectiveComparerProvider>(services => services.AddAlphabeticalUsingNamespaceDirectiveComparerProvider());
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="AlphabeticalUsingNameAliasDirectiveComparerProvider"/> implementation of <see cref="IUsingNameAliasDirectiveComparerProvider"/> as a <see cref="Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IUsingNameAliasDirectiveComparerProvider> AddAlphabeticalUsingNameAliasDirectiveComparerProviderAction(this IServiceAction _)
        {
            var serviceAction = _.New<IUsingNameAliasDirectiveComparerProvider>(services => services.AddAlphabeticalUsingNameAliasDirectiveComparerProvider());
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="UsingDirectivesFormatter"/> implementation of <see cref="IUsingDirectivesFormatter"/> as a <see cref="Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IUsingDirectivesFormatter> AddUsingDirectivesFormatterAction(this IServiceAction _,
            IServiceAction<IUsingNameAliasDirectiveBlockLabelProvider> usingNameAliasDirectiveBlockLabelProviderAction,
            IServiceAction<IUsingNameAliasDirectiveBlockSortOrderProvider> usingNameAliasDirectiveBlockSortOrderProviderAction,
            IServiceAction<IUsingNameAliasDirectiveComparerProvider> usingNameAliasDirectiveComparerProviderAction,
            IServiceAction<IUsingNamespaceDirectiveBlockLabelProvider> usingNamespaceDirectiveBlockLabelProviderAction,
            IServiceAction<IUsingNamespaceDirectiveBlockSortOrderProvider> usingNamespaceDirectiveBlockSortOrderProviderAction,
            IServiceAction<IUsingNamespaceDirectiveComparerProvider> usingNamespaceDirectiveComparerProviderAction)
        {
            var serviceAction = _.New<IUsingDirectivesFormatter>(services => services.AddUsingDirectivesFormatter(
                usingNameAliasDirectiveBlockLabelProviderAction,
                usingNameAliasDirectiveBlockSortOrderProviderAction,
                usingNameAliasDirectiveComparerProviderAction,
                usingNamespaceDirectiveBlockLabelProviderAction,
                usingNamespaceDirectiveBlockSortOrderProviderAction,
                usingNamespaceDirectiveComparerProviderAction));

            return serviceAction;
        }
    }
}
