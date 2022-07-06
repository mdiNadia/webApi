using Application.Dtos.Cart;
using Application.Dtos.Module;
using Application.Helpers;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Identity;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class Module : GenericRepository<Domain.Entities.Module>, IModule
    {
 

        public Module(DataContext context, IConfiguration configuration) : base(context, configuration)
        {
        
        }

        public async Task<List<GetModulesDto>> GetModules()
        {
            var modules = await GetQueryList()
                .Include(c=>c.Parent)
                .AsNoTracking().ToListAsync();
            var modulesInfo = new List<GetModulesDto>();
            foreach (var item in modules)
            {
                modulesInfo.Add(new GetModulesDto() { Id = item.Id,Title = item.Title,ParentId = item.ParentId,Controller=item.Controller });
            }
            return modulesInfo;

        }
    }
}
