using System.IO;
using System.Security.Cryptography;
//
namespace FileCompare
{
    public partial class Program
    {
        private static readonly SHA1 _sha = new SHA1CryptoServiceProvider();

        /// <summary>
        /// Gets a HASHcode from the target file
        /// </summary>
        /// <param name="strFile"></param>
        /// <returns></returns>
        private static byte[] GetHash(string strFile)
        {
            byte[] hash = null;
            //
            using (FileStream fs = File.OpenRead(strFile))
            {
                hash = _sha.ComputeHash(fs);
                fs.Close();
            }
            //
            return hash;
        }

        private static byte[] getHash(string strFile)
            => _sha.ComputeHash(File.OpenRead(strFile));

        /// <summary>
        /// Joins an array of bytes into a string with a separator
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private static string Stringify(byte[] data) => string.Join('-', data);

        /// <summary>
        /// Checks the see if the hash from file 1
        /// matches the hash from file 2.
        /// The string conversion is done to ensure the bytes
        /// are in the same order
        /// </summary>
        /// <param name="strFile1"></param>
        /// <param name="strFile2"></param>
        /// <returns></returns>
        private static bool FileHashesMatch(string strFile1, string strFile2)
            => Stringify(GetHash(strFile1)).Equals(Stringify(GetHash(strFile2)));
    }
}