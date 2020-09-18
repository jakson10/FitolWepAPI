using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using FitOl.WebAPI.Enums;
using FitOl.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitOl.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public async Task<UploadModel> UploadFileAsync(IFormFile formFile, string contentType)
        {
            UploadModel uploadModel = new UploadModel();
            if (formFile != null)
            {
                if (formFile.ContentType != contentType)
                {
                    uploadModel.ErrorMessage = "Uygunsuz dosya türü";
                    uploadModel.UploadState = UploadState.Error;
                    return uploadModel;
                }
                else
                {
                    var newName = Guid.NewGuid() + Path.GetExtension(formFile.FileName);
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" + newName);
                    var stream = new FileStream(path, FileMode.Create);
                    await formFile.CopyToAsync(stream);

                    uploadModel.NewName = newName;
                    uploadModel.UploadState = UploadState.Success;
                    return uploadModel;
                }
            }

            uploadModel.ErrorMessage = "Dosya yok";
            uploadModel.UploadState = UploadState.NotExist;
            return uploadModel;
        }
    }
}
