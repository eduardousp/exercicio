using apibe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApibeController : ControllerBase
    {
        private readonly AllContext _context;
        public ApibeController(AllContext context)
        {
            _context = context;

            if (_context.Discos.Count() == 0)
            {
                 DayOfWeek dia = DateTime.Now.DayOfWeek;
               
                    
                _context.Discos.Add(new Disco { Nome = "teste" });
                _context.Discos.Add(new Disco { Nome = "Disco2" });
                _context.SaveChanges();
            }
        }
        // GET: api/Todo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Disco>>> GetDiscos()
        {
            return await _context.Discos.OrderBy(c=>c.Nome).ToListAsync();
        }

        // GET: api/Todo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Disco>> GetDisco(long id)
        {
            var disco = await _context.Discos.FindAsync(id);

            if (disco == null)
            {
                return NotFound();
            }

            return disco;
        }
        public static async void ConectSpotify()
        {
            SpotifyWebAPI api = new SpotifyWebAPI
            {
                AccessToken = "494597653c5a45f0a29e8cd9f7e8e82c",
                TokenType = "5f4174f319c040d7b532e8c057c2e26c"
            };

            PrivateProfile profile = await api.GetPrivateProfileAsync();
            if (!profile.HasError())
            {
                Console.WriteLine(profile.DisplayName);
            }
            else {
                Console.WriteLine(profile.Error.Message.ToString());
            }
        }
    }
}