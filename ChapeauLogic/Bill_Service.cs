using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ChapeauDAL;
using ChapeauModel;

namespace ChapeauLogic
{
    public class Bill_Service
    {        
        Bill_DAO billDB;
        Order_DAO orderDB;

        public Bill_Service()
        {
            billDB = new Bill_DAO();
            orderDB = new Order_DAO(); 
        }

        /// <summary>
        /// Finishes the order by calling the FinishOrder method of class Bill_DAO
        /// </summary>
        /// <param name="order">The order to finish.</param>
        public void FinishOrder(Order order)
        {
            billDB.FinishOrder(order);
        }

        /// <summary>
        /// Insert the bill data by calling the InsertBillData method of class Bill_DAO
        /// </summary>
        /// <param name="bill">The order to finish.</param>
        public void InsertBillData(Bill bill)
        {
            billDB.InsertBillData(bill);
        }

        /// <summary>
        /// Returns a bill object corresponding to the table, uses method GetByTableId of class Order_DAO
        /// </summary>
        /// <param name="tableId">The id of the table whose bill should be displayed.</param>
        public Bill GetBill(int tableId)
        {
            try
            {
                // Gets the complete order object of corresponding table from the database
                Order order = orderDB.GetByTableId(tableId);
                 
                if (order != null)
                {
                    // Creates the bill object containing the order object in it
                    Bill bill = new Bill()
                    {
                        Order = order,
                        Date = DateTime.Now,
                        Feedback = string.Empty,
                        Tip = 0
                    };

                    // Calculating the price of the order and the VAT
                    bill.OrderPrice = 0;
                    bill.VAT = 0;

                    // loops through each order item and adds the corresponding price and VAT
                    foreach (OrderItem item in order.OrderItems)
                    {
                        bill.OrderPrice += item.Item.Price * item.Quantity;
                        bill.VAT += item.Item.Price * item.Quantity * item.Item.TaxCategory.VAT / 100;
                    }

                    return bill;
                }
                else
                {
                    return new Bill();
                }
            }
            catch (Exception)
            {
                throw new Exception("Something went wrong while displaying the bill.");
            }
        }
    }
}
