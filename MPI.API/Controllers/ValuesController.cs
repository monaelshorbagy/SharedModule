using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POCSharedModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IServiceProvider _services;


        public ValuesController(IServiceProvider services)
            => _services = services;
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Patient>> Get()
        {
            var scope = _services.CreateScope();
            var services = scope.ServiceProvider;
            var db = services.GetService<MPIDBContext>();
            return db.Patients.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
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
