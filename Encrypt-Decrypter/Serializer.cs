using SkopMe.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encrypt_Decrypter
{
    class Serializer
    {
        public string SerializeClass()
        {
            //return new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(new RegisterModel() { UserName = "ashwin", Password = "pass" });

            return new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(new LoginModel() { UserName = "ashwin", Password = "pass" , RememberMe = false});
        }

    }
}
