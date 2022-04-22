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
    public class UserProfile
    {
        private const string PATHUSERPROFILE = "../../Data/userProfile.txt";
        public string firstName;
        public string lastName;
        public int age;
        public int weight;

        public string Get_firstName()
        {
            using (StreamReader sr = new StreamReader(PATHUSERPROFILE))
            {
                firstName = sr.ReadLine();
            }
            return firstName;
        }

        public string Get_lastName()
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

        public int Get_age()
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

        public int Get_weight()
        {
            using (StreamReader sr = new StreamReader(PATHUSERPROFILE))
            {
                firstName = sr.ReadLine();
            }
            return weight;
        }

        public void FillFirstName()
        {
            FirstStartView firstStartView = new FirstStartView();
            string FirstNameToFill = firstStartView.FirstName;
            using (StreamWriter sw = new StreamWriter(PATHUSERPROFILE))
            {
                sw.Write(FirstNameToFill);
            }
        }
    }
}
