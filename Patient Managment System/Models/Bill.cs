using Patient_Managment_System.Models.Base;
using System;
using System.Collections.Generic;

namespace Patient_Managment_System.Models
{
    public partial class Bill : IEntityBase
    {
        public Bill()
        {
            Patients = new HashSet<Patient>();
        }

        public int Id { get; set; }
        public string BillType { get; set; } = null!;
        public string PaymentMode { get; set; } = null!;
        public sbyte PaymentStatus { get; set; }
        public string Reference { get; set; } = null!;
        public decimal InvoiceAmount { get; set; }
        public decimal InvoiceTitle { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
    }
}
