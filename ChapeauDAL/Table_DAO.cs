using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ChapeauDAL
{
    public class Table_DAO : SqlBase
    {
        public List<Table> GetAll()
        {
            string query =
                @"SELECT 
                    table_id,
                    [state],
                    capacity
                FROM tables;";

            SqlParameter[] sqlParameters = new SqlParameter[0];

            return ParseDataTable(Query(query, sqlParameters));
        }

        public Table GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Table table)
        {
            string query =
                @"UPDATE tables 
                    SET [state] = @tableState
                    WHERE table_id = @tableId;";

            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@tableState", $"{table.State}"),
                new SqlParameter("@tableId", $"{table.Id}")
            };

            EditQuery(query, sqlParameters);
        }

        private List<Table> ParseDataTable(DataTable dataTable)
        {
            List<Table> tables = new List<Table>();

            if (dataTable == null)
            {
                throw new DatatableIsNullException("ParseDataTable was given a null value for dataTable in Table_DAO.", new Exception());
            }

            foreach (DataRow row in dataTable.Rows)
            {
                tables.Add(RowToTable(row));
            }

            return tables;
        }

        private Table RowToTable(DataRow row)
        {
            Table table = new Table()
            {
                Id = (int)row["table_id"],
                State = ParseToTableState((string)row["state"]),
                Capacity = (int)row["capacity"]
            };

            return table;
        }

        private TableState ParseToTableState(string state)
        {
            switch (state)
            {
                case "Free":
                    return TableState.Free;
                case "Occupied":
                    return TableState.Occupied;
                case "Reserved":
                    return TableState.Reserved;
                default:
                    return TableState.Free;
            }
        }
    }
}