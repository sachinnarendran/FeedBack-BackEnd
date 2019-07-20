using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OfficeOpenXml;
using OutreachFeedback.Web.BusinessEntity;
using OutreachFeedback.Web.BusinessLogic;
using OutreachFeedback.Web.EF;

namespace OutreachFeedback.Web.Rest.Controllers
{
    /// <summary>
    /// Admin Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class AdminController : ControllerBase
    {

        private IHostingEnvironment _hostingEnvironment;

        private IFileUploadBL _fileUploadBl;

        public AdminController(IHostingEnvironment hostingEnvironment, IFileUploadBL fileUploadBL)
        {
            _hostingEnvironment = hostingEnvironment;
            _fileUploadBl = fileUploadBL;

        }

        /// <summary>
        /// File Upload Controller Method
        /// </summary>
        /// <returns></returns>
        [HttpPost, DisableRequestSizeLimit]
        [Route("FileUpload")]
        public ActionResult FileUpload([FromBody]string datatobeUploaded)
        {
            try
            {
                FileUploadModel filetoUpload = new FileUploadModel();
                dynamic filedetails = JsonConvert.DeserializeObject(datatobeUploaded);
                filetoUpload.Filename = filedetails.Filename;
                int res = _fileUploadBl.SaveFileContent(filedetails.Filedata, filetoUpload.Filename);
                if (res > 0)
                    return new JsonResult("File Upload Was Successfull");
                else
                    return new JsonResult("File Upload Was Unsuccessfull. File May Already Exist");                                
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
                return new JsonResult(ex.Message);
            }
    }


    }
}