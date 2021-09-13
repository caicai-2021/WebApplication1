using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Common;

namespace WebApplication1.Models
{
    public class thesis_inform
    {
        public int key { get; set; }
        public string name { get; set; }
        public string author { get; set; }
        public string tutor { get; set; }
        public string type { get; set; }
        public string gradu_time { get; set; }
        public string file_name { get; set; }

        public static List<thesis_inform> GetThesisLists()
        {
            DataTable dt = Mysqlhelper.ExecuteTable("select * from thesis_inform");
            List<thesis_inform> thesis = new List<thesis_inform>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                thesis.Add(ToModel(dt.Rows[i]));
            }
            return thesis;
        }
        private static thesis_inform ToModel(DataRow dr)
        {
            thesis_inform thesis = new thesis_inform();
            thesis.name= dr["name"].ToString();
            thesis.key = (int)dr["key"];
            thesis.author = dr["author"].ToString();
            thesis.tutor = dr["tutor"].ToString();
            thesis.type = dr["type"].ToString();
            thesis.gradu_time = dr["gradu_time"].ToString();
            thesis.file_name = dr["file_name"].ToString();
            return thesis;
        }

    }
}
