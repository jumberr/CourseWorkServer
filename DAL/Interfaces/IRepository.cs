using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository<T>
    {
        public Task Create(T _object);  
  
        public void Update(T _object);  
  
        public IEnumerable<T> GetAll();  
        
        public void Delete(T _object);  
    }
}