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

        public IEnumerable<Person> GetAllPersons()
        {
            return _person.GetAll().ToList();
        }  

        public Person GetPersonByCredentials(Person person)
        {
            var Username = person.UserName;
            var pass = person.Password;
            
            return _person.GetAll().FirstOrDefault(x => x.UserName == Username && x.Password == pass);  
        }  

        public async Task AddPerson(Person Person)
        {
            await _person.Create(Person);
        }  

        public bool DeletePerson(string UserName)  
        {
            try  
            {  
                var DataList = _person.GetAll().Where(x => x.UserName == UserName).ToList();  
                foreach (var item in DataList)  
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
        //Update Person Details  
        public bool UpdatePerson(Person person)  
        {  
            try  
            {  
                var DataList = _person.GetAll().ToList();  
                foreach (var item in DataList)  
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