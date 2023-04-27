using Microsoft.AspNetCore.Mvc;
using ThreeLayerArchitecture.BAL;
using ThreeLayerArchitecture.DAL;
using ThreeLayerArchitecture.Models;

namespace ThreeLayerArchitecture.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserRepository userRepository;
        public UserController(IUserRepository _userRepository) 
        {
            this.userRepository = _userRepository;
        }


        public IActionResult Index()
        {
           
            var userVMs = userRepository.GetAllUsers();
            return View(userVMs);
        }

        [HttpGet]
        public IActionResult Registration()  
        {

           
            ViewBag.GenderList = userRepository.GetAllGenders();
            ViewBag.CategoryList = userRepository.GetAllCategories();

            UserRegistrationViewModel userVM = new UserRegistrationViewModel();
            //return View("~/Views/Test/Index.cshtml");
            return View("UserRegistration", userVM);

        }

        [HttpPost]
        public IActionResult Registration(UserRegistrationViewModel userVM)
        {
           

            if(userVM.TermsConditions == false)
            {
                ModelState.AddModelError("TermsConditions", "Please accept terms and condeitions");
            }

            if(userVM.Category == null)
            {
                ModelState.AddModelError("Category", "Please select category");
            }


            if (ModelState.IsValid == true)
            {
                userRepository.CreateNewUser(userVM);
                return RedirectToAction("Index");
            }
            


            ViewBag.GenderList = userRepository.GetAllGenders();
            ViewBag.CategoryList = userRepository.GetAllCategories();
            return View("UserRegistration",userVM);
        }

        public IActionResult IsEmailIdValid(string Email)
        {
            MvcprojectContext db = new MvcprojectContext();
            var isEmailIdPresentInDB = db.Users.Any(u => u.Email == Email);
            if (isEmailIdPresentInDB == true)
            {
                return Json("Entered Email is alredy Exist, please enter different Email");
            }
            else
            {
                return Json(true);
            }

        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
           
            userRepository.DeleteUser(id);
            return RedirectToAction("Index");
 
        }
    }
}
