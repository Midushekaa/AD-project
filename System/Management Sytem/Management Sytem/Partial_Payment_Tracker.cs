using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Management_Sytem
{
    public partial class Partial_Payment_Tracker : Form
    {
        public Partial_Payment_Tracker()
        {
            InitializeComponent();
            this.Load += Partial_Payment_Tracker_Load; // Attach Load event
        }

        private void Partial_Payment_Tracker_Load(object sender, EventArgs e)
        {
            LoadGrid(); // Load data when form is fully loaded
        }

        private void LoadGrid()
        {
            try
            {
                // Replace with your actual table and columns
                string sql = "SELECT Payment_Id_PK, Customer_Id_fk, Bill_Id_fk, Amount, Paid_Date FROM Partial_Payment";
                mainClass.LoadData(sql, dataGridView1);

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Optional: implement Save, Update, Delete, etc.
    }
}
