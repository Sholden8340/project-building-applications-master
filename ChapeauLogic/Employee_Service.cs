using ChapeauDAL;
using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ChapeauLogic
{
    public class Employee_Service : Logic<Employee>
    {
        private Employee_DAO userDB;

        public Employee_Service()
        {
            db = new Employee_DAO();
            userDB = new Employee_DAO();
        }

        public Employee Login(string employeeName, int passcode)
        {
            return userDB.Login(employeeName, passcode);
        }

        public void Logout()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateEmployee(Employee employee)
        {
            Employee_DAO employee_DAO = (Employee_DAO)db;
            userDB.Update(employee);
        }

        public void RemoveEmployee(int id)
        {
            Employee_DAO employee_DAO = (Employee_DAO)db;
            userDB.DeleteById(id);
        }

        public void AddEmployee(Employee user)
        {
            Employee_DAO employee_DAO = (Employee_DAO)db;
            userDB.Store(user);
        }
    }
}