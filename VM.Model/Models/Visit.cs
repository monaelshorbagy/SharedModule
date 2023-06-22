using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using System.Collections.Generic;
using MPI;

namespace VM.Model.Model
{
    [Table("Visit", Schema = "VisitMgt")]
    public class Visit
    {
        [Key]
        public int VisitID { get; set; }
        public int? PatientID { get; set; }

    }
}


