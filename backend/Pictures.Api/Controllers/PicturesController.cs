using Microsoft.AspNetCore.Mvc;
using Pictures.Application.DTOs;
using Pictures.Application.Interfaces;
using System.Threading.Tasks;

namespace Pictures.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PicturesController : ControllerBase
    {
        private readonly IPictureService _service;

        public PicturesController(IPictureService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pictures = await _service.GetAllAsync();
            return Ok(pictures);
        }

        [HttpPut]
        public async Task<IActionResult> Upload([FromForm] PictureUploadDto dto)
        {
            await _service.AddAsync(dto);
            return Ok();
        }
    }
}
