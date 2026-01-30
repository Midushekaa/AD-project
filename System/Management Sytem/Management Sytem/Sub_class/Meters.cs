using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Sytem.Sub_class
{
    internal class Meters
    {
        public int Meter_Id_pk { get; set; }
        public int Meter_Number { get; set; }
        public int Account_Id_fk { get; set; }
        public string MeterStatus { get; set; } = "";
    }
}
