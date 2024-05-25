using System;
using System.ComponentModel.DataAnnotations;
using MiniShop.Backend.Model.Enums;
using MiniShop.Backend.Model.Code;

namespace MiniShop.Backend.Model.Dto
{
    public class PosRegisterDto
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "唯一码")]
        public string Code { get; set; }

        [Display(Name = "设备名称")]
        public string Name { get; set; }

        [Display(Name = "是否启用")]
        public EnumEnableStatus Enable { get; set; }

        [Display(Name = "状态描述")]
        public string EnableDes => Enable.ToDescription();

        [Display(Name = "创建时间")]
        public DateTime CreatedTime { get; set; }

        [Display(Name = "修改时间")]
        public virtual DateTime ModifiedTime { get; set; } = DateTime.Now;

        [Display(Name = "操作员")]
        public virtual string OperatorName { get; set; }

        [Display(Name = "最后登录时间")]
        public DateTime LastLoginTime { get; set; } = DateTime.Now;

        [Display(Name = "客户端版本")]
        public string ClientVersion { get; set; }

        [Display(Name = "IP")]
        public string Ip { get; set; }

        [Display(Name = "IP地址")]
        public string IpAddress { get; set; }  
    }
}
