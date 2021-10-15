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
	[EnableCors("Policy")]
	[ApiController]
    public class ProvinceAPIController:ControllerBase
    {
        private readonly ApplicationDbContext _context;

		public ProvinceAPIController(ApplicationDbContext context) {
			_context = context;
		}

		[HttpGet]
		//public JsonResult Get()
		public async Task<ActionResult<List<Province>>> Get()
		{
			return await _context.Provinces.Include(p => p.Cities).ToListAsync();
		}
    }
}