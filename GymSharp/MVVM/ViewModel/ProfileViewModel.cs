using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymSharp.Data;
using System.Windows.Controls;
using GymSharp.MVVM.View;

namespace GymSharp.MVVM.ViewModel
{
    public class ProfileViewModel
    {
        public string ProfileFirstName { get; set; }
        public string ProfileLastName { get; set; }
        public string ProfileAge { get; set; }
        public string ProfileWeight { get; set; }
        public string ProfileHeight { get; set; }
        public ProfileViewModel()
        {
            ProfileFirstName = UserProfile.Get_firstName();
            ProfileLastName = UserProfile.Get_lastName();
            ProfileAge = UserProfile.Get_age().ToString();
            ProfileWeight = UserProfile.Get_weight().ToString();
            ProfileHeight = UserProfile.Get_height().ToString();
        }
        
    }
}
