using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Machinery
    {
        public int MachineryID {  get; set; }
        public string MachineryDescription {  get; set; }
        public string MachineryType { get; set; }
        public double MachineryActualUseTime { get; set; }
        public double MachineryMaxHoursPerDay {  get; set; }
        public double MaintenanceHours {  get; set; }
    }
}
