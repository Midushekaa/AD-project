using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Sytem.Sub_class
{
    internal class Bills
    {
        public int Bill_id_pk { get; set; }
        public int Account_Id_fk { get; set; }
        public int Meter_Id_fk { get; set; }
        public int Reading_Id_fk { get; set; }
        public int TariffPlan_Id_fk { get; set; }
        public string BillingMonth { get; set; } = "";
        public decimal TotalBillAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal OutstandingAmount { get; set; }
        public DateTime DueDate { get; set; }
        public string BillStatus { get; set; } = "";
    }
}
