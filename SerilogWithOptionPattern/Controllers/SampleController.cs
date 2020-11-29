using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SerilogWithOptionPattern.Model;

namespace SerilogWithOptionPattern.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SampleController : ControllerBase
    {
        private readonly DeveloperInfo developerInfo;

        public SampleController(IOptions<DeveloperInfo> developerInfoOption)
        {
            this.developerInfo = developerInfoOption.Value;
        }

        [HttpGet]
        public string Get() => $"Developer Is: '{developerInfo.Name}' and his Email is '{developerInfo.Detail.Email}'";
    }
}
