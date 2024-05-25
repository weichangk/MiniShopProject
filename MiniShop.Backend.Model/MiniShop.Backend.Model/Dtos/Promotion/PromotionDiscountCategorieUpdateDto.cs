using System;
using System.ComponentModel.DataAnnotations;

namespace MiniShop.Backend.Model.Dto
{
    public class PromotionDiscountCategorieUpdateDto
    {
        [Display(Name = "ID")]
        [Required(ErrorMessage = "{0},不能为空")]
        public int Id { get; set; }

        [Display(Name = "类别ID")]
         [Required(ErrorMessage = "{0},不能为空")]
        public int CategorieId { get; set; }
    }
}
