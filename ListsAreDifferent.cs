using System.Collections.Generic;
using System.Linq;
//
namespace FileCompare
{
    public partial class Program
    {
        /// <summary>
        /// Returns true if listOne has a different count of target elements
        /// than lstTwo and vice-versa
        /// </summary>
        /// <param name="lstOne"></param>
        /// <param name="lstTwo"></param>
        /// <returns></returns>
        private static bool ListsAreDifferent(IEnumerable<string> lstOne, IEnumerable<string> lstTwo)
            => (lstOne.Except(lstTwo).Any() || lstTwo.Except(lstOne).Any());
    }
}