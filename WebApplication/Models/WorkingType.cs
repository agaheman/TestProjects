using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public enum WorkingType
    {
        [Display(Name = "تمام وقت")]
        FullTime = 0,

        [Display(Name = "پاره وقت")]
        PartTime = 1,

        [Display(Name = "ساعتی")]
        Hourly = 2,
    }
}
