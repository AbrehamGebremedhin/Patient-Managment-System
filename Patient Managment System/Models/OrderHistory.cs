using Patient_Managment_System.Models.Base;
using System;
using System.Collections.Generic;

namespace Patient_Managment_System.Models
{
    public partial class OrderHistory : IEntityBase
    {
        public OrderHistory()
        {
            Patients = new HashSet<Patient>();
        }

        public int Id { get; set; }
        public string History { get; set; } 
        public string Symptoms { get; set; }
        public string LabOrder { get; set; }
        public int? TestId { get; set; }
        public int? PatientId { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
    }
}
