using MiniShop.Backend.Model.Code;
using MiniShop.Backend.Model.Enums;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniShop.Backend.Model
{
    /// <summary>
    /// 会员
    /// </summary>
    [Table("Vip")]
    public class Vip : EntityBaseNoStoreId<int>
    {
        /// <summary>
        /// 会员类型ID
        /// </summary>
        public int VipTypeId { get; set; }

        /// <summary>
        /// 会员类型
        /// </summary>
        [ForeignKey("VipTypeId")]
        public virtual VipType VipType { get; set; }

        /// <summary>
        /// 卡号
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public EnumSex Sex { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime Birthday { get; set; } = DateTime.Now;

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 有效期
        /// </summary>
        public DateTime ValidDate { get; set; } = DateTime.Now;

        /// <summary>
        /// 状态
        /// </summary>
        public EnumVipStatus State { get; set; }

        /// <summary>
        /// 积分
        /// </summary>
        /// <value></value>
        [DefaultValue(0)]
        public decimal ScoreAmount { get; set; }

        /// <summary>
        /// 消费金额
        /// </summary>
        /// <value></value>
        [DefaultValue(0)]
        public decimal ConsumeAmount { get; set; }

        /// <summary>
        /// 储值金额
        /// </summary>
        /// <value></value>
        [DefaultValue(0)]
        public decimal StoreAmount { get; set; }
    }
}
