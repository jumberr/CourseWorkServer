using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class NoteService
    {
        private readonly IRepository<Note> _notes;

        public NoteService(IRepository<Note> notes)
        {
            _notes = notes;
        }

        public async Task<int> AddNote(Note note)
        {
            await _notes.Create(note);
            return note.ID;
        }

        public IEnumerable<Note> GetAllNoteById(int id)
        {
            return _notes.GetAll().Where(x => x.Creator == id);
        }

        public async Task<int> DeleteNote(int creator, int id)
        {
            var userToDos = FindUsersNote(creator);
            var item = userToDos.First(x => x.ID == id); // find by DataBase id
            var index = userToDos.IndexOf(item); // return local id
            await _notes.Delete(item);
            return index;
        }

        public async Task<int> UpdateNote(Note note, int creator, int id)
        {
            var userToDos = FindUsersNote(creator);
            var item = userToDos.First(x => x.ID == id);
            var index = userToDos.IndexOf(item);

            item.name_note = note.name_note;
            item.groupName = note.groupName;
            item.description_note = note.description_note;

            await _notes.Update(item);
            return index;
        }

        private List<Note> FindUsersNote(int personId)
        {
            var allToDos = _notes.GetAll().ToList();
            return allToDos.Where(x => x.Creator == personId).ToList();
        }
    }
}