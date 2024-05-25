using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniShop.Frontend.Client.Common
{
    public class Helper
    {
        public static dynamic DynamicValueKindToDynamic(object valueKind)
        {
            //c#  dynamic ValueKind = Object 需要使用系统 System.Text.Json.JsonSerializer 先序列化为json 字符串 再用Newtonsoft.Json反序列化为 dynamic 对象
            string jsonString = System.Text.Json.JsonSerializer.Serialize(valueKind);
            dynamic model = JsonConvert.DeserializeObject<dynamic>(jsonString);
            return model;
        }
    }
}
