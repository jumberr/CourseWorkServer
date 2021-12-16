using System;
using System.Threading.Tasks;
using BLL.Services;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CourseworkWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonService _personService;  
  
        private readonly IRepository<Person> _Person;  
  
        public PersonController(IRepository<Person> Person, PersonService ProductService)  
        {  
            _personService = ProductService;  
            _Person = Person;
        }  
        
        [HttpPost("Add")]  
        public async Task AddPerson([FromBody] Person person)  
        {
            await _personService.AddPerson(person);
        }

        [HttpGet("Get")]
        public bool GetPersonByName([FromBody] Person person)
        {
            var data = _personService.GetPersonByCredentials(person);
            return data != null;
        }
        
        [HttpGet("GetID")]
        public int GetPersonId([FromBody] Person person)
        {
            var data = _personService.GetPersonId(person);
            return data;
        }

        [HttpDelete("Delete")]  
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

        [HttpPut("Update")]  
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

        //[HttpGet("GetAll")]  
        //public Object GetAllPersons()  
        //{  
        //    var data = _personService.GetAllPersons();  
        //    var json = JsonConvert.SerializeObject(data, Formatting.Indented,  
        //        new JsonSerializerSettings()  
        //        {  
        //            ReferenceLoopHandling = ReferenceLoopHandling.Ignore  
        //        }  
        //    );  
        //    return json;  
        //}  
    }
}