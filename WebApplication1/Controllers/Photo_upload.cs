using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Minio;
using Minio.DataModel;
using Minio.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Photo_upload : Controller
    {
        [HttpPost]
        //以表单形式，获取文件，表示与 HttpRequest 一起发送的已分析窗体值。
        //目的是返回status的状态值和url，name
        //public IActionResult PostFile([FromForm] IFormCollection upload)
        //{

        //    //创建文件读写操作，进行存储
        //    string result = "Fail";
        //    //{
        //    ////IFormFileCollection 的默认实现，理解为得到上传的文件
        //    FormFileCollection files_upload = (FormFileCollection)upload.Files;
        //    //FormFileCollection fileCollection = (FormFileCollection)formCollection.Files

        //    ////FormFile file = (FormFile)files_upload;
        //    foreach (IFormFile file in files_upload)
        //    {
        //        //目的是得到文件名，先存储到本地，再从本地上传到minio
        //        //StreamReader reader = new StreamReader(file.OpenReadStream());
        //        //string content = reader.ReadToEnd();
        //        try
        //        {
        //            string name = file.FileName;
        //            string filename = @"D:/Test/" + name;

        //            if (System.IO.File.Exists(filename))
        //            {
        //                System.IO.File.Delete(filename);
        //            }
        //            using (FileStream fs = System.IO.File.Create(filename))
        //            {
        //                // 复制文件
        //                file.CopyTo(fs);
        //                // 清空缓冲区数据
        //                fs.Flush();
        //            }
        //            result = "Success";
        //        }
        //        catch (Exception e)
        //        {
        //            result = "Error occurred: " + e;
        //        }

        //    }


        //    return Ok(result);
        //}
        //public class Root
        //{
        //    /// <summary>
        //    /// 
        //    /// </summary>
        //    public string file { get; set; }
        //}
        //}
        //异步程序
        public async Task<IActionResult> Post(List<IFormFile> file)
        {
            long size = file.Sum(f => f.Length);

            foreach (var formFile in file)
            {
                var filePath = @"D:/Test/" + formFile.FileName;
                //var filePath = Path.GetTempFileName();

                if (formFile.Length > 0)
                {
                    var stream = new FileStream(filePath, FileMode.Create);
                    await formFile.CopyToAsync(stream);

                }
            }
            return Ok(new { count = file.Count, size });

        }

        //public async minio_up(name, filename)
        //{
        //    声明minio配置
        //    var endpoint = "127.0.0.1:9000";
        //    var accessKey = "admin";
        //    var secretKey = "123456789";

        //    var minio = new MinioClient(endpoint, accessKey, secretKey);
        //    try
        //    {
        //        await minio.PutObjectAsync("photos", name, filename, contentType: "application/octet-stream");
        //        result = name + " is uploaded successfully";
        //    }
        //    catch (MinioException e)
        //    {
        //        result = "Error occurred: " + e;
        //    }

        //}


    //}

        }
}
