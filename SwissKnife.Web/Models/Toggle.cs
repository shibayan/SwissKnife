using System.ComponentModel.DataAnnotations;

namespace SwissKnife.Web.Models
{
    public enum Toggle
    {
        [Display(Name = "オフ")]
        Off = 0,

        [Display(Name = "オン")]
        On
    }
}