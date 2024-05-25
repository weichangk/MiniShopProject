using System;
using System.ComponentModel.DataAnnotations;
using MiniShop.Backend.Model.Code;
using MiniShop.Backend.Model.Enums;

namespace MiniShop.Backend.Model.Dto
{
    public class SaleFlowCreateDto
    {
        [Display(Name = "商店ID")]
        [Required(ErrorMessage = "{0},不能为空")]
        public Guid ShopId { get; set; }

        [Display(Name = "单号")]
        [Required(ErrorMessage = "{0},不能为空")]
        public string BillNo { get; set; }
        
        [Display(Name = "商品ID")]
        [Required(ErrorMessage = "{0},不能为空")]
        public int ItemId { get; set; }

        [Display(Name = "数量")]
        [Required(ErrorMessage = "{0},不能为空")]
        public decimal Qty { get; set; }

        [Display(Name = "销售售价")]
        [Required(ErrorMessage = "{0},不能为空")]
        public decimal SalePrice { get; set; }

        [Display(Name = "销售金额")]
        [Required(ErrorMessage = "{0},不能为空")]
        public decimal SaleMoney { get; set; }

        [Display(Name = "创建时间")]
        public DateTime CreatedTime { get; set; }
    }
}
