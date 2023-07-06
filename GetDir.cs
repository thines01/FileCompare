using System.Collections.Generic;
using System.IO;
using System.Linq;
//
namespace FileCompare
{
    public partial class Program
    {
        /// <summary>
        /// Pulls an ordered list of files from a directory
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        private static IEnumerable<string> GetDir(string dir, string pattern)
            => Directory.GetFiles(dir, pattern).OrderBy(s => s).ToList();
    }
}