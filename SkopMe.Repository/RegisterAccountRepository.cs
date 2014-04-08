using NHibernate;
using SkopMe.Core.Interface.Repository;
using SkopMe.Core.Models;
using SkopMe.Web.Models;
using System;
using System.Collections.Generic;
using System.Web.Security;

namespace SkopMe.Repositories
{
    /// <summary>
    /// Class to perform the CRUD operations on User Registration Account Models
    /// </summary>
    public class RegisterAccountRepository : BaseRepository<RegisterAccountRepository>, IRegisterAccountRepository
    {     
        public RegisterModel GetUserById(string userId)
        {
            RegisterModel userCategory = new RegisterModel();

            userCategory = _session.Get<RegisterModel>(userId);

            return userCategory;
        }

        public bool RegisterUser(RegisterModel user)
        {
            try
            {
                var newUser = Membership.CreateUser(user.UserName, user.Password);

                if (newUser != null)
                    return true;//success
            }
            catch (Exception exception)
            {
                //TODO
                throw exception;
                
            }
            return false;//error occured

        }
    }
}