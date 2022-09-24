using System;
using System.Collections.Generic;

namespace Patient_Managment_System.Models
{
    public partial class Prescriptiontest
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? Result { get; set; }
        public string? TestId { get; set; }

        public virtual Test IdNavigation { get; set; } = null!;
    }
}
