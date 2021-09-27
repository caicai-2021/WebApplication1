using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Common;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Auth : Controller
    {
        [HttpPost]
        public IActionResult Edit([FromBody] Root autype)
        {
            int type = autype.type;
            string number = autype.number;
            string m = Mysqlhelper.Savedata(@"UPDATE `manage_demo`.`user_inform` SET user_type = " + type + " WHERE user_number = '"+ number + "'");
            if (m == "0")
            {
                var json = new { state = 0, msg = "成功" };
                return Ok(json);
            }
            else
            {
                var json = new { state = 1, msg = "失败" };
                //string str1 = ero.Serialize(json);
                return Ok(json);
            }
        }
    }
    public class Root
    {
        /// <summary>
        /// 
        /// </summary>
        public int type { get; set; }
        /// <summary>
        /// 蔡保玉1
        /// </summary>
        public string number { get; set; }
    }
}
