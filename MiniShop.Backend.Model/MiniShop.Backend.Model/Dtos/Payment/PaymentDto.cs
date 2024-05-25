using System;
using System.ComponentModel.DataAnnotations;
using MiniShop.Backend.Model.Enums;
using MiniShop.Backend.Model.Code;

namespace MiniShop.Backend.Model.Dto
{
    public class PaymentDto
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "商店ID")]
        public Guid ShopId { get; set; }

        [Display(Name = "编码")]
        public string Code { get; set; }

        [Display(Name = "名称")]
        public string Name { get; set; }

        [Display(Name = "是否启用")]
        public EnumEnableStatus Enable { get; set; }

        [Display(Name = "状态描述")]
        public string EnableDes => Enable.ToDescription();

        [Display(Name = "是否系统内置")]
        public EnumYesOrNoStatus SystemPayment { get; set; }

        [Display(Name = "状态描述")]
        public string SystemPaymentDes => SystemPayment.ToDescription();

        [Display(Name = "创建时间")]
        public DateTime CreatedTime { get; set; }
    }
}
