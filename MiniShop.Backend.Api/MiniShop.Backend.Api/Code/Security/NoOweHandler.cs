﻿using Microsoft.AspNetCore.Authorization;
using MiniShop.Backend.Api.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MiniShop.Backend.Api.Code.Security
{
    public class NoOweHandler : AuthorizationHandler<NoOweRequirement>
    {
        private readonly IShopService _shopService;
        public NoOweHandler(IShopService shopService)
        {
            _shopService = shopService;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, NoOweRequirement requirement)
        {
            var value = context.User.Claims.FirstOrDefault(c => c.Type == "shopid").Value;
            var result = (Weick.Orm.Core.Result.ResultModel<Model.Dto.ShopDto>)(_shopService.GetByShopIdAsync(Guid.Parse(value)).Result);
            if (result.Data.ValidDate >= DateTime.Now)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
