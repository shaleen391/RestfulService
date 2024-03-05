using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.IO;

namespace RestfulService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public async Task<string> Get()
        {
           // var data = string.Empty;
            HttpClient client = new HttpClient();
            string data = await client.GetStringAsync("https://randomuser.me/api");


            return data;
            
             
            //return Ok("User Authenticated");
        }

        
    }
}
