using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymSharp.Data;

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
            ProfileFirstName = UserProfile.firstName;
            ProfileLastName = UserProfile.lastName;
            ProfileAge = Convert.ToString(UserProfile.age);
            ProfileWeight = Convert.ToString(UserProfile.weight);
            ///ProfileHeight = Convert.ToString(View.ProfileView.height)
        }
        
    }
}
