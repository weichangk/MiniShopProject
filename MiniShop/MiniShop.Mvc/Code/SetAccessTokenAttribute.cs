using System.Threading.Tasks;

namespace MiniShop.Mvc.Code
    {
        public override Task OnRequestAsync(ApiRequestContext context)
        {
            var userInfo = (IUserInfo)context.HttpContext.ServiceProvider.GetService(typeof(IUserInfo));
            context.HttpContext.HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", userInfo.AccessToken);
            return Task.CompletedTask;
        }
    }