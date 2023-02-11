using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.Magyar;

using R5T.D0116;
using R5T.T0126;

using Instances = R5T.D0116.X001.Instances;


namespace System
{
    public static class IUsingDirectivesFormatterExtensions
    {
        public static async Task<CompilationUnitSyntax> AddAndFormatNamespaceNames(this IUsingDirectivesFormatter usingDirectivesFormatter,
            CompilationUnitSyntax compilationUnit,
            IEnumerable<string> namespaceNames,
            string compilationUnitLocalNamespaceName)
        {
            var outputCompilationUnit = compilationUnit.AddUsings(namespaceNames);

            outputCompilationUnit = await usingDirectivesFormatter.FormatUsingDirectives(
                        outputCompilationUnit,
                        compilationUnitLocalNamespaceName);

            return outputCompilationUnit;
        }

        /// <summary>
        /// Formats using directives by grouping them into separate blocks, ordering those blocks, and ordering the directives within each block.
        /// </summary>
        /// <param name="compilationUnitLocalNamespaceName">
        /// The special namespace that should be made into its own block, indicating functionalty the caller wants to consider "local" to the compilation unit (which can be whatever the caller wants, for example in the same project or solution).
        /// This can be the <see cref="R5T.L0011.X001.NamespaceNames.NoNamespaceNamespaceName"/> value.
        /// </param>
        public static async Task<CompilationUnitSyntax> FormatUsingDirectives(this IUsingDirectivesFormatter usingDirectivesFormatter,
            CompilationUnitSyntax compilationUnit,
            string compilationUnitLocalNamespaceName)
        {
            var outputCompilationUnit = compilationUnit;

            outputCompilationUnit = outputCompilationUnit.GetUsingsAnnotated(out var usingDirectivesAnnotated);

            if (usingDirectivesAnnotated.Any())
            {
                // There is at least one using.
                var usingNamespaceDirectivesAnnotated = usingDirectivesAnnotated.GetUsingNamespaceDirectives(outputCompilationUnit);

                // Sort using namespace directives.
                var usingNamespaceDirectiveBlockLabelProvider = usingDirectivesFormatter.NamespaceBlockLabelProvider;

                var usingNamespaceDirectiveLabeledListsAnnotated = await usingNamespaceDirectiveBlockLabelProvider.GetUsingNamespaceDirectiveLabeledLists(
                    usingNamespaceDirectivesAnnotated,
                    compilationUnitLocalNamespaceName,
                    outputCompilationUnit);

                var usingNamespaceDirectivesSortOrder = await usingDirectivesFormatter.NamespaceBlockSortOrderProvider.GetUsingNamespaceDirectiveBlockSortOrder();

                // Check can sort blocks.
                var anyNamespaceLabelsMissingFromSortOrder = Instances.Operation.AnyLabelsMissingFromSortOrder(
                    usingNamespaceDirectiveLabeledListsAnnotated,
                    usingNamespaceDirectivesSortOrder.BlockLabels);

                if (anyNamespaceLabelsMissingFromSortOrder)
                {
                    throw new Exception("Labels were missing from the sort order.");
                }

                // Sort blocks.
                var orderedUsingNamespaceDirectiveLabeledListsAnnotated = Instances.Operation.OrderByLabels(
                    usingNamespaceDirectiveLabeledListsAnnotated,
                    usingNamespaceDirectivesSortOrder.BlockLabels);

                var usingNamespaceDirectiveComparerProvider = usingDirectivesFormatter.NamespaceComparerProvider;

                foreach (var labeledList in orderedUsingNamespaceDirectiveLabeledListsAnnotated)
                {
                    var comparer = await usingNamespaceDirectiveComparerProvider.GetComparer(labeledList.Label);

                    labeledList.Items.Sort((x, y) =>
                    {
                        var xUsingDirective = x.GetAnnotatedNode_Typed(outputCompilationUnit);
                        var yUsingDirective = y.GetAnnotatedNode_Typed(outputCompilationUnit);

                        var output = comparer.Compare(
                            xUsingDirective.GetNamespaceName(),
                            yUsingDirective.GetNamespaceName());

                        return output;
                    });
                }

                // Using name alias directives.
                var usingNameAliasDirectivesAnnotated = usingDirectivesAnnotated.GetUsingNameAliasDirectives(outputCompilationUnit);

                var usingNameAliasBlockLabelProvider = usingDirectivesFormatter.NameAliasBlockLabelProvider;

                var usingNameAliasDirectiveLabeledListsAnnotated = await usingNameAliasBlockLabelProvider.GetUsingNameAliasDirectiveLabeledLists(
                    usingNameAliasDirectivesAnnotated,
                    compilationUnitLocalNamespaceName,
                    outputCompilationUnit);

                var usingNameAliasDirectivesSortOrder = await usingDirectivesFormatter.NameAliasBlockSortOrderProvider.GetUsingNameAliasDirectiveBlockSortOrder();

                // Check can sort blocks.
                var anyNameAliasLabelsMissingFromSortOrder = Instances.Operation.AnyLabelsMissingFromSortOrder(
                    usingNameAliasDirectiveLabeledListsAnnotated,
                    usingNameAliasDirectivesSortOrder.BlockLabels);

                if (anyNamespaceLabelsMissingFromSortOrder)
                {
                    throw new Exception("Labels were missing from the sort order.");
                }

                // Sort blocks.
                var orderedUsingNameAliasDirectiveLabeledListsAnnotated = Instances.Operation.OrderByLabels(
                    usingNameAliasDirectiveLabeledListsAnnotated,
                    usingNameAliasDirectivesSortOrder.BlockLabels);

                var usingNameAliasDirectiveComparerProvider = usingDirectivesFormatter.NameAliasComparerProvider;

                foreach (var labeledList in usingNameAliasDirectiveLabeledListsAnnotated)
                {
                    var comparer = await usingNameAliasDirectiveComparerProvider.GetComparer(labeledList.Label);

                    labeledList.Items.Sort((x, y) =>
                    {
                        var xUsingDirective = x.GetAnnotatedNode_Typed(outputCompilationUnit);
                        var yUsingDirective = y.GetAnnotatedNode_Typed(outputCompilationUnit);

                        var output = comparer.Compare(
                            xUsingDirective.GetNameAlias_T0129(),
                            yUsingDirective.GetNameAlias_T0129());

                        return output;
                    });
                }

                // Get back to a list of a common type annotation.
                var orderedUsingDirectiveBlocksAnnotated = orderedUsingNamespaceDirectiveLabeledListsAnnotated
                    .Select(x => x.Items
                        .Cast<UsingDirectiveAnnotation>()
                        .ToArray())
                    .AppendRange(orderedUsingNameAliasDirectiveLabeledListsAnnotated
                        .Select(x => x.Items
                            .Cast<UsingDirectiveAnnotation>()
                            .ToArray()))
                    .ToArray();

                // Get specific using directive annotations.
                var firstUsingOfFirstBlockAnnotation = orderedUsingDirectiveBlocksAnnotated.First().First();

                var firstUsingOfBlockAnnotations = orderedUsingDirectiveBlocksAnnotated.SkipFirst()
                    .Select(x => x.First())
                    .ToArray();

                var allOtherUsingAnnotations = orderedUsingDirectiveBlocksAnnotated
                    .SelectMany(x => x.SkipFirst())
                    .ToArray();

                // Set usings now so we can test for whether a using is the first syntax node in a file.
                // Now convert blocks back to an enumerable of usings.
                var orderedUsingDirectives = orderedUsingDirectiveBlocksAnnotated
                    .SelectMany(x => x
                        .Select(x => x.GetAnnotatedNode_Typed(outputCompilationUnit)))
                    .ToArray();

                // Set usings.
                outputCompilationUnit = outputCompilationUnit.WithUsings(orderedUsingDirectives.ToSyntaxList());

                // Now modify spacings.
                var currentFirstUsingOfFirstBlock = outputCompilationUnit.GetAnnotatedNode_Typed(firstUsingOfFirstBlockAnnotation);

                var newFirstUsingOfFirstBlock = currentFirstUsingOfFirstBlock.EnsureFirstBlockFirstUsingDirectiveLeadingLines();

                outputCompilationUnit = outputCompilationUnit.ReplaceNode_Better(currentFirstUsingOfFirstBlock, newFirstUsingOfFirstBlock);

                foreach (var currentFirstUsingOfBlockAnnotation in firstUsingOfBlockAnnotations)
                {
                    var currentFirstUsingOfBlock = outputCompilationUnit.GetAnnotatedNode_Typed(currentFirstUsingOfBlockAnnotation);

                    var newFirstUsingOfBlock = currentFirstUsingOfBlock.EnsureBlockFirstUsingDirectiveLeadingLines();

                    outputCompilationUnit = outputCompilationUnit.ReplaceNode_Better(currentFirstUsingOfBlock, newFirstUsingOfBlock);
                }

                foreach (var currentOtherUsingAnnotation in allOtherUsingAnnotations)
                {
                    var currentOtherUsing = outputCompilationUnit.GetAnnotatedNode_Typed(currentOtherUsingAnnotation);

                    var newOtherUsing = currentOtherUsing.EnsureBlockBodyDirectiveLeadingLines();

                    outputCompilationUnit = outputCompilationUnit.ReplaceNode_Better(currentOtherUsing, newOtherUsing);
                }

                // Delete annotations.
            }

            return outputCompilationUnit;
        }
    }
}
