using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.T0063;


namespace R5T.D0116.I001
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="AlphabeticalUsingNamespaceDirectiveComparerProvider"/> implementation of <see cref="IUsingNamespaceDirectiveComparerProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddAlphabeticalUsingNamespaceDirectiveComparerProvider(this IServiceCollection services)
        {
            services.AddSingleton<IUsingNamespaceDirectiveComparerProvider, AlphabeticalUsingNamespaceDirectiveComparerProvider>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="AlphabeticalUsingNameAliasDirectiveComparerProvider"/> implementation of <see cref="IUsingNameAliasDirectiveComparerProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddAlphabeticalUsingNameAliasDirectiveComparerProvider(this IServiceCollection services)
        {
            services.AddSingleton<IUsingNameAliasDirectiveComparerProvider, AlphabeticalUsingNameAliasDirectiveComparerProvider>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="UsingDirectivesFormatter"/> implementation of <see cref="IUsingDirectivesFormatter"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddUsingDirectivesFormatter(this IServiceCollection services,
            IServiceAction<IUsingNameAliasDirectiveBlockLabelProvider> usingNameAliasDirectiveBlockLabelProviderAction,
            IServiceAction<IUsingNameAliasDirectiveBlockSortOrderProvider> usingNameAliasDirectiveBlockSortOrderProviderAction,
            IServiceAction<IUsingNameAliasDirectiveComparerProvider> usingNameAliasDirectiveComparerProviderAction,
            IServiceAction<IUsingNamespaceDirectiveBlockLabelProvider> usingNamespaceDirectiveBlockLabelProviderAction,
            IServiceAction<IUsingNamespaceDirectiveBlockSortOrderProvider> usingNamespaceDirectiveBlockSortOrderProviderAction,
            IServiceAction<IUsingNamespaceDirectiveComparerProvider> usingNamespaceDirectiveComparerProviderAction)
        {
            services
                .Run(usingNameAliasDirectiveBlockLabelProviderAction)
                .Run(usingNameAliasDirectiveBlockSortOrderProviderAction)
                .Run(usingNameAliasDirectiveComparerProviderAction)
                .Run(usingNamespaceDirectiveBlockLabelProviderAction)
                .Run(usingNamespaceDirectiveBlockSortOrderProviderAction)
                .Run(usingNamespaceDirectiveComparerProviderAction)
                .AddSingleton<IUsingDirectivesFormatter, UsingDirectivesFormatter>();

            return services;
        }
    }
}
