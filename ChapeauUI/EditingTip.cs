using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChapeauModel;

namespace ChapeauUI
{
    public partial class EditingTip : Form
    {
        private decimal tip;
        BillUI billUI;

        // passing the BILL_UI form as a parameter in order to access its "UpdateTip" method
        public EditingTip(BillUI form)
        {
            InitializeComponent();
            billUI = form;
        }

        private void EditingTip_Load(object sender, EventArgs e)
        {
            tbTip.Text = "Enter tip amount";
        }

        // After the button save is pressed,
        // tip is added to the bill object
        // the tip is update in the actual form
        private void BtnSaveTip_Click(object sender, EventArgs e)
        {
            tip = decimal.Parse(tbTip.Text);
            billUI.Bill.Tip = tip;
            billUI.UpdateTip();
            this.Close();    
        }

        // closes the form without saving the tip
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            billUI.Bill.Tip = 0;
            this.Close();
        }
    }
}
