using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MiniShop.Backend.Model.Enums
{
    /// <summary>
    /// 门店状态
    /// </summary>
    public enum EnumStoreStatus
    {
        [Description("开启")]
        [Display(Name = "开启")]
        Open,
        [Description("关闭")]
        [Display(Name = "关闭")]
        Close,
    }
}