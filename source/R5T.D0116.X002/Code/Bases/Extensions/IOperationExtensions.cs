using System;
using System.Collections.Generic;
using System.Linq;

using R5T.Magyar;

using R5T.T0098;


namespace System
{
    public static partial class IOperationExtensions
    {
        /// <summary>
        /// Returns the items from <paramref name="set1"/> that are missing from <paramref name="set2"/>.
        /// </summary>
        public static WasFound<T[]> AnyMissingFromSet1<T>(this IOperation _,
            IEnumerable<T> set1,
            IEnumerable<T> set2)
        {
            var anyMissingFromSet1 = set2.Except(set1);

            var output = WasFound.FromEnumerable(anyMissingFromSet1);
            return output;
        }

        public static WasFound<string[]> AnyLabelsMissingFromSortOrder<TLabeled>(this IOperation _,
            IEnumerable<TLabeled> labeleds,
            IList<string> sortOrder)
            where TLabeled : ILabeled
        {
            var labels = labeleds
                .Select(x => x.Label)
                ;

            var output = _.AnyMissingFromSet1(
                sortOrder,
                labels);

            return output;
        }

        public static IEnumerable<TLabeled> OrderByLabels<TLabeled>(this IOperation _,
            IEnumerable<TLabeled> labeleds,
            IList<string> labelsInOrder)
            where TLabeled : ILabeled
        {
            var indexByLabelsInOrder = labelsInOrder.GetIndexByItem();

            var output = labeleds
                .OrderBy(x => indexByLabelsInOrder[x.Label])
                ;

            return output;
        }
    }
}