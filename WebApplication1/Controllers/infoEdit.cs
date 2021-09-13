using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WebApplication1.Common;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InfoEdit : Controller
    {
        [HttpPost]
        public IActionResult Edit([FromBody] Root user)
        {
            //实现对象解析字符串的功能，并提取提交修改的数据
            string number = user.value.user_number;//用户名

            string name = user.value.name;

            string psd = user.value.confirm_password;//密码
            //用户类型
            string type = user.value.user_type;
            //性别
            string gender = user.value.gender;
            //住址
            string residence = user.value.residence;
            //宿舍号
            string dorm = user.value.dorm;
            //办公室
            string office = user.value.office;
            //邮件
            string email = user.value.mail;
            //电话号码
            string phone = user.value.phone;
            //判断一下是否包含头像数据的属性
          
            //用序号获取list数组，得到头像数据
            //Photo_dataItem p1 = user.value.photo_data[0];
            string photo_data = user.value.photo_data[0].thumbUrl;
            
            //执行sql语句
            string m  = Mysqlhelper.Savedata(@"UPDATE user_inform SET name = '"+name+"',confirm_password = '"+psd+"',gender = '"+gender+"',residence = '"
                                                +residence+"',dorm = '"+ dorm +"',office = '"+office+"',mail = '"+email+"',phone= '"
                                                +phone+ "',photo_data ='" + photo_data + "'WHERE user_number ='" + number + "'");
            if (m=="0") {
                DataTable dt_1 = Mysqlhelper.ExecuteTable("SELECT * FROM user_inform WHERE user_number ='" + number + "' AND confirm_password ='" + psd + "'");
                JObject list = GetJson(dt_1);
                var json = new { state = 0, list };
                //将json对象字符串化，后面再继续对象化，感觉有些多次一举
                //string str2 = suc.Serialize(json);
                //string jsonData = JsonConvert.SerializeObject(json);
                //将json进行对象化输出，前端接收
                //JObject result = JObject.Parse(str2); 
                return Ok(json);
            }
            else
            {
                var json = new { state = 1, msg = "修改信息失败" };
                //string str1 = ero.Serialize(json);
                return Ok(json);
            }
            //
        }
        ///// <summary>
        ///// 利用反射来判断对象是否包含某个属性
        ///// </summary>
        ///// <param name="instance">object</param>
        ///// <param name="propertyName">需要判断的属性</param>
        ///// <returns>是否包含</returns>
        //Func  ContainProperty(this object instance, string propertyName)
        //{
        //    if (instance != null && !string.IsNullOrEmpty(propertyName))
        //    {
        //        PropertyInfo _findedPropertyInfo = instance.GetType().GetProperty(propertyName);
        //        return (_findedPropertyInfo != null);
        //    }
        //    return false;
        //}
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
        //封装json实体类，解读字符串
        public class OriginFileObj
        {
            /// <summary>
            /// 
            /// </summary>
            public string uid { get; set; }
        }

        public class Photo_dataItem
        {
            /// <summary>
            /// 
            /// </summary>
            public string uid { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string lastModified { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string lastModifiedDate { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string name { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int size { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string type { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int percent { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public OriginFileObj originFileObj { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string status { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string thumbUrl { get; set; }
        }

        public class Value
        {
            /// <summary>
            /// 
            /// </summary>
            public string user_number { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string user_type { get; set; }
            /// <summary>
            /// 蔡保玉
            /// </summary>
            public string name { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string mail { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string password { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string confirm_password { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string residence { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string office { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string phone { get; set; }
            /// <summary>
            /// 无 
            /// </summary>
            public string dorm { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string gender { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<Photo_dataItem> photo_data { get; set; }
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
