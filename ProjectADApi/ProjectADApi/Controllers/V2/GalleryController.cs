using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Api.Database.Core;
using Api.Database.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectADApi.ApiConfig;

using ProjectADApi.Contract.V1.Request;
using ProjectADApi.Controllers.V2.Contract;

namespace ProjectADApi.Controllers.V2
{
    [ApiVersion("1.1")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class GalleryController : ControllerBase
    {
        readonly IRepository<Gallary> _galleryRepository;
        readonly IRepository<Artisan> _artisanRepository;
        readonly IRepository<UserLogin> _userLoginRepository;
        readonly AppVariable _appVariable;

        public GalleryController(IRepository<Gallary> galleryRepository, AppVariable appVariable, IRepository<Artisan> artisanRepository, IRepository<UserLogin> userLoginRepository)
        {
            _galleryRepository = galleryRepository;
            _appVariable = appVariable;
            _artisanRepository = artisanRepository;
            _userLoginRepository = userLoginRepository;
        }


        // GET: api/Gallery
        [HttpGet(ApiRoute.Gallery.GetAll)]
        public async Task<IActionResult> MyGallery(int UserId)
        {

            UserLogin thisUser = await _userLoginRepository.GetByAsync(x => x.Id.Equals(UserId)).FirstOrDefaultAsync();

            if (thisUser == null)
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = "User does not exist" });

            Artisan thisArtisan = await _artisanRepository.GetAllAsync().ContinueWith((result) =>
            {
                return result.Result.SingleOrDefault(x => x.UserId == thisUser.Id);
            });

            if (thisUser == null)
                return NotFound(new { status = HttpStatusCode.NotFound, message = "Artisan may not have update his/profile" });

            List<Gallary> thisProjectGallery = await _galleryRepository.GetAllAsync().ContinueWith((result) =>
            {
                return result.Result.Where(x => x.ArtisanId == thisArtisan.Id).ToList();
            });

            return Ok(new { status = HttpStatusCode.OK, Message = thisProjectGallery.ToList() });

        }

        //GET: api/Gallery/5
        [HttpGet(ApiRoute.Gallery.GetAllProjectGallery)]
        public async Task<IActionResult> ProjectGallery(int UserId, int ProjectId)
        {
            UserLogin thisUser = await _userLoginRepository.GetByAsync(x => x.Id.Equals(UserId)).FirstOrDefaultAsync();

            if (thisUser == null)
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = "User does not exist" });

            Artisan thisArtisan = await _artisanRepository.GetAllAsync().ContinueWith((result) =>
            {
                return result.Result.SingleOrDefault(x => x.UserId == thisUser.Id);
            });

            if (thisUser == null)
                return NotFound(new { status = HttpStatusCode.NotFound, message = "Artisan may not have update his/profile" });

            List<Gallary> thisProjectGallery = await _galleryRepository.GetAllAsync().ContinueWith((result) =>
            {
                return result.Result.Where(x => x.ProjectId.Value == ProjectId && x.ArtisanId == thisArtisan.Id).ToList();
            });

            return Ok(new { status = HttpStatusCode.OK, Message = thisProjectGallery });
        }

        // POST: api/Gallery
        [HttpPost(ApiRoute.Gallery.Create)]
        public async Task<IActionResult> Post([FromBody] GalleryRequest model)
        {
            UserLogin thisUser = await _userLoginRepository.GetByAsync(x => x.Id.Equals(model.userId)).FirstOrDefaultAsync();

            if (thisUser == null)
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = "User does not exist" });

            Artisan thisArtisan = await _artisanRepository.GetAllAsync().ContinueWith((result) =>
            {
                return result.Result.SingleOrDefault(x => x.UserId == thisUser.Id);
            });

            if (thisUser == null)
                return NotFound(new { status = HttpStatusCode.NotFound, message = "Artisan may not have update his/profile" });

            Gallary newGalleryItem = new Gallary
            {
                ArtisanId = thisArtisan.Id,
                JobName = model.JobName,
                Descr = model.Descr,
                PicturePath = model.PicturePath,
                JobDate = model.JobDate,
                ProjectId = model.ProjectId,
                CreatedDate = DateTime.Now
            };

            await _galleryRepository.CreateAsync(newGalleryItem);

            return CreatedAtAction(nameof(ProjectGallery), new { UserId = model.userId, ProjectId = model.ProjectId }, new { status = HttpStatusCode.Created, message = new List<Gallary> { newGalleryItem } });


            //string PicturePath = string.Empty;
            //var file = Request.Form.Files[0];
            //var folderName = Path.Combine("ArtisanGallery");
            //var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            //if (file.Length > 0)
            //{
            //    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            //    fileName = $"{DateTime.Now.Ticks}_{fileName}";
            //    var fullPath = Path.Combine(pathToSave, fileName);
            //    var dbPath = Path.Combine(folderName, fileName);

            //    using (var stream = new FileStream(fullPath, FileMode.Create))
            //    {
            //        file.CopyTo(stream);
            //    }

            //PicturePath = $"{_appVariable.BaseUrlPath}/{fullPath}";
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

