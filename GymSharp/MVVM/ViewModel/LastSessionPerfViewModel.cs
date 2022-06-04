using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymSharp.Utils;
using System.IO;
using GymSharp.ressources.enums;
using GymSharp.MVVM.View;

namespace GymSharp.MVVM.ViewModel
{
    public class LastSessionPerfViewModel
    {
        public static LastSessionPerfView View { get; set; }
        public string Title { get; set; }
        public string LastDayTitle { get; set; }


        public static void DisplayLastSession()
        {
            string path = "exoData.txt";
            if (!FindPath.FindFile(ref path))
                throw new Exception("File not found excpetion");
            

            StreamReader sr = new StreamReader(path);
            int? day = null;
            foreach (string line in sr.ReadToEnd().Split('\n').Reverse())
            {
                string[] parts = line.Split('/');

                if (day is null)
                {
                    day = int.Parse(parts[0]);
                }
                else
                {
                    if (int.Parse(parts[0]) == day)
                    {

                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}
