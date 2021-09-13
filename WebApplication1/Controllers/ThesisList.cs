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
    public class ThesisList : Controller
    {
        public IActionResult Post()
        {
            var thesis_list = thesis_inform.GetThesisLists();
            return Ok(thesis_list);
        }
    }
}
