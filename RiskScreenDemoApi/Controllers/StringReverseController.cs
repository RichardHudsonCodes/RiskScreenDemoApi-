using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RiskScreenDemoApi.Contracts;

namespace RiskScreenDemoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StringReverseController : ControllerBase
    {        
        private readonly ILogger<StringReverseController> _logger;

        public StringReverseController(ILogger<StringReverseController> logger)
        {
            _logger = logger;
        }


        //swagger does not support get requests with payloads (complex type parameters)
        [HttpGet]
        public async Task<ActionResult<StringReverseResponse>> Get(string request)
        {
            if (string.IsNullOrEmpty(request))
            {
                return BadRequest("Empty string cannot be reversed"); 
            }

            var reverseCharArray = request.ToCharArray();

            Array.Reverse(reverseCharArray);              

            var response = new StringReverseResponse();
            response.reveresedString =new string(reverseCharArray);  

            return response;
        }        
    }
}
