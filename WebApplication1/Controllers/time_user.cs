using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Common;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class time_user : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var timer_list = timer_inform.GetUserLists();
            return Ok(timer_list);
        }
        public class timer_inform
        {
            public string User_number { get; set; }
            public string Name { get; set; }
            public string Tutor { get; set; }
            public string Createtime { get; set; }



            public static List<timer_inform> GetUserLists()
            {
                DataTable dt = Mysqlhelper.ExecuteTable("select user_number,name,tutor,create_time * from user_inform");
                List<timer_inform> users = new List<timer_inform>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    users.Add(ToModel(dt.Rows[i]));
                }
                return users;
            }
            private static timer_inform ToModel(DataRow dr)
            {
                timer_inform user = new timer_inform();
                user.User_number = dr["user_number"].ToString();
                user.Name = dr["name"].ToString();
                user.Tutor = dr["tutor"].ToString();
                user.Createtime = dr["create_time"].ToString();
                return user;
            }

        }
    }
}
