using ThreeLayerArchitecture.DAL;
using ThreeLayerArchitecture.Models;

namespace ThreeLayerArchitecture.Utility
{
    public static class ExtensionMethodDemo
    {
        public static void ConvertUserVMToUserDTO(this User user, UserRegistrationViewModel userVM)
        {
            user.Email = userVM.Email;
            user.FirstName = userVM.FirstName;
            user.LastName = userVM.LastName;
            user.GenderId = userVM.GenderId;
            user.Password = userVM.Password;
            user.MobileNumber = userVM.MobileNumber;
            user.AadharNumber = userVM.AadharNumber;
            user.Category = userVM.Category;
            user.TermsConditions = userVM.TermsConditions;
        }


        public static void ConvertUserDTOToUserVM(this UserRegistrationViewModel userVM, User user)
        {
            userVM.Id = user.Id;
            userVM.Email = user.Email;
            userVM.FirstName = user.FirstName;
            userVM.LastName = user.LastName;
            userVM.GenderId = user.GenderId;
            userVM.GenderName = user.Gender.Text;
            userVM.MobileNumber = user.MobileNumber;
            userVM.AadharNumber = user.AadharNumber;
            userVM.Category = user.Category;
        }
    }
}
