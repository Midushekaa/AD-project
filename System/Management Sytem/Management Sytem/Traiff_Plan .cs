using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Management_Sytem
{
    public partial class Traiff_Plan : Form
    {
        public static readonly string connectionString =
           @"Server=.\SQLEXPRESS01;Initial Catalog=SLEB_Billing_DB;Integrated Security=True;";


        public Traiff_Plan()
        {
            InitializeComponent();
            LoadGrid();

            // Wire events
            SaveBtn.Click += SaveBtn_Click;
            UpdateBtn.Click += UpdateBtn_Click;
            DeleteBtn.Click += DeleteBtn_Click;
            ClearBtn.Click += ClearBtn_Click;
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        // ===========================
        // Load data into DataGridView
        // ===========================
        private void LoadGrid()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string sql = "SELECT TariffPlan_Id, RatePerUnit, FixedCharge, Effective_From, EffectiveTo FROM TARIFF_PLAN";
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;

                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Loading Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===========================
        // Clear all input fields
        // ===========================
        private void ClearFields()
        {
            RatePerUnitBox.Clear();
            FixedChargeBox.Clear();
            EffectiveFromBox.Clear();
            EffectiveToBox.Clear();
        }

        // ===========================
        // Save Button Click
        // ===========================
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                decimal rate = decimal.Parse(RatePerUnitBox.Text.Trim());
                decimal fixedCharge = decimal.Parse(FixedChargeBox.Text.Trim());
                DateTime effectiveFrom = DateTime.Parse(EffectiveFromBox.Text.Trim());
                DateTime effectiveTo = DateTime.Parse(EffectiveToBox.Text.Trim());

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string sql = @"INSERT INTO TARIFF_PLAN (RatePerUnit, FixedCharge, Effective_From, EffectiveTo)
                                   VALUES (@RatePerUnit, @FixedCharge, @Effective_From, @EffectiveTo)";

                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@RatePerUnit", rate);
                    cmd.Parameters.AddWithValue("@FixedCharge", fixedCharge);
                    cmd.Parameters.AddWithValue("@Effective_From", effectiveFrom);
                    cmd.Parameters.AddWithValue("@EffectiveTo", effectiveTo);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Tariff Plan saved successfully!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGrid();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Saving", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===========================
        // Update Button Click
        // ===========================
        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int planId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["TariffPlan_Id"].Value);

                try
                {
                    decimal rate = decimal.Parse(RatePerUnitBox.Text.Trim());
                    decimal fixedCharge = decimal.Parse(FixedChargeBox.Text.Trim());
                    DateTime effectiveFrom = DateTime.Parse(EffectiveFromBox.Text.Trim());
                    DateTime effectiveTo = DateTime.Parse(EffectiveToBox.Text.Trim());

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        string sql = @"UPDATE TARIFF_PLAN 
                                       SET RatePerUnit=@RatePerUnit, FixedCharge=@FixedCharge, Effective_From=@Effective_From, EffectiveTo=@EffectiveTo
                                       WHERE TariffPlan_Id=@PlanId";

                        SqlCommand cmd = new SqlCommand(sql, con);
                        cmd.Parameters.AddWithValue("@RatePerUnit", rate);
                        cmd.Parameters.AddWithValue("@FixedCharge", fixedCharge);
                        cmd.Parameters.AddWithValue("@Effective_From", effectiveFrom);
                        cmd.Parameters.AddWithValue("@EffectiveTo", effectiveTo);
                        cmd.Parameters.AddWithValue("@PlanId", planId);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        MessageBox.Show("Tariff Plan updated successfully!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadGrid();
                        ClearFields();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Updating", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a row to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ===========================
        // Delete Button Click
        // ===========================
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int planId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["TariffPlan_Id"].Value);

                DialogResult dr = MessageBox.Show("Are you sure you want to delete this plan?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection con = new SqlConnection(connectionString))
                        {
                            string sql = "DELETE FROM TARIFF_PLAN WHERE TariffPlan_Id=@PlanId";
                            SqlCommand cmd = new SqlCommand(sql, con);
                            cmd.Parameters.AddWithValue("@PlanId", planId);

                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();

                            MessageBox.Show("Tariff Plan deleted successfully!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadGrid();
                            ClearFields();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error Deleting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        // ===========================
        // DataGridView Cell Click
        // ===========================
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                RatePerUnitBox.Text = row.Cells["RatePerUnit"].Value?.ToString();
                FixedChargeBox.Text = row.Cells["FixedCharge"].Value?.ToString();

                // SAFE Date Handling
                if (row.Cells["Effective_From"].Value != DBNull.Value)
                {
                    EffectiveFromBox.Text = Convert
                        .ToDateTime(row.Cells["Effective_From"].Value)
                        .ToString("yyyy-MM-dd");
                }
                else
                {
                    EffectiveFromBox.Clear();
                }

                if (row.Cells["EffectiveTo"].Value != DBNull.Value)
                {
                    EffectiveToBox.Text = Convert
                        .ToDateTime(row.Cells["EffectiveTo"].Value)
                        .ToString("yyyy-MM-dd");
                }
                else
                {
                    EffectiveToBox.Clear();
                }
            }
        }


        // ===========================
        // Clear Button Click
        // ===========================
        private void ClearBtn_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}
