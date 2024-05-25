﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MiniShop.Backend.Model.Dto
{
    public class CategorieUpdateDto
    {
        [Display(Name = "ID")]
        [Required(ErrorMessage = "{0},不能为空")]
        public int Id { get; set; }

        [Display(Name = "类别名称")]
        [Required(ErrorMessage = "{0},不能为空")]
        public string Name { get; set; }
    }
}
