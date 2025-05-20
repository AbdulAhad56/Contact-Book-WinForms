using Oracle.ManagedDataAccess.Client;

namespace Contact_Book_Management_System
{
    class OracleDbConnector
    {
        public OracleConnection Connection { get; private set; }

        public OracleDbConnector()
        {
            string connectionString = "Data Source=(DESCRIPTION=" +
                            "(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))" +
                            "(CONNECT_DATA=(SERVICE_NAME=XE)));" +
                            "User id=abdul_ahad;" +
                            "Password=Gujjar05;";

            Connection = new OracleConnection(connectionString);
        }
        public void OpenConnection()
        {
            if (Connection.State == System.Data.ConnectionState.Closed)
            {
                Connection.Open();
            }
        }
        public void CloseConnection()
        {
            if (Connection.State == System.Data.ConnectionState.Open)
            {
                Connection.Close();
            }
        }
    }
}
