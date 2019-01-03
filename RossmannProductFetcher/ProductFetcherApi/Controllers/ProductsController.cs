using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProductFetcherApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // GET api/products/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok();
        }

    }
}
