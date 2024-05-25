using System;
using System.ComponentModel.DataAnnotations;
using MiniShop.Backend.Model.Code;
using MiniShop.Backend.Model.Enums;

namespace MiniShop.Backend.Model.Dto
{
    public class StockUpdateDto
    {
        [Display(Name = "ID")]
        [Required(ErrorMessage = "{0},不能为空")]
        public int Id { get; set; }
        

        [Display(Name = "库存数量")]
        [Required(ErrorMessage = "{0},不能为空")]
        public decimal Number { get; set; }

    }
}
