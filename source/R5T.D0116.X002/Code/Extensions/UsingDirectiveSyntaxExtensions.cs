using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using Instances = R5T.D0116.X001.Instances;


namespace System
{
    public static class UsingDirectiveSyntaxExtensions
    {
        /// <summary>
        /// Ensures that the using directive has no leading lines if it is the first syntax node in the file (no blank line at the start of the file).
        /// Else, ensures two blank lines precede the using directive if there are prior syntax nodes (extern aliases for example).
        /// </summary>
        public static UsingDirectiveSyntax EnsureFirstBlockFirstUsingDirectiveLeadingLines(this UsingDirectiveSyntax usingDirective)
        {
            var outputUsingDirective = usingDirective;

            // Is first token in file?
            var isFirstNodeInCompilationUnit = usingDirective.IsFirstNodeInCompilationUnit();
            if(isFirstNodeInCompilationUnit)
            {
                // Ensure no preceding blank lines.
                outputUsingDirective = outputUsingDirective.SetLeadingTrivia(
                    Instances.SpacingGenerator.None());
            }
            else
            {
                // Ensure two preceding blank lines (separation from extern alias directives, if they exist).
                outputUsingDirective = outputUsingDirective.SetLeadingTrivia(
                    Instances.SpacingGenerator.TwoBlankLines());
            }

            return outputUsingDirective;
        }

        /// <summary>
        /// Ensures that a blank line precedes the using directive.
        /// </summary>
        public static UsingDirectiveSyntax EnsureBlockFirstUsingDirectiveLeadingLines(this UsingDirectiveSyntax usingDirective)
        {
            var outputUsingDirective = usingDirective.SetLeadingTrivia(
                Instances.SpacingGenerator.BlankLine());

            return outputUsingDirective;
        }

        /// <summary>
        /// Ensures that no blank lines precede the using directive.
        /// </summary>
        public static UsingDirectiveSyntax EnsureBlockBodyDirectiveLeadingLines(this UsingDirectiveSyntax usingDirective)
        {
            var outputUsingDirective = usingDirective.SetLeadingTrivia(
                Instances.SpacingGenerator.NewLine());

            return outputUsingDirective;
        }
    }
}
