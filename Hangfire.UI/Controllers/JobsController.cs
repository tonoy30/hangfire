using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire.Jobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hangfire.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IBackgroundJobClient _client;

        public JobsController(IBackgroundJobClient client)
        {
            _client = client;
        }

        [HttpGet]
        public ActionResult Get()
        {
            _client.Enqueue<MyJobs>(j => j.DoJob());
            return Ok();
        }
    }
}