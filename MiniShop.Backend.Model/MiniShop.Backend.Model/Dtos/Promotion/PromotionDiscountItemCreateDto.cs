﻿using System;
using System.ComponentModel.DataAnnotations;

namespace MiniShop.Backend.Model.Dto
{
    public class PromotionDiscountItemCreateDto
    {

        [Display(Name = "商店ID")]
        [Required(ErrorMessage = "{0},不能为空")]
        public Guid ShopId { get; set; }

        [Display(Name = "促销订单ID")]
        [Required(ErrorMessage = "{0},不能为空")]
        public int PromotionOderId { get; set; }

        [Display(Name = "商品ID")]
        [Required(ErrorMessage = "{0},不能为空")]
        public int ItemId { get; set; }
    }
}
