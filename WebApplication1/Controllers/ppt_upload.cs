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
    public class ppt_upload : Controller
    {
        [HttpPost]
        public IActionResult Edit([FromBody] Root ppt)
        {
            //实现对象解析字符串的功能，并传输到数据库留存
            //文件类型
            string type = ppt.value.select;
            //文件名
            string name = ppt.value.name;
            //作者
            string author = ppt.value.author;
            //展示时间
            string time_0 = ppt.value.time;
            string time = time_0.Substring(0, 10);
            //导师
            string tutor = ppt.value.tutor;
            //描述
            string descri = ppt.value.introduction;
            ////文件大小
            //string paper_type = paper.value.dragger[0].type;
            //文件格式
            string file_type = ppt.value.dragger[0].type;
            //文件上传名
            string file_name = ppt.value.dragger[0].name;
            //file_name = file_name.Substring(0, file_name.LastIndexOf("."));

            //执行sql语句
            string m = Mysqlhelper.Savedata(@"INSERT INTO ppt_inform (type, name ,author, time, tutor ,descri,file_type,
                                                file_name) VALUES ('" + type + "','" + name + "','" + author + "','" + time + "','" + tutor + "','" +
                                               descri + "','" + file_type + "','" + file_name + "')");
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
            /// 上传文件名
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
            /// 文件类型
            /// </summary>
            public string select { get; set; }
            /// <summary>
            /// 文件名
            /// </summary>
            public string name { get; set; }
            /// <summary>
            /// 作者
            /// </summary>
            public string author { get; set; }
            /// <summary>
            /// 导师
            /// </summary>
            public string tutor { get; set; }
            /// <summary>
            /// 展示时间
            /// </summary>
            public string time { get; set; }
            /// <summary>
            /// 简短介绍
            /// </summary>
            public string introduction { get; set; }
            /// <summary>
            /// 拖拽文件框
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
