using System;
using System.ComponentModel.DataAnnotations;

namespace SkopMe.Core.Models
{
    public class UserCategoryModel
    {
        [Display(Name = "pId")]
        public virtual int pId { get; set; }

        [Display(Name = "Username")]
        public virtual string Username { get; set; }

        [Display(Name = "Categories")]
        public virtual string Categories { get; set; }
    }
}