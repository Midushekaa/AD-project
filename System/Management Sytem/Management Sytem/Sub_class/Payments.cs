using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Sytem.Sub_class
{
    internal class Payments
    {
        public int Payment_Id_pk { get; set; }
        public int Account_Id_fk { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal AmountPaid { get; set; }
        public string PaymentStatus { get; set; } = "";
        public decimal AllocatedAmount { get; set; }
        public int Bill_Id_fk { get; set; }
    }
}
