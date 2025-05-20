using System;
using System.IO;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using System.Drawing;

namespace Contact_Book_Management_System
{
    public partial class ProfileForm : Form
    {
        private OracleDbConnector db = new OracleDbConnector();
        private string loggedInUser;

        public ProfileForm(string username)
        {
            InitializeComponent();
            loggedInUser = username;
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            string query = "SELECT firstname, lastname, username FROM users WHERE username = :username";
            OracleCommand cmd = new OracleCommand(query, db.Connection);
            cmd.Parameters.Add(":username", OracleDbType.Varchar2).Value = loggedInUser;

            try
            {
                db.OpenConnection();
                OracleDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    tbFirstname.Text = reader["firstname"].ToString();
                    tbLastname.Text = reader["lastname"].ToString();
                    tbUsername.Text = reader["username"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.CloseConnection();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string query = "UPDATE users SET firstname = :firstName, lastname = :lastName, picture = :picture WHERE username = :username";
            OracleCommand cmd = new OracleCommand(query, db.Connection);

            cmd.Parameters.Add(":firstName", OracleDbType.Varchar2).Value = tbFirstname.Text;
            cmd.Parameters.Add(":lastName", OracleDbType.Varchar2).Value = tbLastname.Text;

            byte[] imageBytes = null;
            if (pbPicture.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    pbPicture.Image.Save(ms, pbPicture.Image.RawFormat);
                    imageBytes = ms.ToArray();
                }
            }
            cmd.Parameters.Add(":picture", OracleDbType.Blob).Value = imageBytes;
            cmd.Parameters.Add(":username", OracleDbType.Varchar2).Value = loggedInUser;

            db.OpenConnection();
            cmd.ExecuteNonQuery();
            db.CloseConnection();

            MessageBox.Show("Profile updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        private void btnPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Select Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pbPicture.Image = Image.FromFile(dialog.FileName);
            }
        }
        private void btnPassword_Click(object sender, EventArgs e)
        {
            string username = loggedInUser;
            PasswordChangeForm form = new PasswordChangeForm(username);
            form.ShowDialog();
        }
    }
}
