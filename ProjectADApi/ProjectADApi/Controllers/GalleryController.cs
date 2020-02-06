using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
//using Api.Database.Core;
//using Api.Database.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectADApi.ApiConfig;
//using ProjectADApi.Contract.V1.Request;

namespace ProjectADApi.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class GalleryController : ControllerBase
    {
       // IRepository<Gallary> _galleryRepository;
        readonly AppVariable _appVariable;

        //public GalleryController(IRepository<Gallary> galleryRepository, AppVariable appVariable) { _galleryRepository = galleryRepository;
        //    _appVariable = appVariable;
        //}


        // GET: api/Gallery
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Gallery/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Gallery
        [HttpPost]
        public void Post([FromForm] GalleryRequest model)
        {
            string PicturePath = string.Empty;
            var file = Request.Form.Files[0];
            var folderName = Path.Combine("ArtisanGallery");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                fileName = $"{DateTime.Now.Ticks}_{fileName}";
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(folderName, fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                PicturePath = $"{_appVariable.BaseUrlPath}/{fullPath}";
            }

            

    
        }

        // PUT: api/Gallery/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
