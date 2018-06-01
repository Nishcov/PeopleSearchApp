using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PeopleSearch.Controllers.Resources;
using PeopleSearch.Core;
using PeopleSearch.Core.Models;
using PeopleSearch.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleSearch.Controllers
{
    [Route("/api/people/{personId}")]
    public class PhotosController : Controller
    {
        private readonly IHostingEnvironment host;
        private readonly IPersonRepository repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly PhotoSettings photoSettings;

        public PhotosController(IHostingEnvironment host, IPersonRepository repository, IUnitOfWork unitOfWork, IMapper mapper, IOptionsSnapshot<PhotoSettings> options)
        {
            this.photoSettings = options.Value;
            this.host = host;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Upload(int personId, IFormFile file)
        {
            string fileName;

            Person person = await repository.GetPerson(personId);
            if (person == null)
            {
                return NotFound();
            }

            string uploadsFolderPath = Path.Combine(host.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsFolderPath))
            {
                Directory.CreateDirectory(uploadsFolderPath);
            }

            if (file == null)
            {
                fileName = "default-photo.jpg";
                string filePath = Path.Combine(uploadsFolderPath, fileName);
            }
            else if (file.Length == 0)
            {
                return BadRequest("File provided is empty.");
            }
            else if (file.Length > photoSettings.MaxBytes)
            {
                return BadRequest("File provided exceeds max file size (10 MB).");
            }
            else if (!photoSettings.IsSupported(file.FileName))
            {
                return BadRequest("File provided isn't a valid image type (.jpg, .jpeg, .png).");
            }
            else
            {
                fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string filePath = Path.Combine(uploadsFolderPath, fileName);

                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                Image image = Image.FromFile(@"./wwwroot/uploads/" + fileName);
                Image thumbnail = image.GetThumbnailImage(60, 60, () => false, IntPtr.Zero);
                thumbnail.Save(fileName);
            }
            
            Photo photo = new Photo { FileName = fileName };
            person.Photo = photo;
            await unitOfWork.CompleteAsync();

            return Ok(mapper.Map<Photo, PhotoResource>(photo));
        }
    }
}
