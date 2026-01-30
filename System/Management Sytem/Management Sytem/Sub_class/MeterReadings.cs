using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Sytem.Sub_class
{
    internal class MeterReadings
    {
        public int Reading_Id_pk { get; set; }
        public int Meter_Id_fk { get; set; }
        public DateTime ReadingMonth { get; set; }
        public decimal PreviousReadingValue { get; set; }
        public decimal CurrentReadingValue { get; set; }
        public decimal UnitsConsumed { get; set; }

    }
}
