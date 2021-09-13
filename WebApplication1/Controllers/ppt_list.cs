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
    public class ppt_list : Controller
    {
        public IActionResult Post()
        {
            var ppt_list = ppt_inform.GetThesisLists();
            return Ok(ppt_list);
        }
    }
}
