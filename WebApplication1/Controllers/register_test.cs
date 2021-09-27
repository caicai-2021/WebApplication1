using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Common;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    public class Register_test : Controller
    {
        [HttpPost]
        public IActionResult Fill([FromBody] object user)
        {
            //实现对象解析字符串的功能，并提取响应的数据
            //反序列化功能
            string jsonString = user.ToString();
            Root js = JsonConvert.DeserializeObject<Root>(jsonString);
            string number = js.Value.User_number;

            string tutor = js.Value.Tutor;

            int type = 2;

            string name = js.Value.Name;

            string psd = js.Value.Confirm_password;

            DateTime dt = DateTime.Now;
            string dt_str = dt.ToString("yyyy-MM-dd HH:mm:ss");

            //调用common层里的数据库功能，输入sql语句，进行增加
            string m = Mysqlhelper.Savedata(@"INSERT INTO `manage_demo`.`user_inform`( `user_number`, `user_type`, `name`, 
                                                `confirm_password`, tutor , `create_time`)
                                                     value ('" + number + "' ,'" + type + "' ,'" +
                                                         name + "', '" + psd + "','"+ tutor+ "','"+ dt_str + "')");
            JavaScriptSerializer ero = new JavaScriptSerializer();
            var json = new { status = m, msg = "注册成功" };
            string str1 = ero.Serialize(json);
            JObject result1 = JObject.Parse(str1);
            return Ok(result1);
        }

        public class Value
        {
            public string User_number { get; set; }
            //public int User_type { get; set; }
            public string Name { get; set; }
            public string Tutor { get; set; }
            public string Confirm_password { get; set; }
            public string Createtime { get; set; }
        }

        public class Root
        {
            /// <summary>
            /// 
            /// </summary>
            public Value Value { get; set; }
        }
    }
}
