using Patient_Managment_System.Models.Base;
using System;
using System.Collections.Generic;

namespace Patient_Managment_System.Models
{
    public partial class Patient : IEntityBase
    {
        public int Id { get; set; }
        public string Fullname { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string? Email { get; set; }
        public string Gender { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string BloodType { get; set; } = null!;
        public float Weight { get; set; }
        public float Height { get; set; }
        public DateTime Age { get; set; }
        public int? BillId { get; set; }
        public int? AppointemtId { get; set; }
        public string? Password { get; set; }
        public int? OrderId { get; set; }
        public int? DiagnosisId { get; set; }

        public virtual Appointment? Appointemt { get; set; }
        public virtual Bill? Bill { get; set; }
        public virtual PatientDiag? Diagnosis { get; set; }
        public virtual OrderHistory? Order { get; set; }
    }
}
