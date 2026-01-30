using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Sytem.Sub_class
{
    internal class Customer
    {
        public int Customer_Id_PK { get; set; }
        public string Name { get; set; } = "";
        public string NIC { get; set; } = "";
        public int? Phone_No { get; set; }
        public string Address { get; set; }
        public int? Notification_id_fk { get; set; }

    }
}
