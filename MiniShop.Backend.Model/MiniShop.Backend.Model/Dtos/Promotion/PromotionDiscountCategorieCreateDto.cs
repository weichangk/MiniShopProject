using System;
using System.ComponentModel.DataAnnotations;

namespace MiniShop.Backend.Model.Dto
{
    public class PromotionDiscountCategorieCreateDto
    {
        [Display(Name = "商店ID")]
        [Required(ErrorMessage = "{0},不能为空")]
        public Guid ShopId { get; set; }

        [Display(Name = "促销订单ID")]
        [Required(ErrorMessage = "{0},不能为空")]
        public int PromotionOderId { get; set; }

        [Display(Name = "类别ID")]
         [Required(ErrorMessage = "{0},不能为空")]
        public int CategorieId { get; set; }
    }
}
