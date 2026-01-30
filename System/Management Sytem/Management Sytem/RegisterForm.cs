using System;
using System.Windows.Forms;

namespace Management_Sytem
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void register_loginBtn_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
            this.Hide();
        }

        private void register_showPass_CheckedChanged(object sender, EventArgs e)
        {
            register_password.PasswordChar = register_showPass.Checked ? '\0' : '*';
            register_cPassword.PasswordChar = register_showPass.Checked ? '\0' : '*';
        }

        private void register_btn_Click(object sender, EventArgs e)
        {
            if (register_username.Text == "" || register_password.Text == "" || register_cPassword.Text == "")
            {
                MessageBox.Show("Please fill all fields");
                return;
            }

            if (register_password.Text != register_cPassword.Text)
            {
                MessageBox.Show("Passwords do not match!");
                return;
            }

            MessageBox.Show("Registered Successfully!");
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Optional — you can leave empty
        }
    }
}
