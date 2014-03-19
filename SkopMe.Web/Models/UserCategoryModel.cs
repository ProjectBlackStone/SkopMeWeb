using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SkopMe.Web.Models
{
    public class UserCategoryModel
    {
        [Display(Name = "pId")]
        public virtual Int32 pId { get; set; }

        [Display(Name = "Username")]
        public virtual string Username { get; set; }

        [Display(Name = "Categories")]
        public virtual string Categories { get; set; }
    }
}