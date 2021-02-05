using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class SampleModel
    {
        [HiddenInput]
        public int Id { get; set; }

        [Display(Name = "نام")]
        [Required(AllowEmptyStrings =false , ErrorMessage = "وارد کردن نام الزامی است.")]
        public string FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "وارد کردن نام خانوادگی الزامی است.")]
        public string LastName { get; set; }

        [HiddenInput]
        public string EditDescription { get; set; }
    }
}
