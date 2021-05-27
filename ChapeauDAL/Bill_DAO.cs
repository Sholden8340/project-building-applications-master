using System.Data.SqlClient;

using ChapeauModel;

namespace ChapeauDAL
{
    public class Bill_DAO : SqlBase
    {
        /// <summary>
        /// Inserts the data of bill into database
        /// </summary>
        /// <param name="bill">The bill object to be inserted.</param>
        public void InsertBillData(Bill bill)
        {
            string query = @"INSERT INTO bills(tip,order_price,payment_method,date,feedback,order_id)
                             VALUES 
                            (@tip,@totalPrice,@paymentMethod,@date,@feedback,@orderId)";

            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@orderId", bill.Order.Id),
                new SqlParameter("@totalPrice", bill.TotalPrice),
                new SqlParameter("@paymentMethod", $"{bill.PaymentMethod}"),
                new SqlParameter("@tip", bill.Tip),
                new SqlParameter("@feedback", bill.Feedback),
                new SqlParameter("@date", bill.Date)
            };

            EditQuery(query, sqlParameters);           
        }

        /// <summary>
        /// Finishes the order by marking the order property is_paid true
        /// </summary>
        /// <param name="order">The order to be marked finished.</param>            
        public void FinishOrder(Order order)
        {
            string query = @"Update orders 
                                SET is_Payed = @isPayed
                                WHERE order_id = @orderId";

            SqlParameter[] sqlParameters =
            {
                 new SqlParameter("@isPayed", order.IsPayed),
                 new SqlParameter("@orderId", order.Id)
            };

            EditQuery(query, sqlParameters);
        }
    }
}
