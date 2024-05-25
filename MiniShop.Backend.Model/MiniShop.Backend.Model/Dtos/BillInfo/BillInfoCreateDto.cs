using System;
using System.ComponentModel.DataAnnotations;
using MiniShop.Backend.Model.Enums;

namespace MiniShop.Backend.Model.Dto
{
    public class BillInfoCreateDto
    {
        [Display(Name = "商店ID")]
        [Required(ErrorMessage = "{0},不能为空")]
        public Guid ShopId { get; set; }

        [Display(Name = "创建时间")]
        [Required(ErrorMessage = "{0},不能为空")]
        public DateTime CreatedTime { get; set; }

        [Display(Name = "操作员")]
        public virtual string OperatorName { get; set; }

        [Display(Name = "单号")]
        [Required(ErrorMessage = "{0},不能为空")]
        public string BillNo { get; set; }

        [Display(Name = "销售方式")]
        [Required(ErrorMessage = "{0},不能为空")]
        public EnumSaleWay SaleWay { get; set; }    

        [Display(Name = "销售金额")]
        [Required(ErrorMessage = "{0},不能为空")]
        public decimal SaleMoney { get; set; }

        [Display(Name = "会员ID")]
        public int MemberId { get; set; }
    }
}
