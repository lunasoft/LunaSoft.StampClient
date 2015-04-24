using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LunaSoft.StampClient.Etc
{
    internal class FileUtil
    {
        internal static string GetDirPath(string path)
        {
            string directorybase = System.IO.Path.GetDirectoryName(
          System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);

            Uri uripath = new Uri(directorybase);


            string appLevel = Directory.GetParent(uripath.LocalPath).FullName;


            return Path.Combine(appLevel, path);

        }
        internal static string GetAppDirectory(string folder)
        {
            string directorybase = System.IO.Path.GetDirectoryName(
     System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);

            Uri uripath = new Uri(directorybase);

            return Path.Combine(uripath.LocalPath, folder);

        }
    }
}
