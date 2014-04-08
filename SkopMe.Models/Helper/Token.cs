using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkopMe.Core.Helper
{
    /// <summary>
    /// Class to hold the token information
    /// </summary>
    public class Token
    {
        public Token(string userId, string macAddress,DateTime expiryDate)
        {
            UserId = userId;
            MacAddress = macAddress;
            ExpiryDate = expiryDate;
        }

        public string UserId { get; set; }
        public string MacAddress { get; set; }
        public DateTime ExpiryDate { get; set; }

    }
}
