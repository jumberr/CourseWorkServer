using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class PersonService
    {
        private readonly IRepository<Person> _person;  
  
        public PersonService(IRepository<Person> perosn)  
        {  
            _person = perosn;  
        }

        public async Task AddPerson(Person person)
        {
            await _person.Create(person);
        }

        public Person GetPersonByCredentials(Person person)
        {
            var username = person.UserName;
            var pass = person.Password;
            
            return _person.GetAll().FirstOrDefault(x => x.UserName == username && x.Password == pass);  
        }

        public IEnumerable<Person> GetAllPersons()
        {
            return _person.GetAll().ToList();
        }

        public bool DeletePerson(string username)  
        {
            try  
            {  
                var dataList = _person.GetAll().Where(x => x.UserName == username).ToList();  
                foreach (var item in dataList)  
                {  
                    _person.Delete(item);  
                }  
                return true;  
            }  
            catch (Exception)  
            {  
                return true;  
            }  
  
        }  

        public bool UpdatePerson(Person person)  
        {  
            try  
            {  
                var dataList = _person.GetAll().ToList();  
                foreach (var item in dataList)  
                {  
                    _person.Update(item);  
                }  
                return true;  
            }  
            catch (Exception)  
            {  
                return true;  
            }  
        }
    }
}