using System;

using R5T.T0064;


namespace R5T.D0116.I001
{
    [ServiceImplementationMarker]
    public class UsingDirectivesFormatter : IUsingDirectivesFormatter, IServiceImplementation
    {
        public IUsingNameAliasDirectiveBlockLabelProvider NameAliasBlockLabelProvider { get; set; }
        public IUsingNameAliasDirectiveBlockSortOrderProvider NameAliasBlockSortOrderProvider { get; set; }
        public IUsingNameAliasDirectiveComparerProvider NameAliasComparerProvider { get; set; }

        public IUsingNamespaceDirectiveBlockLabelProvider NamespaceBlockLabelProvider { get; set; }
        public IUsingNamespaceDirectiveBlockSortOrderProvider NamespaceBlockSortOrderProvider { get; set; }
        public IUsingNamespaceDirectiveComparerProvider NamespaceComparerProvider { get; set; }


        public UsingDirectivesFormatter(
            IUsingNameAliasDirectiveBlockLabelProvider nameAliasBlockLabelProvider,
            IUsingNameAliasDirectiveBlockSortOrderProvider nameAliasBlockSortOrderProvider,
            IUsingNameAliasDirectiveComparerProvider nameAliasComparerProvider,
            IUsingNamespaceDirectiveBlockLabelProvider namespaceBlockLabelProvider,
            IUsingNamespaceDirectiveBlockSortOrderProvider namespaceBlockSortOrderProvider,
            IUsingNamespaceDirectiveComparerProvider namespaceComparerProvider)
        {
            this.NameAliasBlockLabelProvider = nameAliasBlockLabelProvider;
            this.NameAliasBlockSortOrderProvider = nameAliasBlockSortOrderProvider;
            this.NameAliasComparerProvider = nameAliasComparerProvider;

            this.NamespaceBlockLabelProvider = namespaceBlockLabelProvider;
            this.NamespaceBlockSortOrderProvider = namespaceBlockSortOrderProvider;
            this.NamespaceComparerProvider = namespaceComparerProvider;
        }
    }
}
