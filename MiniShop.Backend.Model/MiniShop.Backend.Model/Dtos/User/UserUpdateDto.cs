using MiniShop.Backend.Model.Enums;
using System.ComponentModel.DataAnnotations;

namespace MiniShop.Backend.Model.Dto
{
    public class UserUpdateDto
    {
        [Display(Name = "用户ID")]
        [Required(ErrorMessage = "{0},不能为空")]
        public string Id { get; set; }

        [Display(Name = "用户名")]
        [RegularExpression(@"^[a-zA-Z0-9_-]{4,16}$", ErrorMessage = "{0}的格式不正确，4到16位（字母，数字，下划线，减号）")]
        public string UserName { get; set; }

        [Display(Name = "手机号")]
        [RegularExpression(@"^(13[0-9]|14[579]|15[0-3,5-9]|16[6]|17[0135678]|18[0-9]|19[89])\d{8}$", ErrorMessage = "{0}的格式不正确")]
        public string PhoneNumber { get; set; }

        [Display(Name = "邮箱")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "{0}的格式不正确")]
        public string Email { get; set; }

        [Display(Name = "职称")]
        [Required(ErrorMessage = "{0},不能为空")]
        public EnumRole Rank { get; set; }

        [Display(Name = "是否冻结")]
        [Required(ErrorMessage = "{0},不能为空")]
        public bool IsFreeze { get; set; }
    }
}