using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using MiniShop.Platform.Api.Code.Core;
using MiniShop.Platform.Api.Config;
using MiniShop.Platform.Model.Code;

namespace MiniShop.Platform.Api
{
    public class Startup : AbstractStartup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env) : base(configuration, env)
        {
            // 绑定配置信息
            configuration.Binding<BasicSetting>("Setting")
                .OnChange(BasicSetting.Setting);
        }
    }
}
