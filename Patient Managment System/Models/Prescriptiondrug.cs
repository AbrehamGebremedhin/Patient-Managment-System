using System;
using System.Collections.Generic;

namespace Patient_Managment_System.Models
{
    public partial class Prescriptiondrug
    {
        public int Id { get; set; }
        public string Type { get; set; } = null!;
        public string Dose { get; set; } = null!;
        public string Duration { get; set; } = null!;
        public string Advice { get; set; } = null!;
        public int DrugId { get; set; }

        public virtual Drug IdNavigation { get; set; } = null!;
    }
}
