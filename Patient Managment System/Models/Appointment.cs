using Patient_Managment_System.Models.Base;
using System;
using System.Collections.Generic;

namespace Patient_Managment_System.Models
{
    public partial class Appointment : IEntityBase
    {
        public Appointment()
        {
            Patients = new HashSet<Patient>();
        }

        public int Id { get; set; }
        public DateOnly? NextAppointment { get; set; }
        public DateOnly? LastVisited { get; set; }
        public int? DoctorId { get; set; }

        public virtual Doctor? Doctor { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
    }
}
