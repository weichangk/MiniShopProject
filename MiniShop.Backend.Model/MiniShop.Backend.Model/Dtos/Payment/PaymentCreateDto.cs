using System;
using System.ComponentModel.DataAnnotations;
using MiniShop.Backend.Model.Enums;
using MiniShop.Backend.Model.Code;

namespace MiniShop.Backend.Model.Dto
{
    public class PaymentCreateDto
    {
        [Display(Name = "商店ID")]
        [Required(ErrorMessage = "{0},不能为空")]
        public Guid ShopId { get; set; }

        [Display(Name = "编码")]
        [Required(ErrorMessage = "{0},不能为空")]
        public string Code { get; set; }

        [Display(Name = "名称")]
        [Required(ErrorMessage = "{0},不能为空")]
        public string Name { get; set; }

        [Display(Name = "是否启用")]
        [Required(ErrorMessage = "{0},不能为空")]
        public EnumEnableStatus Enable { get; set; }

        [Display(Name = "是否系统内置")]
        [Required(ErrorMessage = "{0},不能为空")]
        public EnumYesOrNoStatus SystemPayment { get; set; }
    }
}
