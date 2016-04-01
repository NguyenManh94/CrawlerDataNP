using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//TODO Comment FileProcess
namespace SSWA_ExtractData.Common.StringProcess
{
    /// <summary>
    /// Create By: ManhNV1 -Date: 03/29/2016
    /// Description: File Process (Directory, FileInfor)
    /// </summary>
    class SEDFileProcess
    {
        /// <summary>
        /// [EN] CheckDirectoryPathExist
        /// Create By: ManhNV1 -Date: 03/29/2016
        /// Description: Check the directory path exists
        /// </summary>
        /// <param name="path">The path to the Folder</param>
        /// <returns>true: if path exist | else false</returns>
        public static bool CheckDirectoryPathExist(string path)
        {
            return Directory.Exists(path);
        }

        /// <summary>
        /// [EN] CheckFilePathExist
        /// Create By: ManhNV1 -Date: 03/29/2016
        /// Description: Check the file path exists
        /// </summary>
        /// <param name="path">The path to the Folder</param>
        /// <returns>true: if path exist | else false</returns>
        public static bool CheckFilePathExist(string path)
        {
            var fileInfor = new FileInfo(path);
            return fileInfor.Exists;
        }

        public static void CreateNewFile(string path)
        {
            if (!CheckFilePathExist(path))
                Directory.CreateDirectory(path);
        }

        public static void CoppyFile(string pathFileCoppy, string destFileName)
        {
            var fileInfor = new FileInfo(pathFileCoppy);
            fileInfor.CopyTo(destFileName + @"\" + fileInfor.Name, true);
        }
    }
}
