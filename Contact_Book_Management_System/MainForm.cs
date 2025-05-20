using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using System.Drawing;

namespace Contact_Book_Management_System
{
    public partial class MainForm : Form
    {
        private OracleDbConnector db = new OracleDbConnector();
        private string loggedInUser;
        public MainForm(string Username)
        {
            InitializeComponent();
            loggedInUser = Username;

            cbSearch.SelectedIndexChanged += cbSearch_SelectedIndexChanged;

        }
        private void SetProfile()
        {
            string query = "SELECT firstname, lastname FROM users WHERE username = :username";
            OracleCommand cmd = new OracleCommand(query, db.Connection);
            cmd.Parameters.Add(":username", OracleDbType.Varchar2).Value = loggedInUser;

            try
            {
                db.OpenConnection();
                OracleDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lbProfileName.Text = $"{reader["firstname"]} {reader["lastname"]}";
                }
                else
                {
                    MessageBox.Show("User not found. Please ensure the username is correct.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show($"Oracle Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"General Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.CloseConnection();
            }
        }
        private void PopulateComboBoxWithNames()
        {
            string query = "SELECT DISTINCT firstname || ' ' || lastname AS fullname FROM contacts ORDER BY fullname";
            OracleCommand cmd = new OracleCommand(query, db.Connection);

            try
            {
                db.OpenConnection();
                OracleDataReader reader = cmd.ExecuteReader();
                cbSearch.Items.Clear();
                cbSearch.Items.Add("Select a name"); // Default option

                while (reader.Read())
                {
                    cbSearch.Items.Add(reader["fullname"].ToString());
                }

                cbSearch.SelectedIndex = 0; // Set default selection
            }
            catch (OracleException ex)
            {
                MessageBox.Show($"Oracle Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"General Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.CloseConnection();
            }
        }

        private void SetGroups()
        {
            string query = "SELECT group_id, group_name FROM groups";
            OracleCommand cmd = new OracleCommand(query, db.Connection);

            db.OpenConnection();
            OracleDataReader reader = cmd.ExecuteReader();
            dgvGroups.Rows.Clear();
            while (reader.Read())
            {
                dgvGroups.Rows.Add(
                    reader["group_id"].ToString(),
                    reader["group_name"].ToString()
                );
            }

            db.CloseConnection();
        }

        private void SetAllContacts()
        {
            string query = "SELECT contact_id, firstname, lastname, phone, email, address, group_id FROM contacts";
            OracleCommand cmd = new OracleCommand(query, db.Connection);

            try
            {
                db.OpenConnection();
                OracleDataReader reader = cmd.ExecuteReader();
                dgvContacts.Rows.Clear();

                while (reader.Read())
                {
                    dgvContacts.Rows.Add(
                        reader["contact_id"].ToString(),
                        reader["firstname"].ToString(),
                        reader["lastname"].ToString(),
                        reader["phone"].ToString(),
                        reader["email"].ToString(),
                        reader["address"].ToString(),
                        reader["group_id"].ToString()
                    );
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show($"Oracle Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"General Error: {ex.Message}");
            }
            finally
            {
                db.CloseConnection();
            }
        }
        private void SetupGroupIdColumn()
        {
            AddGroupIdColumnToGrid(dgvGroups);
            AddGroupIdColumnToGrid(dgvContacts);
        }
        private void AddGroupIdColumnToGrid(DataGridView grid)
        {
            if (!grid.Columns.Contains("group_id"))
            {
                DataGridViewTextBoxColumn groupIdColumn = new DataGridViewTextBoxColumn
                {
                    Name = "group_id",
                    HeaderText = "Group ID",
                    DataPropertyName = "group_id",
                    ReadOnly = true,
                    Visible = true,
                    Width = 100
                };
                grid.Columns.Add(groupIdColumn);
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            SetupGroupIdColumn();
            SetProfile();
            SetGroups();
            SetAllContacts();
            PopulateComboBoxWithNames();
        }
        private void llbEditProfile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProfileForm form = new ProfileForm(loggedInUser);
            if (form.ShowDialog() == DialogResult.OK)
            {
                SetProfile();
            }
        }
        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            GroupForm form = new GroupForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                SetGroups();
            }
        }

        private void btnEditGroup_Click(object sender, EventArgs e)
        {
            if (dgvGroups.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvGroups.SelectedRows[0];

                int groupId = Convert.ToInt32(selectedRow.Cells["group_id"].Value);
                string groupName = selectedRow.Cells["group_name"].Value.ToString();

                GroupForm form = new GroupForm(groupId, groupName);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    SetGroups();
                }
            }
            else
            {
                MessageBox.Show("Please select a group to edit.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRemoveGroup_Click(object sender, EventArgs e)
        {
            if (dgvGroups.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvGroups.SelectedRows[0];

                int groupId = Convert.ToInt32(selectedRow.Cells["group_id"].Value);

                var confirmResult = MessageBox.Show("Are you sure you want to delete this group?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmResult == DialogResult.Yes)
                {
                    string deleteContactsQuery = "DELETE FROM contacts WHERE group_id = :groupId";
                    OracleCommand deleteContactsCmd = new OracleCommand(deleteContactsQuery, db.Connection);
                    deleteContactsCmd.Parameters.Add(":groupId", OracleDbType.Int32).Value = groupId;

                    string deleteGroupQuery = "DELETE FROM groups WHERE group_id = :groupId";
                    OracleCommand deleteGroupCmd = new OracleCommand(deleteGroupQuery, db.Connection);
                    deleteGroupCmd.Parameters.Add(":groupId", OracleDbType.Int32).Value = groupId;

                    db.OpenConnection();
                    deleteContactsCmd.ExecuteNonQuery();
                    deleteGroupCmd.ExecuteNonQuery();
                    db.CloseConnection();

                    SetGroups();
                }

            }
            else
            {
                MessageBox.Show("Please select a group to remove.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            ContactForm form = new ContactForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                SetAllContacts();
            }
        }

        private void btnEditContact_Click(object sender, EventArgs e)
        {
            if (dgvContacts.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvContacts.SelectedRows[0];

                int contactId = Convert.ToInt32(selectedRow.Cells["contact_id"].Value);

                ContactForm form = new ContactForm(contactId);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    SetAllContacts();
                }
            }
            else
            {
                MessageBox.Show("Please select a contact to edit.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRemoveContact_Click(object sender, EventArgs e)
        {
            if (dgvContacts.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvContacts.SelectedRows[0];

                int contactId = Convert.ToInt32(selectedRow.Cells["contact_id"].Value);

                var confirmResult = MessageBox.Show("Are you sure you want to delete this contact?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmResult == DialogResult.Yes)
                {
                    string query = "DELETE FROM contacts WHERE contact_id = :contactId";
                    OracleCommand cmd = new OracleCommand(query, db.Connection);
                    cmd.Parameters.Add(":contactId", OracleDbType.Int32).Value = contactId;

                    db.OpenConnection();
                    cmd.ExecuteNonQuery();
                    db.CloseConnection();

                    SetAllContacts();
                }
            }
            else
            {
                MessageBox.Show("Please select a contact to remove.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvGroups_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvGroups.Rows[e.RowIndex];

                int groupId = Convert.ToInt32(selectedRow.Cells["group_id"].Value);
                string groupName = selectedRow.Cells["group_name"].Value.ToString();

                SetContactsForGroup(groupId);

                lbSelectedGroup.Text = $"Group Name: {groupName}";
            }
            
        }
        private void SetContactsForGroup(int groupId)
        {
            string query = "SELECT contact_id, firstname, lastname, phone, email, address FROM contacts WHERE group_id = :groupId";
            OracleCommand cmd = new OracleCommand(query, db.Connection);
            cmd.Parameters.Add(":groupId", OracleDbType.Int32).Value = groupId;

            try
            {
                db.OpenConnection();
                OracleDataReader reader = cmd.ExecuteReader();
                dgvContacts.Rows.Clear();

                while (reader.Read())
                {
                    dgvContacts.Rows.Add(
                        reader["contact_id"].ToString(),
                        reader["firstname"].ToString(),
                        reader["lastname"].ToString(),
                        reader["phone"].ToString(),
                        reader["email"].ToString(),
                        reader["address"].ToString()
                    );
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show($"Oracle Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"General Error: {ex.Message}");
            }
            finally
            {
                db.CloseConnection();
            }
        }
        private void btnShowAllContacts_Click(object sender, EventArgs e)
        {
            SetAllContacts();
        }

        private void lbSelectedGroup_Click(object sender, EventArgs e)
        {

        }

        private void dgvContacts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSearch.SelectedIndex == 0) // Ignore the default option
            {
                SetAllContacts();
                return;
            }

            string selectedName = cbSearch.SelectedItem.ToString();
            string[] nameParts = selectedName.Split(' '); // Assuming first and last names are separated by space

            string query = "SELECT contact_id, firstname, lastname, phone, email, address, group_id " +
                           "FROM contacts WHERE firstname = :firstName AND lastname = :lastName";

            OracleCommand cmd = new OracleCommand(query, db.Connection);
            cmd.Parameters.Add(":firstName", OracleDbType.Varchar2).Value = nameParts[0];
            cmd.Parameters.Add(":lastName", OracleDbType.Varchar2).Value = nameParts.Length > 1 ? nameParts[1] : "";

            try
            {
                db.OpenConnection();
                OracleDataReader reader = cmd.ExecuteReader();
                dgvContacts.Rows.Clear();

                while (reader.Read())
                {
                    dgvContacts.Rows.Add(
                        reader["contact_id"].ToString(),
                        reader["firstname"].ToString(),
                        reader["lastname"].ToString(),
                        reader["phone"].ToString(),
                        reader["email"].ToString(),
                        reader["address"].ToString(),
                        reader["group_id"].ToString()
                    );
                }

                if (dgvContacts.Rows.Count == 0)
                {
                    MessageBox.Show("No contacts found for the selected name.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show($"Oracle Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"General Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.CloseConnection();
            }
        }
    }
}
