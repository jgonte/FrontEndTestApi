using FrontEndTestApi.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEndTestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GendersController : ControllerBase
    {
        // GET: api/<GendersController>
        [HttpGet]
        public IEnumerable<LookupItem> Get()
        {
            return new LookupItem[]
            {
                new LookupItem
                {
                    Code = "m",
                    Description = "Male"
                },
                new LookupItem
                {
                    Code = "f",
                    Description = "Female"
                }
            };
        }
    }
}
