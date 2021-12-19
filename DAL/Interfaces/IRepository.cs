using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IRepository<T>
    {
        public Task Create(T o);  
  
        public Task Update(T o);  
  
        public IEnumerable<T> GetAll();  
        
        public Task Delete(T o);  
    }
}