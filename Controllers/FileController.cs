using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationServices;
using ApplicationServices.Dtos.Inputs;

namespace VideoWebApp.Controllers
{
    public class FileController : Controller
    {
        IFileAppService _fileService;
        public async Task<IActionResult> GetFileStream(Guid fileId)
        {
            var contentType = "application/stream";
            var fstream = await _fileService.GetFileStream(fileId);
            FileStreamResult result = new FileStreamResult(fstream, contentType);
            return result;
        }
        public async Task<IActionResult> GetFileInfo(Guid fileId)
        {
            GetFileDto fileInpData = new GetFileDto {Id = fileId };
            var fileInfo = await _fileService.GetFile(fileInpData);
            return Json(fileInfo);
        }
        public async Task<IActionResult> UploadFile(FileCreateDto fileCreate)
        {
            var res = await _fileService.CreateFile(fileCreate);

            return Json(res);
        }
        public async Task<IActionResult> DeleteFile(DeleteFile criteries)
        {
            var res = await _fileService.DeleteFile(criteries);
            return Json(res);
        }
    }
}
