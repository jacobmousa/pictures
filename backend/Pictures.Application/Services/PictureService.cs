using Pictures.Application.DTOs;
using Pictures.Application.Interfaces;
using Pictures.Domain.Entities;
using System.Collections.Generic;
using System.IO;
using System.Security;
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

        public async Task<OperationResultDto> AddAsync(PictureUploadDto dto)
        {
            if (await _repository.ExistsByFileNameAsync(dto.File.FileName))
                return OperationResultDto.Fail("File with the same name already exists.");

            using var stream = new MemoryStream();
            await dto.File.CopyToAsync(stream);

            var picture = new Picture
            {
                Name = dto.Name,
                FileName = dto.File.FileName,
                Description = dto.Description,
                Date = dto.Date,
                FileContent = stream.ToArray()
            };

            var newId = await _repository.AddAsync(picture);

            return OperationResultDto.Ok(newId);
        }


    }
}
