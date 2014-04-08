using SkopMe.Core.Models;
using System.Collections.Generic;

namespace SkopMe.Core.Interface.Repository
{
    public interface IUserCategoryRepository
    {
        IList<UserCategoryModel> GetUserCategories();

        UserCategoryModel GetUserCategoryById(int Id);

        int CreateUserCategory(UserCategoryModel userCategory);

        void UpdateUserCategory(UserCategoryModel userCategory);

        void DeleteUserCategory(UserCategoryModel userCategory);

    }
}
