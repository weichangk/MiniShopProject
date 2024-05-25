using System;
using System.ComponentModel.DataAnnotations;
using MiniShop.Backend.Model.Enums;
using MiniShop.Backend.Model.Code;

namespace MiniShop.Backend.Model.Dto
{
    public class PosRegisterCreateDto
    {
        [Display(Name = "唯一码")]
        [Required(ErrorMessage = "{0},不能为空")]
        public string Code { get; set; }

        [Display(Name = "设备名称")]
        [Required(ErrorMessage = "{0},不能为空")]
        public string Name { get; set; }

        [Display(Name = "是否启用")]
        [Required(ErrorMessage = "{0},不能为空")]
        public EnumEnableStatus Enable { get; set; }

        [Display(Name = "客户端版本")]
        public string ClientVersion { get; set; }

        [Display(Name = "IP")]
        public string Ip { get; set; }

        [Display(Name = "IP地址")]
        public string IpAddress { get; set; } 
    }
}
