using HMIS.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.DependencyInjection;
using MPI;
using MPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using VM.Model;
using VM.Model.Model;
using VM.Model.PatientService;

namespace VM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IServiceProvider _services;
        private readonly IUnitOfWork<VMDBContext> _unitOfWork;
        public ValuesController(IServiceProvider services, IUnitOfWork<VMDBContext> unitOfWork)
        {
            _services = services;
            _unitOfWork = unitOfWork;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Patient>> Get()
        {
            var patientService = new VMPatientService(_unitOfWork);
            var visits = _unitOfWork.GetRepository<Visit>().GetAll();

            var query = visits
                .Join(patientService.GetPatientsReadOnly(),
                    visit => visit.PatientID,
                    patient => patient.PatientID,
                    (visit, patient) => patient);

            return query.ToList();
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
            var scope = _services.CreateScope();
            var services = scope.ServiceProvider;
            var db = services.GetService<VMDBContext>();
            //MPI.Patient patient = new Patient();
            //patient.PatientName = "mona2";
            //patient.PatientCode = "moc2";

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
