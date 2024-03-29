﻿using System;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using NameAlias = R5T.T0129.NameAlias;

using Instances = R5T.D0116.X001.Instances;


namespace System
{
    public static class UsingDirectiveSyntaxExtensions
    {
        public static NameAlias GetNameAlias_T0129(this UsingDirectiveSyntax usingDirective)
        {
            var destinationName = usingDirective.GetDestinationName();
            var sourceNameExpression = usingDirective.GetSourceNameExpression();

            var output = new NameAlias(
                destinationName,
                sourceNameExpression);

            return output;
        }

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
                outputUsingDirective = outputUsingDirective.SetIndentation2(
                    Instances.Indentation.None());
            }
            else
            {
                // Ensure two preceding blank lines (separation from extern alias directives, if they exist).
                outputUsingDirective = outputUsingDirective.SetIndentation2(
                    Instances.Indentation.BlankLines_Two());
            }

            return outputUsingDirective;
        }

        /// <summary>
        /// Ensures that a blank line precedes the using directive.
        /// </summary>
        public static UsingDirectiveSyntax EnsureBlockFirstUsingDirectiveLeadingLines(this UsingDirectiveSyntax usingDirective)
        {
            var outputUsingDirective = usingDirective.SetIndentation2(
                Instances.Indentation.BlankLine());

            return outputUsingDirective;
        }

        /// <summary>
        /// Ensures that no blank lines precede the using directive.
        /// </summary>
        public static UsingDirectiveSyntax EnsureBlockBodyDirectiveLeadingLines(this UsingDirectiveSyntax usingDirective)
        {
            var outputUsingDirective = usingDirective.SetIndentation2(
                Instances.Indentation.NewLine());

            return outputUsingDirective;
        }
    }
}
