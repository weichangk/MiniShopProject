using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniShop.Frontend.Client.Common
{
    public class CashierOperBar : BindableBase
    {
        public string Icon { get; set; }
        public string Title { get; set; }
        public string NameSpace { get; set; }
    }
}
