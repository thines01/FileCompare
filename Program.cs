using System.Collections.Generic;
using System.IO;
using System.Linq;
//
using ArgMap;
using NowTime;

namespace FileCompare
{
    using NT = CNowTime;
    using ArgMap = CArgMap;

    public partial class Program
    {
        static void Main(string[] args)
        {
            var argMap = new ArgMap(args);
            var reqdArgsList = new List<string> { "MasterDir", "CompDir", "Pattern", "OutputFile" };
            var masterDir = argMap.GetArg(reqdArgsList[0]);
            var compDir = argMap.GetArg(reqdArgsList[1]);
            var searchPattern = argMap.GetArg(reqdArgsList[2]);
            var outFile = argMap.GetArg(reqdArgsList[3]);
            //
            if (!argMap.HasAllRequiredArgs(reqdArgsList))
            {
                NT.WriteLine("Required argument(s) missing:\r\n"
                    +string.Join("\r\n", reqdArgsList));
                return;
            }

            ////////////////////////////////////////////////////////////////////
            //
            NT.WriteLine("Loading Master directory.");
            var masterFilesList = GetDir(masterDir, searchPattern);

            ////////////////////////////////////////////////////////////////////
            //
            NT.WriteLine("Loading Comp directory.");
            var compFilesList = GetDir(compDir, searchPattern);

            ////////////////////////////////////////////////////////////////////
            //
            NT.WriteLine("Checking number of files.");
            static string GetShortName(string strLongName) => new FileInfo(strLongName).Name;
            var masterNamesList = masterFilesList.Select(GetShortName);
            var compNamesList = compFilesList.Select(GetShortName);

            if (ListsAreDifferent(masterNamesList, compNamesList))
            {
                var skippingList = GetSkippingList(masterNamesList, compNamesList);

                NT.WriteLine(
                    "File counts differ!"
                    + "\r\n\t\t\tSkipping: " 
                    + string.Join(',', skippingList) 
                    + "\r\n\t\t\tContinuing..."
                    );
            }

            ////////////////////////////////////////////////////////////////////
            //
            NT.WriteLine("Comparing individual files.");
            var errorString = "";
            if (!PutResultsInFile(masterDir, compDir, outFile, masterNamesList.Intersect(compNamesList), ref errorString))
            {
                NT.WriteLine("Couldn't store the results in:\r\n\t" + outFile);
            }
        }
    }
}
