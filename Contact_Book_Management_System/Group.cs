using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace Contact_Book_Management_System
{
    class Group
    {
        private OracleDbConnector db = new OracleDbConnector();  // Oracle connection

        // Method to execute any query and ensure proper handling of database operations
        private bool ExecuteNonQuery(string query, OracleParameter[] parameters)
        {
            try
            {
                using (OracleCommand command = new OracleCommand(query, db.Connection))
                {
                    command.Parameters.AddRange(parameters);  // Add parameters to command

                    db.OpenConnection();  // Open the connection
                    int result = command.ExecuteNonQuery();  // Execute query

                    return result > 0;  // Return true if at least one row is affected
                }
            }
            catch (Exception ex)
            {
                // Log exception if necessary (consider using a logging library)
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            finally
            {
                db.CloseConnection();  // Ensure the connection is always closed
            }
        }

        public bool AddGroup(int userId, string groupName)
        {
            string query = "INSERT INTO groups (name, userid) VALUES (:gname, :userid)";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter(":gname", OracleDbType.Varchar2) { Value = groupName },
                new OracleParameter(":userid", OracleDbType.Int32) { Value = userId }
            };

            return ExecuteNonQuery(query, parameters);  // Call ExecuteNonQuery helper method
        }

        public bool EditGroup(string groupName, int groupId)
        {
            string query = "UPDATE groups SET name = :gname WHERE id = :groupid";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter(":gname", OracleDbType.Varchar2) { Value = groupName },
                new OracleParameter(":groupid", OracleDbType.Int32) { Value = groupId }
            };

            return ExecuteNonQuery(query, parameters);  // Call ExecuteNonQuery helper method
        }

        public bool DeleteGroup(int groupId)
        {
            string query = "DELETE FROM groups WHERE id = :groupid";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter(":groupid", OracleDbType.Int32) { Value = groupId }
            };

            return ExecuteNonQuery(query, parameters);  // Call ExecuteNonQuery helper method
        }

        public DataTable GetAllGroups(int userId)
        {
            string query = "SELECT id, name FROM groups WHERE userid = :userid";
            OracleCommand command = new OracleCommand(query, db.Connection);
            command.Parameters.Add(":userid", OracleDbType.Int32).Value = userId;

            OracleDataAdapter adapter = new OracleDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public DataTable CheckGroupExists(int userId, string groupName)
        {
            string query = "SELECT * FROM groups WHERE name = :gname AND userid = :userid";
            OracleCommand command = new OracleCommand(query, db.Connection);
            command.Parameters.Add(":gname", OracleDbType.Varchar2).Value = groupName;
            command.Parameters.Add(":userid", OracleDbType.Int32).Value = userId;

            OracleDataAdapter adapter = new OracleDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
