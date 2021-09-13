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
    public class thesis_upload : Controller
    {
        [HttpPost]
        public IActionResult Edit([FromBody] Root thesis)
        {

            //实现对象解析字符串的功能，并传输到数据库留存
            //文章中文名
            string Chinese_name = thesis.value.name;
            //导师
            string tutor = thesis.value.tutor;
            //作者
            string autor = thesis.value.author;
            //毕业时间
            string time = thesis.value.gradu_time;
            string gradu_time = time.Substring(0, 7);
            //文件名
            string thesis_name = thesis.value.dragger[0].name;
            //thesis_name = thesis_name.Substring(0, thesis_name.LastIndexOf("."));
            //文件格式
            string thesis_type = thesis.value.dragger[0].type;
            //执行sql语句
            string m = Mysqlhelper.Savedata(@"INSERT INTO thesis_inform (author, name ,tutor, type, gradu_time ,file_name) VALUES ('" +
                                               autor + "','" + Chinese_name + "','" + tutor + "','" + thesis_type + "','" + gradu_time + "','" + thesis_name + "')");

            if (m == "0")
            {
                //DataTable dt_1 = Mysqlhelper.ExecuteTable("SELECT * FROM user_inform WHERE user_number ='" + number + "' AND confirm_password ='" + psd + "'");
                //JObject list = GetJson(dt_1);
                //var json = new { state = 0, list };
                var json = new { state = 0, msg = "信息添加成功" };
                return Ok(json);
            }
            else
            {
                var json = new { state = 1, msg = "信息添加失败" };
                //string str1 = ero.Serialize(json);
                return Ok(json);
            }

        }


        public class DraggerItem
        {
            /// <summary>
            ///
            /// 视频封面 (2).jpg
            /// 文件名
            /// </summary>
            public string name { get; set; }
            /// <summary>
            /// 文件大小
            /// </summary>
            public int size { get; set; }
            /// <summary>
            /// 文件类型
            /// </summary>
            public string type { get; set; }

        }

        public class Value
        {
            /// <summary>
            /// 姓名
            /// </summary>
            public string name { get; set; }

            public string author { get; set; }
            /// <summary>
            /// 导师
            /// </summary>
            public string tutor { get; set; }
            /// <summary>
            /// 选择文件类型
            /// </summary>
            public string radio_group { get; set; }
            /// <summary>
            /// 毕业时间
            /// </summary>
            public string gradu_time { get; set; }
            /// <summary>
            /// 文件包
            /// </summary>
            public List<DraggerItem> dragger { get; set; }
        }

        public class Root
        {
            /// <summary>
            /// 
            /// </summary>
            public Value value { get; set; }
        }
    }
}


