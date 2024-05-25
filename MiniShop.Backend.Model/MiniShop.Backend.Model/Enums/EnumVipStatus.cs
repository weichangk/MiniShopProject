﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MiniShop.Backend.Model.Enums
{
    /// <summary>
    /// 会员状态
    /// </summary>
    public enum EnumVipStatus
    {
        [Description("正常")]
        [Display(Name = "正常")]
        Normal,
        [Description("挂失")]
        [Display(Name = "挂失")]
        Loss,
    }
}
