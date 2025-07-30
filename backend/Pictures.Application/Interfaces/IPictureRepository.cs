using Pictures.Application.DTOs;
using Pictures.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pictures.Application.Interfaces
{
    public interface IPictureRepository
    {
        Task<IEnumerable<PictureItemDto>> GetAllAsync();
        Task<int> AddAsync(Picture picture); 
        Task<bool> ExistsByFileNameAsync(string fileName);
    }
}
