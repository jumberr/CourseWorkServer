using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repository
{
    public class ToDoListRepository : IRepository<ToDo>
    {
        ApplicationDbContext _dbContext;  
        public ToDoListRepository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public async Task Create(ToDo o)
        {
            await _dbContext.ToDos.AddAsync(o);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(ToDo o)
        {
            _dbContext.Update(o);  
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<ToDo> GetAll()
        {
            return _dbContext.ToDos.ToList();
        }

        public async Task Delete(ToDo o)
        {
            _dbContext.ToDos.Remove(o);  
            await _dbContext.SaveChangesAsync(); 
        }
    }
}