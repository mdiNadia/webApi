
using Application.Dtos.Product;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Dtos.Common;
using System.Data;
using ClosedXML.Excel;
using System.IO;

namespace PouyanSiteStore.Controllers
{

    public class ProductController : BaseController
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProduct _product;

        public ProductController(ILogger<ProductController> logger, IProduct product)
        {
           _logger = logger;
            this._product = product;
        }
        [HttpGet]
        public async Task<IActionResult> GetProductsAsync([FromQuery]RequestFilterDataDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _product.GetProductsByFilter(request);
            return Ok(result);
            
        }
        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProductAsync([FromForm]RequestInsertProductDto request)
        {
            var result = await _product.AddProduct(request);
            if(result == null)
            {
                return NotFound();
            }
            if (result == 200)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("Report")]
        public async Task<IActionResult> ReportExcelAsync([FromForm]RequestFilterDataDto request)
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[4] { new DataColumn("Id"),
                                        new DataColumn("Name"),
                                        new DataColumn("Descrition"),
                                        new DataColumn("CreateDate") });

            var data =await _product.GetProductsByFilter(request);

            foreach (var product in data.Result)
            {
                dt.Rows.Add(product.Id, product.Title, product.Description, product.CreateDate);
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    var file= File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Products.xlsx");
                    return file;
                }
            }
        }
    }
}
