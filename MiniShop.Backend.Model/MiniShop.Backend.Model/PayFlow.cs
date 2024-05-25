using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniShop.Backend.Model
{
    /// <summary>
    /// 支付流水
    /// </summary>
    [Table("PayFlow")]
    public class PayFlow : EntityBaseNoDeletedStoreId<int>
    {
        [NotMapped]
        public override string Name { get => base.Name; set => base.Name = value; }

        [NotMapped]
        public override DateTime ModifiedTime { get; set; } = DateTime.Now;

        [NotMapped]
        public override string OperatorName { get; set; }

        /// <summary>
        /// 单号
        /// </summary>
        public string BillNo { get; set; }

        /// <summary>
        /// 付款方式ID
        /// </summary>
        public int PaymentId { get; set; }

        /// <summary>
        /// 付款方式
        /// </summary>
        [ForeignKey("PaymentId")]
        public virtual Payment Payment { get; set; }

        /// <summary>
        /// 付款金额
        /// </summary>
        /// <value></value>
        public decimal PayMoney { get; set; }
    }
}
