using Application.Dtos.Common;
using Application.Dtos.Slider;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
   public interface ISlider:IGenericRepository<Slider>
    {
        //
        Task<int> AddSlider(RequestInsertSliderDto request);
        Task<int> UpdateSlider(RequestInsertSliderDto request);
        Task<int> DeleteSlider(int id);
        //
        Task<GetSlidersByFilterDto> GetSlidersByFilter(RequestFilterDataDto request);

    }
}
