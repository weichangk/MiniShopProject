using System;
using System.ComponentModel.DataAnnotations;
using MiniShop.Backend.Model.Code;
using MiniShop.Backend.Model.Enums;

namespace MiniShop.Backend.Model.Dto
{
    public class VipDto
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "商店ID")]
        public Guid ShopId { get; set; }

        [Display(Name = "会员类别ID")]
        public int VipTypeId { get; set; }

        [Display(Name = "会员类别名称")]
        public string VipTypeName { get; set; }

        [Display(Name = "姓名")]
        public string Name { get; set; }

        [Display(Name = "卡号")]
        public string Code { get; set; }

        [Display(Name = "性别")]
        public EnumSex Sex { get; set; }

        [Display(Name = "性别")]
        public string SexDes => Sex.ToDescription();

        [Display(Name = "生日")]
        public DateTime Birthday { get; set; } = DateTime.Now;

        [Display(Name = "手机号")]
        public string Phone { get; set; }

        [Display(Name = "有效期")]
        public DateTime ValidDate { get; set; } = DateTime.Now;

        [Display(Name = "状态")]
        public EnumVipStatus State { get; set; }

        [Display(Name = "状态")]
        public string StateDes => State.ToDescription();

        [Display(Name = "积分")]
        public decimal ScoreAmount { get; set; }

        [Display(Name = "消费金额")]
        public decimal ConsumeAmount { get; set; }

        [Display(Name = "储值金额")]
        public decimal StoreAmount { get; set; }
        
        [Display(Name = "创建时间")]
        public DateTime CreatedTime { get; set; }
    }
}
