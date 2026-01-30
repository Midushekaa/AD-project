using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Sytem.Sub_class
{
    internal class Admin
    {
        public int admin_id_pk { get; set; }
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string Status { get; set; } = "";
        public int? Bill_id_fk { get; set; }
        public int? Notification_id_fk { get; set; }
    }
}
