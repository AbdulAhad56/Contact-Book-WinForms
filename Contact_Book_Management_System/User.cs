using System;
using System.Data;
using System.IO;
using Oracle.ManagedDataAccess.Client;

namespace Contact_Book_Management_System
{
    class User
    {
        private OracleDbConnector db = new OracleDbConnector();
        private bool ExecuteNonQuery(string query, OracleParameter[] parameters)
        {
            try
            {
                using (OracleCommand command = new OracleCommand(query, db.Connection))
                {
                    command.Parameters.AddRange(parameters);
                    db.OpenConnection();
                    int result = command.ExecuteNonQuery();

                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            finally
            {
                db.CloseConnection();
            }
        }

        public bool AddNewUser(string firstname, string lastname, string username, string password, MemoryStream picture)
        {
            string query = "INSERT INTO users (firstname, lastname, username, user_password, picture) VALUES (:fname, :lname, :uname, :passwd, :picture)";

            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter(":fname", OracleDbType.Varchar2) { Value = firstname },
                new OracleParameter(":lname", OracleDbType.Varchar2) { Value = lastname },
                new OracleParameter(":uname", OracleDbType.Varchar2) { Value = username },
                new OracleParameter(":passwd", OracleDbType.Varchar2) { Value = password },
                new OracleParameter(":picture", OracleDbType.Blob) { Value = picture.ToArray() }
            };

            return ExecuteNonQuery(query, parameters);
        }

        public bool EditUser(int userId, string firstname, string lastname, string username, MemoryStream picture)
        {
            string query = "UPDATE users SET firstname = :fname, lastname = :lname, username = :uname, picture = :picture WHERE id = :userID";

            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter(":fname", OracleDbType.Varchar2) { Value = firstname },
                new OracleParameter(":lname", OracleDbType.Varchar2) { Value = lastname },
                new OracleParameter(":uname", OracleDbType.Varchar2) { Value = username },
                new OracleParameter(":picture", OracleDbType.Blob) { Value = picture.ToArray() },
                new OracleParameter(":userID", OracleDbType.Int32) { Value = userId }
            };

            return ExecuteNonQuery(query, parameters);
        }

        public bool EditPassword(int userID, string password)
        {
            string query = "UPDATE users SET user_password = :passwd WHERE id = :userID";

            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter(":userID", OracleDbType.Int32) { Value = userID },
                new OracleParameter(":passwd", OracleDbType.Varchar2) { Value = password }
            };

            return ExecuteNonQuery(query, parameters);
        }

        public DataTable GetUserData(int userId)
        {
            string query = "SELECT * FROM users WHERE id = :userID";
            OracleCommand command = new OracleCommand(query, db.Connection);
            command.Parameters.Add(":userID", OracleDbType.Int32).Value = userId;

            OracleDataAdapter adapter = new OracleDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        public DataTable CheckUsernameExists(string username)
        {
            string query = "SELECT id FROM users WHERE username = :uname";
            OracleCommand command = new OracleCommand(query, db.Connection);
            command.Parameters.Add(":uname", OracleDbType.Varchar2).Value = username;

            OracleDataAdapter adapter = new OracleDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        public int CheckPassword(string username, string password)
        {
            string query = "SELECT id, user_password FROM users WHERE username = :uname";
            OracleCommand command = new OracleCommand(query, db.Connection);
            command.Parameters.Add(":uname", OracleDbType.Varchar2).Value = username;

            OracleDataAdapter adapter = new OracleDataAdapter(command);
            DataTable table = new DataTable();

            try
            {
                adapter.Fill(table);
            }
            catch
            {
                return -2;
            }

            if (table.Rows.Count > 0)
            {
                if (password == table.Rows[0]["user_password"].ToString())
                {
                    return Convert.ToInt32(table.Rows[0]["id"]);
                }
            }
            return -1;
        }
    }
}
