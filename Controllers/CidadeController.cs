using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("v2/cidade")]
    public class CidadeController : ControllerBase
    {
        [HttpGet]
        [Route("{Nomecidade}")]
        public ActionResult<List<string>> getUFCidade([FromServices] DataContext context,string Nomecidade)
        {
            return context.Cidades.Where(cidade => cidade.Nome.Equals(Nomecidade)).Select(uf => uf.UF).ToList();
        }
    }
}