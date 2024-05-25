using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MiniShop.Backend.Model.Enums
{
    /// <summary>
    /// 会员积分方式
    /// </summary>
    public enum EnumVipScoreWay
    {
        [Description("按消费金额积分")]
        [Display(Name = "按消费金额积分")]
        ConsumeAmountScore,
    }
}
