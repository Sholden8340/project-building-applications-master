using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    /// <summary>
    /// A menu category, this is a subcategory of a Menu.
    /// </summary>
    /// <remarks>Yannick</remarks>
    public class MenuCategory
    {
        /// <summary>
        /// The ID of the menu category.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the menu category.
        /// </summary>
        public string Name { get; set; }
    }
}
