using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    /// <summary>
    /// An order object in the Chapeau application.
    /// </summary>
    /// <remarks>Yannick</remarks>
    public class Order
    {
        /// <summary>
        /// The unique ID of the order.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The table that this order belongs to.
        /// </summary>
        public Table Table { get; set; }

        /// <summary>
        /// The employee that took this order.
        /// </summary>
        public Employee Employee { get; set; }

        /// <summary>
        /// The items that belong too this order.
        /// </summary>
        public List<OrderItem> OrderItems { get; set; }

        /// <summary>
        /// Has the order been payed for.
        /// </summary>
        public bool IsPayed { get; set; }
    }
}
