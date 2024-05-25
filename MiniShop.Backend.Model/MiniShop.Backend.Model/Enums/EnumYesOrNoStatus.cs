using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MiniShop.Backend.Model.Enums
{
    /// <summary>
    /// 开启状态
    /// </summary>
    public enum EnumYesOrNoStatus
    {
        [Description("是")]
        [Display(Name = "是")]
        Yes,
        [Description("否")]
        [Display(Name = "否")]
        No,
    }
}