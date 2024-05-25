using MiniShop.Backend.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniShop.Backend.Model
{
    /// <summary>
    /// 采购退货订单
    /// </summary>
    [Table("PurchaseReturnOder")]
    public class PurchaseReturnOder : EntityBaseNoDeletedStoreId<int>
    {
        [NotMapped]
        public override string Name { get => base.Name; set => base.Name = value; }

        /// <summary>
        /// 采购订单ID
        /// </summary>
        /// <value></value>
        public int PurchaseOderId { get; set; }

        /// <summary>
        /// 收货订单号
        /// </summary>
        public string OderNo { get; set; }

        /// <summary>
        /// 采购订单号
        /// </summary>
        public string PurchaseOderNo { get; set; }

        /// <summary>
        /// 供应商ID
        /// </summary>
        public int SupplierId { get; set; }

        /// <summary>
        /// 供应商
        /// </summary>
        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; }

        /// <summary>
        /// 单据金额
        /// </summary>
        public decimal OderAmount { get; set; }

        /// <summary>
        /// 审核状态
        /// </summary>
        public EnumAuditStatus AuditState { get; set; }

        /// <summary>
        /// 审核人员
        /// </summary>
        public string AuditOperatorName { get; set; }

        /// <summary>
        /// 审核日期
        /// </summary>
        public DateTime? AuditTime { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public EnumPurchaseOrderStatus OrderState { get; set; } = EnumPurchaseOrderStatus.UnReturned;

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
