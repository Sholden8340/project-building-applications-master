using ChapeauDAL;
using ChapeauModel;

namespace ChapeauLogic
{
    /// <summary>
    /// The logic layer used to get menus from the DAL layer.
    /// </summary>
    /// <remarks>Yannick</remarks>
    public class Menu_Service : Logic<Menu>
    {
        public Menu_Service()
        {
            db = new Menu_DAO();
        }
    }
}
