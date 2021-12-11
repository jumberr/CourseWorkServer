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
        public async Task Create(Person _object)  
        {  
            var obj = await _dbContext.Persons.AddAsync(_object);  
            _dbContext.SaveChanges();  
        }  
  
        public void Delete(Person _object)  
        {  
            _dbContext.Remove(_object);  
            _dbContext.SaveChanges();  
        }  
  
        public IEnumerable<Person> GetAll()
        {
            return _dbContext.Persons.ToList();
        }

        public void Update(Person _object)  
        {  
            _dbContext.Persons.Update(_object);  
            _dbContext.SaveChanges();  
        }  
    }
}