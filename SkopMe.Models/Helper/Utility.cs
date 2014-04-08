using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace SkopMe.Core.Helper
{
    public class Utility
    {
        /// <summary>
        /// Extract the token information from the header
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static Token ProcessHeader(string token)
        {
            return new Token(Convert.ToString(token.Split('*')[0]), 
                             Convert.ToString(token.Split('*')[1]),
                             Convert.ToDateTime(token.Split('*')[2]));
           
        }

        /// <summary>
        /// Validate if all the header values are good
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static bool ValidateHeader(Token token)
        {
            var user = Membership.GetUser(token.UserId);

            //if valud user
            if (user != null)
            {
                //validate mac address

                //validate time

                return true;
            }

            return false;

        }
    }
}
