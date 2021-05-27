using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    /// <summary>
    /// A menu of Chapeau.
    /// </summary>
    /// <remarks>Yannick, 2020/05/16</remarks>
    public class Menu
    {
        /// <summary>
        /// The ID of the menu.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the menu.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The start time of when this menu is served.
        /// </summary>
        public TimeSpan StartTime { get; set; }

        /// <summary>
        /// Till what time is this menu served.
        /// </summary>
        public TimeSpan EndTime { get; set; }

        /// <summary>
        /// The categories that belong to this menu.
        /// </summary>
        public List<MenuCategory> MenuCategories { get; set; }
    }
}
