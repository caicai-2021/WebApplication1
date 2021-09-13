using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Common;

namespace WebApplication1.Models
{
    public class ppt_inform
    {
        public int key { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string author { get; set; }
        public string time { get; set; }
        public string tutor { get; set; }
        public string descri { get; set; }
        public string file_type { get; set; }
        public string file_name { get; set; }


        public static List<ppt_inform> GetThesisLists()
        {
            DataTable dt = Mysqlhelper.ExecuteTable("select * from ppt_inform");
            List<ppt_inform> thesis = new List<ppt_inform>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                thesis.Add(ToModel(dt.Rows[i]));
            }
            return thesis;
        }
        private static ppt_inform ToModel(DataRow dr)
        {
            ppt_inform ppt = new ppt_inform();
            ppt.name = dr["name"].ToString();
            ppt.key = (int)dr["key"];
            ppt.author = dr["author"].ToString();
            ppt.tutor = dr["tutor"].ToString();
            ppt.type = dr["type"].ToString();
            ppt.time = dr["time"].ToString();
            ppt.file_name = dr["file_name"].ToString();
            ppt.file_type = dr["file_type"].ToString();
            ppt.descri = dr["descri"].ToString();
            return ppt;
        }
            
        
    }
}
