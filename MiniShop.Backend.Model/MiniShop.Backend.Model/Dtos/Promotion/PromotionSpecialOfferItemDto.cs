using System;
using System.ComponentModel.DataAnnotations;

namespace MiniShop.Backend.Model.Dto
{
    public class PromotionSpecialOfferItemDto
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "商店ID")]
        public Guid ShopId { get; set; }

        [Display(Name = "商品ID")]
        public int ItemId { get; set; }

        [Display(Name = "货号")]
        public string ItemCode { get; set; }

        [Display(Name = "品名")]
        public string ItemName { get; set; }

        [Display(Name = "单位")]
        public string UnitName { get; set; }

        [Display(Name = "零售价")]
        public decimal Price { get; set; }

        [Display(Name = "特价")]
        public decimal SpecialPrice { get; set; }
    }
}
