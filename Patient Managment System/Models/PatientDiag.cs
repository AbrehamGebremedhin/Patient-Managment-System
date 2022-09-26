using Patient_Managment_System.Models.Base;
using System;
using System.Collections.Generic;

namespace Patient_Managment_System.Models
{
    public partial class PatientDiag : IEntityBase
    {
        public PatientDiag()
        {
            Patients = new HashSet<Patient>();
        }

        public int Id { get; set; }
        public string Diagnosis { get; set; } = null!;
        public string MedicineOrder { get; set; } = null!;
        public int? MedId { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
    }
}
