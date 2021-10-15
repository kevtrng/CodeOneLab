using System.Collections.Generic;
using System.Threading.Tasks;
using CodeOne.Data;
using CodeOne.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeOne.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	[EnableCors("Policy")]
    public class CityAPIController:ControllerBase 
    {
        private readonly ApplicationDbContext _context;
        public CityAPIController(ApplicationDbContext context) {
			_context = context;
		}

        [HttpGet]
		// public IEnumerable<City> Get() {
		// 	return _context.Cities.ToList();
		// }
		public async Task<ActionResult<List<City>>> Get() {
			return await _context.Cities.Include(c => c.Province).ToListAsync();
		}
        
    }
}