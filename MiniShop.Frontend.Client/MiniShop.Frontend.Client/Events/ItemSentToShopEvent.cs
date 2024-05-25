using MiniShop.Frontend.Client.Dtos;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniShop.Frontend.Client.Events
{
    public class ItemSentToShopEvent : PubSubEvent<SaleItemDto>
    {

    }
}
