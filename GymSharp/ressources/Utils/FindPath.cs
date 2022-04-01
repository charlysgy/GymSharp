using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GymSharp.ressources.Utils
{
    internal class FindPath
    {
        public static string FindFile(string filename)
        {
            string basePath = FindBase();
            string path = "";
            List<string> dirs = new List<string>();

            foreach (string dir in Directory.GetDirectories(basePath))
            {
                if (File.Exists(path)) //Terminer la recherche de fichier
            }
        }

        private static string FindBase()
        {
            string path = "";
            bool found = false;
            while (!found)
            {
                foreach (string dir in Directory.GetDirectories(Path.Combine("../", path)))
                {
                    if (dir.Substring(path.Length) == "GymSharp")
                    {
                        found = true;
                    }
                }
            }
            return path;
        }
        
        private static List<string> ExploreDir(string dir)
        {
            List<string> list = new List<string>();

            foreach (string file in Directory.GetFiles(dir))
            {
                list.Add(file);
            }

            return list;
        }
    }
}
