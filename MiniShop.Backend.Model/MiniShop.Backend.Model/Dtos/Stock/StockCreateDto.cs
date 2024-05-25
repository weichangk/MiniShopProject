using System;
using System.ComponentModel.DataAnnotations;
using MiniShop.Backend.Model.Code;
using MiniShop.Backend.Model.Enums;

namespace MiniShop.Backend.Model.Dto
{
    public class StockCreateDto
    {
        [Display(Name = "ID")]
        public int Id { get; set; }
        
        [Display(Name = "商店ID")]
        [Required(ErrorMessage = "{0},不能为空")]
        public Guid ShopId { get; set; }
        
        [Display(Name = "商品ID")]
        [Required(ErrorMessage = "{0},不能为空")]
        public int ItemId { get; set; }

        [Display(Name = "库存数量")]
        [Required(ErrorMessage = "{0},不能为空")]
        public decimal Number { get; set; }

    }
}
