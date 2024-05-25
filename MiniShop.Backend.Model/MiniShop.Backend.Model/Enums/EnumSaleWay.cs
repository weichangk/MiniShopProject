using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MiniShop.Backend.Model.Enums
{
    /// <summary>
    /// 销售方式
    /// </summary>
    public enum EnumSaleWay
    {
        [Description("销售")]
        [Display(Name = "销售")]
        Sale,
        [Description("退货")]
        [Display(Name = "退货")]
        Return,
    }
}
