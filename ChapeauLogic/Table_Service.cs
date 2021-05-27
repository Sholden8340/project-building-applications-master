using System;
using System.Collections.Generic;

using ChapeauDAL;
using ChapeauModel;

namespace ChapeauLogic
{
    public class Table_Service
    {
        private Table_DAO tableDB;

        public Table_Service()
        {
            tableDB = new Table_DAO();
        }

        public List<Table> GetAll()
        {
            return tableDB.GetAll();
        }

        public Table GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Table table)
        {
            try
            {
                tableDB.Update(table);
            }
            catch
            {
                throw new Exception("Something went wrong while updating the table.");
            }
        }
    }
}