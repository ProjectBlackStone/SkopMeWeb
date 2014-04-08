using SkopMe.Core.Interface.Repository;
using SkopMe.Core.Interface.Services;
using SkopMe.Core.Models;
using SkopMe.Web.Models;
using System.Collections.Generic;


namespace SkopMe.Repositories
{
    /// <summary>
    /// Class to perform the CRUD operations on RegisterAccount Model
    /// </summary>
    public class RegisterAccountService : IRegisterAccountService
    {
        IRegisterAccountRepository _userRegistration;

        public RegisterAccountService(IRegisterAccountRepository repository)
        {
            _userRegistration = repository;
        }

        public RegisterModel GetUserById(string userId)
        {
            return _userRegistration.GetUserById(userId);
        }

        public bool RegisterUser(RegisterModel user)
        {
            return _userRegistration.RegisterUser(user);
        }
    }
}