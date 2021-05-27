using System;
using System.Drawing;
using System.Windows.Forms;

using ChapeauModel;
using ChapeauLogic;

namespace ChapeauUI
{
    public partial class BillUI : Form
    {
        // public  bill object in order to be accessed by other form
        public Bill Bill;
        private Table table;
        Bill_Service billService;
        Table_Service tableService;

        public BillUI(Table table, Employee employee)
        {
            InitializeComponent();
            billService = new Bill_Service();
            tableService = new Table_Service();
            
            this.table = table;
            Text = $"Bill - {employee.FirstName} {employee.LastName}";

            // gets the bill of the table
            Bill = billService.GetBill(table.Id);
        }

        // shows the bill if there is an order for the table 
        private void BillUI_Load(object sender, EventArgs e)
        {
            if (Bill.Order != null)
            {
                ShowBill();
            }
            else
            {
                pnl_NoOrder.Show();
            }

            LoadListViewTables();
            btnUndoFeedback.Visible = false;
        }

        private void ShowPanel(string panelName)
        {
            try
            {
                if (panelName == "Feedback")
                {
                    pnl_Bill.Hide();
                    pnl_paymentMethod.Hide();
                    pnl_Payment.Hide();
                    pnl_CompleteBill.Hide();
                    pnl_NoOrder.Hide();

                    pnl_feedback.Show();
                }
                else if (panelName == "Pay")
                {
                    pnl_Bill.Hide();
                    pnl_feedback.Hide();
                    pnl_Payment.Hide();
                    pnl_CompleteBill.Hide();
                    pnl_NoOrder.Hide();

                    pnl_paymentMethod.Show();

                    listViewOrderPM.Clear();
                    listViewOrderPM.Columns.Add("Quantity", 28);
                    listViewOrderPM.Columns.Add("Name", 144);

                    Show_Order_Items(listViewOrderPM);

                    lblOrderPM.Text = Bill.OrderPrice.ToString("€ 0.00");
                    lblVatPM.Text = Bill.VAT.ToString("€ 0.00");
                    lblTipPM.Text = Bill.Tip.ToString("€ 0.00");
                    lblTotalPM.Text = Bill.TotalPrice.ToString("€ 0.00");
                }
                else if (panelName == "Order")
                {
                    pnl_feedback.Hide();
                    pnl_paymentMethod.Hide();
                    pnl_Payment.Hide();
                    pnl_CompleteBill.Hide();
                    pnl_NoOrder.Hide();

                    pnl_Bill.Show();
                }
                else if (panelName == "Complete Bill")
                {
                    pnl_Bill.Hide();
                    pnl_feedback.Hide();
                    pnl_paymentMethod.Hide();
                    pnl_Payment.Hide();
                    pnl_NoOrder.Hide();

                    pnl_CompleteBill.Show();
                }
                else if (panelName == "Payment")
                {
                    pnl_Bill.Hide();
                    pnl_feedback.Hide();
                    pnl_paymentMethod.Hide();
                    pnl_CompleteBill.Hide();
                    pnl_NoOrder.Hide();

                    pnl_Payment.Show();

                    listViewOrderPayment.Clear();
                    listViewOrderPayment.Columns.Add("Quantity", 28);
                    listViewOrderPayment.Columns.Add("Name", 144);

                    Show_Order_Items(listViewOrderPayment);

                    lblOrderPayment.Text = Bill.OrderPrice.ToString("€ 0.00");
                    lblVatPayment.Text = Bill.VAT.ToString("€ 0.00");
                    lblTipPayment.Text = Bill.Tip.ToString("€ 0.00");
                    lblTotalPayment.Text = Bill.TotalPrice.ToString("€ 0.00");
                }
            }
            catch (Exception e)
            {
                // Catches exception and shows an error message detailing what went wrong
                ErrorUI.ShowErrorDialog(e.Message);
            }
        }

        private void BtnFeedbackM_Click(object sender, EventArgs e)
        {
            ShowPanel("Feedback");
        }

        private void BtnBackF_Click(object sender, EventArgs e)
        {
            ShowPanel("Order");
        }

        private void BtnSaveFeedback_Click(object sender, EventArgs e)
        {
            ShowPanel("Order");
            Bill.Feedback = tbFeedback.Text;
            btnUndoFeedback.Visible = true;
        }

        private void Btn_Pay_Click(object sender, EventArgs e)
        {
            ShowPanel("Pay");
        }

        private void BtnBackPM_Click(object sender, EventArgs e)
        {
            ShowPanel("Order");
        }

        private void BtnFeedbackPM_Click(object sender, EventArgs e)
        {
            ShowPanel("Feedback");
        }

        private void BtnCreditCard_Click(object sender, EventArgs e)
        {
            Bill.PaymentMethod = PaymentMethod.CreditCard;
            ShowPanel("Payment");
        }

        private void BtnManualComplete_Click(object sender, EventArgs e)
        {
            ShowPanel("Complete Bill");

            // marks the is_Payed property of order object true after the bill is paid
            Bill.Order.IsPayed = true;
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            // marks the order as finshed order 
            billService.FinishOrder(Bill.Order);

            // changes the state of the table to available 
            table.State = TableState.Free;
            tableService.Update(table);

            // inserts the data of the bill into the database
            billService.InsertBillData(Bill);

            this.Close();
        }

