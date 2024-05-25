﻿using System.ComponentModel.DataAnnotations.Schema;

namespace MiniShop.Backend.Model
{
    /// <summary>
    /// 商品单位
    /// </summary>
    [Table("Unit")]
    public class Unit : EntityBaseNoDeletedStoreId<int>
    {
        public int Code { get; set; }   
    }
}
