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
    public class paper_upload : Controller
    {
        [HttpPost]
        public IActionResult Edit([FromBody] Root paper)
        {
            //实现对象解析字符串的功能，并传输到数据库留存
            //期刊名
            string paper_name = paper.value.paper_name;
            //期刊号
            string paper_number = paper.value.paper_number;
            //中文题目
            string nameCN = paper.value.nameCN;
            //英文题目
            string nameEN = paper.value.nameEN;
            //第一作者
            string first_author = paper.value.first_author;
            //第一基金
            string first_ack = paper.value.first_ack;
            //所有作者
            string authors = paper.value.authors;
            //通讯作者
            string Co_author = paper.value.Co_author;
            //导师
            string tutor = paper.value.tutor;
            //发表时间
            string time = paper.value.pub_time;
            string pub_time = time.Substring(0, 10);
            ////文件大小
            //string paper_type = paper.value.dragger[0].type;
            //文件格式
            string file_type = paper.value.dragger[0].type;
            //文件名
            string file_name = paper.value.dragger[0].name;
            //file_name = file_name.Substring(0, file_name.LastIndexOf("."));


            //执行sql语句
            string m = Mysqlhelper.Savedata(@"INSERT INTO paper_inform (paper_name, paper_number ,nameCN, nameEN, first_author ,first_ack, authors, Co_author, tutor, pub_time, file_type,
                                                file_name) VALUES ('" + paper_name+"','"+paper_number + "','"+ nameCN + "','" + nameEN + "','" + first_author + "','"+ 
                                               first_ack + "','" + authors + "','" + Co_author + "','" + tutor + "','" + pub_time + "','" +file_type + "','" + file_name + "')");

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
            /// 期刊名
            /// </summary>
            public string paper_name { get; set; }
            /// <summary>
            /// 期刊号
            /// </summary>
            public string paper_number { get; set; }
            /// <summary>
            /// 中文题目
            /// </summary>
            public string nameCN { get; set; }
            /// <summary>
            /// 英文题目
            /// </summary>
            public string nameEN { get; set; }
            /// <summary>
            /// 第一作者
            /// </summary>
            public string first_author { get; set; }
            /// <summary>
            /// 所有作者
            /// </summary>
            public string authors { get; set; }
            /// <summary>
            /// 通讯作者
            /// </summary>
            public string Co_author { get; set; }
            /// <summary>
            /// 导师
            /// </summary>
            public string tutor { get; set; }
            /// <summary>
            /// 第一标注基金
            /// </summary>
            public string first_ack { get; set; }
            /// <summary>
            /// 发表时间
            /// </summary>
            public string pub_time { get; set; }
            /// <summary>
            /// 文件
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
