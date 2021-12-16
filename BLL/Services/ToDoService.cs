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

        public async Task AddToDo(ToDo toDo)
        {
            await _todo.Create(toDo);
        }

        public IEnumerable<ToDo> GetAllToDoById(int id)
        {
            return _todo.GetAll().Where(x => x.Creator == id);
        }

        public bool DeleteToDo(ToDo o)
        {
            try
            {
                var dataList = _todo.GetAll().Where(x => x == o).ToList();
                foreach (var item in dataList)
                {
                    _todo.Delete(item);
                }

                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }

        public bool UpdateToDo(ToDo o)
        {
            try
            {
                _todo.Update(o);
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}