using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Contact_Book_Management_System
{
    public partial class ContactForm : Form
    {
        private OracleDbConnector db = new OracleDbConnector();
        private int contactId = -1;

        public ContactForm()
        {
            InitializeComponent();
        }

        public ContactForm(int contactID)
        {
            InitializeComponent();
            this.contactId = contactID;
            LoadContactData(contactID);
        }

        private void LoadGroups()
        {
            string query = "SELECT group_id, group_name FROM groups";
            OracleCommand cmd = new OracleCommand(query, db.Connection);

            db.OpenConnection();
            OracleDataReader reader = cmd.ExecuteReader();
            cbGroup.Items.Clear();

            while (reader.Read())
            {
                cbGroup.Items.Add(new { Text = reader["group_name"].ToString(), Value = reader["group_id"] });
            }
            db.CloseConnection();
        }


        private void LoadContactData(int contactID)
        {
            string query = "SELECT firstname, lastname, phone, email, address, group_id FROM contacts WHERE contact_id = :contactID";
            OracleCommand cmd = new OracleCommand(query, db.Connection);
            cmd.Parameters.Add(":contactID", OracleDbType.Int32).Value = contactID;

            db.OpenConnection();
            OracleDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                tbFirstname.Text = reader["firstname"].ToString();
                tbLastname.Text = reader["lastname"].ToString();
                tbPhone.Text = reader["phone"].ToString();
                tbEmail.Text = reader["email"].ToString();
                tbAddress.Text = reader["address"].ToString();
                int groupId = Convert.ToInt32(reader["group_id"]);

                foreach (var item in cbGroup.Items)
                {
                    dynamic group = item;
                    if (Convert.ToInt32(group.Value) == groupId)
                    {
                        cbGroup.SelectedItem = group;
                        break;
                    }
                }
            }
            db.CloseConnection();
        }

        private bool CheckEmptyFields()
        {
            return string.IsNullOrEmpty(tbFirstname.Text.Trim()) ||
                   string.IsNullOrEmpty(tbLastname.Text.Trim()) ||
                   (string.IsNullOrEmpty(tbPhone.Text.Trim()) && string.IsNullOrEmpty(tbEmail.Text.Trim()));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckEmptyFields())
            {
                MessageBox.Show("Please fill all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbGroup.SelectedItem == null)
            {
                MessageBox.Show("Please select a group.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedGroupId = (int)((dynamic)cbGroup.SelectedItem).Value;

            string query = contactId == -1 ?
                "INSERT INTO contacts (firstname, lastname, phone, email, address, group_id) VALUES (:firstName, :lastName, :phone, :email, :address, :groupId)" :
                "UPDATE contacts SET firstname = :firstName, lastname = :lastName, phone = :phone, email = :email, address = :address, group_id = :groupId WHERE contact_id = :contactID";

            OracleCommand cmd = new OracleCommand(query, db.Connection);
            cmd.Parameters.Add(":firstName", OracleDbType.Varchar2).Value = tbFirstname.Text;
            cmd.Parameters.Add(":lastName", OracleDbType.Varchar2).Value = tbLastname.Text;
            cmd.Parameters.Add(":phone", OracleDbType.Varchar2).Value = tbPhone.Text;
            cmd.Parameters.Add(":email", OracleDbType.Varchar2).Value = tbEmail.Text;
            cmd.Parameters.Add(":address", OracleDbType.Varchar2).Value = tbAddress.Text;
            cmd.Parameters.Add(":groupId", OracleDbType.Int32).Value = selectedGroupId;

            if (contactId != -1)
            {
                cmd.Parameters.Add(":contactID", OracleDbType.Int32).Value = contactId;
            }

            try
            {
                db.OpenConnection();
                cmd.ExecuteNonQuery();
                db.CloseConnection();

                MessageBox.Show(contactId == -1 ? "Contact added successfully." : "Contact updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }


        private void btnGroups_Click(object sender, EventArgs e)
        {
            GroupForm groupForm = new GroupForm();
            if (groupForm.ShowDialog() == DialogResult.OK)
            {
                // Get the selected group ID and assign it to the Group ComboBox
                int selectedGroupId = groupForm.SelectedGroupId;

                // Find the group in the ComboBox and select it
                foreach (var item in cbGroup.Items)
                {
                    dynamic group = item;
                    if (Convert.ToInt32(group.Value) == selectedGroupId)
                    {
                        cbGroup.SelectedItem = group;
                        break;
                    }
                }
            }
        }

        private void ContactForm_Load(object sender, EventArgs e)
        {
            LoadGroups();
            if (contactId != -1)
            {
                LoadContactData(contactId);
            }
        }
    }
}
