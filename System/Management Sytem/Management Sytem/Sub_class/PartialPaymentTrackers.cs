using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Sytem.Sub_class
{
    internal class PartialPaymentTrackers
    {
        public int Tracker_Id_fk { get; set; }
        public int Account_Id_fk { get; set; }
        public DateTime? LastPartialMonth { get; set; }
        public int ConsecutivePartialCount { get; set; }
    }
}
