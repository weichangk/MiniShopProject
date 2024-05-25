using System;
using System.ComponentModel.DataAnnotations;
using MiniShop.Backend.Model.Code;
using MiniShop.Backend.Model.Enums;

namespace MiniShop.Backend.Model.Dto
{
    public class VipUpdateDto
    {
        [Display(Name = "ID")]
        [Required(ErrorMessage = "{0},不能为空")]
        public int Id { get; set; }

        [Display(Name = "会员类别ID")]
        [Required(ErrorMessage = "{0},不能为空")]
        public int VipTypeId { get; set; }

        [Display(Name = "姓名")]
        public string Name { get; set; }

        [Display(Name = "手机号")]
        public string Phone { get; set; }

        [Display(Name = "状态")]
        public EnumVipStatus State { get; set; }
    }
}
