using Pictures.Application.DTOs;
using Pictures.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pictures.Application.Interfaces
{
    public interface IPictureService
    {
        Task<IEnumerable<PictureItemDto>> GetAllAsync();
        Task AddAsync(PictureUploadDto dto);
    }
}
