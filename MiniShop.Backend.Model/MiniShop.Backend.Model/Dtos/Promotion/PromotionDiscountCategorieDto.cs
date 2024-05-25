using System;
using System.ComponentModel.DataAnnotations;

namespace MiniShop.Backend.Model.Dto
{
    public class PromotionDiscountCategorieDto
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "商店ID")]
        public Guid ShopId { get; set; }

        [Display(Name = "类别ID")]
        public int CategorieId { get; set; }

        [Display(Name = "编码")]
        public int CategorieCode { get; set; }

        [Display(Name = "类别")]
        public string CategorieName { get; set; }
    }
}
