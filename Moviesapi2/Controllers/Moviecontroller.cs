using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moviesapi2.dtos;
using Moviesapi2.model;
using System.Runtime.CompilerServices;

namespace Moviesapi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Moviecontroller : ControllerBase
    {
        private readonly applicationDBcontext _context;
        public Moviecontroller(applicationDBcontext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync ()
        {
            var movies = await _context.movies.Include(g => g.gener).ToListAsync();
               
            return Ok(movies);
        }
        [HttpGet("{name}")]
         public async Task<IActionResult> getbyname(string name)
         {
            var movie = await _context.movies.Include(n=>n.gener).SingleOrDefaultAsync(m => m.name == name);
            if (movie == null)
                return NotFound();
            return Ok(movie);   
         }
        [HttpGet("{getmovegenraid}")]
        public async Task<IActionResult> getmovegenraid(byte generid)
        {
            var movies=await _context.movies.Include(n=>n.gener).Where(m=>m.generId==generid).ToListAsync();
            return Ok(movies);
        }
        [HttpPost]
        public async Task<IActionResult> putindata([FromForm]movieDTo dto)
        {
            using var datastream=new MemoryStream();
            await dto.poster.CopyToAsync(datastream);
            var movies =new movie {
             name=dto.name,
             title=dto.title,
             rate=dto.rate,
             year=dto.year,
             storeline=dto.storeline,
             generId=dto.generId,
             poster=datastream.ToArray()};
            await _context.AddAsync(movies);
            _context.SaveChanges();
            return Ok(movies);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> updatemove(int id,movieDTo dto)
        {
            var movies=await _context.movies.FindAsync(id);
            if (movies == null)
                return BadRequest();
            if(dto.poster!=null)
            {
                using var datastream = new MemoryStream();
                await dto.poster.CopyToAsync(datastream);
                movies.poster = datastream.ToArray();
            }
           
            movies.name = dto.name;
            movies.title = dto.title;
            movies.rate = dto.rate;
            movies.year = dto.year;
            movies.storeline = dto.storeline;
            _context.SaveChanges();
            return Ok(movies);    
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> remove(int id)
        {
            var movies = await _context.movies.FindAsync(id);
            if (movies == null)
                return BadRequest();
            _context.Remove(movies);
            _context.SaveChanges();
            return Ok(movies);
        }
         
    }
}
