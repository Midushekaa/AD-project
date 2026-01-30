using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Management_Sytem
{
    public partial class Meter : Form
    {
        SqlConnection con = new SqlConnection(
            @"Server=.\SQLEXPRESS01;Initial Catalog=SLEB_Billing_DB;Integrated Security=True;"
        );

        int meterId = 0;

        public Meter()
        {
            InitializeComponent();
            LoadMeterData();
        }

        // ================= LOAD DATA =================
        private void LoadMeterData()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT Meter_Id_pk, Meter_Number, MeterStatus FROM METER", con);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                dataGridView1.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ================= SAVE =================
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (MeterBox.Text == "" || MeterstatusCmb.Text == "-- none --")
            {
                MessageBox.Show("Please fill all fields");
                return;
            }

            try
            {
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO METER (Meter_Number, MeterStatus, Account_Id_fk) " +
                    "VALUES (@num, @status, @account)", con);

                cmd.Parameters.AddWithValue("@num", int.Parse(MeterBox.Text));
                cmd.Parameters.AddWithValue("@status", MeterstatusCmb.Text);
                cmd.Parameters.AddWithValue("@account", 1); // TEMP account id

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Meter Saved Successfully");
                LoadMeterData();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        // ================= UPDATE =================
        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (meterId == 0)
            {
                MessageBox.Show("Select a record to update");
                return;
            }

            try
            {
                SqlCommand cmd = new SqlCommand(
                    "UPDATE METER SET Meter_Number=@num, MeterStatus=@status " +
                    "WHERE Meter_Id_pk=@id", con);

                cmd.Parameters.AddWithValue("@num", int.Parse(MeterBox.Text));
                cmd.Parameters.AddWithValue("@status", MeterstatusCmb.Text);
                cmd.Parameters.AddWithValue("@id", meterId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Meter Updated Successfully");
                LoadMeterData();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        // ================= DELETE =================
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (meterId == 0)
            {
                MessageBox.Show("Select a record to delete");
                return;
            }

            if (MessageBox.Show("Are you sure?", "Confirm",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(
                        "DELETE FROM METER WHERE Meter_Id_pk=@id", con);

                    cmd.Parameters.AddWithValue("@id", meterId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Meter Deleted");
                    LoadMeterData();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    con.Close();
                }
            }
        }

        // ================= CLEAR =================
        private void ClearBtn_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            MeterBox.Clear();
            MeterstatusCmb.Text = "-- none --";
            meterId = 0;
        }

        // ================= GRID CLICK =================
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                meterId = Convert.ToInt32(
                    dataGridView1.Rows[e.RowIndex].Cells["Meter_Id_pk"].Value);

                MeterBox.Text =
                    dataGridView1.Rows[e.RowIndex].Cells["Meter_Number"].Value.ToString();

                MeterstatusCmb.Text =
                    dataGridView1.Rows[e.RowIndex].Cells["MeterStatus"].Value.ToString();
            }
        }
    }
}
