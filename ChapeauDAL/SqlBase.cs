using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections.Generic;

namespace ChapeauDAL
{
    /// <summary>
    /// The SQL base class, that contains the different SQL methods.
    /// </summary>
    public abstract class SqlBase
    {
        private readonly SqlDataAdapter sqlDataAdapter;
        private readonly SqlConnection sqlConnection;

        public SqlBase()
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChapeauDatabase"].ConnectionString);
            sqlDataAdapter = new SqlDataAdapter();
        }

        /// <summary>
        /// Opens the connection with the SQL server.
        /// </summary>
        /// 
        /// <returns>The current SQL connection.</returns>
        protected SqlConnection OpenConnection()
        {
            // If the SQL connection is currently closed or broken, open a new connection.
            if (sqlConnection.State == ConnectionState.Closed || sqlConnection.State == ConnectionState.Broken)
            {
                sqlConnection.Open();
            }

            // Return the SQL connection.
            return sqlConnection;
        }

        /// <summary>
        /// Close the current SQL connection.
        /// </summary>
        private void CloseConnection()
        {
            sqlConnection.Close();
        }

        /// <summary>
        /// Adds the SQL parameters to the SqlCommand.
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="command"></param>
        private void AddSqlParameters(SqlParameter[] parameters, SqlCommand command)
        {
            command.Parameters.AddRange(parameters);
        }

        /// <summary>
        /// Executes a SQL query that is used to modify the data in the database.
        /// Usage: Use this if you need the ID of the created/modified row.
        /// </summary>
        /// <param name="query">The SQL statement.</param>
        /// <param name="parameters">An array of the SQL parameters to use for the query.</param>
        /// <returns>The ID of the created/modified row.</returns>
        protected int EditQueryWithId(string query, SqlParameter[] parameters)
        {
            int id = -1;

            try
            {
                // Modify the query to add the scope_identity to it.
                string identityQuery = query + "SELECT CAST(scope_identity() AS int)";

                // Create the SQL command.
                SqlCommand command = new SqlCommand(identityQuery, OpenConnection());

                // Add the SQL parameters to the command (example: "@id", "123")
                AddSqlParameters(parameters, command);
                sqlDataAdapter.InsertCommand = command;

                // Execute the SQL query.
                id = int.Parse(command.ExecuteScalar().ToString());
            }
            catch (SqlException error)
            {
                throw error;
            }
            finally
            {
                // After everything is done, close the SQL connection.
                CloseConnection();
            }

            // Return the id of the created/modified row
            return id;
        }

        /// <summary>
        /// Executes a SQL query that is used to modify the data in the database.
        /// </summary>
        /// <param name="query">The SQL statement.</param>
        /// <param name="parameters">An array of the SQL parameters to use for the query.</param>
        protected void EditQuery(string query, SqlParameter[] parameters)
        {
            try
            {
                // Create the SQL command.
                SqlCommand command = new SqlCommand(query, OpenConnection());
                
                // Add the SQL parameters to the command (example: "@id", "123")
                AddSqlParameters(parameters, command);
                sqlDataAdapter.InsertCommand = command;

                // Execute the SQL query.
                command.ExecuteNonQuery();
            }
            catch (SqlException error)
            {
                throw error;
            }
            finally
            {
                // After everything is done, close the SQL connection.
                CloseConnection();
            }
        }

        /// <summary>
        /// Executes the edit transaction query operation.
        /// For Insert/Update/Delete Queries with transaction
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="sqlParameters">Options for controlling the SQL.</param>
        /// <param name="sqlTransaction">The SQL transaction.</param>
        protected void EditTransactionQuery(string query, SqlParameter[] parameters, SqlTransaction transaction)
        {
            try
            {
                SqlCommand command = new SqlCommand(query, sqlConnection, transaction);

                // Add the SQL parameters.
                AddSqlParameters(parameters, command);

                sqlDataAdapter.InsertCommand = command;

                command.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// Insert a DataTable into the database.
        /// </summary>
        /// <param name="dataTable">The DataTable to insert into the database.</param>
        /// <param name="target">The name of the table in the database.</param>
        /// <param name="columns">The columns mappings for the bulk copy.</param>
        /// <remarks>Yannick, 2020/5/20</remarks>
        protected void BulkInsert(DataTable dataTable, string target, List<SqlBulkCopyColumnMapping> columns)
        {
            try
            {
                SqlBulkCopy bulkCopy = new SqlBulkCopy(OpenConnection())
                {
                    DestinationTableName = target
                };

                foreach (SqlBulkCopyColumnMapping column in columns)
                {
                    bulkCopy.ColumnMappings.Add(column);
                }

                bulkCopy.WriteToServer(dataTable);
            }
            catch (SqlException error)
            {
                throw error;
            }
            finally
            {
                CloseConnection();
            }
        }
            
        /// <summary>
        /// Used to get data from the database.
        /// </summary>
        /// <param name="query">The SQL query string.</param>
        /// <param name="parameters">An array of the SQL parameters to use for this request.</param>
        /// <returns>Returns a data table of the results that match the given query.</returns>
        protected DataTable Query(string query, params SqlParameter[] parameters)
        {
            DataTable dataTable;
            DataSet dataSet = new DataSet();

            try
            {
                // Create the SQL command.
                SqlCommand command = new SqlCommand(query, OpenConnection());

                // Add the SQL parameters.
                AddSqlParameters(parameters, command);

                // Execute the select query.
                command.ExecuteNonQuery();
                
                sqlDataAdapter.SelectCommand = command;
                sqlDataAdapter.Fill(dataSet);
                
                dataTable = dataSet.Tables[0];
            }
            catch (SqlException)
            {
                return null;
            }
            finally
            {
                // Close the SQL connection.
                CloseConnection();
            }

            // Return the results of the given SQL query.
            return dataTable;
        }
    }
}