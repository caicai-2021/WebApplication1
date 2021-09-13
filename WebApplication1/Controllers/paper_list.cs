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
    public class paper_list : Controller
    {
        public IActionResult Post()
        {
            var paper_list = paper_inform.GetThesisLists();
            return Ok(paper_list);
        }
    }
}
