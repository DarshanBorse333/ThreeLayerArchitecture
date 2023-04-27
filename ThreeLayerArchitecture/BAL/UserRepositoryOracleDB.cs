using ThreeLayerArchitecture.DAL;
using ThreeLayerArchitecture.Models;

namespace ThreeLayerArchitecture.BAL
{
    public class UserRepositoryOracleDB : IUserRepository
    {
        public void CreateNewUser(UserRegistrationViewModel userVM)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public List<Gender> GetAllGenders()
        {
            throw new NotImplementedException();
        }

        public List<UserRegistrationViewModel> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public User GetUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
