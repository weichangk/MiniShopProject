﻿using AutoMapper;
using Microsoft.Extensions.Logging;
using MiniShop.Backend.Model.Dto;
using MiniShop.Backend.Model;
using System;
using Weick.Orm.Core;
using System.Threading.Tasks;
using Weick.Orm.Core.Result;
using AutoMapper.QueryableExtensions;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MiniShop.Backend.Api.Services
{
    public class SupplierService : BaseService<Supplier, SupplierDto, int>, ISupplierService, IDependency
    {
        public SupplierService(Lazy<IMapper> mapper, IUnitOfWork unitOfWork, ILogger<SupplierService> logger,
            Lazy<IRepository<Supplier>> _repository) : base(mapper, unitOfWork, logger, _repository)
        {

        }

        public async Task<IResultModel> GetByShopIdCodeAsync(Guid shopId, int code)
        {
            var data = _repository.Value.TableNoTracking.Where(s => s.ShopId == shopId && s.Code == code);
            var dto = await data.ProjectTo<SupplierDto>(_mapper.Value.ConfigurationProvider).FirstOrDefaultAsync();
            return ResultModel.Success(dto);
        }

        public async Task<IResultModel> GetMaxCodeByShopIdAsync(Guid shopId)
        {
            var data = _repository.Value.TableNoTracking.Where(s => s.ShopId == shopId);
            var list = await data.ToListAsync();
            var maxCode = list == null || list.Count == 0 ? 0 : list.Max(s => s.Code);
            return ResultModel.Success(maxCode);
        }

        public async Task<IResultModel> GetByShopIdAsync(Guid shopId)
        {
            var data = _repository.Value.TableNoTracking.Where(s => s.ShopId == shopId);
            var list = await data.ProjectTo<SupplierDto>(_mapper.Value.ConfigurationProvider).ToListAsync();
            return ResultModel.Success(list);
        }

        public async Task<IResultModel> GetPageByShopIdAsync(int pageIndex, int pageSize, Guid shopId)
        {
            var data = _repository.Value.TableNoTracking;
            data = data.Where(s => s.ShopId == shopId);
            var list = await data.ProjectTo<SupplierDto>(_mapper.Value.ConfigurationProvider).ToPagedListAsync(pageIndex, pageSize);
            return ResultModel.Success(list);
        }

        public async Task<IResultModel> GetPageByShopIdWhereQueryAsync(int pageIndex, int pageSize , Guid shopId, string code, string name)
        {
            var data = _repository.Value.TableNoTracking;
            data = data.Where(s => s.ShopId == shopId);

            code = System.Web.HttpUtility.UrlDecode(code);
            if (!string.IsNullOrEmpty(code))
            {
                data = data.Where(s => s.Code.ToString().Contains(code));
            }
            name = System.Web.HttpUtility.UrlDecode(name);
            if (!string.IsNullOrEmpty(name))
            {
                data = data.Where(s => s.Name != null && s.Name.Contains(name));
            }
            var list = await data.ProjectTo<SupplierDto>(_mapper.Value.ConfigurationProvider).ToPagedListAsync(pageIndex, pageSize);
            return ResultModel.Success(list);
        }
    }

    public class CreateSupplierService : BaseService<Supplier, SupplierCreateDto, int>, ICreateSupplierService, IDependency
    {
        public CreateSupplierService(Lazy<IMapper> mapper, IUnitOfWork unitOfWork, ILogger<CreateSupplierService> logger,
            Lazy<IRepository<Supplier>> repository) : base(mapper, unitOfWork, logger, repository)
        {

        }
    }


    public class UpdateSupplierService : BaseService<Supplier, SupplierUpdateDto, int>, IUpdateSupplierService, IDependency
    {
        public UpdateSupplierService(Lazy<IMapper> mapper, IUnitOfWork unitOfWork, ILogger<UpdateSupplierService> logger, Lazy<IRepository<Supplier>> repository)
        : base(mapper, unitOfWork, logger, repository)
        {

        }
    }
}
