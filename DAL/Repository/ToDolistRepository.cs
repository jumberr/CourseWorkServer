using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repository
{
    public class ToDolistRepository : IRepository<ToDo>
    {
        ApplicationDbContext _dbContext;  
        public ToDolistRepository(ApplicationDbContext applicationDbContext)  
        {  
            _dbContext = applicationDbContext;  
        }
        public async Task Create(ToDo _object)
        {
            var obj = await _dbContext.ToDos.AddAsync(_object);  
            _dbContext.SaveChanges(); 
        }

        public void Update(ToDo _object)
        {
            _dbContext.Remove(_object);  
            _dbContext.SaveChanges();
        }

        public IEnumerable<ToDo> GetAll()
        {
            return _dbContext.ToDos.ToList();
            
        }

        public void Delete(ToDo _object)
        {
            _dbContext.ToDos.Update(_object);  
            _dbContext.SaveChanges(); 
        }
    }
}