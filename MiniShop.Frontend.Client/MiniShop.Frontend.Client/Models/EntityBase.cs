using System;
using System.ComponentModel.DataAnnotations;
using Weick.Orm.Core;

namespace MiniShop.Frontend.Client.Models
{
    public class EntityBase<TKey> : IEntity where TKey : struct
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        public TKey Id { get; set; }

        /// <summary>
        /// 商店ID
        /// </summary>
        public virtual Guid ShopId { get; set; }
    }
}
