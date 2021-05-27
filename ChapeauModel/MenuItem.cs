using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    /// <summary>
    /// An menu item, this is a dish that is on the menu.
    /// </summary>
    /// <remarks>Yannick</remarks>
    public class MenuItem
    {
        /// <summary>
        /// The ID of the menu item.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the menu item.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The amount that is in stock of this item.
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// The price of this item.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// What menu does this item belong to.
        /// </summary>
        public Menu Menu { get; set; }

        /// <summary>
        /// What tax category does this item belong to.
        /// </summary>
        public TaxCategory TaxCategory { get; set; }
        
        /// <summary>
        /// What menu/sub category does this item belong to.
        /// </summary>
        public MenuCategory Category { get; set; }
    }
}
