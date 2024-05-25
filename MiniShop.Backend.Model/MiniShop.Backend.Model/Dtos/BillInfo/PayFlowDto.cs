using System;
using System.ComponentModel.DataAnnotations;

namespace MiniShop.Backend.Model.Dto
{
    public class PayFlowDto
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "商店ID")]
        public Guid ShopId { get; set; }

        [Display(Name = "单号")]
        public string BillNo { get; set; }

        [Display(Name = "创建时间")]
        public DateTime CreatedTime { get; set; }
        
        [Display(Name = "付款ID")]
        public int PaymentId { get; set; }

         [Display(Name = "付款方式编码")]
        public String PaymentCode { get; set; }

        [Display(Name = "付款方式")]
        public String PaymentName { get; set; }

        [Display(Name = "付款金额")]
        public decimal PayMoney { get; set; }
    }
}
