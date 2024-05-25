using System.ComponentModel.DataAnnotations;
using Weick.Orm.Core;

namespace MediaKitWpfApp.Models
{
    public class EntityBase<TKey> : IEntity where TKey : struct
    {
        [Key]
        public TKey Id { get; set; }
    }
}
