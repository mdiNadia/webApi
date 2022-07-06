
using Application.Dtos.Product;
using Application.Dtos.Common;
using Application.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using ClosedXML.Excel;
using System.IO;
using Application.EM;

namespace Infrastructure.Services
{
    public class Product : GenericRepository<Domain.Entities.Product>, IProduct
    {

        public Product(DataContext context, IConfiguration configuration) : base(context, configuration)
        {
        }

        public async Task<int> AddProduct(RequestInsertProductDto request)
        {
            try
            {
                var model = new Domain.Entities.Product();
                model.Title = request.Title;
                model.Price = request.Price;
                model.Description = request.Description;
                model.CreateDate = DateTime.Now;

                Insert(model);
                await SaveEntityChangeAsync();
                return 200;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GetProductsByFilterDto> GetProductsByFilter(RequestFilterDataDto request)
        {
            try
            {
                var data = from s in context.Products select s;
                var pageData = await data.Skip((request.Pageno - 1) * request.Take).Take(request.Take).ToListAsync();
                var convertPageData = new List<GetProductsDto>();
                foreach (var item in pageData)
                {
                    convertPageData.Add(new GetProductsDto()
                    {
                        Id = item.Id,
                        Title = item.Title,
                        Description = item.Description,
                        Price=item.Price,
                        CreateDate = item.CreateDate.ChangeMiladiToLongShamsi()



                    });

                }
                var result = new GetProductsByFilterDto
                {
                    Result = convertPageData,
                    Page = request.Pageno,
                    Search = request.Search,
                    Take = request.Take,
                    Count = data.Count(),
                    SortId = request.SortId,
                    Key = request.Key

                };


                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
