using System.Collections.Generic;
using System.Linq;
//
namespace FileCompare
{
    public partial class Program
    {
        /// <summary>
        /// Produce a list of strings that don't have a match in either list
        /// </summary>
        /// <param name="lst1"></param>
        /// <param name="lst2"></param>
        /// <returns></returns>
        private static IEnumerable<string> GetSkippingList(IEnumerable<string> lst1, IEnumerable<string> lst2)
        => lst1.Except(lst2).Concat(lst2.Except(lst1)).Distinct();
    }
}