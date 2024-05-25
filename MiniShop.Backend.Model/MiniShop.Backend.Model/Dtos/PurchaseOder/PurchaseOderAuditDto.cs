using MiniShop.Backend.Model.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace MiniShop.Backend.Model.Dto
{
    public class PurchaseOderAuditDto
    {
        [Display(Name = "ID")]
        [Required(ErrorMessage = "{0},不能为空")]
        public int Id { get; set; }

        [Display(Name = "审核人员")]
        [Required(ErrorMessage = "{0},不能为空")]
        public string AuditOperatorName { get; set; }

        [Display(Name = "审核日期")]
        [Required(ErrorMessage = "{0},不能为空")]
        public DateTime? AuditTime { get; set; }

        [Display(Name = "审核状态")]
        [Required(ErrorMessage = "{0},不能为空")]
        public EnumAuditStatus AuditState { get; set; }
    }
}
