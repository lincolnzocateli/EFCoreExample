using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace EfCoreExample.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {

        [HttpGet]
        [Route("info")]
        public async ValueTask<IActionResult> Info([FromServices]IHostingEnvironment env,
            [FromServices]IConfiguration configuration)
        {
            var info = new
            {
                NomeAplicacao = env.ApplicationName,
                DataHora = DateTimeOffset.Now,
                ContentPath = env.ContentRootPath,
                WebPath = env.WebRootPath,
                Ambiente = env.EnvironmentName,
                UsuarioServidor = Environment.UserName.ToString(),
                UsuarioApp = HttpContext.User.Identity.Name,
                Servidor = Environment.MachineName,
                Conexao = configuration.GetConnectionString("myconn")
            };
            
            return await Task.FromResult(StatusCode(StatusCodes.Status200OK, info));
        }  

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
