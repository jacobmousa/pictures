using Microsoft.EntityFrameworkCore;
using Pictures.Application.Interfaces;
using Pictures.Domain.Entities;
using Pictures.Infrastructure.Data;
using System.Collections.Generic;
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

        public async Task<List<Picture>> GetAllAsync() => await _context.Pictures.ToListAsync();

        public async Task<int?> AddAsync(Picture picture)
        {
            if (await ExistsByFileNameAsync(picture.FileName)) return null;
            _context.Pictures.Add(picture);
            await _context.SaveChangesAsync();
            return picture.Id;
        }

        public async Task<bool> ExistsByFileNameAsync(string fileName) =>
            await _context.Pictures.AnyAsync(p => p.FileName == fileName);

    }
}
