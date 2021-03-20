using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public enum Gender
    {
        [Display(Name = "زن")]
        Female = 0,

        [Display(Name = "مرد")]
        Male = 1
    }
}
