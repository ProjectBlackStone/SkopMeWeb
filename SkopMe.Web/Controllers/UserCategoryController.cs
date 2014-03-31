using SkopMe.Core.Interface.Repository;
using SkopMe.Core.Interface.Services;
using SkopMe.Core.Models;
using SkopMe.Repositories;
using System.Web.Mvc;

namespace SkopMe.Web.Controllers
{
    public class UserCategoryController : Controller
    {
        IUserCategoryService _userCategoryService;

        public UserCategoryController(IUserCategoryService userCategoryService) 
        {
            _userCategoryService = userCategoryService; 
        } 

        public ActionResult Index()
        {
            var userCategories = _userCategoryService.GetUserCategories();
            return View(userCategories); 
        }

        public ActionResult Create()
        {
            var userCategories = _userCategoryService.GetUserCategories();
            return View(userCategories);
        }
        
        // POST: /UserCategory/Create 
        [HttpPost]
        public ActionResult Create(UserCategoryModel userCategory)
        {            
            _userCategoryService.CreateUserCategory(userCategory);
            return RedirectToAction("Index", "Home");             
        }

        
        // GET: /UserCategory/Edit/5 
        public ActionResult Edit(int id)
        {
            var Emp = _userCategoryService.GetUserCategoryById(id);
            return View(Emp);
        }
        
        // POST: /UserCategory/Edit/5 
        [HttpPost]
        public ActionResult Edit(int id, UserCategoryModel userCategory)
        {
            try
            {
                _userCategoryService.UpdateUserCategory(userCategory);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
         
        // GET: /UserCategory/Delete/5 
        public ActionResult Delete(int id)
        {
            var userCategory = _userCategoryService.GetUserCategoryById(id);
            return View(userCategory);
        }
         
        // POST: /UserCategory/Delete/5 
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var userCategory = _userCategoryService.GetUserCategoryById(id);
                _userCategoryService.DeleteUserCategory(userCategory);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        } 
    }
}
