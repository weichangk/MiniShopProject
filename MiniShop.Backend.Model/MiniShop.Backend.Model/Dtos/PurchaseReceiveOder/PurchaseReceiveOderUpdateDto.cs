using MiniShop.Backend.Model.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace MiniShop.Backend.Model.Dto
{
    public class PurchaseReceiveOderUpdateDto
    {
        [Display(Name = "ID")]
        [Required(ErrorMessage = "{0},不能为空")]
        public int Id { get; set; }

        [Display(Name = "审核人员")]
        public string AuditOperatorName { get; set; }

        [Display(Name = "审核日期")]
        public DateTime? AuditTime { get; set; }

        [Display(Name = "审核状态")]
        public EnumAuditStatus AuditState { get; set; }
        
        [Display(Name = "采购状态")]
        public EnumPurchaseOrderStatus OrderState { get; set; } = EnumPurchaseOrderStatus.UnReceived;

        [Display(Name = "备注")]
        public string Remark { get; set; }
    }
}
