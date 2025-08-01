using Microsoft.EntityFrameworkCore;
using Pictures.Application.DTOs;
using Pictures.Application.Interfaces;
using Pictures.Domain.Entities;
using Pictures.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pictures.Infrastructure.Repositories
{
    public class PictureRepository : IPictureRepository
    {
        private readonly PictureDbContext _context;

        public PictureRepository(PictureDbContext context)
        {
            _context = context;
        }


        public async Task<bool> ExistsByFileNameAsync(string fileName) =>
         await _context.Pictures.AnyAsync(p => p.FileName == fileName);


        public async Task<IEnumerable<PictureItemDto>> GetAllAsync()
        {
            return await _context.Pictures
               .Select(p => new PictureItemDto { Id = p.Id, Name = p.Name })
               .ToListAsync();
        }

        public async Task<int> AddAsync(Picture picture)
        {
            _context.Pictures.Add(picture);
            await _context.SaveChangesAsync();
            return picture.Id; // EF Core automatically populates Id after SaveChangesAsync
        }
    }
}
