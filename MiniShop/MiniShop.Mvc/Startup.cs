using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MiniShop.Mvc.Code;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using WebApiClientCore;

namespace MiniShop.Mvc
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)      
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IUserInfo, UserInfo>();

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, config => {
                config.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                config.Authority = _configuration["IdsConfig:Authority"];
                config.ClientId = _configuration["IdsConfig:ClientId"];
                config.ClientSecret = _configuration["IdsConfig:ClientSecret"];
                config.SaveTokens = true;
                config.ResponseType = _configuration["IdsConfig:ResponseType"];
                config.RequireHttpsMetadata = false;
                //config.SignedOutCallbackPath = "/Home/Index";

                // two trips to load claims in to the cookie
                // but the id token is smaller !
                config.GetClaimsFromUserInfoEndpoint = true;

                // configure scope
                config.Scope.Clear();
                var scopes = _configuration["IdsConfig:Scopes"];
                var scopeArray = scopes.Split(" ");
                for (int i = 0; i < scopeArray.Length; i++)
                {
                    config.Scope.Add(scopeArray[i]);
                }
            });

            //services.ConfigureNonBreakingSameSiteCookies();
            services.Configure<CookiePolicyOptions>(option =>
            {
                option.CheckConsentNeeded = context => false;
            });

            services.AddHttpClient();

            services.AddControllersWithViews();

            // ����cookie����
            services.Configure<CookiePolicyOptions>(options =>
            {
                //https://docs.microsoft.com/zh-cn/aspnet/core/security/samesite?view=aspnetcore-3.1&viewFallbackFrom=aspnetcore-3
                options.MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.Lax;
            });

            //���HttpClient���
            var miniShopApiTypes = typeof(Startup).Assembly.GetTypes()
                        .Where(type => type.IsInterface
                        && ((System.Reflection.TypeInfo)type).ImplementedInterfaces != null
                        && type.GetInterfaces().Any(a => a.FullName == typeof(IHttpApi).FullName)
                        && type.IsDefined(typeof(MiniShopApiAttribute), false));
            foreach (var type in miniShopApiTypes)
            {
                services.AddHttpApi(type);
                services.ConfigureHttpApi(type, o =>
                {
                    o.HttpHost = new Uri(_configuration["MiniShopApi:Urls"]);
                    // ���Ϲ���Ĳ���׼ʱ���ʽ����Щ�ӿھ�����ôҪ����벻��׼
                    o.JsonSerializeOptions.Converters.Add(new WebApiClientCore.Serialization.JsonConverters.JsonDateTimeConverter("yyyy-MM-dd HH:mm:ss"));
                });
            }

            var miniShopAdminApiTypes = typeof(Startup).Assembly.GetTypes()
                        .Where(type => type.IsInterface
                        && ((System.Reflection.TypeInfo)type).ImplementedInterfaces != null
                        && type.GetInterfaces().Any(a => a.FullName == typeof(IHttpApi).FullName)
                        && type.IsDefined(typeof(MiniShopAdminApiAttribute), false));
            foreach (var type in miniShopAdminApiTypes)
            {
                services.AddHttpApi(type);
                services.ConfigureHttpApi(type, o =>
                {
                    o.HttpHost = new Uri(_configuration["MiniShopAdminApi:Urls"]);
                    // ���Ϲ���Ĳ���׼ʱ���ʽ����Щ�ӿھ�����ôҪ����벻��׼
                    o.JsonSerializeOptions.Converters.Add(new WebApiClientCore.Serialization.JsonConverters.JsonDateTimeConverter("yyyy-MM-dd HH:mm:ss"));
                });
            }

            services.AddScoped(typeof(RefreshAccessTokenAttribute));

            //���AutoMapper
            services.AddAutoMapper(typeof(Dto.Profiles.AutoMapperProfiles).Assembly);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Add this before any other middleware that might write cookies
            app.UseCookiePolicy();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }

    public static class SameSiteCookiesServiceCollectionExtensions
    {
        /// <summary>
        /// -1 defines the unspecified value, which tells ASPNET Core to NOT
        /// send the SameSite attribute. With ASPNET Core 3.1 the
        /// <seealso cref="SameSiteMode" /> enum will have a definition for
        /// Unspecified.
        /// </summary>
        private const SameSiteMode Unspecified = (SameSiteMode)(-1);

        /// <summary>
        /// Configures a cookie policy to properly set the SameSite attribute
        /// for Browsers that handle unknown values as Strict. Ensure that you
        /// add the <seealso cref="Microsoft.AspNetCore.CookiePolicy.CookiePolicyMiddleware" />
        /// into the pipeline before sending any cookies!
        /// </summary>
        /// <remarks>
        /// Minimum ASPNET Core Version required for this code:
        ///   - 2.1.14
        ///   - 2.2.8
        ///   - 3.0.1
        ///   - 3.1.0-preview1
        /// Starting with version 80 of Chrome (to be released in February 2020)
        /// cookies with NO SameSite attribute are treated as SameSite=Lax.
        /// In order to always get the cookies send they need to be set to
        /// SameSite=None. But since the current standard only defines Lax and
        /// Strict as valid values there are some browsers that treat invalid
        /// values as SameSite=Strict. We therefore need to check the browser
        /// and either send SameSite=None or prevent the sending of SameSite=None.
        /// Relevant links:
        /// - https://tools.ietf.org/html/draft-west-first-party-cookies-07#section-4.1
        /// - https://tools.ietf.org/html/draft-west-cookie-incrementalism-00
        /// - https://www.chromium.org/updates/same-site
        /// - https://devblogs.microsoft.com/aspnet/upcoming-samesite-cookie-changes-in-asp-net-and-asp-net-core/
        /// - https://bugs.webkit.org/show_bug.cgi?id=198181
        /// </remarks>
        /// <param name="services">The service collection to register <see cref="CookiePolicyOptions" /> into.</param>
        /// <returns>The modified <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection ConfigureNonBreakingSameSiteCookies(this IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.MinimumSameSitePolicy = Unspecified;
                options.OnAppendCookie = cookieContext =>
                   CheckSameSite(cookieContext.Context, cookieContext.CookieOptions);
                options.OnDeleteCookie = cookieContext =>
                   CheckSameSite(cookieContext.Context, cookieContext.CookieOptions);
            });

            return services;
        }

        private static void CheckSameSite(Microsoft.AspNetCore.Http.HttpContext httpContext, CookieOptions options)
        {
            if (options.SameSite == SameSiteMode.None)
            {
                var userAgent = httpContext.Request.Headers["User-Agent"].ToString();
                options.SameSite = ReplaceSameSiteNoneByUserAgent(userAgent);
            }
        }

        /// <summary>
        /// Checks if the UserAgent is known to interpret an unknown value as Strict.
        /// For those the <see cref="CookieOptions.SameSite" /> property should be
        /// set to <see cref="Unspecified" />.
        /// </summary>
        /// <remarks>
        /// This code is taken from Microsoft:
        /// https://devblogs.microsoft.com/aspnet/upcoming-samesite-cookie-changes-in-asp-net-and-asp-net-core/
        /// </remarks>
        /// <param name="userAgent">The user agent string to check.</param>
        /// <returns>Whether the specified user agent (browser) accepts SameSite=None or not.</returns>
        private static SameSiteMode ReplaceSameSiteNoneByUserAgent(string userAgent)
        {
            // Cover all iOS based browsers here. This includes:
            //   - Safari on iOS 12 for iPhone, iPod Touch, iPad
            //   - WkWebview on iOS 12 for iPhone, iPod Touch, iPad
            //   - Chrome on iOS 12 for iPhone, iPod Touch, iPad
            // All of which are broken by SameSite=None, because they use the
            // iOS networking stack.
            // Notes from Thinktecture:
            // Regarding https://caniuse.com/#search=samesite iOS versions lower
            // than 12 are not supporting SameSite at all. Starting with version 13
            // unknown values are NOT treated as strict anymore. Therefore we only
            // need to check version 12.
            if (userAgent.Contains("CPU iPhone OS 12")
               || userAgent.Contains("iPad; CPU OS 12"))
            {
                return Unspecified;
            }

            // Cover Mac OS X based browsers that use the Mac OS networking stack.
            // This includes:
            //   - Safari on Mac OS X.
            // This does not include:
            //   - Chrome on Mac OS X
            // because they do not use the Mac OS networking stack.
            // Notes from Thinktecture: 
            // Regarding https://caniuse.com/#search=samesite MacOS X versions lower
            // than 10.14 are not supporting SameSite at all. Starting with version
            // 10.15 unknown values are NOT treated as strict anymore. Therefore we
            // only need to check version 10.14.
            if (userAgent.Contains("Safari")
               && userAgent.Contains("Macintosh; Intel Mac OS X 10_14")
               && userAgent.Contains("Version/"))
            {
                return Unspecified;
            }

            // Cover Chrome 50-69, because some versions are broken by SameSite=None
            // and none in this range require it.
            // Note: this covers some pre-Chromium Edge versions,
            // but pre-Chromium Edge does not require SameSite=None.
            // Notes from Thinktecture:
            // We can not validate this assumption, but we trust Microsofts
            // evaluation. And overall not sending a SameSite value equals to the same
            // behavior as SameSite=None for these old versions anyways.
            if (userAgent.Contains("Chrome/5") || userAgent.Contains("Chrome/6"))
            {
                return Unspecified;
            }

            if (userAgent.Contains("Chrome/8"))
            {
                return SameSiteMode.Lax;
            }

            if (userAgent.Contains("Chrome/9"))
            {
                return SameSiteMode.Lax;
            }

            return SameSiteMode.None;
        }
    }
}
