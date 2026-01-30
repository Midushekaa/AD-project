using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Sytem.Sub_class
{
    internal class TariffPlan
    {
        public int TariffPlan_Id { get; set; }
        public int? Bill_id_fk { get; set; }
        public decimal FixedCharge { get; set; }
        public decimal RatePerUnit { get; set; }
        public DateTime Effective_From { get; set; }
        public DateTime? EffectiveTo { get; set; }
    }
}
