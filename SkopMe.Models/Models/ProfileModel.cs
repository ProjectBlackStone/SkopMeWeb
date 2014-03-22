using System.ComponentModel.DataAnnotations;

namespace SkopMe.Web.Models
{
    public class ProfileModel
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }

    }
}