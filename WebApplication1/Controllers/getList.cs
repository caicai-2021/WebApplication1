using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GetList : Controller
    {
        [HttpPost]
        public IActionResult Post()
        {

            var user_list = user_inform.GetUserLists();
            return Ok(user_list);
        }
    }
}
