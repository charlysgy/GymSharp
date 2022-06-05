using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace GymSharp.Utils
{
    internal class FindPath
    {
        /*
         * Methods that search for a file in the project directories
         * <return>true if file has been found and modify filename in reference with the valid path
         * false if file has not been found, filename is not change in this case</return>
         */
        public static bool FindFile(ref string filename)
        {
            string basePath = FindBase();
            List<string> dirs = Directory.GetDirectories(basePath).ToList();
            int i = 0;
            bool found = false;

            while (!found && i < dirs.Count)
            {
                if (File.Exists(dirs[i] + $"\\{filename}")) {
                    filename = Path.Combine(dirs[i], filename);
                    found = true;
                }

                foreach (string dir in Directory.GetDirectories(dirs[i]))
                {
                    dirs.Add(dir);
                }
                i++;
            }
            return found;
        }

        /*
         * Methods that search for a directory in the project directories
         * <return>true if directory has been found and modify dirname in reference with the valid path
         * false if drectory has not been found, dirname is not change in this case</return>
         */
        public static bool FindDirectory(ref string dirname)
        {
            bool found = false;
            string basePath = FindBase();
            List<string> dirs = Directory.GetDirectories(basePath).ToList();
            int i = 0;

            while (!found && i < dirs.Count)
            {
                if (dirs[i].Contains(dirname))
                {
                    dirname = dirs[i];
                    found = true;
                }

                foreach (string dir in Directory.GetDirectories(dirs[i]))
                {
                    dirs.Add(dir);
                }
                i++;
            }

            return found;
        }

        /*
         * Return the path from the current directory where the code runs to the base of the project
         * Takes no parameter
         */
        public static string FindBase()
        {
            string path = "";
            bool found = false;
            while (!found)
            {
                foreach (string dir in Directory.GetDirectories(Path.Combine("../", path)))
                {
                    if (dir.Substring(path.Length).Contains("GymSharp"))
                    {
                        found = true;
                    }
                }
               if (!found)
                    path += "../";
            }
            return path;
        }

        /*
         * Parameter : path, the path to the directory where files are going to be search
         * Returns a string array where strings are files in the path specified in parameter
         */
        public static string[] GetAllFiles(string path)
        {
            return Directory.GetFiles(path);
        }

        /*
         * Parameter : path, the path to the directory where directories are going to be search
         * Returns a string array where strings are directories in the path specified in parameter
         */
        public static string[] GetAllDir(string path)
        {
            return Directory.GetDirectories(path);
        }

        /*
         * Takes no parameter
         * Returns a string containing the absolute path of the directory where code is running
         */
        public static string GetCurrentDir()
        {
            return Directory.GetCurrentDirectory();
        }
    }
}
