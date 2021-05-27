using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    /// <summary>
    /// An dish that was ordered.
    /// </summary>
    public class OrderItem
    {
        /// <summary>
        /// The ID of the order item.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The menu item that belongs to this class.
        /// </summary>
        public MenuItem Item { get; set; }

        /// <summary>
        /// The state of the order item.
        /// </summary>
        public OrderItemState State { get; set; }

        /// <summary>
        /// Since when is the order item this state.
        /// </summary>
        public DateTime StateTime { get; set; }

        /// <summary>
        /// When was this order_item taken.
        /// </summary>
        public DateTime TakenAt { get; set; }

        /// <summary>
        /// How many of the dish are in this order.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Any special requests for this item.
        /// </summary>
        public string Comment { get; set; }
    }
}
