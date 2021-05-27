using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    /// <summary>
    /// The state of an order item.
    /// </summary>
    public enum OrderItemState
    {
        Taken,
        InProgress,
        ReadyToServe,
        Served
    }
}
