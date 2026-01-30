using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Sytem.Sub_class
{
    internal class Notification
    {
        public int Notification_id_pk { get; set; }
        public int Account_id_fk { get; set; }
        public int? Bill_id_fk { get; set; }
        public string Title { get; set; } = "";
        public string message { get; set; } = "";
    }
}
