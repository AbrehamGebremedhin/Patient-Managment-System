using Patient_Managment_System.Models.Base;
using System;
using System.Collections.Generic;

namespace Patient_Managment_System.Models
{
    public partial class Appointment : IEntityBase
    {
        public int Id { get; set; }
        public DateTime NextAppointment { get; set; }
        public DateTime LastVisited { get; set; }
        public string DoctorName { get; set; }
        public string PatientName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
