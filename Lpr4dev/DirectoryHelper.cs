using System;
using System.IO;

namespace Lpr4dev
{
    public static class DirectoryHelper
    {
        public static string GetDataDir(CommandLineOptions options)
        {
            return string.IsNullOrEmpty(options.BaseAppDataPath)
                ? Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "lpr4dev")
                : options.BaseAppDataPath;
        }
    }
}