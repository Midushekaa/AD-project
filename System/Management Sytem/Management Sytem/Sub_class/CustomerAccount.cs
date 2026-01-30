using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Sytem.Sub_class
{
    internal class CustomerAccount
    {
        public int Account_Id_pk { get; set; }
        public int Customer_Id_fk { get; set; }
        public int AccountNumber { get; set; }
        public string Account_Status { get; set; } = "";
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
    }
}
