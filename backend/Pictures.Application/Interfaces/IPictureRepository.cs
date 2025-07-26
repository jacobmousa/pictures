using Pictures.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pictures.Application.Interfaces
{
    public interface IPictureRepository
    {
        Task<List<Picture>> GetAllAsync();
        Task<int?> AddAsync(Picture picture);
        Task<bool> ExistsByFileNameAsync(string fileName);
    }
}
