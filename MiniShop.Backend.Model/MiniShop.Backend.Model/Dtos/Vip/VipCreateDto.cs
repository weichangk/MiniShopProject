using System;
using System.ComponentModel.DataAnnotations;
using MiniShop.Backend.Model.Code;
using MiniShop.Backend.Model.Enums;

namespace MiniShop.Backend.Model.Dto
{
    public class VipCreateDto
    {

        [Display(Name = "商店ID")]
        [Required(ErrorMessage = "{0},不能为空")]
        public Guid ShopId { get; set; }

        [Display(Name = "会员类别ID")]
        [Required(ErrorMessage = "{0},不能为空")]
        public int VipTypeId { get; set; }

        [Display(Name = "姓名")]
        public string Name { get; set; }

        [Display(Name = "卡号")]
        [Required(ErrorMessage = "{0},不能为空")]
        public string Code { get; set; }

        [Display(Name = "性别")]
        public EnumSex Sex { get; set; }

        [Display(Name = "生日")]
        [Required(ErrorMessage = "{0},不能为空")]
        public DateTime Birthday { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "{0},不能为空")]
        [Display(Name = "密码")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "确认密码")]
        [Compare("Password", ErrorMessage = "密码和确认密码不匹配")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "手机号")]
        public string Phone { get; set; }

        [Display(Name = "有效期")]
        public DateTime ValidDate { get; set; } = DateTime.Now;

        [Display(Name = "状态")]
        public EnumVipStatus State { get; set; }
    }
}
