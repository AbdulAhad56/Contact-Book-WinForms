using System;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Contact_Book_Management_System
{
    public partial class GroupForm : Form
    {
        private OracleDbConnector db = new OracleDbConnector();
        private readonly int groupId = -1;
        private bool isSelectionMode = false;
        public int SelectedGroupId { get; private set; }

        public GroupForm()
        {
            InitializeComponent();
        }

        public GroupForm(bool isSelectionMode)
        {
            InitializeComponent();
            this.isSelectionMode = isSelectionMode;
        }
        public GroupForm(int groupId, string groupName)
        {
            InitializeComponent();
            this.groupId = groupId;
            this.tbGroupName.Text = groupName;
        }

        private bool CheckEmptyFields()
        {
            return string.IsNullOrEmpty(tbGroupName.Text.Trim());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckEmptyFields())
            {
                MessageBox.Show("Please enter a group name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = groupId == -1 ?
                "INSERT INTO groups (group_name) VALUES (:groupName)" :
                "UPDATE groups SET group_name = :groupName WHERE group_id = :groupID";

            OracleCommand cmd = new OracleCommand(query, db.Connection);
            cmd.Parameters.Add(":groupName", OracleDbType.Varchar2).Value = tbGroupName.Text;

            if (groupId != -1)
            {
                cmd.Parameters.Add(":groupID", OracleDbType.Int32).Value = groupId;
            }

            try
            {
                db.OpenConnection();
                cmd.ExecuteNonQuery();
                MessageBox.Show(groupId == -1 ? "Group added successfully." : "Group updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.CloseConnection();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
