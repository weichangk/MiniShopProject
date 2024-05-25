﻿using AutoMapper;
using Microsoft.Extensions.Logging;
using MiniShop.Backend.Model.Dto;
using MiniShop.Backend.Model;
using System;
using Weick.Orm.Core;
using System.Threading.Tasks;
using Weick.Orm.Core.Result;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace MiniShop.Backend.Api.Services
{
    public class ItemService : BaseService<Item, ItemDto, int>, IItemService, IDependency
    {
        public ItemService(Lazy<IMapper> mapper, IUnitOfWork unitOfWork, ILogger<ItemService> logger,
            Lazy<IRepository<Item>> _repository) : base(mapper, unitOfWork, logger, _repository)
        {

        }

        public async Task<IResultModel> GetByShopIdCodeAsync(Guid shopId, string code)
        {
            var data = _repository.Value.TableNoTracking.Where(s => s.ShopId == shopId && s.Code == code);
            var dto = await data.ProjectTo<ItemDto>(_mapper.Value.ConfigurationProvider).FirstOrDefaultAsync();
            return ResultModel.Success(dto);
        }

        public async Task<IResultModel> GetPageByShopIdAsync(int pageIndex, int pageSize, Guid shopId)
        {
            var data = _repository.Value.TableNoTracking;
            data = data.Where(s => s.ShopId == shopId);
            var list = await data.ProjectTo<ItemDto>(_mapper.Value.ConfigurationProvider).ToPagedListAsync(pageIndex, pageSize);
            return ResultModel.Success(list);
        }

        public async Task<IResultModel> GetPageByShopIdWhereQueryAsync(int pageIndex, int pageSize, Guid shopId, string code, string name)
        {
            var data = _repository.Value.TableNoTracking;
            data = data.Where(s => s.ShopId == shopId);

            code = System.Web.HttpUtility.UrlDecode(code);
            if (!string.IsNullOrEmpty(code))
            {
                data = data.Where(s => s.Code.Contains(code));
            }
            name = System.Web.HttpUtility.UrlDecode(name);
            if (!string.IsNullOrEmpty(name))
            {
                data = data.Where(s => s.Name != null && s.Name.Contains(name));
            }
            var list = await data.ProjectTo<ItemDto>(_mapper.Value.ConfigurationProvider).ToPagedListAsync(pageIndex, pageSize);
            return ResultModel.Success(list);
        }

        public async Task<IResultModel> GetListAllByShopIdAsync(Guid shopId, bool isDescending = false)
        {
            var data = _repository.Value.TableNoTracking;
            data = data.Where(s => s.ShopId == shopId);
            if (isDescending)
            {
                var Descendinglist = await data.OrderByDescending(k => k.Id).ProjectTo<ItemDto>(_mapper.Value.ConfigurationProvider).ToListAsync();
                return ResultModel.Success(Descendinglist);
            }
            var list = await data.OrderBy(k => k.Id).ProjectTo<ItemDto>(_mapper.Value.ConfigurationProvider).ToListAsync();
            return ResultModel.Success(list);
        }
    }

    public class CreateItemService : BaseService<Item, ItemCreateDto, int>, ICreateItemService, IDependency
    {
        public CreateItemService(Lazy<IMapper> mapper, IUnitOfWork unitOfWork, ILogger<CreateItemService> logger,
            Lazy<IRepository<Item>> repository) : base(mapper, unitOfWork, logger, repository)
        {

        }
    }


    public class UpdateItemService : BaseService<Item, ItemUpdateDto, int>, IUpdateItemService, IDependency
    {
        public UpdateItemService(Lazy<IMapper> mapper, IUnitOfWork unitOfWork, ILogger<UpdateItemService> logger, Lazy<IRepository<Item>> repository)
        : base(mapper, unitOfWork, logger, repository)
        {

        }
    }
}
