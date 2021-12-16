using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Services;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CourseworkWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly ToDoService _toDoService;  
  
        private readonly IRepository<ToDo> _repository;  
  
        public ToDoController(IRepository<ToDo> repository, ToDoService service)  
        {  
            _toDoService = service;  
            _repository = repository;
        }  
        
        [HttpPost("Add")]  
        public async Task AddToDo([FromBody] ToDo o)  
        {
            await _toDoService.AddToDo(o);
        }

        [HttpGet("GetAll/{id:int}")]
        public IEnumerable<ToDo> GetToDoListById(int id)
        {
            return _toDoService.GetAllToDoById(id);
        }
        
        [HttpGet("Get")]
        public ToDo GetToDo([FromBody] int personId, int todoId)
        {
            return _toDoService.GetAllToDoById(personId).FirstOrDefault(x => x.ID == todoId);
        }

        [HttpDelete("Delete")]  
        public bool DeleteToDo([FromBody] ToDo o)  
        {  
            try  
            {  
                _toDoService.DeleteToDo(o);  
                return true;  
            }  
            catch (Exception)  
            {  
                return false;  
            }  
        }

        [HttpPut("Update")]  
        public bool UpdatePerson(ToDo o)  
        {  
            try  
            {  
                _toDoService.UpdateToDo(o);  
                return true;  
            }  
            catch (Exception)  
            {  
                return false;  
            }  
        }
    }
}