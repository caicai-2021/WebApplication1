using Microsoft.AspNetCore.Mvc;
using Nancy.Json.Simple;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Common;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ListDelect : Controller
    {
        [HttpPost]
        public IActionResult Del([FromBody] Root key)
        {

            string[] key_arr = key.value.ToArray();
            int[] key_int = Array.ConvertAll(key_arr, new Converter<string, int>(StrToInt));
            //var key_1 = key.value.Select(x => Convert.ToInt32(x));
            foreach (int i in key_int)
            {
                Mysqlhelper.Savedata("DELETE FROM `manage_demo`.`user_inform` WHERE `key` = '" + i + "'");
            }
            var json = new { status =0 };
            //string str1 = ero.Serialize(json);
            return Ok(json);
        }
        public static int StrToInt(string str)
        {
            return int.Parse(str);
        }
        public class Root
        {
            /// <summary>
            /// 
            /// </summary>
            public List<string> value { get; set; }
        }
    }
}
