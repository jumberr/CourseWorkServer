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
        public async Task<int> AddToDo([FromBody] ToDo o)
        {
            return await _toDoService.AddToDo(o);
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

        [HttpPost("Delete/{personId:int}/{toDoId:int}")]
        public async Task<int> DeleteToDo(int personId, int toDoId)
        {
            var val = await _toDoService.DeleteToDo(personId, toDoId);
            return val;
        }

        [HttpPost("Update/{personId:int}/{id:int}")]
        public async Task<int> UpdateToDo([FromBody] ToDo toDo, int personId,int id)
        {
            return await _toDoService.UpdateToDo(toDo, personId, id);
        }
    }
}