using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repository
{
    public class NoteRepository : IRepository<Note>
    {
        ApplicationDbContext _dbContext;

        public NoteRepository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task Create(Note o)
        {
            var obj = await _dbContext.Notes.AddAsync(o);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Note o)
        {
            _dbContext.Update(o);
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<Note> GetAll()
        {
            return _dbContext.Notes.ToList();
        }

        public async Task Delete(Note o)
        {
            _dbContext.Notes.Remove(o);
            await _dbContext.SaveChangesAsync();
        }
    }
}