using ChapeauModel;
using System.Windows.Forms;

namespace ChapeauUI
{
    public class TableUIElements
    {
        public Table Table { get; set; }

        public Order Order { get; set; }
        
        public PictureBox TableImage { get; set; }
        
        public PictureBox TableOccupiedImage { get; set; }
        
        public PictureBox TableReadyImage { get; set; }

        public PictureBox TableOrderTakenImage { get; set; }

        public Button OccupyButton { get; set; }

        public Button PlaceOrderButton { get; set; }

        public Button OrderReadyButton { get; set; }

        public Button PayBillButton { get; set; }

        public Button ClearButton { get; set; }

        public Label TimerLabel { get; set; }
    }
}