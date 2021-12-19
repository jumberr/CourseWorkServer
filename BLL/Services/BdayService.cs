using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class BdayService
    {
        private readonly IRepository<Bday> _bdays;

        public BdayService(IRepository<Bday> bdays)
        {
            _bdays = bdays;
        }

        public async Task<int> AddBday(Bday bday)
        {
            await _bdays.Create(bday);
            return bday.ID;
        }

        public IEnumerable<Bday> GetAllBdayById(int id)
        {
             var list = _bdays.GetAll().ToList();
             var filteredList = list.FindAll(x => x.Creator == id);
             return filteredList;
        }

        public async Task<int> DeleteBday(int creator, int id)
        {
            var userToDos = FindUsersNote(creator);
            var item = userToDos.First(x => x.ID == id); // find by DataBase id
            var index = userToDos.IndexOf(item); // return local id
            await _bdays.Delete(item);
            return index;
        }

        public async Task<int> UpdateBday(Bday bday, int creator, int id)
        {
            var userToDos = FindUsersNote(creator);
            var item = userToDos.First(x => x.ID == id);
            var index = userToDos.IndexOf(item);

            item.name_Bday = bday.name_Bday;
            item.date_Bday = bday.date_Bday;
            item.addition_Bday = bday.addition_Bday;
            item.phone_num_Bday = bday.phone_num_Bday;

            await _bdays.Update(item);
            return index;
        }

        private List<Bday> FindUsersNote(int personId)
        {
            var allToDos = _bdays.GetAll().ToList();
            return allToDos.Where(x => x.Creator == personId).ToList();
        }
    }
}