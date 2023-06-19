using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arztpraxis.Shared
{
    public class Termin
    {
        public int Id { get; set; }
        public DateTime Beginn { get; set; } = DateTime.MinValue; 
        public DateTime Ende { get; set; } = DateTime.MinValue;
        public string Uhrzeit { get; set; } = string.Empty;
        public string Bemerkung { get; set; } = string.Empty;
        public int PatientId { get; set; } = 0;
        public Person Patient { get; set; } = new();
        public int DiagnoseId { get; set; } = 0;
        public Diagnose Diagnose { get; set; } = new();
    }
}
