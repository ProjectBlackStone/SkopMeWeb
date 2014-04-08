using NHibernate;
using SkopMe.Core.Interface.Repository;
using SkopMe.Core.Models;
using System.Collections.Generic;

namespace SkopMe.Repositories
{
    /// <summary>
    /// Class to perform the CRUD operations on UserCategories
    /// </summary>
    public class UserCategoryRepository : BaseRepository<UserCategoryRepository>, IUserCategoryRepository
    {
     
        public IList<UserCategoryModel> GetUserCategories()
        {
            IList<UserCategoryModel> userCategories = _session
                                    .CreateCriteria(typeof(UserCategoryModel))
                                    .List<UserCategoryModel>();
            
            //NHibernate query 
            //IQuery query = _session.CreateSQLQuery("select * from usercategorymodel");
            //userCategories = query.List<UserCategoryModel>();

            
            return userCategories;
        }

        public UserCategoryModel GetUserCategoryById(int Id)
        {
            UserCategoryModel userCategory = new UserCategoryModel();

            userCategory = _session.Get<UserCategoryModel>(Id);
            
            return userCategory;
        }

        public int CreateUserCategory(UserCategoryModel userCategory)
        {
            int categoryId  = 0;
            //Perform transaction 
            using (ITransaction transaction = _session.BeginTransaction())
            {
                _session.Save(userCategory);
                transaction.Commit();
            }
            return categoryId;
        }

        public void UpdateUserCategory(UserCategoryModel userCategory)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                _session.Update(userCategory);
                transaction.Commit();
            }            
        }

        public void DeleteUserCategory(UserCategoryModel userCategory)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                _session.Delete(userCategory);
                transaction.Commit();
            }            
        }
    }
}