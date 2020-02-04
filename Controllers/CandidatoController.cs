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
    public class CandidatoController : Controller
    {

        #region getCandidato
        /// <summary>
        /// Serve pra pegar o Candidato
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        
        public async Task<ActionResult<List<Candidato>>> GetAsync([FromServices] DataContext context)
        {
            List<Candidato> candidato = await context.Candidatos.ToListAsync();
            //candidato.Add(new Candidato { Id = 1, Nome = "Thiago", Apelido = "TT", CPF = "025" });
            //candidato.Add(new Candidato { Id = 2, Nome = "Ana", Apelido = "Ana", CPF = "026" });
            return candidato;
        }
        #endregion

  #region Post Candidato
        /// <summary>
        /// Serve para add no um Candidato
        /// </summary>
        /// <param name="context"></param>
        /// <param name="model"></param>
        /// <returns>
        /// 200 - ok
        /// 400 - Bad Request
        /// </returns> 
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
        #endregion

        #region Put Candidato
        //[HttpPost]
        //[Route("")]
        //public ActionResult<List<>> Candidato_Put ([FromServices] DataContext context,[FromBody] Candidato model)
        //{
             
        //}
        #endregion
        [HttpGet]
        [Route("{Nomecidade}")]
        public ActionResult<List<String>> CandidatosCidade([FromServices] DataContext context,string Nomecidade)
        {
            var candidato_cidade = context.Candidatos.Where(x => x.cidade.Nome.Equals(Nomecidade)).Select(x => x.Nome).ToList();
            return candidato_cidade;
        }

        /// <summary>
        /// Pega pela cidade dos candidato
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("cidade")]
        public async Task<ActionResult<List<Candidato>>> Getcidade([FromServices] DataContext context)
        {
            var cidade = await context.Candidatos.Include(cidade => cidade.cidade).ToListAsync();
            return cidade;
        }

      
    }
}
