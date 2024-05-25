using System;
using System.ComponentModel.DataAnnotations;

namespace MiniShop.Backend.Model.Dto
{
    public class PromotionSpecialOfferItemUpdateDto
    {
        [Display(Name = "ID")]
        [Required(ErrorMessage = "{0},不能为空")]
        public int Id { get; set; }

        [Display(Name = "商品ID")]
        [Required(ErrorMessage = "{0},不能为空")]
        public int ItemId { get; set; }

        [Display(Name = "特价")]
        [Required(ErrorMessage = "{0},不能为空")]
        public decimal SpecialPrice { get; set; }
    }
}
