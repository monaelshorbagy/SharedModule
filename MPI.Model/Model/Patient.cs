using System;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MPI
{
    [Table("Patient", Schema = "MPI")]
    public  class Patient
    {
        [Key]
        public int PatientID { get;  set; }

        public string PatientCode { get;  set; }

        public string PatientName { get;  set; }

        public DateTime DateOfBirth { get;  set; }

    }
}
