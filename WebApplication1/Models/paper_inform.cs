using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Common;

namespace WebApplication1.Models
{
    public class paper_inform
    {
        public int key { get; set; }
        public string paper_name { get; set; }
        public string paper_number { get; set; }
        public string nameCN { get; set; }
        public string nameEN { get; set; }
        public string first_author { get; set; }
        public string first_ack { get; set; }
        public string authors{ get; set; }
        public string Co_author { get; set; }
        public string tutor { get; set; }
        public string pub_time { get; set; }
        public string file_type { get; set; }
        public string file_name { get; set; }


        public static List<paper_inform> GetThesisLists()
        {
            DataTable dt = Mysqlhelper.ExecuteTable("select * from paper_inform");
            List<paper_inform> thesis = new List<paper_inform>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                thesis.Add(ToModel(dt.Rows[i]));
            }
            return thesis;
        }
        private static paper_inform ToModel(DataRow dr)
        {
            paper_inform paper = new paper_inform();
            paper.paper_name = dr["paper_name"].ToString();
            paper.key = (int)dr["key"];
            paper.authors = dr["authors"].ToString();
            paper.tutor = dr["tutor"].ToString();
            paper.paper_number = dr["paper_name"].ToString();
            paper.nameCN = dr["nameCN"].ToString();
            paper.nameEN = dr["nameEN"].ToString();
            paper.file_name = dr["file_name"].ToString();
            paper.file_type = dr["file_type"].ToString();
            paper.first_ack= dr["first_ack"].ToString();
            paper.first_author = dr["first_author"].ToString();
            paper.pub_time = dr["pub_time"].ToString();
            paper.Co_author = dr["Co_author"].ToString();
            return paper;
        }
            
            
        }
    }

