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
    public class NoteController : ControllerBase
    {
        private readonly NoteService _noteService;

        private readonly IRepository<Note> _note;

        public NoteController(IRepository<Note> note, NoteService noteService)
        {
            _noteService = noteService;
            _note = note;
        }

        [HttpPost("Add")]
        public async Task<int> AddNote([FromBody] Note o)
        {
            return await _noteService.AddNote(o);
        }

        [HttpGet("GetAll/{id:int}")]
        public IEnumerable<Note> GetNoteListById(int id)
        {
            return _noteService.GetAllNoteById(id);
        }

        [HttpGet("Get")]
        public Note GetNote([FromBody] int personId, int noteId)
        {
            return _noteService.GetAllNoteById(personId).FirstOrDefault(x => x.ID == noteId);
        }

        [HttpPost("Delete/{personId:int}/{noteId:int}")]
        public async Task<int> DeleteNote(int personId, int noteId)
        {
            var val = await _noteService.DeleteNote(personId, noteId);
            return val;
        }

        [HttpPost("Update/{personId:int}/{id:int}")]
        public async Task<int> UpdateNote([FromBody] Note note, int personId, int id)
        {
            return await _noteService.UpdateNote(note, personId, id);
        }
    }
}