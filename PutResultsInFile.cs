using System;
using System.Collections.Generic;
using System.IO;
//
namespace FileCompare
{
    public partial class Program
    {
        /// <summary>
        /// Gathers results and places them in the target output file.
        /// </summary>
        /// <param name="masterDir"></param>
        /// <param name="compDir"></param>
        /// <param name="outFile"></param>
        /// <param name="masterNamesList"></param>
        /// <param name="errorString"></param>
        /// <returns></returns>
        private static bool PutResultsInFile(
            string masterDir, string compDir, string outFile, IEnumerable<string> masterNamesList, ref string errorString)
        {
            bool retVal = true;

            try
            {
                File.WriteAllLines(outFile,  GetResultsInStrings(masterNamesList, masterDir, compDir));
            }
            catch (Exception exc)
            {
                retVal = false;
                errorString = exc.Message;
            }

            return retVal;
        }
    }
}