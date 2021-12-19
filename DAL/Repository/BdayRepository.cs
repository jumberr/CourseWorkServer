using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repository
{
    public class BdayRepository : IRepository<Bday>
    {
        ApplicationDbContext _dbContext;

        public BdayRepository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task Create(Bday o)
        {
            var obj = await _dbContext.Bdays.AddAsync(o);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Bday o)
        {
            _dbContext.Update(o);
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<Bday> GetAll()
        {
             var res = _dbContext.Bdays.ToList();
             return res;
        }

        public async Task Delete(Bday o)
        {
            _dbContext.Bdays.Remove(o);
            await _dbContext.SaveChangesAsync();
        }
    }
}