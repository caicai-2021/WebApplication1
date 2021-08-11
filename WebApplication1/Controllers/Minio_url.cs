using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Web.Helpers;
using Minio;
using Minio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    //[Route("[controller]")]

    public class Minio_url : Controller
    {
        [Route("GetMinioUploadURL")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<ApiResult<string>> GetMinioUploadURL()
        {
            var result = new ApiResult<string>();
            string bucketName = "photos";
            string objectName = DateTime.Now.ToString("yyyyMMddHHmmsss") + ".jpg";
            var client = new MinioClient(
                endpoint: "127.0.0.1:9000 ",
                accessKey: "admin",
                secretKey: "123456789"
                );
            try
            {
                string presignedUrl = await client.PresignedPutObjectAsync(bucketName, objectName, 1000);
                result.Message = presignedUrl;
            }
            catch (Exception e)
            {
                result.Message = e.Message;
            }
            return result;
        }
    }
}