        private void BtnTipM_Click(object sender, EventArgs e)
        {
            ShowTipForm();         
        }

        private void Bill_UI_Paint(object sender, PaintEventArgs e)
        {
            Pen myPen = new Pen(Color.LightGray, 1);
            e.Graphics.DrawLine(myPen, 0, 50, 800, 50);
            e.Graphics.DrawLine(myPen, 150, 50, 150, 900);
        }

        private void BtnCash_Click(object sender, EventArgs e)
        {
            Bill.PaymentMethod = PaymentMethod.Cash;
            ShowPanel("Payment");
        }

        private void BtnPin_Click(object sender, EventArgs e)
        {
            Bill.PaymentMethod = PaymentMethod.Pin;
            ShowPanel("Payment");
        }

        private void Pnl_Bill_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.LightGray, 1);
            
            Rectangle rectangle = new Rectangle(460, 0, 150, 120);
            e.Graphics.DrawRectangle(pen, rectangle);
            e.Graphics.DrawLine(pen, 470, 85, 600, 85);
        }

        private void BtnChangePaymentMethod_Click(object sender, EventArgs e)
        {
            ShowPanel("Pay");
        }

        private void BtnTipPM_Click(object sender, EventArgs e)
        {
            ShowTipForm();
        }

        private void BtnUndoFeedback_Click(object sender, EventArgs e)
        {
            Bill.Feedback = string.Empty;
            ShowPanel("Feedback");
            btnUndoFeedback.Visible = false;
        }

        /// <summary>
        /// Displays the complete order.
        /// </summary>
        private void Show_Order()
        {
            listViewOrder.Clear();
            listViewOrder.Items.Clear();

            listViewOrder.Columns.Add("Quantity", 60);
            listViewOrder.Columns.Add("Name", 300);
            listViewOrder.Columns.Add("Price", 100);

            Show_Order_Items(listViewOrder);
        }

        /// <summary>
        /// Displays the items in the order, made a method in order to avoid duplication.
        /// </summary>
        private void Show_Order_Items(ListView listView)
        {
            foreach (OrderItem orderItem in Bill.Order.OrderItems)
            {
                ListViewItem listViewItem = new ListViewItem(new string[]
                {
                    orderItem.Quantity.ToString("0x"),
                });
                listViewItem.SubItems.Add(orderItem.Item.Name.ToString());
                listViewItem.SubItems.Add(orderItem.Item.Price.ToString("€ 0.00"));

                listViewItem.Tag = orderItem;

                listView.Items.Add(listViewItem);
            }
        }

        /// <summary>
        /// Displays the tables.
        /// </summary>
        private void LoadListViewTables()
        {
            listViewTable.Columns.Add("Table", 80);
            listViewTable.Columns.Add("Id", 50);

            for (int i = 1; i <= 10; i++)
            {
                Table table = new Table
                {
                    Id = i
                };

                ListViewItem item = new ListViewItem("TABLE");
                
                item.SubItems.Add(table.Id.ToString());
                item.Tag = table;
                listViewTable.Items.Add(item);
            }
        }

        private void ShowBill()
        {
            Show_Order();
            ShowPanel("Order");
            lblTableno.Text = table.Id.ToString();

            lblOrder.Text = Bill.OrderPrice.ToString("€ 0.00");
            lblVat.Text = Bill.VAT.ToString("€ 0.00");
            lblTip.Text = Bill.Tip.ToString("€ 0.00");
            lblTotal.Text = Bill.TotalPrice.ToString("€ 0.00");
        }

        private void ShowTipForm()
        {
            EditingTip editingTip = new EditingTip(this);
            editingTip.ShowDialog();
        }

        /// <summary>
        /// Updates the amount of tip 
        /// </summary>
        public void UpdateTip()
        {
            lblTip.Text = Bill.Tip.ToString("€ 0.00");
            lblTotal.Text = Bill.TotalPrice.ToString("€ 0.00");
        }

        private void Pnl_paymentMethod_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Red, 1);
            e.Graphics.DrawLine(pen, 470, 100, 600, 100);
        }

        private void ListViewTable_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listViewTable.SelectedItems.Count < 1)
            {
                pnl_NoOrder.Show();
            }
            else
            {
                try
                {
                    // gets the corresponding table 
                    table = (Table)listViewTable.SelectedItems[0].Tag;
                    lblTableno.Text = table.Id.ToString();

                    Bill = billService.GetBill(table.Id);

                    if (Bill.Order == null)
                    {
                        pnl_Bill.Enabled = false;
                        pnl_NoOrder.Show();
                    }
                    else
                    {
                        ShowBill();
                        pnl_Bill.Enabled = true;
                    }
                }
                catch (Exception error)
                {
                    ErrorUI.ShowErrorDialog(error.Message);
                }
            }
        }

        private void Timerbtn_Tick(object sender, EventArgs e)
        {
            btnUndoFeedback.Visible = false;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Program.Logout();
        }
    }    
}
