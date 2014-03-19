using NHibernate;
using NHibernate.Cfg;
using SkopMe.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkopMe.Web.Repository
{
    /// <summary>
    /// Class to perform the CRUD operations on UserCategories
    /// </summary>
    public class UserCategoryRepository
    {
        //Define the session factory, this is per database 
        ISessionFactory _sessionFactory;

        /// <summary> 
        /// Method to create session and manage entities 
        /// </summary> 
        /// <returns></returns> 
        ISession OpenSession()
        {
            if (_sessionFactory == null)
            {
                var configuration = new Configuration();
                var data = configuration.Configure
                                    (
                                        HttpContext.Current.
                                        Server.MapPath(@"..\Models\Configuration\hibernate.cfg.xml")
                                    );
                configuration.AddDirectory(new System.IO.DirectoryInfo
                                    (
                                        HttpContext.Current
                                        .Server.MapPath(@"..\Models\Configuration\Mapping\"))
                                    );
                _sessionFactory = data.BuildSessionFactory();
            }
            return _sessionFactory.OpenSession();
        }

        public IList<UserCategoryModel> GetUserCategories()
        {
            IList<UserCategoryModel> userCategories;
            using (ISession session = OpenSession())
            {
                //NHibernate query 
                IQuery query = session.CreateQuery("from UserCategories");
                userCategories = query.List<UserCategoryModel>();
            }
            return userCategories;
        }

        public UserCategoryModel GetUserCategoryById(int Id)
        {
            UserCategoryModel userCategory = new UserCategoryModel();
            using (ISession session = OpenSession())
            {
                userCategory = session.Get<UserCategoryModel>(Id);
            }
            return userCategory;
        }

        public int CreateUserCategory(UserCategoryModel userCategory)
        {
            int categoryId  = 0;
            using (ISession session = OpenSession())
            {
                //Perform transaction 
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(userCategory);
                    transaction.Commit();
                }
            }
            return categoryId;
        }

        public void UpdateUserCategory(UserCategoryModel userCategory)
        {
            using (ISession session = OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(userCategory);
                    transaction.Commit();
                }
            }
        }

        public void DeleteUserCategory(UserCategoryModel userCategory)
        {
            using (ISession session = OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(userCategory);
                    transaction.Commit();
                }
            }
        }
    }
}