using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Sytem.Sub_class
{
    internal class Login
    {
        public int Login_id_Pk { get; set; }
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string Role { get; set; } = "";
        public int? Admin_Id_fk { get; set; }
        public int? Account_Id_fk { get; set; }
    }
}
