using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ChapeauDAL
{
    public class Employee_DAO : SqlBase, IDAO<Employee>
    {
        public List<Employee> GetAll()
        {
            string query =
                @"SELECT employee_id,
                first_name,
                last_name,
                [password],
                [name] AS [role]
                FROM employees
                LEFT JOIN roles on [role] = role_id;";

            SqlParameter[] sqlParameters = new SqlParameter[0];

            return ParseDataTable(Query(query, sqlParameters));
        }

        public Employee GetById(int id)
        {
            string query =
                @"SELECT 
                    employee_id,
                    first_name,
                    last_name,
                    [password],
                    [name] AS [role]
                FROM employees
                INNER JOIN roles on [role] = role_id
                WHERE employee_id = @employeeId;";

            SqlParameter[] sqlParameters =
            {
                 new SqlParameter("@employeeId", id)
            };
            return ParseDataTable(Query(query, sqlParameters))[0];
        }

        public void Store(Employee employee)
        {
            string query =
                @"INSERT INTO employees ([employee_id], [first_name], [last_name], [password], [role])
                    VALUES (@id, @fname, @lname, @passcode,
                        (SELECT [role_id] 
                        FROM roles 
                        WHERE [name] = @role))";

            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@id", employee.Id),
                new SqlParameter("@fname", employee.FirstName),
                new SqlParameter("@lname", employee.LastName),
                new SqlParameter("@passcode", employee.Passcode),
                new SqlParameter("@role", employee.Role.ToString()),
            };

            EditQuery(query, sqlParameters);
        }

        public void DeleteById(int id)
        {
            string query =
                @"DELETE FROM employees
                  WHERE [employee_id] = @id;";

            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@id", id),
            };

            EditQuery(query, sqlParameters);
        }

        public void Update(Employee employee)
        {
            string query =
                @"UPDATE employees
                    SET
                        [first_name] = @fname,
                        [last_name] = @lname,
                        [password] = @passcode,
                        [role] = (SELECT [role_id] 
                        FROM roles 
                        WHERE [name] = @role)
                    WHERE [employee_id] = @id;"; 

            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@id", employee.Id),
                new SqlParameter("@fname", employee.FirstName),
                new SqlParameter("@lname", employee.LastName),
                new SqlParameter("@passcode", employee.Passcode),
                new SqlParameter("@role", employee.Role.ToString()),
            };

            EditQuery(query, sqlParameters);
        }

        private List<Employee> ParseDataTable(DataTable dataTable)
        {
            List<Employee> users = new List<Employee>();

            foreach (DataRow dr in dataTable.Rows)
            {
                users.Add(new Employee()
                {
                    Id = (int)dr["employee_id"],
                    FirstName = (string)dr["first_name"],
                    LastName = (string)dr["last_name"],
                    Passcode = (int)dr["password"],
                    Role = (Role)Role.Parse(typeof(Role), dr["role"].ToString(), true)
                });
            }

            return users;
        }

        /// <summary>
        /// The login method for the employee.
        /// </summary>
        /// <param name="employeeName">The first name of the employee.</param>
        /// <param name="passcode">The 4 digit password of the employee.</param>
        /// <returns>The employee object.</returns>
        public Employee Login(string employeeName, int passcode)
        {
            string query =
                @"SELECT 
                    employee_id,
                    first_name,
                    last_name,
                    [password],
                    [name] AS [role]
                FROM employees
                INNER JOIN roles on [role] = role_id
                WHERE password = @password 
                    AND lower([first_name]) = @employeeName;";

            SqlParameter[] sqlParameters =
            {
                 new SqlParameter("@password", passcode),
                 new SqlParameter("@employeeName", employeeName)
            };

            // query by password + first name.
            DataTable datatable = Query(query, sqlParameters);

            if (datatable.Rows.Count < 1)
            {
                // TODO: This should throw a error.
                throw new Exception("Invalid login");
            } 
            else
            {
                // Valid login:
                return ParseDataTable(datatable)[0];
            }
        }
    }
}