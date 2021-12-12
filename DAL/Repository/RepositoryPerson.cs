using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repository
{
    public class RepositoryPerson : IRepository<Person>
    {
        ApplicationDbContext _dbContext;  
        public RepositoryPerson(ApplicationDbContext applicationDbContext)  
        {  
            _dbContext = applicationDbContext;  
        }  
        public async Task Create(Person o)  
        {  
            var obj = await _dbContext.Persons.AddAsync(o);  
            await _dbContext.SaveChangesAsync();  
        }  
  
        public async Task Delete(Person o)  
        {  
            _dbContext.Remove(o);  
            await _dbContext.SaveChangesAsync();  
        }  
  
        public IEnumerable<Person> GetAll()
        {
            return _dbContext.Persons.ToList();
        }

        public async Task Update(Person o)  
        {  
            _dbContext.Persons.Update(o);  
            await _dbContext.SaveChangesAsync();  
        }  
    }
}