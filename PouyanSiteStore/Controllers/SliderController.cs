using Application.Dtos.Common;
using Application.Dtos.Slider;
using Application.Interfaces;
using Infrastructure.Services.FilesStorage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PouyanSiteStore.Controllers
{
    public class SliderController : BaseController
    {
        private readonly ILogger<SliderController> _logger;
        private readonly ISlider _slider;
        private readonly IFileUploader _fileUploader;

        public SliderController(ILogger<SliderController> logger, ISlider slider, IFileUploader fileUploader)
        {
            _logger = logger;
            this._slider = slider;
            this._fileUploader = fileUploader;
        }
        [HttpGet]
        public async Task<IActionResult> GetSlidersAsync([FromQuery] RequestFilterDataDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _slider.GetSlidersByFilter(request);
            return Ok(result);

        }
        [HttpPost("AddSlider")]
        public async Task<IActionResult> AddSliderAsync([FromForm] RequestInsertSliderDto request)
        {
            await _slider.AddSlider(request);
            return Ok();
        }
        [HttpPut("UpdateSlider")]
        public async Task<IActionResult> UpdateSliderAsync([FromForm] RequestInsertSliderDto request)
        {

            await _slider.UpdateSlider(request);
            return Ok();

        }
        [HttpDelete("DeleteSlider")]
        public async Task<IActionResult> DeleteSliderAsync(int id)
        {

            await _slider.DeleteSlider(id);
            return Ok();

        }
    }
}
