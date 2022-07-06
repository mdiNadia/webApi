
using Application.Dtos.Cart;
using Application.Dtos.Common;
using Application.Dtos.Module;
using Application.Dtos.Product;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IModule : IGenericRepository<Module>
    {
        Task<List<GetModulesDto>> GetModules();

    }
}
