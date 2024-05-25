using IdentityModel.Client;
using Microsoft.Extensions.Configuration;
using MiniShop.Frontend.Client.Common;
using MiniShop.Frontend.Client.Dtos;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace MiniShop.Frontend.Client.HttpApis
{
    public class LoginApi
    {
        public static async Task<bool> AccessTokenAsync(UserDto user, IConfiguration configuration, string error)
        {
            error = "";
            if (string.IsNullOrWhiteSpace(user.UserName) || string.IsNullOrWhiteSpace(user.PassWord))
            {
                error = "请输入用户名和密码";
                return false;
            }

            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync(configuration["IdsConfig:Authority"]);
            if (disco.IsError)
            {
                //error = disco.Error;
                error = "登录请求失败";
                return false;
            }

            // request access token
            var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = configuration["IdsConfig:ClientId"],
                ClientSecret = configuration["IdsConfig:ClientSecret"],
                Scope = configuration["IdsConfig:Scopes"],
                UserName = user.UserName,
                Password = user.PassWord
            });

            if (tokenResponse.IsError)
            {
                //error = tokenResponse.ErrorDescription;//invalid_username_or_password
                error = "请输入正确的用户名和密码";
                return false;
            }
            UserInfo.AccessToken = tokenResponse.AccessToken;

            // call Identity Resource from Identity Server
            var apiClient = new HttpClient();
            apiClient.SetBearerToken(UserInfo.AccessToken);

            var response = await apiClient.GetAsync(disco.UserInfoEndpoint);
            if (!response.IsSuccessStatusCode)
            {
                error = "";
                return false;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                dynamic sss =  JsonConvert.DeserializeObject(content);
                UserInfo.Email = sss.email;
                UserInfo.Phone = sss.phone_number;
                UserInfo.UserName = sss.name;
                UserInfo.Rank = sss.rank;
                UserInfo.Role = sss.role;
                UserInfo.ShopId = sss.shopid;
                UserInfo.Isfreeze = sss.isfreeze;
                UserInfo.Createdtime = sss.createdtime;
                return true;
            }
        }
    }
}
