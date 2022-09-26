using Patient_Managment_System.Models.Base;
using System;
using System.Collections.Generic;

namespace Patient_Managment_System.Models
{
    public partial class Prescriptiondrug : IEntityBase
    {
        public int Id { get; set; }
        public string Type { get; set; } = null!;
        public string Dose { get; set; } = null!;
        public string Duration { get; set; } = null!;
        public string Advice { get; set; } = null!;
        public string PhysicianName { get; set; } = null!;
        public int DrugId { get; set; }

        public virtual Drug IdNavigation { get; set; } = null!;
    }
}
