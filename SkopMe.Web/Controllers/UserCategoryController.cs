using SkopMe.Web.Models;
using SkopMe.Web.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            var userCategory = new UserCategoryModel();
            return View(userCategory);
        }


        // 
        // POST: /UserCategory/Create 
        [HttpPost]
        public ActionResult Create(UserCategoryModel userCategory)
        {
            try
            {
                _userCategory.CreateUserCategory(userCategory);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // 
        // GET: /UserCategory/Edit/5 
        public ActionResult Edit(int id)
        {
            var Emp = _userCategory.GetUserCategoryById(id);
            return View(Emp);
        }
        // 
        // POST: /EmployeeInfo/Edit/5 
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
        // 
        // GET: /EmployeeInfo/Delete/5 
        public ActionResult Delete(int id)
        {
            var userCategory = _userCategory.GetUserCategoryById(id);
            return View(userCategory);
        }
        // 
        // POST: /EmployeeInfo/Delete/5 
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
