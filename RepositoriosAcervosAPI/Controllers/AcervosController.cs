﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RepositoriosAcervosAPI.Utils;

namespace RepositoriosAcervosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcervosController : ControllerBase
    {

        //Teste
        // GET api/values
        [HttpGet]
        [Route("lista")]
        public ActionResult<IEnumerable<string>> Get()
        {
            Conexao conexao = new Conexao();
            var teste = conexao.ObtenhaAcervos();

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return $"celso{id}";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
