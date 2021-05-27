using System;

namespace ChapeauModel
{
    /// <summary>
    /// Error that is fired when an item is out of stock.
    /// </summary>
    /// <remarks>Yannick, 2020/06/09</remarks>
    public class OutOfStockException : Exception
    {
        public OutOfStockException() 
        { 
        }

        public OutOfStockException(string message)
            : base(message) 
        {
        }

        public OutOfStockException(string message, Exception inner)
            : base(message, inner) 
        {
        }
    }

    /// <summary>
    /// An error that happens when an data table is null.
    /// This is commonly caused when an SQL query ran into an error that wasn't handled properly.
    /// </summary>
    /// <remarks>Yannick, 2020/06/10</remarks>
    public class DatatableIsNullException : Exception
    {
        public DatatableIsNullException() 
        {
        }

        public DatatableIsNullException(string message)
            : base(message) 
        {
        }

        public DatatableIsNullException(string message, Exception inner)
            : base(message, inner) 
        {
        }
    }

    /// <summary>
    /// An error that happens when the method doesn't accept the given Role.
    /// </summary>
    /// <remarks>Yannick, 2020/06/10</remarks>
    public class InvalidRoleException : Exception
    {
        public InvalidRoleException()
        {
        }

        public InvalidRoleException(string message)
            : base(message)
        {
        }

        public InvalidRoleException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
