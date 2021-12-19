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
    public class BirthdayController : ControllerBase
    {
        private readonly BdayService _bdayService;

        private readonly IRepository<Bday> _bday;

        public BirthdayController(IRepository<Bday> bday, BdayService bdayService)
        {
            _bdayService = bdayService;
            _bday = bday;
        }

        [HttpPost("Add")]
        public async Task<int> AddBday([FromBody] Bday o)
        {
            return await _bdayService.AddBday(o);
        }

        [HttpGet("GetAll/{id:int}")]
        public IEnumerable<Bday> GetBdayListById(int id)
        {
            var res = _bdayService.GetAllBdayById(id);
            return res;
        }

        [HttpGet("Get")]
        public Bday GetBday([FromBody] int personId, int bdayId)
        {
            return _bdayService.GetAllBdayById(personId).FirstOrDefault(x => x.ID == bdayId);
        }

        [HttpPost("Delete/{personId:int}/{bdayId:int}")]
        public async Task<int> DeleteBday(int personId, int bdayId)
        {
            var val = await _bdayService.DeleteBday(personId, bdayId);
            return val;
        }

        [HttpPost("Update/{personId:int}/{id:int}")]
        public async Task<int> UpdateBday([FromBody] Bday bday, int personId, int id)
        {
            return await _bdayService.UpdateBday(bday, personId, id);
        }
    }
}