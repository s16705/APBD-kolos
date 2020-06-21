using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APBD_kolos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APBD_kolos.Controllers
{
    [Route("api/artists")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly EventDbContext _context;
        public ArtistController(EventDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetArtists()
        {
            return Ok(_context.Artist.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetArtist(int id)
        {
            try
            {

                var perfDate = _context.Artist_Event
                                                .Select(a => a.PerformanceDate)
                                                .ToList();

                var result = from Artist in _context.Artist
                                join Artist_Event in _context.Artist_Event
                                on new {Artist.IdArtist} equals new {Artist_Event.IdArtist} into details
                                where Artist.IdArtist == id
                                select new {Artist.IdArtist, Artist.Nickname};
            
                return Ok(result);

            }catch(Exception e)
            {
                return BadRequest(e);
            }
            
        }

        [HttpPut("{id}")]
        public IActionResult UpdateArtistTime(int id)
        {
            


            return Ok(_context.Artist.Where(e => e.IdArtist == id).Select(e => e.Artist_Events));
        }

    }
}
