using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using net03_group02.src.Application.DTOs;

namespace net03_group02.src.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly FAMSContext _dbContext;
        public AuthController(FAMSContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginReq req)
        {
            
        }
    }
}