using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GymSharp.MVVM.View;
using GymSharp.Utils;

namespace GymSharp.Data
{
    public static class UserProfile
    {
        private static string pathUserProfile = "userProfile.txt";

        public static string Get_firstName()
        {
            FindPath.FindFile(ref pathUserProfile);
            string res;
            using (StreamReader sr = new StreamReader(pathUserProfile))
            {
                res = sr.ReadLine();
            }
            return res;
        }

        public static string Get_lastName()
        {
            FindPath.FindFile(ref pathUserProfile);
            string res = "";
            using (StreamReader sr = new StreamReader(pathUserProfile))
            {
                for (int i = 0; i <= 1; i++)
                {
                    res = sr.ReadLine();
                }
            }
            return res;
        }

        public static int Get_age()
        {
            FindPath.FindFile(ref pathUserProfile);
            string res = "";
            using (StreamReader sr = new StreamReader(pathUserProfile))
            {
                for(int i = 0; i <= 2; i++)
                {
                    res = sr.ReadLine();
                }
            }
            return res == "" ? 0 : int.Parse(res);
        }

        public static int Get_weight()
        {
            FindPath.FindFile(ref pathUserProfile);
            string res = "";
            using (StreamReader sr = new StreamReader(pathUserProfile))
            {
                for (int i = 0; i <= 3; i++)
                {
                    res = sr.ReadLine();
                }
            }
            return res == "" ? 0 : int.Parse(res);
        }

        public static int Get_height()
        {
            FindPath.FindFile(ref pathUserProfile);
            string res = "";
            using (StreamReader sr = new StreamReader(pathUserProfile))
            {
                for (int i = 0; i <= 4; i++)
                {
                    res = sr.ReadLine();
                }
            }
            return res == "" ? 0 : int.Parse(res);
        }

        public static string Get_sexe()
        {
            FindPath.FindFile(ref pathUserProfile);
            string res = "";
            using (StreamReader sr = new StreamReader(pathUserProfile))
            {
                for (int i = 0; i <= 5; i++)
                {
                    res = sr.ReadLine();
                }
            }
            return res;
        }

        public static string Get_objective()
        {
            FindPath.FindFile(ref pathUserProfile);
            string res = "";
            using (StreamReader sr = new StreamReader(pathUserProfile))
            {
                for (int i = 0; i <= 6; i++)
                {
                    res = sr.ReadLine();
                }
            }
            return res;
        }

        public static void FillInfos(string name ="", string lastname ="", string age ="", string weight ="", string height ="", string sex ="", string objective ="")
        {
            List<string> infos = new List<string>{name, lastname, age, weight, height, sex, objective};

            FindPath.FindFile(ref pathUserProfile);

            using (StreamWriter sw = new StreamWriter(pathUserProfile))
            {
                foreach (string info in infos)
                {
                    sw.WriteLine(info);
                }
            }
        }

    }
}
