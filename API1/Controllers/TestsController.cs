using Microsoft.AspNetCore.Mvc;

namespace API1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly HttpClient api2;

        public TestsController(IHttpClientFactory httpClientFactory)
        {
             api2  =httpClientFactory.CreateClient("api2");
        }
        [HttpGet]
        public async Task<IActionResult> GetRequestAsync()
        {
            var response = await api2.GetStringAsync("/api/products");

            return Ok(response);
        }
    }
}
