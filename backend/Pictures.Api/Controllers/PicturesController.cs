using Microsoft.AspNetCore.Mvc;
using Pictures.Application.Dtos.Pictures.Application.Dtos;
using Pictures.Application.Interfaces;
using Pictures.Domain.Entities;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Pictures.Api.Controllers
{
    [ApiController]
    [Route("api/pictures")]
    public class PicturesController : ControllerBase
    {
        private readonly IPictureRepository _repository;

        public PicturesController(IPictureRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pictures = await _repository.GetAllAsync();
            return Ok(pictures.Select(p => new { p.Id, p.Name }));
        }

        [HttpPut]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Upload([FromForm] UploadPictureRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { error = "Invalid input" });

            using var stream = new MemoryStream();
            await request.File.CopyToAsync(stream);

            var picture = new Picture
            {
                Name = request.Name,
                Description = request.Description,
                Date = request.Date,
                FileContent = stream.ToArray(),
                FileName = request.File.FileName
            };

            var result = await _repository.AddAsync(picture);
            if (result == null)
                return Conflict(new { error = "Picture name already exists" });

            return Ok(new { id = result });
        }
    }
}
