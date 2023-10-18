using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using ShirtCatalog.Application.Services.Interfaces;
using ShirtCatalog.Application.ViewModel;
using ShirtCatalog.Core.Entities;
using static System.Net.Mime.MediaTypeNames;

namespace ShirtCatalog.API.Controllers
{
    [Route("api/variations/[action]")]
    [ApiController]
    public class VariationController : ControllerBase
    {
        private readonly IVariationService _variationService;
        public VariationController(IVariationService variationService)
        {
            _variationService = variationService;
        }

        [HttpPost]
        //TODO - send to the service and do this task of uploading on the infra layer maybe
        //TODO - dont use this path combine, try other thing, this is just to get running
        public async Task<string> UploadImage([FromForm] IFormFile imageFile, int idVariation)
        {
            string fileName = "";

            try
            {
                var extension = "." + imageFile.FileName.Split('.')[imageFile.FileName.Split('.').Length - 1];
                fileName = DateTime.Now.Ticks.ToString() + extension;

                string apiBaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string projectRoot = Directory.GetParent(apiBaseDirectory).Parent.Parent.Parent.Parent.FullName;
                string filePath = Path.Combine(projectRoot, "ShirtCatalog.UI", "wwwroot", "upload", "images");

                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                // I couldn't get this to work out. I placed the upload folder in my wwwroot directory,
                // which is why I can't write the files. It seems I need to use a virtual directory or something similar on IIS,
                // or employ middleware. I tried using middleware, but it caused my app to lose references to the
                // default CSS and JS files from ASP.NET. I'll need to refactor this later.
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                _variationService.InsertImage(idVariation, fileName);

            } catch (Exception ex) { }

            return fileName;
        }

        [HttpGet]
        public async Task<IActionResult> RetrieveImage(string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files", fileName);

            var provider = new FileExtensionContentTypeProvider();

            if (!provider.TryGetContentType(filePath, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            var bytes = await System.IO.File.ReadAllBytesAsync(filePath);

            return File(bytes, contentType, Path.GetFileName(filePath));
        }

        [HttpGet]
        public async Task<ActionResult<VariationViewModel>> GetVariations(int idShirt)
        {
            var variations = await _variationService.GetAllByShirtAsync(idShirt);

            if (variations == null)
            {
                return NotFound();
            }

            return Ok(variations);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteImage(int idImage)
        {
            _variationService.DeleteImage(idImage);

            return NoContent();
        }
    }
}
