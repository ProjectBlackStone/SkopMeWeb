using SkopMe.Core.Models;
using SkopMe.Repositories;
using System.Web.Mvc;

namespace SkopMe.Web.Controllers
{
    public class UserCategoryController : Controller
    {
        UserCategoryRepository _userCategory;
        public UserCategoryController() 
        {
            _userCategory = new UserCategoryRepository(); 
        } 

        public ActionResult Index()
        {
            var userCategories = _userCategory.GetUserCategories();
            return View(userCategories); 
        }

        public ActionResult Create()
        {
            var userCategories = _userCategory.GetUserCategories();
            return View(userCategories);
        }
        
        // POST: /UserCategory/Create 
        [HttpPost]
        public ActionResult Create(UserCategoryModel userCategory)
        {            
            _userCategory.CreateUserCategory(userCategory);
            return RedirectToAction("Index", "Home");             
        }

        
        // GET: /UserCategory/Edit/5 
        public ActionResult Edit(int id)
        {
            var Emp = _userCategory.GetUserCategoryById(id);
            return View(Emp);
        }
        
        // POST: /UserCategory/Edit/5 
        [HttpPost]
        public ActionResult Edit(int id, UserCategoryModel userCategory)
        {
            try
            {
                _userCategory.UpdateUserCategory(userCategory);
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
            var userCategory = _userCategory.GetUserCategoryById(id);
            return View(userCategory);
        }
         
        // POST: /UserCategory/Delete/5 
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var userCategory = _userCategory.GetUserCategoryById(id);
                _userCategory.DeleteUserCategory(userCategory);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        } 
    }
}
