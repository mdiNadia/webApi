using Application.Dtos.Cart;
using Application.Dtos.Common;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace PouyanSiteStore.Controllers
{
    public class ModuleController : BaseController
    {
        private readonly IModule _module;

        public ModuleController(ILogger<CartController> logger,IModule module)
        {
            this._module = module;
        }


        [HttpGet]
        public async Task<IActionResult> GetModulesAsync()
        {
            var result = await _module.GetModules();
            return Ok(result);
        }

  
    }
}
