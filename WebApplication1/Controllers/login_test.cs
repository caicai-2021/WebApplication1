using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using System.Text.Json;
using WebApplication1.Common;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json.Serialization;
using Nancy.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;
using JsonProperty = Newtonsoft.Json.Serialization.JsonProperty;
using Newtonsoft.Json;
using System.Web.Helpers;
using Json = Nancy.Json.Json;
using Microsoft.Ajax.Utilities;
using System.Text;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Login_test : ControllerBase
    {
        [HttpPost]
        //public IActionResult PostStudent(JObject student)
        //{

        //}
        //frombody 是指的是原生 fromform指的是表格
        //FromBody:在Action方法传入参数后添加[frombody]属性，参数将以一个整体的json的形式传递。
        //FromForm:在Action方法传入参数后添加[FromForm]属性，参数将以表单【key:value对Array组】的形式提交。
        public IActionResult Fill ([FromBody] Root user)
        {
            //实现对象解析字符串的功能，并提取响应的数据
            //反序列化功能
            string number = user.value.user_number;//用户
            string psd = user.value.password;//密码

            //需要配置一系列的nuget包和引用
            //调用common层里的数据库功能，输入sql语句，进行查询
            DataTable dt_1 = Mysqlhelper.ExecuteTable("SELECT * FROM user_inform WHERE user_number ='" + number + "' AND confirm_password ='" + psd + "'");
            //判断得到的列表是否为空，进行判断
            if (dt_1.Rows.Count == 0)
            {
                //序列化进行返回传输
                //JavaScriptSerializer ero = new JavaScriptSerializer();
                var json = new { state = 1, msg = "用户名或密码不正确!" };
                //string str1 = ero.Serialize(json);
                return Ok(json);
            }
            //登录成功返回state=0
            else
            {
                //var list =new StringBuilder();
                //JavaScriptSerializer suc = new JavaScriptSerializer();
                //调用get方法来转化表格对象为json格式输出
                JObject list = GetJson(dt_1);
                var json = new { state = 0 , list };
                //将json对象字符串化，后面再继续对象化，感觉有些多次一举
                //string str2 = suc.Serialize(json);
                //string jsonData = JsonConvert.SerializeObject(json);
                //将json进行对象化输出，前端接收
                //JObject result = JObject.Parse(str2); 
                return Ok(json);
            }
        }


        //声明一个将表格数据转化为json对象的方法
        public static JObject GetJson(DataTable myTable)
        {
            //定义一个list<string>
            List<string> list = new List<string>();
            //遍历得到列的名字
            foreach (DataColumn col in myTable.Columns)
            {

                list.Add(col.ColumnName);
            }
            //定义一个接收行的值
            JObject Jtemp = new JObject();
            //JObject jb = new JObject();
            //JArray ja = new JArray();
            foreach (DataRow row in myTable.Rows)
            {
                
                list.ForEach(x => Jtemp.Add(x, row[x].ToString()));
                return Jtemp;
            }
            //jb.Add("rows", ja);
            //JObject jb = JObject.Parse(list);
            return Jtemp;
        }

        //定义json字符串的c#实例化，封装成类，使用转化工具
        public class Value
        {
            /// <summary>
            /// 
            /// </summary>
            public string user_number { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string password { get; set; }
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
