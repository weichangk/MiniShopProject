using System;
using System.ComponentModel.DataAnnotations.Schema;
using MiniShop.Backend.Model.Enums;

namespace MiniShop.Backend.Model
{
    /// <summary>
    /// POS登记
    /// </summary>
    [Table("PosRegister")]
    public class PosRegister : EntityBaseNoDeletedStoreId<int>
    {
        [NotMapped]
        public override Guid ShopId { get => base.ShopId; set => base.ShopId = value; }
        /// <summary>
        /// 唯一码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 是否启用状态
        /// </summary>
        public EnumEnableStatus Enable { get; set; }

        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime LastLoginTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 客户端版本
        /// </summary>
        public string ClientVersion { get; set; }

        /// <summary>
        /// IP
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
        public string IpAddress { get; set; }  
    }
}
