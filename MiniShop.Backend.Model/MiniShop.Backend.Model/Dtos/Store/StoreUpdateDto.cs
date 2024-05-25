using System;
using System.ComponentModel.DataAnnotations;
using MiniShop.Backend.Model.Enums;

namespace MiniShop.Backend.Model.Dto
{
    public class StoreUpdateDto
    {
        [Display(Name = "ID")]
        [Required(ErrorMessage = "{0},不能为空")]
        public int Id { get; set; }

        [Display(Name = "门店ID")]
        [Required(ErrorMessage = "{0},不能为空")]
        public Guid StoreId { get; set; }

        [Display(Name = "商店ID")]
        [Required(ErrorMessage = "{0},不能为空")]
        public Guid ShopId { get; set; }

        [Display(Name = "门店名称")]
        [Required(ErrorMessage = "{0},不能为空")]
        public string Name { get; set; }

        [Display(Name = "联系人")]
        [Required(ErrorMessage = "{0},不能为空")]
        public string Contacts { get; set; }

        [Display(Name = "手机号")]
        [RegularExpression(@"^(13[0-9]|14[579]|15[0-3,5-9]|16[6]|17[0135678]|18[0-9]|19[89])\d{8}$", ErrorMessage = "{0}的格式不正确")]
        public string Phone { get; set; }

        [Display(Name = "地址")]
        public string Address { get; set; }

        [Display(Name = "状态")]
        [Required(ErrorMessage = "{0},不能为空")]
        public EnumStoreStatus State { get; set; }
    }
}
