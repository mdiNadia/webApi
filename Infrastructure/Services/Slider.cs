using Application.Dtos.Cart;
using Application.Dtos.Common;
using Application.Dtos.Slider;
using Application.EM;
using Application.Helpers;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Identity;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repository;
using Infrastructure.Services.FilesStorage;
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
    public class Slider : GenericRepository<Domain.Entities.Slider>, ISlider
    {
        private readonly IFileUploader _fileUploader;

        public Slider(DataContext context, IConfiguration configuration,IFileUploader fileUploader) : base(context, configuration)
        {
            this._fileUploader = fileUploader;
        }
        public async Task<int> AddSlider(RequestInsertSliderDto request)
        {
            if (request.Image != null)
            {
                var uploadImage = await _fileUploader.UploadFile(request.Image);
                request.ImageName = uploadImage;
            }
            try
            {
                var model = new Domain.Entities.Slider();
                model.Title = request.Title;
                model.Description = request.Description;
                model.SubTitle = request.SubTitle;
                model.IsActive = request.IsActive;
                model.Image = request.ImageName??null;
                model.DestinationLink1 = request.Link1;
                model.DestinationLink2 = request.Link2;
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

        public async Task<int> DeleteSlider(int id)
        {
            try
            {
                Delete(id);
                await SaveEntityChangeAsync();
                return 200;
            }catch(Exception err)
            {
                throw err;
            }
        }

        public async Task<GetSlidersByFilterDto> GetSlidersByFilter(RequestFilterDataDto request)
        {
            try
            {
                var data = from s in context.Sliders select s;
                var pageData = await data.Skip((request.Pageno - 1) * request.Take).Take(request.Take).ToListAsync();
                var convertPageData = new List<GetSlidersDto>();
                foreach (var item in pageData)
                {
                    convertPageData.Add(new GetSlidersDto()
                    {
                        Id = item.Id,
                        Title = item.Title,
                        SubTitle = item.SubTitle,
                        Description = item.Description,
                        Link1 = item.DestinationLink1,
                        Link2 =item.DestinationLink2,
                        CreateDate = item.CreateDate.ChangeMiladiToLongShamsi(),
                        Image = item.Image,
                        IsActive=item.IsActive


                    });
                   
                }
                var result = new GetSlidersByFilterDto
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

        public async Task<int> UpdateSlider(RequestInsertSliderDto request)
        {
            if (request.Image != null)
            {
                var uploadImage = await _fileUploader.UploadFile(request.Image);
                request.ImageName = uploadImage;
            }
            try
            {
                var data = await GetByID(request.Id);
                if (data != null)
                {
                    data.CreateDate = DateTime.Now;
                    data.Title = request.Title;
                    data.SubTitle = request.SubTitle;
                    data.Description = request.Description;

                    data.DestinationLink1 = request.Link1;
                    data.DestinationLink2 = request.Link2;
                    data.Image = request.ImageName?? data.Image;
                    data.IsActive = request.IsActive;
                    Update(data);
                    await SaveEntityChangeAsync();
                    return 200;
                }
                return 404;
            }
            catch(Exception err)
            {
                throw err;
            }

        }
    }
}
