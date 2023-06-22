using HMIS.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using MPI;

namespace PatientService
{
    public class PatientService<TDbContext> where TDbContext : DbContext
    {
        private readonly IUnitOfWork<TDbContext> _unitOfWork;

        public PatientService(IUnitOfWork<TDbContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public virtual IQueryable<Patient> GetPatientsReadOnly()
        {
            var repository = _unitOfWork.GetRepository<Patient>();
            return repository.GetAll().AsNoTracking();
        }

        // Other methods...
    }



}
