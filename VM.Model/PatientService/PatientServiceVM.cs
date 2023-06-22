using MPI.Data;
using VM.Model.Model;
using HMIS.Core;
using PatientService;

namespace VM.Model.PatientService
{
    public class VMPatientService : PatientService<VMDBContext>
    {
        public VMPatientService(IUnitOfWork<VMDBContext> unitOfWork) : base(unitOfWork)
        {
        }
    }


}
