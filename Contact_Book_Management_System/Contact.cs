using System;
using System.Data;
using System.IO;
using Oracle.ManagedDataAccess.Client;

namespace Contact_Book_Management_System
{
    class Contact
    {
        private OracleDbConnector db = new OracleDbConnector();  // Oracle connection

        // Helper method for executing database commands
        private bool ExecuteNonQuery(string query, OracleParameter[] parameters)
        {
            try
            {
                using (OracleCommand command = new OracleCommand(query, db.Connection))
                {
                    command.Parameters.AddRange(parameters);
                    db.OpenConnection();
                    int result = command.ExecuteNonQuery();  // Execute query

                    return result > 0;  // Return true if at least one row is affected
                }
            }
            catch (Exception ex)
            {
                // Log exception (consider using a logging library)
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            finally
            {
                db.CloseConnection();  // Ensure the connection is closed properly
            }
        }

        public bool AddContact(int userId, string firstName, string lastName, int groupId, string phoneNumber, string email, string address, MemoryStream picture)
        {
            string query = "INSERT INTO contacts (firstname, lastname, phone, email, address, picture, userid, groupid) " +
                           "VALUES (:fname, :lname, :phone, :email, :addr, :pict, :userid, :groupid)";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter(":fname", OracleDbType.Varchar2) { Value = firstName },
                new OracleParameter(":lname", OracleDbType.Varchar2) { Value = lastName },
                new OracleParameter(":phone", OracleDbType.Varchar2) { Value = phoneNumber },
                new OracleParameter(":email", OracleDbType.Varchar2) { Value = email },
                new OracleParameter(":addr", OracleDbType.Varchar2) { Value = address },
                new OracleParameter(":pict", OracleDbType.Blob) { Value = picture.ToArray() },
                new OracleParameter(":userid", OracleDbType.Int32) { Value = userId },
                new OracleParameter(":groupid", OracleDbType.Int32) { Value = groupId }
            };

            return ExecuteNonQuery(query, parameters);
        }

        public bool EditContact(int contactId, string firstName, string lastName, string phoneNumber, string email, string address, MemoryStream picture)
        {
            string query = "UPDATE contacts SET firstname = :fname, lastname = :lname, phone = :phone, email = :email, " +
                           "address = :addr, picture = :pict WHERE id = :contactid";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter(":fname", OracleDbType.Varchar2) { Value = firstName },
                new OracleParameter(":lname", OracleDbType.Varchar2) { Value = lastName },
                new OracleParameter(":phone", OracleDbType.Varchar2) { Value = phoneNumber },
                new OracleParameter(":email", OracleDbType.Varchar2) { Value = email },
                new OracleParameter(":addr", OracleDbType.Varchar2) { Value = address },
                new OracleParameter(":pict", OracleDbType.Blob) { Value = picture.ToArray() },
                new OracleParameter(":contactid", OracleDbType.Int32) { Value = contactId }
            };

            return ExecuteNonQuery(query, parameters);
        }

        public bool DeleteContact(int contactId)
        {
            string query = "DELETE FROM contacts WHERE id = :contactid";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter(":contactid", OracleDbType.Int32) { Value = contactId }
            };

            return ExecuteNonQuery(query, parameters);
        }

        public DataTable GetAllContacts(int userId)
        {
            string query = "SELECT * FROM contacts WHERE userid = :userid";
            OracleCommand command = new OracleCommand(query, db.Connection);
            command.Parameters.Add(":userid", OracleDbType.Int32).Value = userId;

            OracleDataAdapter adapter = new OracleDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        public DataTable GetContactById(int contactId)
        {
            string query = "SELECT * FROM contacts WHERE id = :contactid";
            OracleCommand command = new OracleCommand(query, db.Connection);
            command.Parameters.Add(":contactid", OracleDbType.Int32).Value = contactId;

            OracleDataAdapter adapter = new OracleDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
