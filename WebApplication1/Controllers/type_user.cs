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
    public class type_user : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var timer_list = typer_inform.GetUserLists();
            return Ok(timer_list);
        }
        public class typer_inform
        {
          
            public decimal 管理员 { get; set; }
            public decimal 用户 { get; set; }
            public decimal 待审核 { get; set; }
            public decimal 已离开 { get; set; }

            public static List<typer_inform> GetUserLists()
            {
                DataTable dt = Mysqlhelper.ExecuteTable("select sum(user_type=0),sum(user_type=1),sum(user_type=2),sum(user_type=3) from user_inform");
                List<typer_inform> users = new List<typer_inform>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    users.Add(ToModel(dt.Rows[i]));
                }
                return users;
            }
            private static typer_inform ToModel(DataRow dr)
            {
                typer_inform user = new typer_inform();
                user.管理员 = (decimal)dr["sum(user_type=0)"];
                user.用户 = (decimal)dr["sum(user_type=1)"];
                user.待审核 = (decimal)dr["sum(user_type=2)"];
                user.已离开 = (decimal)dr["sum(user_type=3)"];
                return user;
            }

        }
    }
}
