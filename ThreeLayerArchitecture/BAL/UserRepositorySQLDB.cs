using ThreeLayerArchitecture.DAL;
using ThreeLayerArchitecture.Models;
using Microsoft.EntityFrameworkCore;
using ThreeLayerArchitecture.Utility;

namespace ThreeLayerArchitecture.BAL    
{
    public class UserRepositorySQLDB: IUserRepository
    {

        private readonly MvcprojectContext db;
        public UserRepositorySQLDB(MvcprojectContext _db)
        {
            this.db = _db;
        }

        public List<Gender> GetAllGenders()
        {
            

            var genders = db.Genders.ToList();
            return genders;

        }

 
       public void CreateNewUser(UserRegistrationViewModel userVM)
        {
            

            //User user = new User(userVM);

            User user = new User();
            user.ConvertUserVMToUserDTO(userVM);

            db.Users.Add(user);
            db.SaveChanges();
        }

        public List<Category> GetAllCategories()
        {
            List<Category> categories = new List<Category>();
               
            Category category1 = new Category();
            category1.Id = 1;
            category1.Name = "General";

            Category category2 = new Category();
            category2.Id = 2;
            category2.Name = "OBC";

            Category category3 = new Category();
            category3.Id = 3;
            category3.Name = "Other";

            categories.Add(category1);
            categories.Add(category2);
            categories.Add(category3);

            return categories;
        }

        public List<UserRegistrationViewModel> GetAllUsers()
        {
            
            //List<User> usersPrevious = db.Users.ToList();
            List<User> users = db.Users.Include(user=>user.Gender).ToList();

            List<UserRegistrationViewModel> userRegistrationViewModel = new List<UserRegistrationViewModel>();

            foreach(var user in users)
            {
                //UserRegistrationViewModel userVM = new UserRegistrationViewModel(user);
                UserRegistrationViewModel userVM = new UserRegistrationViewModel();
                userVM.ConvertUserDTOToUserVM(user);

                userRegistrationViewModel.Add(userVM);
                

            }

            return userRegistrationViewModel;

        }

        public void DeleteUser(int id)
        {
            

            var user = GetUser(id);
            if(user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }

        }

        public User GetUser(int id)
        {
            
            var user = db.Users.FirstOrDefault(user => user.Id == id);
            return user;
        }
    }
}
