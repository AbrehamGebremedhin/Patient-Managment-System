using System;
using System.Collections.Generic;

namespace Patient_Managment_System.Models
{
    public partial class OrderHistory
    {
        public OrderHistory()
        {
            Patients = new HashSet<Patient>();
        }

        public int Id { get; set; }
        public string History { get; set; } = null!;
        public string Symptoms { get; set; } = null!;
        public string LabOrder { get; set; } = null!;
        public int? TestId { get; set; }
        public int? PatientId { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
    }
}
