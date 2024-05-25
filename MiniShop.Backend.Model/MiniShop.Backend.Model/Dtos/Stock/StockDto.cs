using System;
using System.ComponentModel.DataAnnotations;
using MiniShop.Backend.Model.Code;
using MiniShop.Backend.Model.Enums;

namespace MiniShop.Backend.Model.Dto
{
    public class StockDto
    {
        [Display(Name = "商店ID")]
        public Guid ShopId { get; set; }
        
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "商品ID")]
        public int ItemId { get; set; }

        [Display(Name = "货号")]
        public string ItemCode { get; set; }

        [Display(Name = "品名")]
        public string ItemName { get; set; }

        [Display(Name = "单位名称")]
        public string UnitName { get; set; }
        
        [Display(Name = "类别名称")]
        public string CategorieName { get; set; }

        [Display(Name = "库存数量")]
        public decimal Number { get; set; }

    }
}
