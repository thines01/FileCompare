using System.Collections.Generic;
using System.IO;
using System.Linq;
//
namespace FileCompare
{
    public partial class Program
    {
        /// <summary>
        /// Calls the matching routine and returns the results in a list of string
        /// </summary>
        /// <param name="masterNamesList"></param>
        /// <param name="masterDir"></param>
        /// <param name="compDir"></param>
        /// <returns></returns>
        private static IEnumerable<string> GetResultsInStrings(IEnumerable<string> masterNamesList, string masterDir, string compDir)
        => masterNamesList.Select(file => string.Format("{0}:\t{1}",
        (
            FileHashesMatch(Path.Combine(masterDir, file), Path.Combine(compDir, file))
            ? "same"
            : "DIFF"
        ), file));
    }
}