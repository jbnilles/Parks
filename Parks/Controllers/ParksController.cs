using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Parks.Models;
using Parks.Services;
using Parks.Helpers;
using Parks.Filter;
using Parks.Wrappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
namespace Parks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParksController : ControllerBase
    {
        private ParksContext _db;
        private readonly IUriService uriService;
        public ParksController(ParksContext db, IUriService uriService)
        {
            _db = db;
            this.uriService = uriService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var query = _db.Parks.AsQueryable();
            query = query.Skip((validFilter.PageNumber - 1) * validFilter.PageSize).Take(validFilter.PageSize);
            var totalRecords = await _db.Parks.CountAsync();
            var pagedResponse = PaginationHelper.CreatePagedReponse<Park>(query.ToList(), validFilter, totalRecords, uriService, route);
            return Ok(pagedResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var park = await _db.Parks.Where(a => a.ParkId == id).FirstOrDefaultAsync();
            return Ok(new Response<Park>(park));
        }

        [HttpPost]
        public void Post([FromBody] Park park)
        {
            park.State = park.State.ToUpper();
            _db.Parks.Add(park);
            _db.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Park park)
        {
            park.ParkId = id;
            _db.Entry(park).State = EntityState.Modified;
            _db.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var parkToDelete = _db.Parks.FirstOrDefault(entry => entry.ParkId == id);
            _db.Parks.Remove(parkToDelete);
            _db.SaveChanges();
        }

        [HttpGet("random")]
        public ActionResult<Park> Get()
        {
            int count = _db.Parks.Count();
            int index = new Random().Next(count);
            return Ok(new Response<Park>(_db.Parks.Skip(index).FirstOrDefault()));
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] PaginationFilter filter, string city, string state, string name)
        {
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var query = _db.Parks.AsQueryable();
            
            if (city != null)
            {
                query = query.Where(entry => entry.City == city); 
            }
            if (state != null)
            {
                query = query.Where(entry => entry.State == state);
            }
            if (name != null)
            {
                query = query.Where(entry => entry.Name == name);
            }

            query = query.Skip((validFilter.PageNumber - 1) * validFilter.PageSize).Take(validFilter.PageSize);

            var totalRecords = await _db.Parks.CountAsync();
            var pagedResponse = PaginationHelper.CreatePagedReponse<Park>(query.ToList(), validFilter, totalRecords, uriService, route);
            
            return Ok(pagedResponse);
        }
    }
}