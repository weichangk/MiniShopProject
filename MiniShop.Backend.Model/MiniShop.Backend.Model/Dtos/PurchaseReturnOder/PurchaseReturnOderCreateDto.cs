using MiniShop.Backend.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MiniShop.Backend.Model.Dto
{
    public class PurchaseReturnOderCreateDto
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "采购订单号ID")]
        [Required(ErrorMessage = "{0},不能为空")]
        public int PurchaseOderId { get; set; }

        [Display(Name = "商店ID")]
        [Required(ErrorMessage = "{0},不能为空")]
        public Guid ShopId { get; set; }

        [Display(Name = "单号")]
        [Required(ErrorMessage = "{0},不能为空")]
        public string OderNo { get; set; }

        [Display(Name = "采购订单号")]
        [Required(ErrorMessage = "{0},不能为空")]
        public string PurchaseOderNo { get; set; }

        [Display(Name = "单据金额")]
        [Required(ErrorMessage = "{0},不能为空")]
        public decimal OderAmount { get; set; }

        [Display(Name = "供应商ID")]
        [Required(ErrorMessage = "{0},不能为空")]
        public int SupplierId { get; set; }

        [Display(Name = "制单人员")]
        [Required(ErrorMessage = "{0},不能为空")]
        public string OperatorName { get; set; }

        [Display(Name = "制单日期")]
        public DateTime CreatedTime { get; set; } = DateTime.Now;

        [Display(Name = "审核状态")]
        public EnumAuditStatus AuditState { get; set; } = EnumAuditStatus.UnAudited;

        [Display(Name = "订单状态")]
        public EnumPurchaseOrderStatus OrderState { get; set; } = EnumPurchaseOrderStatus.ToAudit;

        [Display(Name = "备注")]
        public string Remark { get; set; }
    }
}
