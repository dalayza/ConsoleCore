using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProAgil.WebAPI.Data;
using ProAgil.WebAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ProAgil.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly DataContext _context;
        public ValuesController(DataContext context)
        {
          _context = context;
        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
          try
          {
            var result = await _context.Eventos.ToListAsync();

            return Ok(result);
          }
          catch (System.Exception)
          {
            return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
          }
        }

        // GET site/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
          try
          {
            var result = await _context.Eventos.FirstOrDefaultAsync(x => x.EventoId == id);;

            return Ok(result);
          }
          catch (System.Exception)
          {
            return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
          }
        }

        // POST site/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT site/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE site/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
