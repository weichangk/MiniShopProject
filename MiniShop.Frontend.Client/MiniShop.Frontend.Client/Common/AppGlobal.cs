using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniShop.Frontend.Client.Common
{
    public static class AppGlobal
    {

    }

    public static class UserInfo
    {
        public static string AccessToken { get; set; }
        public static string UserName { get; set; }
        public static string Email { get; set; }
        public static string Phone { get; set; }
        public static string Rank { get; set; }
        public static string Role { get; set; }
        public static Guid ShopId { get; set; }
        public static DateTime Createdtime { get; set; }
        public static bool Isfreeze { get; set; }
    }


}
