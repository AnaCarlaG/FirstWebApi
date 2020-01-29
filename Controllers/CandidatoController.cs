using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("v1/candidato")]
    public class CandidatoController : ControllerBase
    {

        [HttpGet]
        [Route("")]

        public async Task<ActionResult<List<Candidato>>> GetAsync([FromServices] DataContext context)
        {
            List<Candidato> candidato = await context.Candidatos.ToListAsync();
            candidato.Add(new Candidato{ID = 1,Nome="Thiago",Apelido="TT",CPF = "025"});
            candidato.Add(new Candidato { ID = 2, Nome = "Ana", Apelido = "Ana", CPF = "026" });
            return candidato;
        }

        //[HttpGet]
        //[Route("{id:int}")]
        //public async Task<ActionResult<Candidato>> GetById([FromServices] DataContext context, int id)
        //{
        //    var candidato = await context.Candidatos.Include(x => x.Cidade).AsNoTracking().FirstOrDefaultAsync(x => x.IDCIDADE == id);
        //    return candidato;
        //}

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Candidato>> Post([FromServices] DataContext context, [FromBody] Candidato model)
        {
            if (ModelState.IsValid)
            {
                context.Candidatos.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }

}
