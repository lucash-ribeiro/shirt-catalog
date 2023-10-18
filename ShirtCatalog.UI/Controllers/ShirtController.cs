using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShirtCatalog.UI.Contracts;
using ShirtCatalog.UI.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Xml.Linq;

namespace ShirtCatalog.UI.Controllers
{
    public class ShirtController : Controller
    {
        private readonly IShirtService _shirtService;

        Uri baseAddress = new Uri("https://localhost:7290/api");
        private readonly HttpClient _client;

        public ShirtController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        public async Task<ActionResult> Index()
        {
            HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + "/shirts/Get");
            List<ShirtViewModel> shirtList = new List<ShirtViewModel>();

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;

                shirtList = JsonConvert.DeserializeObject<List<ShirtViewModel>>(data);
            }

            return View(shirtList);
        }

        public async Task<ActionResult> Details(int id, string name)
        {
            HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + $"/variations/GetVariations?idShirt={id}");
            ShirtDetailsViewModel shirtDetails = new ShirtDetailsViewModel() { Id = id, Name = name };

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;

                shirtDetails.Variations = JsonConvert.DeserializeObject<List<VariationViewModel>>(data);
            }

            foreach (var item in shirtDetails.Variations)
            {
                if (item.ImagePath != null && item.ImagePath.Length > 0)
                    item.ImagePath = Path.Combine("\\upload\\images", item.ImagePath);
            }

            return View(shirtDetails);
        }

        // POST: ShirtController/Delete/5
        [HttpPost]
        public async Task<ActionResult> DeleteImage(int id)
        {
            var response = await _client.DeleteAsync(_client.BaseAddress + $"/variations/DeleteImage?idImage={id}");

            if (response.IsSuccessStatusCode)
            {
                return Json(new { success = true });
            }

            return Json(new { success = false });
        }

        [HttpPost]
        public async Task<ActionResult> UploadImage(IFormFile imageFile, int idVariation, int idShirt, string shirtName)
        {
            try
            {
                var content = new MultipartFormDataContent();

                var imageContent = new StreamContent(imageFile.OpenReadStream());
                imageContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = "imageFile",
                    FileName = imageFile.FileName,
                };

                content.Add(imageContent);
                content.Add(new StringContent(idVariation.ToString()), "idVariation");

                var response = await _client.PostAsync(_client.BaseAddress + $"/variations/UploadImage", content);

                if (response.IsSuccessStatusCode)
                {
                    ///the best way here to update the things on the page is using a partial view, but I don't have time rn
                    return RedirectToAction("Details", new { idShirt, shirtName });
                }
                else
                {
                    string errorMessage = "Image upload failed. Please try again.";
                    return RedirectToPage("/Error", new { errorMessage });
                }
            }
            catch (Exception ex)
            {
                string errorMessage = "Image upload failed. Please try again.";
                return RedirectToPage("/Error", new { errorMessage });
            }
        }

        // GET: ShirtController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShirtController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShirtController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ShirtController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShirtController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }


    }
}
