using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using service.Models;
using service.Services;
using System.Threading.Tasks;

namespace service.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ContractsController : ControllerBase
    {
        private readonly ContractsService contractsService;
        public ContractsController(demoContext dbContext)
        {
            contractsService = new ContractsService();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await contractsService.Get();
            return new ObjectResult(result);
        }

        [HttpGet("{keyword}")]
        public async Task<IActionResult> Search(string keyword)
        {
            var result = await contractsService.Search(keyword);
            return new ObjectResult(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await contractsService.Get(id);
            return new ObjectResult(result);
        }
    }
}
