using MiniShop.Backend.Model.Code;
using MiniShop.Backend.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MiniShop.Backend.Model.Dto
{
    public class PurchaseReceiveOderDto
    {
        [Display(Name = "商店ID")]
        public Guid ShopId { get; set; }

        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "采购订单号ID")]
        public int PurchaseOderId { get; set; }

        [Display(Name = "订单号")]
        public string OderNo { get; set; }

        [Display(Name = "采购订单号")]
        public string PurchaseOderNo { get; set; }

        [Display(Name = "供应商ID")]
        public int SupplierId { get; set; }

        [Display(Name = "供应商")]
        public string SupplierName { get; set; }

        [Display(Name = "单据金额")]
        public decimal OderAmount { get; set; }

        [Display(Name = "制单人员")]
        public string OperatorName { get; set; }

        [Display(Name = "制单日期")]
        public DateTime CreatedTime { get; set; }

        [Display(Name = "审核人员")]
        public string AuditOperatorName { get; set; }

        [Display(Name = "审核日期")]
        public DateTime? AuditTime { get; set; }

        [Display(Name = "审核状态")]
        public EnumAuditStatus AuditState { get; set; }

        [Display(Name = "审核状态描述")]
        public string AuditStateDes => AuditState.ToDescription();

        [Display(Name = "订单状态")]
        public EnumPurchaseOrderStatus OrderState { get; set; }

        [Display(Name = "订单状态描述")]
        public string OrderStateDes => OrderState.ToDescription();

        [Display(Name = "备注")]
        public string Remark { get; set; }
    }
}
