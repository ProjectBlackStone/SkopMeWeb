﻿using SkopMe.Core.Models;
using SkopMe.Web.Models;
using System.Collections.Generic;

namespace SkopMe.Core.Interface.Repository
{
    public interface IRegisterAccountService
    {
        RegisterModel GetUserById(string userId);

        bool RegisterUser(RegisterModel user);

    }
}
