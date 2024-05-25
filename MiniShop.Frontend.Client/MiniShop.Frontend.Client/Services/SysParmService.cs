using AutoMapper;
using MiniShop.Frontend.Client.Dtos;
using MiniShop.Frontend.Client.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weick.Orm.Core;

namespace MiniShop.Frontend.Client.Services
{
    public class SysParmService : BaseService<SysParm, SysParmDto, int>, ISysParmService, IDependency
    {
        public SysParmService(Lazy<IMapper> mapper, IUnitOfWork unitOfWork, ILogger logger, Lazy<IRepository<SysParm>> repository) : base(mapper, unitOfWork, logger, repository)
        {
        }
    }
}
