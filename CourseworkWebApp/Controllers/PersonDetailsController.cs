using System;
using System.Threading.Tasks;
using BLL.Services;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CourseworkWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonDetailsController : ControllerBase
    {
        private readonly PersonService _personService;  
  
        private readonly IRepository<Person> _Person;  
  
        public PersonDetailsController(IRepository<Person> Person, PersonService ProductService)  
        {  
            _personService = ProductService;  
            _Person = Person;
        }  
        
        [HttpPost("AddPerson")]  
        public async Task AddPerson([FromBody] Person person)  
        {
            await _personService.AddPerson(person);
        }

        [HttpPost("GetPersonByName")]
        public bool GetPersonByName([FromBody] Person person)
        {
            var data = _personService.GetPersonByCredentials(person);
            return data != null;
        }

        [HttpDelete("DeletePerson")]  
        public bool DeletePerson(string UserEmail)  
        {  
            try  
            {  
                _personService.DeletePerson(UserEmail);  
                return true;  
            }  
            catch (Exception)  
            {  
                return false;  
            }  
        }

        [HttpPut("UpdatePerson")]  
        public bool UpdatePerson(Person Object)  
        {  
            try  
            {  
                _personService.UpdatePerson(Object);  
                return true;  
            }  
            catch (Exception)  
            {  
                return false;  
            }  
        }

        [HttpGet("GetAllPersons")]  
        public Object GetAllPersons()  
        {  
            var data = _personService.GetAllPersons();  
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,  
                new JsonSerializerSettings()  
                {  
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore  
                }  
            );  
            return json;  
        }  
    }
}