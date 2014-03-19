using SkopMe.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace SkopMe.Web.WebApi
{
    public class UsersRepository : IUsersRepository
    {
        public IEnumerable<Models.UserModel> GetAll()
        {
            throw new NotImplementedException();
        }


        public Models.UserModel GetUserByName(string userName)
        {
            //Get the user from db
            MembershipUser member = Membership.GetUser(userName);

            if (member != null)
            {
                return new UserModel
                {
                    Id = Convert.ToString(member.ProviderName),
                    UserName = Convert.ToString(member.UserName),
                    Email = Convert.ToString(member.Email)
                };
            }

            return null; 

        }

        public Models.UserModel Add(Models.UserModel item)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Models.UserModel item)
        {
            throw new NotImplementedException();
        }
    }
}