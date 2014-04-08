using SkopMe.Core.Interface.Repository;
using SkopMe.Core.Interface.Services;
using SkopMe.Core.Models;
using System.Collections.Generic;


namespace SkopMe.Repositories
{
    /// <summary>
    /// Class to perform the CRUD operations on UserCategories
    /// </summary>
    public class UserCategoryService : IUserCategoryService
    {
        IUserCategoryRepository _userCategory;

        public UserCategoryService(IUserCategoryRepository repository)            
        {
            _userCategory = repository; 
        } 
            
        public IList<UserCategoryModel> GetUserCategories()
        {
            return _userCategory.GetUserCategories(); 
        }

        public UserCategoryModel GetUserCategoryById(int Id)
        {
            return _userCategory.GetUserCategoryById(Id);
        }

        public int CreateUserCategory(UserCategoryModel userCategory)
        {
            return _userCategory.CreateUserCategory(userCategory);
        }

        public void UpdateUserCategory(UserCategoryModel userCategory)
        {
            _userCategory.UpdateUserCategory(userCategory);            
        }

        public void DeleteUserCategory(UserCategoryModel userCategory)
        {
            _userCategory.DeleteUserCategory(userCategory);
        }
    }
}