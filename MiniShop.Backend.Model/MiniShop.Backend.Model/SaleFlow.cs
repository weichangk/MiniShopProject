using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniShop.Backend.Model
{
    /// <summary>
    /// 销售流水
    /// </summary>
    [Table("SaleFlow")]
    public class SaleFlow : EntityBaseNoDeletedStoreId<int>
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
        /// 商品ID
        /// </summary>
        public int ItemId { get; set; }

        /// <summary>
        /// 商品
        /// </summary>
        [ForeignKey("ItemId")]
        public virtual Item Item { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        /// <value></value>
        public decimal Qty { get; set; }

        /// <summary>
        /// 售价
        /// </summary>
        /// <value></value>
        public decimal SalePrice { get; set; }

        /// <summary>
        /// 售价金额
        /// </summary>
        /// <value></value>
        public decimal SaleMoney { get; set; }
    }
}
