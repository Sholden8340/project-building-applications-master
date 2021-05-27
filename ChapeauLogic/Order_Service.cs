using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ChapeauDAL;
using ChapeauModel;

namespace ChapeauLogic
{
    public class Order_Service : Logic<Order>
    {
        public Order_Service()
        {
            db = new Order_DAO();
        }

        public void Delete(int id)
        {
            try
            {
                Order_DAO orderDB = (Order_DAO)db;
                orderDB.Delete(id);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void DeleteOrderItem(int orderItemId)
        {
            try
            {
                Order_DAO orderDB = (Order_DAO)db;
                orderDB.DeleteOrderItem(orderItemId);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Order> GetOpenOrders()
        {
            try
            {
                Order_DAO orderDB = (Order_DAO)db;
                return orderDB.GetOpenOrders();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public List<Order> GetFromToday()
        {
            try
            {
                Order_DAO orderDB = (Order_DAO)db;
                return orderDB.GetAllToday();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        /// <summary>
        /// Get all open orders of today for the given employee role.
        /// </summary>
        /// <param name="employee">Based on role with either return kitchen or bar orders.</param>
        /// <returns>A list off all open orders of today.</returns>
        public List<Order> GetAllOpenOrders(Employee employee)
        {
            try
            {
                Order_DAO orderDB = (Order_DAO)db;
                
                if (employee.Role == Role.Kitchen)
                {
                    return orderDB.GetAllOpenKitchenOrders();
                }
                else if (employee.Role == Role.Bar)
                {
                    return orderDB.GetAllOpenBarOrders();
                }
                else
                {
                    throw new InvalidRoleException("The GetAllOpenOrders method only accepts an employee with the role Kitchen or Bar.");
                }
            }
            catch (InvalidRoleException error)
            {
                // We do this because we don't want to catch the InvalidRoleException in the Exception catch statement.
                throw error;
            }
            catch (Exception error)
            {
                throw new Exception("System was unable to get the open orders", error);
            }
        }

        /// <summary>
        /// Get all finished orders of today for the given employee role.
        /// </summary>
        /// <param name="employee">Based on role with either return kitchen or bar orders.</param>
        /// <returns>A list off all finished orders of today.</returns>
        public List<Order> GetAllFinishedOrders(Employee employee)
        {
            try
            {
                Order_DAO orderDB = (Order_DAO)db;

                if (employee.Role == Role.Kitchen)
                {
                    return orderDB.GetAllFinishedKitchenOrders();
                }
                else if (employee.Role == Role.Bar)
                {
                    return orderDB.GetAllFinishedBarOrders();
                }
                else
                {
                    throw new InvalidRoleException("The GetAllFinishedOrders method only accepts an employee with the role Kitchen or Bar.");
                }
            }
            catch (InvalidRoleException error)
            {
                // We do this because we don't want to catch the InvalidRoleException in the Exception catch statement.
                throw error;
            }
            catch (Exception error)
            {
                throw new Exception("System was unable to get the finished orders", error);
            }
        }
    }
}
