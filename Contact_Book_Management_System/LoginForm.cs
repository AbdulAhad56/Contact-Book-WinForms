using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Contact_Book_Management_System
{
    public partial class LoginForm : Form
    {
        private OracleDbConnector db = new OracleDbConnector();

        public LoginForm()
        {
            InitializeComponent();
        }

        private bool ValidateUser(string username, string password)
        {
            string query = "SELECT id, user_password FROM users WHERE username = :username";
            OracleCommand command = new OracleCommand(query, db.Connection);
            command.Parameters.Add(":username", OracleDbType.Varchar2).Value = username;

            db.OpenConnection();
            OracleDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                string storedPassword = reader["user_password"].ToString();
                if (password == storedPassword)
                {
                    db.CloseConnection();
                    return true;
                }
            }

            db.CloseConnection();
            return false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbLoginUsername.Text;
            string password = tbLoginPassword.Text;

            if (ValidateUser(username, password))
            {
                string Username = tbLoginUsername.Text;
                MainForm mainForm = new MainForm(Username);
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSignin_Click(object sender, EventArgs e)
        {
            string firstName = tbFirstname.Text;
            string lastName = tbLastname.Text;
            string username = tbSigninUsername.Text;
            string password = tbSigninPassword.Text;

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill all the fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string checkUsernameQuery = "SELECT COUNT(*) FROM users WHERE username = :username";
            OracleCommand checkUsernameCommand = new OracleCommand(checkUsernameQuery, db.Connection);
            checkUsernameCommand.Parameters.Add(":username", OracleDbType.Varchar2).Value = username;

            try
            {
                db.OpenConnection();
                int userCount = Convert.ToInt32(checkUsernameCommand.ExecuteScalar());

                if (userCount > 0)
                {
                    MessageBox.Show("Username already exists. Please choose another username.", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                byte[] pictureBytes = null;
                if (pbPicture.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        pbPicture.Image.Save(ms, pbPicture.Image.RawFormat);
                        pictureBytes = ms.ToArray();
                    }
                }

                string insertQuery = "INSERT INTO users (firstname, lastname, username, user_password, picture) VALUES (:firstName, :lastName, :username, :password, :picture)";
                OracleCommand insertCommand = new OracleCommand(insertQuery, db.Connection);
                insertCommand.Parameters.Add(":firstName", OracleDbType.Varchar2).Value = firstName;
                insertCommand.Parameters.Add(":lastName", OracleDbType.Varchar2).Value = lastName;
                insertCommand.Parameters.Add(":username", OracleDbType.Varchar2).Value = username;
                insertCommand.Parameters.Add(":password", OracleDbType.Varchar2).Value = password;
                insertCommand.Parameters.Add(":picture", OracleDbType.Blob).Value = pictureBytes;

                insertCommand.ExecuteNonQuery();
                MessageBox.Show("Registration successful! You can now log in.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
            catch (OracleException ex)
            {
                MessageBox.Show($"Database error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Oracle Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"General Error: {ex.Message}");
            }
            finally
            {
                db.CloseConnection();
            }
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

        private void llbCreateAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            timerSwipeRight.Start();
            llbCreateAccount.Enabled = false;
            llbLogin.Enabled = false;
            SwitchToSignUpPage();
        }

        private void llbLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            timerSwipeLeft.Start();
            llbCreateAccount.Enabled = false;
            llbLogin.Enabled = false;
            SwitchToLoginPage();
        }

        private void SwitchToSignUpPage()
        {
            tbLoginUsername.TabStop = false;
            tbLoginPassword.TabStop = false;
            btnLogin.TabStop = false;

            tbFirstname.TabStop = true;
            tbLastname.TabStop = true;
            tbSigninUsername.TabStop = true;
            tbSigninPassword.TabStop = true;
            btnPicture.TabStop = true;
            btnSignin.TabStop = true;

            this.AcceptButton = btnSignin;
        }
        private void SwitchToLoginPage()
        {
            tbFirstname.TabStop = false;
            tbLastname.TabStop = false;
            tbSigninUsername.TabStop = false;
            tbSigninPassword.TabStop = false;
            btnPicture.TabStop = false;
            btnSignin.TabStop = false;

            tbLoginUsername.TabStop = true;
            tbLoginPassword.TabStop = true;
            btnLogin.TabStop = true;

            this.AcceptButton = btnLogin;
        }
        private void timerSwipeRight_Tick(object sender, EventArgs e)
        {
            if (pnBackground.Location.X > -320)
            {
                pnBackground.Location = new Point(pnBackground.Location.X - 10, pnBackground.Location.Y);
            }
            else
            {
                timerSwipeRight.Stop();
                llbCreateAccount.Enabled = true;
                llbLogin.Enabled = true;
            }
        }
        private void timerSwipeLeft_Tick(object sender, EventArgs e)
        {
            if (pnBackground.Location.X < 0)
            {
                pnBackground.Location = new Point(pnBackground.Location.X + 10, pnBackground.Location.Y);
            }
            else
            {
                timerSwipeLeft.Stop();
                llbCreateAccount.Enabled = true;
                llbLogin.Enabled = true;
            }
        }
    }
}
