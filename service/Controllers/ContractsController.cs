using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using service.Models;
using service.Services;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace service.Controllers
{
    [ApiController]
    public class ContractsController : ControllerBase
    {
        private readonly ContractsService contractsService;
        public ContractsController(demoContext dbContext)
        {
            contractsService = new ContractsService();
        }

        [HttpGet]
        [Route("contracts")]
        public async Task<IActionResult> Get()
        {
            var result = await contractsService.Get();
            return new ObjectResult(result);
        }

        [HttpGet]
        [Route("contracts/search")]
        public async Task<IActionResult> Search(string keyword)
        {
            var result = await contractsService.Search(keyword);
            return new ObjectResult(result);
        }

        [HttpGet]
        [Route("contracts/get/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await contractsService.Get(id);
            var jsonData = JsonConvert.SerializeObject(result, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return new ObjectResult(jsonData);
        }
    }
}
