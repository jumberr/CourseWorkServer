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
        
        //Add Person  
        [HttpPost("AddPerson")]  
        public async Task AddPerson([FromBody] Person person)  
        {  

                await _personService.AddPerson(person);
        }  
        //Delete Person  
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
        //Delete Person  
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
        //GET All Person by Name  
        [HttpGet("GetPersonByName")]  
        public Object GetPersonByName(string Username)  
        {  
            var data = _personService.GetPersonByUserName(Username);  
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,  
                new JsonSerializerSettings()  
                {  
                    ReferenceLoopHandling =  ReferenceLoopHandling.Ignore  
                }  
            );  
            return json;  
        }  
  
        //GET All Person  
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