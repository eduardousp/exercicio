using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apibe.Models;


namespace apibe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        private readonly AllContext _context;

        public ComprasController(AllContext context)
        {
            _context = context;
        }

        // GET: api/Compras
        [HttpGet]
        public IEnumerable<Compra> GetCompras()
        {
            return _context.Compras;
        }

        // GET: api/Compras/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompra([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var compra = await _context.Compras.FindAsync(id);

            if (compra == null)
            {
                return NotFound();
            }

            return Ok(compra);
        }

        // PUT: api/Compras/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompra([FromRoute] long id, [FromBody] Compra compra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != compra.Id)
            {
                return BadRequest();
            }

            _context.Entry(compra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompraExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Compras
        [HttpPost]
        public async Task<IActionResult> PostCompra([FromBody] Compra compra)
        {
             float[,] cash = { {0.25F, 0.7F ,0.6F, 0.2F, 0.1F, 0.15F, 0.2F},
                            {0.30F, 0.5F, 0.10F, 0.15F ,0.20F, 0.25F, 0.30F},
                            {0.35F, 0.3F, 0.5F, 0.8F, 0.13F, 0.18F, 0.25F},
                            {0.40F, 0.1F, 0.15F,0.15F, 0.15F, 0.20F, 0.40F},
                        };
            int temp;
            DayOfWeek dia = DateTime.Now.DayOfWeek;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            foreach (var Disco in compra.Disco)
            {
                string genero = Disco.Genero;
                switch (genero)
                {
                    case "POP":
                        temp = 0;
                        break;
                    case "MPB":
                        temp = 1;
                        break;
                    case "CLASSIC":
                        temp = 2;
                        break;
                    case "ROCK":
                        temp = 3;
                        break;

                    default:
                        temp = -1;
                        break;

                }

                if (temp != -1)
                    Disco.Cash = cash[temp, (int)dia];
            }          
            
            _context.Compras.Add(compra);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompra", new { id = compra.Id }, compra);
        }

     
        private bool CompraExists(long id)
        {
            return _context.Compras.Any(e => e.Id == id);
        }

        
    }
}