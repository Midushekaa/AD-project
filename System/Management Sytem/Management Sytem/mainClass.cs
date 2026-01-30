using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Management_Sytem
{
    public class mainClass
    {
        // Make connection string public for other classes to access
        public static readonly string connectionString =
            @"Server=.\SQLEXPRESS01;Initial Catalog=SLEB_Billing_DB;Integrated Security=True;";

        // ===============================
        // INSERT (Parameterized)
        // ===============================
        public static bool InsertData(string sqlQuery, string successMsg, string failMsg, params SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    if (parameters != null && parameters.Length > 0)
                        cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    bool success = cmd.ExecuteNonQuery() > 0;

                    MessageBox.Show(
                        success ? successMsg : failMsg,
                        success ? "Success" : "Failed",
                        MessageBoxButtons.OK,
                        success ? MessageBoxIcon.Information : MessageBoxIcon.Error
                    );

                    return success;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ===============================
        // UPDATE
        // ===============================
        public static bool UpdateData(string sqlQuery, params SqlParameter[] parameters)
        {
            try
            {
                if (MessageBox.Show("Do you want to update?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                    {
                        if (parameters != null && parameters.Length > 0)
                            cmd.Parameters.AddRange(parameters);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data Updated Successfully");
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Error");
            }
            return false;
        }

        // ===============================
        // DELETE
        // ===============================
        public static bool DeleteData(string sqlQuery, params SqlParameter[] parameters)
        {
            try
            {
                if (MessageBox.Show("Do you want to delete?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                    {
                        if (parameters != null && parameters.Length > 0)
                            cmd.Parameters.AddRange(parameters);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data Deleted Successfully");
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Error");
            }
            return false;
        }

        // ===============================
        // LOAD DATA INTO DATAGRIDVIEW
        // ===============================
        public static void LoadData(string sqlQuery, DataGridView dgv, params SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    if (parameters != null && parameters.Length > 0)
                        cmd.Parameters.AddRange(parameters);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgv.DataSource = dt;
                    dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
