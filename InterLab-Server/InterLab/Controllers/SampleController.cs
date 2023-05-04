using InterLab.Application;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InterLab.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private ISampleService _samplesService;
        public SampleController(ISampleService samplesService)
        {
            _samplesService = samplesService;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            return await _samplesService.GetNews();
        }
    }
}
