using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class ToDoService
    {
        private readonly IRepository<ToDo> _todo;

        public ToDoService(IRepository<ToDo> todo)
        {
            _todo = todo;
        }

        public async Task<int> AddToDo(ToDo toDo)
        {
            await _todo.Create(toDo);
            return toDo.ID;
        }

        public IEnumerable<ToDo> GetAllToDoById(int id)
        {
            return _todo.GetAll().Where(x => x.Creator == id);
        }

        public async Task<int> DeleteToDo(int creator, int id)
        {
            var userToDos = FindUsersToDo(creator);
            var item = userToDos.First(x => x.ID == id); // find by DataBase id
            var index = userToDos.IndexOf(item); // return local id
            await _todo.Delete(item);
            return index;
        }

        public async Task<int> UpdateToDo(ToDo toDo, int creator, int id)
        {
            var userToDos = FindUsersToDo(creator);
            var item = userToDos.First(x => x.ID == id);
            var index = userToDos.IndexOf(item);

            item.name_ToDo = toDo.name_ToDo;
            item.description_ToDo = toDo.description_ToDo;
            item.status_ToDo = toDo.status_ToDo;
            item.end_date_ToDo = toDo.end_date_ToDo;

            await _todo.Update(item);
            return index;
        }

        private List<ToDo> FindUsersToDo(int personId)
        {
            var allToDos = _todo.GetAll().ToList();
            return allToDos.Where(x => x.Creator == personId).ToList();
        }
    }
}