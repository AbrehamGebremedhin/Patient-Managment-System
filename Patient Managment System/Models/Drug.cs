using Patient_Managment_System.Models.Base;
using System;
using System.Collections.Generic;

namespace Patient_Managment_System.Models
{
    public partial class Drug : IEntityBase
    {
        public int Id { get; set; }
        public string TradeName { get; set; } = null!;
        public string GenericName { get; set; } = null!;
        public string Note { get; set; } = null!;
        public decimal Price { get; set; }
        public DateTime ExpireDate { get; set; }
        public sbyte? Avaliable { get; set; }

        public virtual Prescriptiondrug Prescriptiondrug { get; set; } = null!;
    }
}
