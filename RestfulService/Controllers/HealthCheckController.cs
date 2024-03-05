using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace RestfulService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        private readonly HealthCheckService _service;

        public HealthCheckController(
        HealthCheckService service)
        {
            
            _service = service;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var report = await _service.CheckHealthAsync();
            string json = System.Text.Json.JsonSerializer.Serialize(report);

            if (report.Status == HealthStatus.Healthy)
                return Ok(json);
            return NotFound("Service unavailable");
        }

        
    }
}
