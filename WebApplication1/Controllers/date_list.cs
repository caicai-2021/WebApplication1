using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Common;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class date_list : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var date_list = date_inform.GetUserLists();
            return Ok(date_list);
        }
        //定义一个类
        public class date_inform
        {
            //建立一个动态数组f
            public static ArrayList GetUserLists()
            {
                //使用list可以改变长度，类型随便
                ArrayList list = new ArrayList();
                //dt来接收sql传出的数据
                DataTable dt = Mysqlhelper.ExecuteTable("select create_time from user_inform");
                //把dt的数据用矩阵排列

                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    for (int j = 0; j < dt.Columns.Count; j++)
                //    {
                //        //选取时间的前几位进行填充
                //        ArrayList list_sub = new ArrayList();
                //        string date = dt.Rows[i][j].ToString().Substring(10);
                //        list_sub.Add(date);

                //        list.Add(list_sub);
                //    }
                //}
                //得到所有时间的数组
                ArrayList list_sub = new ArrayList();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        //选取时间的前几位进行填充                        
                        string date = dt.Rows[i][j].ToString().Substring(0,dt.Rows[i][j].ToString().IndexOf(" "));
                        //string date = string.Format("{yyyy-MM-dd}", date_1);
                        list_sub.Add(date);
                    }
                }
                var dict = new Dictionary<string, int>();
                foreach (string v in list_sub)
                {
                    if (!dict.ContainsKey(v))
                        dict.Add(v, 0);
                    dict[v]++;
                }
                
                foreach (var v in dict)
                {
                    ArrayList list_sub_1 = new ArrayList();
                    list_sub_1.Add(v.Key);
                    list_sub_1.Add(v.Value);
                    list.Add(list_sub_1);
                }
               
                return list;
            }
        }
        
    }
}
