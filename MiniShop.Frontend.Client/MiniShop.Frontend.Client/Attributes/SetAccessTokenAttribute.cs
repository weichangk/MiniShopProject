using MiniShop.Frontend.Client.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClientCore;
using WebApiClientCore.Attributes;

namespace MiniShop.Frontend.Client.Attributes
{
    public class SetAccessTokenAttribute : ApiActionAttribute
    {
        public override Task OnRequestAsync(ApiRequestContext context)
        {
            context.HttpContext.HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", UserInfo.AccessToken);
            return Task.CompletedTask;
        }
    }
}
