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
    public static class IUsingNameAliasDirectiveBlockLabelProviderExtensions
    {
        public static async Task<string> GetBlockLabel(this IUsingNameAliasDirectiveBlockLabelProvider usingNameAliasDirectiveBlockLabelProvider,
            UsingDirectiveSyntax usingNameAliasDirective,
            string localNamespaceName)
        {
            var (destinationName, sourceNameExpression) = usingNameAliasDirective.GetNameAliasValues();

            var output = await usingNameAliasDirectiveBlockLabelProvider.GetBlockLabel(
                destinationName,
                sourceNameExpression,
                localNamespaceName);

            return output;
        }

        public static async Task<string> GetBlockLabel<TNode>(this IUsingNameAliasDirectiveBlockLabelProvider usingNameAliasDirectiveBlockLabelProvider,
            UsingNameAliasDirectiveAnnotation usingNameAliasDirective,
            string localNamespaceName,
            TNode node)
            where TNode : SyntaxNode
        {
            var usingNameAliasDirectiveSyntax = usingNameAliasDirective.GetNode(node);

            var output = await usingNameAliasDirectiveBlockLabelProvider.GetBlockLabel(
                usingNameAliasDirectiveSyntax,
                localNamespaceName);

            return output;
        }

        public static async Task<string> GetBlockLabel(this IUsingNameAliasDirectiveBlockLabelProvider usingNameAliasDirectiveBlockLabelProvider,
            UsingNameAliasDirectiveSyntax usingNameAliasDirective,
            string localNamespaceName)
        {
            var (destinationName, sourceNameExpression) = usingNameAliasDirective.GetNameAliasValues();

            var output = await usingNameAliasDirectiveBlockLabelProvider.GetBlockLabel(
                destinationName,
                sourceNameExpression,
                localNamespaceName);

            return output;
        }

        public static async Task<List<LabeledList<UsingNameAliasDirectiveSyntax>>> GetUsingNameAliasDirectiveLabeledLists(this IUsingNameAliasDirectiveBlockLabelProvider usingNameAliasDirectiveBlockLabelProvider,
            IEnumerable<UsingNameAliasDirectiveSyntax> usingNameAliasDirectives,
            string localNamespaceName)
        {
            var listsByBlockLabel = new Dictionary<string, List<UsingNameAliasDirectiveSyntax>>();

            foreach (var usingNameAliasDirective in usingNameAliasDirectives)
            {
                var blockLabel = await usingNameAliasDirectiveBlockLabelProvider.GetBlockLabel(
                    usingNameAliasDirective,
                    localNamespaceName);

                listsByBlockLabel.AddValueByKey(blockLabel, usingNameAliasDirective);
            }

            var output = listsByBlockLabel
                .Select(xPair =>
                {
                    var xOutput = new LabeledList<UsingNameAliasDirectiveSyntax>()
                    {
                        Label = xPair.Key
                    };

                    xOutput.Items.AddRange(xPair.Value);

                    return xOutput;
                })
                .ToList();

            return output;
        }

        public static async Task<List<LabeledList<UsingNameAliasDirectiveAnnotation>>> GetUsingNameAliasDirectiveLabeledLists<TNode>(this IUsingNameAliasDirectiveBlockLabelProvider usingNameAliasDirectiveBlockLabelProvider,
            IEnumerable<UsingNameAliasDirectiveAnnotation> usingNameAliasDirectives,
            string localNamespaceName,
            TNode node)
            where TNode : SyntaxNode
        {
            var listsByBlockLabel = new Dictionary<string, List<UsingNameAliasDirectiveAnnotation>>();

            foreach (var usingNameAliasDirective in usingNameAliasDirectives)
            {
                var blockLabel = await usingNameAliasDirectiveBlockLabelProvider.GetBlockLabel(
                    usingNameAliasDirective,
                    localNamespaceName,
                    node);

                listsByBlockLabel.AddValueByKey(blockLabel, usingNameAliasDirective);
            }

            var output = listsByBlockLabel
                .Select(xPair =>
                {
                    var xOutput = new LabeledList<UsingNameAliasDirectiveAnnotation>()
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
