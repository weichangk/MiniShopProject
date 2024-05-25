using System;
using System.ComponentModel.DataAnnotations;

namespace MiniShop.Backend.Model.Dto
{
    public class PayFlowCreateDto
    {
        [Display(Name = "商店ID")]
        [Required(ErrorMessage = "{0},不能为空")]
        public Guid ShopId { get; set; }

        [Display(Name = "单号")]
        [Required(ErrorMessage = "{0},不能为空")]
        public string BillNo { get; set; }

        [Display(Name = "创建时间")]
        public DateTime CreatedTime { get; set; }
          
        [Display(Name = "付款ID")]
        [Required(ErrorMessage = "{0},不能为空")]
        public int PaymentId { get; set; }

        [Display(Name = "付款金额")]
        [Required(ErrorMessage = "{0},不能为空")]
        public decimal PayMoney { get; set; }
    }
}
