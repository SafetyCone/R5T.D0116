using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.Magyar;

using R5T.D0116;
using R5T.T0134;


namespace System
{
    public static class IUsingNamespaceDirectiveBlockLabelProviderExtensions
    {
        public static async Task<string> GetBlockLabel(this IUsingNamespaceDirectiveBlockLabelProvider usingNamespaceDirectiveBlockLabelProvider,
            UsingDirectiveSyntax usingNamespaceDirectiveSyntax,
            string localNamespaceName)
        {
            var namespaceName = usingNamespaceDirectiveSyntax.GetNamespaceName();

            var output = await usingNamespaceDirectiveBlockLabelProvider.GetBlockLabel(
                namespaceName,
                localNamespaceName);

            return output;
        }

        public static async Task<string> GetBlockLabel<TNode>(this IUsingNamespaceDirectiveBlockLabelProvider usingNamespaceDirectiveBlockLabelProvider,
            UsingNamespaceDirectiveAnnotation usingNamespaceDirective,
            string localNamespaceName,
            TNode node)
            where TNode : SyntaxNode
        {
            var usingNamespaceDirectiveSyntax = usingNamespaceDirective.GetNode(node);

            var output = await usingNamespaceDirectiveBlockLabelProvider.GetBlockLabel(
                usingNamespaceDirectiveSyntax,
                localNamespaceName);

            return output;
        }

        public static async Task<string> GetBlockLabel(this IUsingNamespaceDirectiveBlockLabelProvider usingNamespaceDirectiveBlockLabelProvider,
            UsingNamespaceDirectiveSyntax usingNamespaceDirective,
            string localNamespaceName)
        {
            var namespaceName = usingNamespaceDirective.GetNamespaceName();

            var output = await usingNamespaceDirectiveBlockLabelProvider.GetBlockLabel(
                namespaceName,
                localNamespaceName);

            return output;
        }

        public static async Task<List<LabeledList<UsingNamespaceDirectiveSyntax>>> GetUsingNamespaceDirectiveLabeledLists(this IUsingNamespaceDirectiveBlockLabelProvider usingNamespaceDirectiveBlockLabelProvider,
            IEnumerable<UsingNamespaceDirectiveSyntax> usingNamespaceDirectives,
            string localNamespaceName)
        {
            var listsByBlockLabel = new Dictionary<string, List<UsingNamespaceDirectiveSyntax>>();

            foreach (var usingNamespaceDirective in usingNamespaceDirectives)
            {
                var blockLabel = await usingNamespaceDirectiveBlockLabelProvider.GetBlockLabel(
                    usingNamespaceDirective,
                    localNamespaceName);

                listsByBlockLabel.AddValueByKey(blockLabel, usingNamespaceDirective);
            }

            var output = listsByBlockLabel
                .Select(xPair =>
                {
                    var xOutput = new LabeledList<UsingNamespaceDirectiveSyntax>()
                    {
                        Label = xPair.Key
                    };

                    xOutput.Items.AddRange(xPair.Value);

                    return xOutput;
                })
                .ToList();

            return output;
        }

        public static async Task<List<LabeledList<UsingNamespaceDirectiveAnnotation>>> GetUsingNamespaceDirectiveLabeledLists<TNode>(this IUsingNamespaceDirectiveBlockLabelProvider usingNamespaceDirectiveBlockLabelProvider,
            IEnumerable<UsingNamespaceDirectiveAnnotation> usingNamespaceDirectives,
            string localNamespaceName,
            TNode node)
            where TNode : SyntaxNode
        {
            var listsByBlockLabel = new Dictionary<string, List<UsingNamespaceDirectiveAnnotation>>();

            foreach (var usingNamespaceDirective in usingNamespaceDirectives)
            {
                var blockLabel = await usingNamespaceDirectiveBlockLabelProvider.GetBlockLabel(
                    usingNamespaceDirective,
                    localNamespaceName,
                    node);

                listsByBlockLabel.AddValueByKey(blockLabel, usingNamespaceDirective);
            }

            var output = listsByBlockLabel
                .Select(xPair =>
                {
                    var xOutput = new LabeledList<UsingNamespaceDirectiveAnnotation>()
                    {
                        Label = xPair.Key
                    };

                    xOutput.Items.AddRange(xPair.Value);

                    return xOutput;
                })
                .ToList();

            return output;
        }
    }
}
