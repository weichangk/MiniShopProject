﻿using System;
using System.ComponentModel.DataAnnotations;

namespace MiniShop.Backend.Model.Dto
{
    public class PurchaseReceiveOderItemUpdateDto
    {
        [Display(Name = "ID")]
        [Required(ErrorMessage = "{0},不能为空")]
        public int Id { get; set; }
 
        [Display(Name = "商品ID")]
        [Required(ErrorMessage = "{0},不能为空")]
        public int ItemId { get; set; }

        [Display(Name = "数量")]
        [Range(0.01,99999, ErrorMessage = "{0},在 0.01 - 99999 之间")]
        public decimal Number { get; set; }

        [Display(Name = "赠送数量")]
        [Range(0, 999, ErrorMessage = "{0},在 0.01 - 999 之间")]
        public decimal GiveNumber { get; set; }

        [Display(Name = "小计金额")]
        [Required(ErrorMessage = "{0},不能为空")]
        public decimal Amount { get; set; }

        [Display(Name = "实际进货价")]
        [Required(ErrorMessage = "{0},不能为空")]
        public decimal RealPurchasePrice { get; set; }

        [Display(Name = "备注")]
        public string Remark { get; set; }
    }
}
