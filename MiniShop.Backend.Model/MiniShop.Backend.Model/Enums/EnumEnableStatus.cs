using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MiniShop.Backend.Model.Enums
{
    /// <summary>
    /// 开启状态
    /// </summary>
    public enum EnumEnableStatus
    {
        [Description("开启")]
        [Display(Name = "开启")]
        Enable,
        [Description("关闭")]
        [Display(Name = "关闭")]
        DisEnable,
    }
}