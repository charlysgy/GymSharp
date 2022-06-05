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
        public static string firstName;
        public static string lastName;
        public static int age;
        public static int weight;

        public static string Get_firstName()
        {
            FindPath.FindFile(ref pathUserProfile);
            using (StreamReader sr = new StreamReader(pathUserProfile))
            {
                firstName = sr.ReadLine();
            }
            return firstName;
        }

        public static string Get_lastName()
        {
            FindPath.FindFile(ref pathUserProfile);
            using (StreamReader sr = new StreamReader(pathUserProfile))
            {
                for (int i = 0; i <= 1; i++)
                {
                    lastName = sr.ReadLine();
                }
            }
            return lastName;
        }

        public static int Get_age()
        {
            FindPath.FindFile(ref pathUserProfile);
            using (StreamReader sr = new StreamReader(pathUserProfile))
            {
                string res;
                for(int i = 0; i <= 2; i++)
                {
                    res = sr.ReadLine();
                }
            }
            return age;
        }

        public static int Get_weight()
        {
            FindPath.FindFile(ref pathUserProfile);
            using (StreamReader sr = new StreamReader(pathUserProfile))
            {
                firstName = sr.ReadLine();
            }
            return weight;
        }

        public static void FillFirstName(string name)
        {
            FindPath.FindFile(ref pathUserProfile);
            using (StreamWriter sw = new StreamWriter(pathUserProfile))
            {
                sw.Write(name);
            }
        }
    }
}
