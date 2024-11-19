using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Maintenance
    {
        public  int MaintenanceID { get; set; }
        public required int ClientID { get; set; }
        public required DateTime MaintenanceExecutedDate { get; set; }
        public required DateTime MaintenanceScheduledDate { get; set; }
        public required double PropertyAreaSize { get; set; }
        public required double HedgeArea { get; set; }
        public required int DaysWithoutMowing { get; set; }
        public required int MowingPreferenceID { get; set; }
        public required string GrassType { get; set; }
        public required bool HasAppliedProducts { get; set; }
        public string ?AppliedProductName { get; set; }
        public  double AppliedProductPrice { get; set; }
        public required double MowingCostPerSquareMeter { get; set; }
        public  double ProductApplicationCostPerSquareMeter { get; set; }
        public required int MaintenanceStatus { get; set; }
        public required double TotalCost { get; set; }
        public DateTime NextMowingDate { get; set; }
    }
}
