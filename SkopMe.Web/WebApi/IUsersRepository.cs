using SkopMe.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkopMe.Web.WebApi
{
    interface IUsersRepository
    {
        IEnumerable<UserModel> GetAll();
        UserModel GetUserByName(string userName);
        UserModel Add(UserModel item);
        void Remove(int id);
        bool Update(UserModel item);
    }
}
