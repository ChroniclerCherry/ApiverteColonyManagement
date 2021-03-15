using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("[controller]")]
    public class PhotoController : Controller
    {

        public static IWebHostEnvironment _environment;

        public PhotoController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpPost]
        public async Task<IActionResult> UploadColonyPhoto(String ColonyId, IFormFile file)
        {
            string path = Path.Combine(_environment.ContentRootPath, "Filesystem/Colonies/" + ColonyId + Path.GetExtension(file.FileName));
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> UploadSpecialInpectionPhoto(String SpecialInspectionId, IFormFile file)
        {
            string path = Path.Combine(_environment.ContentRootPath, "Filesystem/Colonies/" + SpecialInspectionId + Path.GetExtension(file.FileName));
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> UploadTypicalInspectionPhoto(String TypicalInspectionId, IFormFile file)
        {
            string path = Path.Combine(_environment.ContentRootPath, "Filesystem/Colonies/" + TypicalInspectionId + Path.GetExtension(file.FileName));
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return Ok();
        }
    }
}
