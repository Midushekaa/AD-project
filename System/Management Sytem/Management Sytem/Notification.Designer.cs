using System.Windows.Forms;

namespace Management_Sytem
{
    partial class Notification
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvNotifications;
        private TextBox txtNotificationId, txtAccountId, txtBillId, txtTitle, txtMessage;
        private Button btnSave, btnUpdate, btnDelete, btnClear;

        private void InitializeComponent()
        {
            this.dgvNotifications = new DataGridView();
            this.txtNotificationId = new TextBox();
            this.txtAccountId = new TextBox();
            this.txtBillId = new TextBox();
            this.txtTitle = new TextBox();
            this.txtMessage = new TextBox();
            this.btnSave = new Button();
            this.btnUpdate = new Button();
            this.btnDelete = new Button();
            this.btnClear = new Button();

            // Form
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Text = "Notifications";

            // DataGridView
            this.dgvNotifications.Location = new System.Drawing.Point(10, 300);
            this.dgvNotifications.Size = new System.Drawing.Size(780, 280);
            this.dgvNotifications.CellClick += dgvNotifications_CellClick;
            this.Controls.Add(this.dgvNotifications);

            // TextBoxes & Labels
            int top = 20;
            void addLabelAndTextbox(string labelText, TextBox tb)
            {
                Label lbl = new Label() { Text = labelText, Location = new System.Drawing.Point(20, top), Width = 120 };
                tb.Location = new System.Drawing.Point(150, top);
                tb.Width = 200;
                this.Controls.Add(lbl);
                this.Controls.Add(tb);
                top += 40;
            }

            addLabelAndTextbox("Notification ID", txtNotificationId);
            addLabelAndTextbox("Account ID", txtAccountId);
            addLabelAndTextbox("Bill ID", txtBillId);
            addLabelAndTextbox("Title", txtTitle);
            addLabelAndTextbox("Message", txtMessage);

            // Buttons
            btnSave.Text = "Save"; btnSave.Location = new System.Drawing.Point(400, 20); btnSave.Click += btnSave_Click;
            btnUpdate.Text = "Update"; btnUpdate.Location = new System.Drawing.Point(400, 70); btnUpdate.Click += btnUpdate_Click;
            btnDelete.Text = "Delete"; btnDelete.Location = new System.Drawing.Point(400, 120); btnDelete.Click += btnDelete_Click;
            btnClear.Text = "Clear"; btnClear.Location = new System.Drawing.Point(400, 170); btnClear.Click += btnClear_Click;

            this.Controls.Add(btnSave);
            this.Controls.Add(btnUpdate);
            this.Controls.Add(btnDelete);
            this.Controls.Add(btnClear);
        }
    }
}
