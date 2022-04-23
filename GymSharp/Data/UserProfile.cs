using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GymSharp.MVVM.View;

namespace GymSharp.Data
{
    public static class UserProfile
    {
        private const string PATHUSERPROFILE = "../../Data/userProfile.txt";
        public static string firstName;
        public static string lastName;
        public static int age;
        public static int weight;

        public static string Get_firstName()
        {
            using (StreamReader sr = new StreamReader(PATHUSERPROFILE))
            {
                firstName = sr.ReadLine();
            }
            return firstName;
        }

        public static string Get_lastName()
        {
            using (StreamReader sr = new StreamReader(PATHUSERPROFILE))
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
            using (StreamReader sr = new StreamReader(PATHUSERPROFILE))
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
            using (StreamReader sr = new StreamReader(PATHUSERPROFILE))
            {
                firstName = sr.ReadLine();
            }
            return weight;
        }

        public static void FillFirstName(FirstStartView view)
        {
            string FirstNameToFill = view.FirstNameBox.Text;
            Console.WriteLine("DZ" + view.FirstNameBox.Text);
            using (StreamWriter sw = new StreamWriter(PATHUSERPROFILE))
            {
                sw.Write(FirstNameToFill);
            }
        }
    }
}
