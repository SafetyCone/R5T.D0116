using System;

using R5T.T0064;


namespace R5T.D0116
{
    /// <summary>
    /// Provides a set of services for extension methods to use to sort using annotations.
    /// </summary>
    /// <remarks>
    /// Uses an "open-innards" strategy to allow extension methods to operate on any level of abstraction in the Roslyn syntax hierarchy.
    /// </remarks>
    [ServiceDefinitionMarker]
    public interface IUsingDirectivesFormatter : IServiceDefinition
    {
        IUsingNameAliasDirectiveBlockLabelProvider NameAliasBlockLabelProvider { get; }
        IUsingNameAliasDirectiveBlockSortOrderProvider NameAliasBlockSortOrderProvider { get; }
        IUsingNameAliasDirectiveComparerProvider NameAliasComparerProvider { get; }

        IUsingNamespaceDirectiveBlockLabelProvider NamespaceBlockLabelProvider { get; }
        IUsingNamespaceDirectiveBlockSortOrderProvider NamespaceBlockSortOrderProvider { get; }
        IUsingNamespaceDirectiveComparerProvider NamespaceComparerProvider { get; }
    }
}
