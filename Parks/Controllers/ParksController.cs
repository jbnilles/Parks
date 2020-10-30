using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Parks.Models;
using Parks.Services;
using Parks.Helpers;
using Parks.Filter;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
namespace Parks.Controllers
{
    public class ParksController : ControllerBase
    {
        private ParksContext _db;
        private readonly IUriService uriService;
        public ParksController(ParksContext db, IUriService uriService)
        {
            _db = db;
            this.uriService = uriService;
        }
        // GET api/parks
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter, string city, string state, string name)
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
            // .ToListAsync();
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

    }
}