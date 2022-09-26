using Patient_Managment_System.Models.Base;
using System;
using System.Collections.Generic;

namespace Patient_Managment_System.Models
{
    public partial class Doctor :IEntityBase
    {
        public Doctor()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public string? Speciality { get; set; }
        public string? SaturdayFrom { get; set; }
        public string? SaturdayTo { get; set; }
        public string? SundayFrom { get; set; }
        public string? SundayTo { get; set; }
        public string? MondayFrom { get; set; }
        public string? MondayTo { get; set; }
        public string? TuesdayFrom { get; set; }
        public string? TuesdayTo { get; set; }
        public string? WednesdayFrom { get; set; }
        public string? WednesdayTo { get; set; }
        public string? ThursdayFrom { get; set; }
        public string? ThursdayTo { get; set; }
        public string? FridayFrom { get; set; }
        public string? FridayTo { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
