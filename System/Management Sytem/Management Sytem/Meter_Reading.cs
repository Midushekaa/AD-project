using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Management_Sytem
{
    public partial class Meter_Reading : Form
    {
        private static readonly string connectionString =
            @"Server=.\SQLEXPRESS01;Initial Catalog=SLEB_Billing_DB;Integrated Security=True;";

        public Meter_Reading()
        {
            InitializeComponent();
            LoadGrid();

            SaveBtn.Click += SaveBtn_Click;
            UpdateBtn.Click += UpdateBtn_Click;
            DeleteBtn.Click += DeleteBtn_Click;
            ClearBtn.Click += ClearBtn_Click;
            dataGridView1.CellClick += dataGridView1_CellClick;

            CurrentValueBox.TextChanged += CalculateUnits;
            PreviousValueBox.TextChanged += CalculateUnits;
        }

        // =========================
        // LOAD DATA
        // =========================
        private void LoadGrid()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT * FROM METER_READING", con);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        // =========================
        // CALCULATE UNITS
        // =========================
        private void CalculateUnits(object sender, EventArgs e)
        {
            if (int.TryParse(PreviousValueBox.Text, out int prev) &&
                int.TryParse(CurrentValueBox.Text, out int curr))
            {
                if (curr >= prev)
                    UnitsBox.Text = (curr - prev).ToString();
                else
                    UnitsBox.Clear();
            }
            else
            {
                UnitsBox.Clear();
            }
        }

        // =========================
        // SAVE
        // =========================
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs(out int prev, out int curr, out int units))
                return;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(
                    @"INSERT INTO METER_READING 
                      (ReadingMonth, PreviousValue, CurrentValue, UnitsConsumed)
                      VALUES (@Month, @Prev, @Curr, @Units)", con);

                cmd.Parameters.AddWithValue("@Month", ReadingMonthDate.Value.Date);
                cmd.Parameters.AddWithValue("@Prev", prev);
                cmd.Parameters.AddWithValue("@Curr", curr);
                cmd.Parameters.AddWithValue("@Units", units);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Meter Reading Saved Successfully");
            LoadGrid();
            ClearFields();
        }

        // =========================
        // UPDATE
        // =========================
        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Select a record first");
                return;
            }

            if (!ValidateInputs(out int prev, out int curr, out int units))
                return;

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["MeterReading_Id"].Value);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(
                    @"UPDATE METER_READING 
                      SET ReadingMonth=@Month, PreviousValue=@Prev,
                          CurrentValue=@Curr, UnitsConsumed=@Units
                      WHERE MeterReading_Id=@Id", con);

                cmd.Parameters.AddWithValue("@Month", ReadingMonthDate.Value.Date);
                cmd.Parameters.AddWithValue("@Prev", prev);
                cmd.Parameters.AddWithValue("@Curr", curr);
                cmd.Parameters.AddWithValue("@Units", units);
                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Meter Reading Updated");
            LoadGrid();
            ClearFields();
        }

        // =========================
        // DELETE
        // =========================
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Select a record first");
                return;
            }

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["MeterReading_Id"].Value);

            if (MessageBox.Show("Delete this reading?", "Confirm",
                MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM METER_READING WHERE MeterReading_Id=@Id", con);

                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Meter Reading Deleted");
            LoadGrid();
            ClearFields();
        }

        // =========================
        // GRID CLICK
        // =========================
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            ReadingMonthDate.Value = Convert.ToDateTime(row.Cells["ReadingMonth"].Value);
            PreviousValueBox.Text = row.Cells["PreviousValue"].Value.ToString();
            CurrentValueBox.Text = row.Cells["CurrentValue"].Value.ToString();
            UnitsBox.Text = row.Cells["UnitsConsumed"].Value.ToString();
        }

        // =========================
        // VALIDATION
        // =========================
        private bool ValidateInputs(out int prev, out int curr, out int units)
        {
            prev = curr = units = 0;

            if (!int.TryParse(PreviousValueBox.Text, out prev))
            {
                MessageBox.Show("Invalid Previous Value");
                return false;
            }

            if (!int.TryParse(CurrentValueBox.Text, out curr))
            {
                MessageBox.Show("Invalid Current Value");
                return false;
            }

            if (curr < prev)
            {
                MessageBox.Show("Current Value cannot be less than Previous Value");
                return false;
            }

            units = curr - prev;
            UnitsBox.Text = units.ToString();
            return true;
        }

        // =========================
        // CLEAR
        // =========================
        private void ClearFields()
        {
            PreviousValueBox.Clear();
            CurrentValueBox.Clear();
            UnitsBox.Clear();
            ReadingMonthDate.Value = DateTime.Now;
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}
