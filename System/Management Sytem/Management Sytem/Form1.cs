using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Management_Sytem
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection(
            @"Server=.\SQLEXPRESS01;Initial Catalog=SLEB_Billing_DB;Integrated Security=True;"
        );

        public Form1()
        {
            InitializeComponent();
        }

        // Show / Hide password
        private void login_showPass_CheckedChanged(object sender, EventArgs e)
        {
            login_password.PasswordChar = login_showPass.Checked ? '\0' : '*';
        }

        // Close app
        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Go to Register form
        private void login_registerBtn_Click(object sender, EventArgs e)
        {
            RegisterForm rf = new RegisterForm();
            rf.Show();
            this.Hide();
        }

        // ===========================
        // LOGIN BUTTON
        // ===========================
        private void login_btn_Click(object sender, EventArgs e)
        {
            // Check empty fields
            if (string.IsNullOrWhiteSpace(login_username.Text) || string.IsNullOrWhiteSpace(login_password.Text))
            {
                MessageBox.Show("Please enter username and password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                conn.Open();

                string query = @"
            SELECT Account_Id_fk, Role
            FROM LOGIN
            WHERE Username = @username
            AND [Password] = @password";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", login_username.Text.Trim());
                cmd.Parameters.AddWithValue("@password", login_password.Text.Trim());

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string role = reader["Role"].ToString().ToUpper();

                    if (role == "CUSTOMER")
                    {
                        // Check for Account_Id_fk being null
                        if (reader["Account_Id_fk"] == DBNull.Value)
                        {
                            MessageBox.Show("Customer account not found. Please contact admin.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        int accountId = Convert.ToInt32(reader["Account_Id_fk"]);
                        MessageBox.Show("Customer Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Open Customer Dashboard
                        this.Hide();
                        CustomerDashboard cd = new CustomerDashboard(accountId);
                        cd.Show();
                    }
                    else if (role == "ADMIN")
                    {
                        MessageBox.Show("Admin Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Open Admin Dashboard
                        this.Hide();
                        AdminDashboard ad = new AdminDashboard();
                        ad.Show();
                    }
                    else
                    {
                        MessageBox.Show("Unknown role. Contact administrator.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("System Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}