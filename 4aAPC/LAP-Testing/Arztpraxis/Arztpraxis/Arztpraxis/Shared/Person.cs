using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arztpraxis.Shared
{
    public class Person
    {
        public int Id { get; set; }
        public string VName { get; set; } = string.Empty;
        public string NName { get; set; } = string.Empty;
        public int svnr { get; set; } = 0;
        public DateTime GebDatum { get; set; } = DateTime.MinValue;
    }
}
