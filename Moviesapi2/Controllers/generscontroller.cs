using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moviesapi2.dtos;
using Moviesapi2.model;

namespace Moviesapi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class generscontroller : ControllerBase
    {
        private readonly applicationDBcontext _context;

        public generscontroller(applicationDBcontext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> get()
        {
            var genras = await _context.gener.OrderBy(g => g.Name).ToListAsync();
            return Ok(genras);
        }
        [HttpPost]
        public async Task<IActionResult> postdata(generDTO dTO)
        {
            var gen = new gener { Name = dTO.name, Description = dTO.Description };
            await _context.gener.AddAsync(gen);
            _context.SaveChanges();
            return Ok(gen);
        }
        //[HttpPut("{id}")]
        //public async Task<IActionResult> updata(int id, [FromBody] generDTO dto)
        //{
        //    var genres=await _context.gener.FirstOrDefaultAsync(g => g.Id == id);
        //    if(genres == null)
        //        return NotFound();
        //    genres.Name = dto.name;
        //    _context.SaveChanges();
        //    return Ok(genres);
        //}
        [HttpPut("{id}")]
        public async Task<IActionResult> updata(int id, [FromBody] generDTO dto)
        {
            var generas=await _context.gener.SingleOrDefaultAsync(g=>g.Id==id);
            if(generas==null)
                return NotFound();
            generas.Name = dto.name;
            generas.Description = dto.Description;
            _context.SaveChanges();
            return Ok(generas);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> deletedata(int id)
        {
            var gen=await _context.gener.SingleOrDefaultAsync(d=>d.Id==id);
            if (gen==null)
                return NotFound();
            _context.Remove(gen);
            _context.SaveChanges();
            return Ok(gen);
        }
    }
}
