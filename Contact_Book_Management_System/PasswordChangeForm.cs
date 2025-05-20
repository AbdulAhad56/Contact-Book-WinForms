using System;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Contact_Book_Management_System
{
    public partial class PasswordChangeForm : Form
    {
        private OracleDbConnector db = new OracleDbConnector();
        private string loggedInUser;

        public PasswordChangeForm(string username)
        {
            InitializeComponent();
            loggedInUser = username;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbOld.Text) ||
                string.IsNullOrWhiteSpace(tbNew.Text) ||
                string.IsNullOrWhiteSpace(tbConfirm.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tbNew.Text != tbConfirm.Text)
            {
                MessageBox.Show("New password and confirmation do not match.", "Password Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string query = "SELECT \"USER_PASSWORD\" FROM users WHERE username = :username";
            try
            {
                db.OpenConnection();

                OracleCommand cmd = new OracleCommand(query, db.Connection);
                cmd.Parameters.Add(":username", OracleDbType.Varchar2).Value = loggedInUser;

                OracleDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string storedPassword = reader["USER_PASSWORD"].ToString();

                    if (tbOld.Text == storedPassword)
                    {
                        string updateQuery = "UPDATE users SET \"USER_PASSWORD\" = :newPassword WHERE username = :username";
                        OracleCommand updateCmd = new OracleCommand(updateQuery, db.Connection);
                        updateCmd.Parameters.Add(":newPassword", OracleDbType.Varchar2).Value = tbNew.Text;
                        updateCmd.Parameters.Add(":username", OracleDbType.Varchar2).Value = loggedInUser;

                        int rowsAffected = updateCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Password updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show("Failed to update password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Current password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("User not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
