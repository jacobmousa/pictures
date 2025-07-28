using Pictures.Application.DTOs;
using Pictures.Application.Interfaces;
using Pictures.Domain.Entities;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Pictures.Application.Services
{
    public class PictureService : IPictureService
    {
        private readonly IPictureRepository _repository;

        public PictureService(IPictureRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PictureItemDto>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task AddAsync(PictureUploadDto dto)
        {
            using var stream = new MemoryStream();
            await dto.File.CopyToAsync(stream);

            var picture = new Picture
            {
                Name = dto.Name,
                Description = dto.Description,
                Date = dto.Date,
                FileContent = stream.ToArray(),
                FileName = dto.File.FileName
            };

            await _repository.AddAsync(picture);
        }
    }
}
