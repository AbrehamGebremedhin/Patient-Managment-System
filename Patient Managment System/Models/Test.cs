using System;
using System.Collections.Generic;

namespace Patient_Managment_System.Models
{
    public partial class Test
    {
        public int Id { get; set; }
        public string? TestName { get; set; }
        public string? Comment { get; set; }
        public string? Price { get; set; }

        public virtual Prescriptiontest Prescriptiontest { get; set; } = null!;
    }
}
