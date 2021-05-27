using System.Drawing;

namespace ChapeauUI
{
    partial class BillUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new string[] {
            "Quantity"}, -1, System.Drawing.Color.Empty, System.Drawing.Color.Empty, new System.Drawing.Font("Circular Std Bold", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem(new string[] {
            "Name"}, -1, System.Drawing.Color.Empty, System.Drawing.Color.Empty, new System.Drawing.Font("Circular Std Book", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem(new string[] {
            "Price"}, -1, System.Drawing.Color.Empty, System.Drawing.Color.Empty, new System.Drawing.Font("Circular Std Book", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BillUI));
            this.listViewOrder = new System.Windows.Forms.ListView();
            this.btnFeedbackM = new System.Windows.Forms.Button();
            this.btnPay = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTableno = new System.Windows.Forms.Label();
            this.listViewTable = new System.Windows.Forms.ListView();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pnl_Bill = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTip = new System.Windows.Forms.Label();
            this.lblVat = new System.Windows.Forms.Label();
            this.lblOrder = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnEditOrderM = new System.Windows.Forms.Button();
            this.btnTipM = new System.Windows.Forms.Button();
            this.pnl_feedback = new System.Windows.Forms.Panel();
            this.btnSaveFeedback = new System.Windows.Forms.Button();
            this.btnBackF = new System.Windows.Forms.Button();
            this.tbFeedback = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.pnl_paymentMethod = new System.Windows.Forms.Panel();
            this.label23 = new System.Windows.Forms.Label();
            this.lblTotalPM = new System.Windows.Forms.Label();
            this.lblTipPM = new System.Windows.Forms.Label();
            this.lblVatPM = new System.Windows.Forms.Label();
            this.lblOrderPM = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.listViewOrderPM = new System.Windows.Forms.ListView();
            this.btnCreditCard = new System.Windows.Forms.Button();
            this.btnBackPM = new System.Windows.Forms.Button();
            this.btnPin = new System.Windows.Forms.Button();
            this.btnCash = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.btnFeedbackPM = new System.Windows.Forms.Button();
            this.btnOrderPM = new System.Windows.Forms.Button();
            this.btnTipPM = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnl_Payment = new System.Windows.Forms.Panel();
            this.label24 = new System.Windows.Forms.Label();
            this.lblTotalPayment = new System.Windows.Forms.Label();
            this.lblTipPayment = new System.Windows.Forms.Label();
            this.lblVatPayment = new System.Windows.Forms.Label();
            this.lblOrderPayment = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.btnChangePaymentMethod = new System.Windows.Forms.Button();
            this.btnManualComplete = new System.Windows.Forms.Button();
            this.listViewOrderPayment = new System.Windows.Forms.ListView();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnl_CompleteBill = new System.Windows.Forms.Panel();
            this.btnFinish = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.pbMenu = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnUndoFeedback = new System.Windows.Forms.Button();
            this.label25 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.pnl_NoOrder = new System.Windows.Forms.Panel();
            this.label33 = new System.Windows.Forms.Label();
            this.Timerbtn = new System.Windows.Forms.Timer(this.components);
            this.pnl_Bill.SuspendLayout();
            this.pnl_feedback.SuspendLayout();
            this.pnl_paymentMethod.SuspendLayout();
            this.pnl_Payment.SuspendLayout();
            this.pnl_CompleteBill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnl_NoOrder.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewOrder
            // 
            this.listViewOrder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewOrder.Font = new System.Drawing.Font("Circular Std Book", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewOrder.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewOrder.HideSelection = false;
            this.listViewOrder.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem4,
            listViewItem5,
            listViewItem6});
            this.listViewOrder.Location = new System.Drawing.Point(3, 10);
            this.listViewOrder.Name = "listViewOrder";
            this.listViewOrder.Scrollable = false;
            this.listViewOrder.Size = new System.Drawing.Size(450, 322);
            this.listViewOrder.TabIndex = 0;
            this.listViewOrder.UseCompatibleStateImageBehavior = false;
            this.listViewOrder.View = System.Windows.Forms.View.Details;
            // 
            // btnFeedbackM
            // 
            this.btnFeedbackM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
            this.btnFeedbackM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFeedbackM.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
            this.btnFeedbackM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFeedbackM.Font = new System.Drawing.Font("Circular Std Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFeedbackM.Location = new System.Drawing.Point(190, 338);
            this.btnFeedbackM.Name = "btnFeedbackM";
            this.btnFeedbackM.Size = new System.Drawing.Size(163, 37);
            this.btnFeedbackM.TabIndex = 1;
            this.btnFeedbackM.Text = "ADD FEEDBACK";
            this.btnFeedbackM.UseVisualStyleBackColor = false;
            this.btnFeedbackM.Click += new System.EventHandler(this.BtnFeedbackM_Click);
            // 
            // btnPay
            // 
            this.btnPay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
            this.btnPay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPay.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
            this.btnPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPay.Font = new System.Drawing.Font("Circular Std Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPay.Location = new System.Drawing.Point(503, 339);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(84, 36);
            this.btnPay.TabIndex = 2;
            this.btnPay.Text = "PAY";
            this.btnPay.UseVisualStyleBackColor = false;
            this.btnPay.Click += new System.EventHandler(this.Btn_Pay_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Manteka", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(162, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 23);
            this.label5.TabIndex = 14;
            this.label5.Text = "Bill - ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Manteka", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(235, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 23);
            this.label6.TabIndex = 15;
            this.label6.Text = "Table";
            // 
            // lblTableno
            // 
            this.lblTableno.AutoSize = true;
            this.lblTableno.Font = new System.Drawing.Font("Manteka", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTableno.Location = new System.Drawing.Point(299, 73);
            this.lblTableno.Name = "lblTableno";
            this.lblTableno.Size = new System.Drawing.Size(20, 23);
            this.lblTableno.TabIndex = 16;
            this.lblTableno.Text = "-";
            // 
            // listViewTable
            // 
            this.listViewTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewTable.Font = new System.Drawing.Font("Circular Std Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewTable.FullRowSelect = true;
            this.listViewTable.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewTable.HideSelection = false;
            this.listViewTable.Location = new System.Drawing.Point(2, 118);
            this.listViewTable.MultiSelect = false;
            this.listViewTable.Name = "listViewTable";
            this.listViewTable.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listViewTable.Scrollable = false;
            this.listViewTable.Size = new System.Drawing.Size(147, 284);
            this.listViewTable.TabIndex = 23;
            this.listViewTable.TileSize = new System.Drawing.Size(170, 40);
            this.listViewTable.UseCompatibleStateImageBehavior = false;
            this.listViewTable.View = System.Windows.Forms.View.Details;
            this.listViewTable.SelectedIndexChanged += new System.EventHandler(this.ListViewTable_SelectedIndexChanged_1);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Circular Std Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnLogout.Location = new System.Drawing.Point(655, 8);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(103, 36);
            this.btnLogout.TabIndex = 24;
            this.btnLogout.Text = "LOGOUT";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // pnl_Bill
            // 
            this.pnl_Bill.Controls.Add(this.lblTotal);
            this.pnl_Bill.Controls.Add(this.lblTip);
            this.pnl_Bill.Controls.Add(this.lblVat);
            this.pnl_Bill.Controls.Add(this.lblOrder);
            this.pnl_Bill.Controls.Add(this.label11);
            this.pnl_Bill.Controls.Add(this.label10);
            this.pnl_Bill.Controls.Add(this.label9);
            this.pnl_Bill.Controls.Add(this.label8);
            this.pnl_Bill.Controls.Add(this.btnEditOrderM);
            this.pnl_Bill.Controls.Add(this.btnTipM);
            this.pnl_Bill.Controls.Add(this.btnFeedbackM);
            this.pnl_Bill.Controls.Add(this.listViewOrder);
            this.pnl_Bill.Controls.Add(this.btnPay);
            this.pnl_Bill.Location = new System.Drawing.Point(152, 105);
            this.pnl_Bill.Name = "pnl_Bill";
            this.pnl_Bill.Size = new System.Drawing.Size(614, 390);
            this.pnl_Bill.TabIndex = 25;
            this.pnl_Bill.Paint += new System.Windows.Forms.PaintEventHandler(this.Pnl_Bill_Paint);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Image = ((System.Drawing.Image)(resources.GetObject("lblTotal.Image")));
            this.lblTotal.Location = new System.Drawing.Point(533, 97);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(26, 16);
            this.lblTotal.TabIndex = 23;
            this.lblTotal.Text = "......";
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTip.Image = ((System.Drawing.Image)(resources.GetObject("lblTip.Image")));
            this.lblTip.Location = new System.Drawing.Point(533, 61);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(23, 16);
            this.lblTip.TabIndex = 23;
            this.lblTip.Text = ".....";
            // 
            // lblVat
            // 
            this.lblVat.AutoSize = true;
            this.lblVat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVat.Image = ((System.Drawing.Image)(resources.GetObject("lblVat.Image")));
            this.lblVat.Location = new System.Drawing.Point(533, 37);
            this.lblVat.Name = "lblVat";
            this.lblVat.Size = new System.Drawing.Size(26, 16);
            this.lblVat.TabIndex = 23;
            this.lblVat.Text = "......";
            // 
            // lblOrder
            // 
            this.lblOrder.AutoSize = true;
            this.lblOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrder.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblOrder.Location = new System.Drawing.Point(530, 13);
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(26, 16);
            this.lblOrder.TabIndex = 23;
            this.lblOrder.Text = "......";
            this.lblOrder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Image = ((System.Drawing.Image)(resources.GetObject("label11.Image")));
            this.label11.Location = new System.Drawing.Point(472, 95);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 16);
            this.label11.TabIndex = 22;
            this.label11.Text = "Total";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Image = ((System.Drawing.Image)(resources.GetObject("label10.Image")));
            this.label10.Location = new System.Drawing.Point(472, 59);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 16);
            this.label10.TabIndex = 21;
            this.label10.Text = "Tip";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Image = ((System.Drawing.Image)(resources.GetObject("label9.Image")));
            this.label9.Location = new System.Drawing.Point(469, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 16);
            this.label9.TabIndex = 20;
            this.label9.Text = "VAT";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Image = ((System.Drawing.Image)(resources.GetObject("label8.Image")));
            this.label8.Location = new System.Drawing.Point(469, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 16);
            this.label8.TabIndex = 19;
            this.label8.Text = "Order";
            // 
            // btnEditOrderM
            // 
            this.btnEditOrderM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
            this.btnEditOrderM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditOrderM.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
            this.btnEditOrderM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditOrderM.Font = new System.Drawing.Font("Circular Std Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditOrderM.Location = new System.Drawing.Point(46, 339);
            this.btnEditOrderM.Name = "btnEditOrderM";
            this.btnEditOrderM.Size = new System.Drawing.Size(128, 36);
            this.btnEditOrderM.TabIndex = 18;
            this.btnEditOrderM.Text = "EDIT ORDER";
            this.btnEditOrderM.UseVisualStyleBackColor = false;
            // 
            // btnTipM
            // 
            this.btnTipM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
            this.btnTipM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTipM.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
            this.btnTipM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTipM.Font = new System.Drawing.Font("Circular Std Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTipM.Location = new System.Drawing.Point(369, 338);
            this.btnTipM.Name = "btnTipM";
            this.btnTipM.Size = new System.Drawing.Size(118, 37);
            this.btnTipM.TabIndex = 17;
            this.btnTipM.Text = "EDIT TIP";
            this.btnTipM.UseVisualStyleBackColor = false;
            this.btnTipM.Click += new System.EventHandler(this.BtnTipM_Click);
            // 
            // pnl_feedback
            // 
            this.pnl_feedback.Controls.Add(this.btnSaveFeedback);
            this.pnl_feedback.Controls.Add(this.btnBackF);
            this.pnl_feedback.Controls.Add(this.tbFeedback);
            this.pnl_feedback.Controls.Add(this.label12);
            this.pnl_feedback.Location = new System.Drawing.Point(155, 105);
            this.pnl_feedback.Name = "pnl_feedback";
            this.pnl_feedback.Size = new System.Drawing.Size(611, 380);
            this.pnl_feedback.TabIndex = 24;
            // 
            // btnSaveFeedback
            // 
            this.btnSaveFeedback.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
            this.btnSaveFeedback.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveFeedback.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
            this.btnSaveFeedback.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveFeedback.Font = new System.Drawing.Font("Circular Std Bold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveFeedback.Location = new System.Drawing.Point(427, 302);
            this.btnSaveFeedback.Name = "btnSaveFeedback";
            this.btnSaveFeedback.Size = new System.Drawing.Size(146, 36);
            this.btnSaveFeedback.TabIndex = 3;
            this.btnSaveFeedback.Text = "SAVE FEEDBACK";
            this.btnSaveFeedback.UseVisualStyleBackColor = false;
            this.btnSaveFeedback.Click += new System.EventHandler(this.BtnSaveFeedback_Click);
            // 
            // btnBackF
            // 
            this.btnBackF.BackColor = System.Drawing.Color.White;
            this.btnBackF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackF.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnBackF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackF.Font = new System.Drawing.Font("Circular Std Bold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackF.Location = new System.Drawing.Point(335, 303);
            this.btnBackF.Name = "btnBackF";
            this.btnBackF.Size = new System.Drawing.Size(75, 36);
            this.btnBackF.TabIndex = 2;
            this.btnBackF.Text = "BACK";
            this.btnBackF.UseVisualStyleBackColor = false;
            this.btnBackF.Click += new System.EventHandler(this.BtnBackF_Click);
            // 
            // tbFeedback
            // 
            this.tbFeedback.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFeedback.Location = new System.Drawing.Point(0, 31);
            this.tbFeedback.Multiline = true;
            this.tbFeedback.Name = "tbFeedback";
            this.tbFeedback.Size = new System.Drawing.Size(320, 180);
            this.tbFeedback.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Circular Std Book", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(0, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(262, 20);
            this.label12.TabIndex = 0;
            this.label12.Text = "Add comments from customers";
            // 
            // pnl_paymentMethod
            // 
            this.pnl_paymentMethod.Controls.Add(this.label23);
            this.pnl_paymentMethod.Controls.Add(this.lblTotalPM);
            this.pnl_paymentMethod.Controls.Add(this.lblTipPM);
            this.pnl_paymentMethod.Controls.Add(this.lblVatPM);
            this.pnl_paymentMethod.Controls.Add(this.lblOrderPM);
            this.pnl_paymentMethod.Controls.Add(this.label27);
            this.pnl_paymentMethod.Controls.Add(this.label28);
            this.pnl_paymentMethod.Controls.Add(this.label29);
            this.pnl_paymentMethod.Controls.Add(this.label30);
            this.pnl_paymentMethod.Controls.Add(this.listViewOrderPM);
            this.pnl_paymentMethod.Controls.Add(this.btnCreditCard);
            this.pnl_paymentMethod.Controls.Add(this.btnBackPM);
            this.pnl_paymentMethod.Controls.Add(this.btnPin);
            this.pnl_paymentMethod.Controls.Add(this.btnCash);
            this.pnl_paymentMethod.Controls.Add(this.label13);
            this.pnl_paymentMethod.Controls.Add(this.btnFeedbackPM);
            this.pnl_paymentMethod.Controls.Add(this.btnOrderPM);
            this.pnl_paymentMethod.Controls.Add(this.btnTipPM);
            this.pnl_paymentMethod.Location = new System.Drawing.Point(152, 98);
            this.pnl_paymentMethod.Name = "pnl_paymentMethod";
            this.pnl_paymentMethod.Size = new System.Drawing.Size(614, 385);
            this.pnl_paymentMethod.TabIndex = 4;
            this.pnl_paymentMethod.Paint += new System.Windows.Forms.PaintEventHandler(this.Pnl_paymentMethod_Paint);
            // 
            // label23
            // 
            this.label23.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label23.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label23.Location = new System.Drawing.Point(430, 268);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(163, 14);
            this.label23.TabIndex = 32;
            // 
            // lblTotalPM
            // 
            this.lblTotalPM.AutoSize = true;
            this.lblTotalPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPM.Image = ((System.Drawing.Image)(resources.GetObject("lblTotalPM.Image")));
            this.lblTotalPM.Location = new System.Drawing.Point(508, 284);
            this.lblTotalPM.Name = "lblTotalPM";
            this.lblTotalPM.Size = new System.Drawing.Size(26, 16);
            this.lblTotalPM.TabIndex = 28;
            this.lblTotalPM.Text = "......";
            // 
            // lblTipPM
            // 
            this.lblTipPM.AutoSize = true;
            this.lblTipPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipPM.Image = ((System.Drawing.Image)(resources.GetObject("lblTipPM.Image")));
            this.lblTipPM.Location = new System.Drawing.Point(508, 248);
            this.lblTipPM.Name = "lblTipPM";
            this.lblTipPM.Size = new System.Drawing.Size(23, 16);
            this.lblTipPM.TabIndex = 29;
            this.lblTipPM.Text = ".....";
            // 
            // lblVatPM
            // 
            this.lblVatPM.AutoSize = true;
            this.lblVatPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVatPM.Image = ((System.Drawing.Image)(resources.GetObject("lblVatPM.Image")));
            this.lblVatPM.Location = new System.Drawing.Point(508, 224);
            this.lblVatPM.Name = "lblVatPM";
            this.lblVatPM.Size = new System.Drawing.Size(26, 16);
            this.lblVatPM.TabIndex = 30;
            this.lblVatPM.Text = "......";
            // 
            // lblOrderPM
            // 
            this.lblOrderPM.AutoSize = true;
            this.lblOrderPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderPM.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblOrderPM.Location = new System.Drawing.Point(505, 200);
            this.lblOrderPM.Name = "lblOrderPM";
            this.lblOrderPM.Size = new System.Drawing.Size(26, 16);
            this.lblOrderPM.TabIndex = 31;
            this.lblOrderPM.Text = "......";
            this.lblOrderPM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Image = ((System.Drawing.Image)(resources.GetObject("label27.Image")));
            this.label27.Location = new System.Drawing.Point(447, 282);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(44, 16);
            this.label27.TabIndex = 27;
            this.label27.Text = "Total";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Image = ((System.Drawing.Image)(resources.GetObject("label28.Image")));
            this.label28.Location = new System.Drawing.Point(447, 246);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(31, 16);
            this.label28.TabIndex = 26;
            this.label28.Text = "Tip";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Image = ((System.Drawing.Image)(resources.GetObject("label29.Image")));
            this.label29.Location = new System.Drawing.Point(444, 223);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(38, 16);
            this.label29.TabIndex = 25;
            this.label29.Text = "VAT";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Image = ((System.Drawing.Image)(resources.GetObject("label30.Image")));
            this.label30.Location = new System.Drawing.Point(444, 197);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(47, 16);
            this.label30.TabIndex = 24;
            this.label30.Text = "Order";
            // 
            // listViewOrderPM
            // 
            this.listViewOrderPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewOrderPM.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewOrderPM.HideSelection = false;
            this.listViewOrderPM.Location = new System.Drawing.Point(430, 4);
            this.listViewOrderPM.Name = "listViewOrderPM";
            this.listViewOrderPM.Size = new System.Drawing.Size(176, 301);
            this.listViewOrderPM.TabIndex = 19;
            this.listViewOrderPM.UseCompatibleStateImageBehavior = false;
            this.listViewOrderPM.View = System.Windows.Forms.View.Details;
            // 
            // btnCreditCard
            // 
            this.btnCreditCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
            this.btnCreditCard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreditCard.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
            this.btnCreditCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreditCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreditCard.Image = ((System.Drawing.Image)(resources.GetObject("btnCreditCard.Image")));
            this.btnCreditCard.Location = new System.Drawing.Point(223, 48);
            this.btnCreditCard.Name = "btnCreditCard";
            this.btnCreditCard.Size = new System.Drawing.Size(144, 78);
            this.btnCreditCard.TabIndex = 1;
            this.btnCreditCard.Text = "CREDIT CARD";
            this.btnCreditCard.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCreditCard.UseVisualStyleBackColor = false;
            this.btnCreditCard.Click += new System.EventHandler(this.BtnCreditCard_Click);
            // 
            // btnBackPM
            // 
            this.btnBackPM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackPM.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(146)))), ((int)(((byte)(255)))));
            this.btnBackPM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackPM.Font = new System.Drawing.Font("Circular Std Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackPM.Location = new System.Drawing.Point(71, 325);
            this.btnBackPM.Name = "btnBackPM";
            this.btnBackPM.Size = new System.Drawing.Size(92, 36);
            this.btnBackPM.TabIndex = 2;
            this.btnBackPM.Text = "BACK";
            this.btnBackPM.UseVisualStyleBackColor = true;
            this.btnBackPM.Click += new System.EventHandler(this.BtnBackPM_Click);
            // 
            // btnPin
            // 
            this.btnPin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
            this.btnPin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
            this.btnPin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPin.Image = ((System.Drawing.Image)(resources.GetObject("btnPin.Image")));
            this.btnPin.Location = new System.Drawing.Point(128, 48);
            this.btnPin.Name = "btnPin";
            this.btnPin.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnPin.Size = new System.Drawing.Size(78, 78);
            this.btnPin.TabIndex = 1;
            this.btnPin.Text = "PIN";
            this.btnPin.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPin.UseVisualStyleBackColor = false;
            this.btnPin.Click += new System.EventHandler(this.BtnPin_Click);
            // 
            // btnCash
            // 
            this.btnCash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
            this.btnCash.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCash.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
            this.btnCash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCash.Image = ((System.Drawing.Image)(resources.GetObject("btnCash.Image")));
            this.btnCash.Location = new System.Drawing.Point(16, 48);
            this.btnCash.Name = "btnCash";
            this.btnCash.Size = new System.Drawing.Size(92, 78);
            this.btnCash.TabIndex = 1;
            this.btnCash.Text = "CASH";
            this.btnCash.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCash.UseVisualStyleBackColor = false;
            this.btnCash.Click += new System.EventHandler(this.BtnCash_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(3, 4);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(213, 20);
            this.label13.TabIndex = 0;
            this.label13.Text = "Select a payment method";
            // 
            // btnFeedbackPM
            // 
            this.btnFeedbackPM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFeedbackPM.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(146)))), ((int)(((byte)(255)))));
            this.btnFeedbackPM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFeedbackPM.Font = new System.Drawing.Font("Circular Std Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFeedbackPM.Location = new System.Drawing.Point(180, 325);
            this.btnFeedbackPM.Name = "btnFeedbackPM";
            this.btnFeedbackPM.Size = new System.Drawing.Size(161, 36);
            this.btnFeedbackPM.TabIndex = 1;
            this.btnFeedbackPM.Text = "ADD FEEDBACK";
            this.btnFeedbackPM.UseVisualStyleBackColor = true;
            this.btnFeedbackPM.Click += new System.EventHandler(this.BtnFeedbackPM_Click);
            // 
            // btnOrderPM
            // 
            this.btnOrderPM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrderPM.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(146)))), ((int)(((byte)(255)))));
            this.btnOrderPM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrderPM.Font = new System.Drawing.Font("Circular Std Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrderPM.Location = new System.Drawing.Point(478, 325);
            this.btnOrderPM.Name = "btnOrderPM";
            this.btnOrderPM.Size = new System.Drawing.Size(128, 36);
            this.btnOrderPM.TabIndex = 18;
            this.btnOrderPM.Text = "EDIT ORDER";
            this.btnOrderPM.UseVisualStyleBackColor = true;
            // 
            // btnTipPM
            // 
            this.btnTipPM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTipPM.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(146)))), ((int)(((byte)(255)))));
            this.btnTipPM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTipPM.Font = new System.Drawing.Font("Circular Std Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTipPM.Location = new System.Drawing.Point(359, 325);
            this.btnTipPM.Name = "btnTipPM";
            this.btnTipPM.Size = new System.Drawing.Size(107, 36);
            this.btnTipPM.TabIndex = 17;
            this.btnTipPM.Text = "EDIT TIP";
            this.btnTipPM.UseVisualStyleBackColor = true;
            this.btnTipPM.Click += new System.EventHandler(this.BtnTipPM_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Circular Std Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(54, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 24);
            this.label1.TabIndex = 27;
            this.label1.Text = "MENU";
            // 
            // pnl_Payment
            // 
            this.pnl_Payment.Controls.Add(this.label24);
            this.pnl_Payment.Controls.Add(this.lblTotalPayment);
            this.pnl_Payment.Controls.Add(this.lblTipPayment);
            this.pnl_Payment.Controls.Add(this.lblVatPayment);
            this.pnl_Payment.Controls.Add(this.lblOrderPayment);
            this.pnl_Payment.Controls.Add(this.label35);
            this.pnl_Payment.Controls.Add(this.label36);
            this.pnl_Payment.Controls.Add(this.label37);
            this.pnl_Payment.Controls.Add(this.label38);
            this.pnl_Payment.Controls.Add(this.btnChangePaymentMethod);
            this.pnl_Payment.Controls.Add(this.btnManualComplete);
            this.pnl_Payment.Controls.Add(this.listViewOrderPayment);
            this.pnl_Payment.Controls.Add(this.label4);
            this.pnl_Payment.Controls.Add(this.label3);
            this.pnl_Payment.Controls.Add(this.label2);
            this.pnl_Payment.Location = new System.Drawing.Point(152, 76);
            this.pnl_Payment.Name = "pnl_Payment";
            this.pnl_Payment.Size = new System.Drawing.Size(614, 409);
            this.pnl_Payment.TabIndex = 28;
            // 
            // label24
            // 
            this.label24.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label24.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label24.Location = new System.Drawing.Point(435, 290);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(163, 14);
            this.label24.TabIndex = 40;
            // 
            // lblTotalPayment
            // 
            this.lblTotalPayment.AutoSize = true;
            this.lblTotalPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPayment.Image = ((System.Drawing.Image)(resources.GetObject("lblTotalPayment.Image")));
            this.lblTotalPayment.Location = new System.Drawing.Point(511, 307);
            this.lblTotalPayment.Name = "lblTotalPayment";
            this.lblTotalPayment.Size = new System.Drawing.Size(26, 16);
            this.lblTotalPayment.TabIndex = 36;
            this.lblTotalPayment.Text = "......";
            // 
            // lblTipPayment
            // 
            this.lblTipPayment.AutoSize = true;
            this.lblTipPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipPayment.Image = ((System.Drawing.Image)(resources.GetObject("lblTipPayment.Image")));
            this.lblTipPayment.Location = new System.Drawing.Point(511, 271);
            this.lblTipPayment.Name = "lblTipPayment";
            this.lblTipPayment.Size = new System.Drawing.Size(23, 16);
            this.lblTipPayment.TabIndex = 37;
            this.lblTipPayment.Text = ".....";
            // 
            // lblVatPayment
            // 
            this.lblVatPayment.AutoSize = true;
            this.lblVatPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVatPayment.Image = ((System.Drawing.Image)(resources.GetObject("lblVatPayment.Image")));
            this.lblVatPayment.Location = new System.Drawing.Point(511, 247);
            this.lblVatPayment.Name = "lblVatPayment";
            this.lblVatPayment.Size = new System.Drawing.Size(26, 16);
            this.lblVatPayment.TabIndex = 38;
            this.lblVatPayment.Text = "......";
            // 
            // lblOrderPayment
            // 
            this.lblOrderPayment.AutoSize = true;
            this.lblOrderPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderPayment.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblOrderPayment.Location = new System.Drawing.Point(508, 223);
            this.lblOrderPayment.Name = "lblOrderPayment";
            this.lblOrderPayment.Size = new System.Drawing.Size(26, 16);
            this.lblOrderPayment.TabIndex = 39;
            this.lblOrderPayment.Text = "......";
            this.lblOrderPayment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Image = ((System.Drawing.Image)(resources.GetObject("label35.Image")));
            this.label35.Location = new System.Drawing.Point(450, 305);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(44, 16);
            this.label35.TabIndex = 35;
            this.label35.Text = "Total";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Image = ((System.Drawing.Image)(resources.GetObject("label36.Image")));
            this.label36.Location = new System.Drawing.Point(450, 269);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(31, 16);
            this.label36.TabIndex = 34;
            this.label36.Text = "Tip";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.Image = ((System.Drawing.Image)(resources.GetObject("label37.Image")));
            this.label37.Location = new System.Drawing.Point(447, 246);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(38, 16);
            this.label37.TabIndex = 33;
            this.label37.Text = "VAT";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Image = ((System.Drawing.Image)(resources.GetObject("label38.Image")));
            this.label38.Location = new System.Drawing.Point(447, 220);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(47, 16);
            this.label38.TabIndex = 32;
            this.label38.Text = "Order";
            // 
            // btnChangePaymentMethod
            // 
            this.btnChangePaymentMethod.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnChangePaymentMethod.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangePaymentMethod.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnChangePaymentMethod.FlatAppearance.BorderSize = 0;
            this.btnChangePaymentMethod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePaymentMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePaymentMethod.Image = ((System.Drawing.Image)(resources.GetObject("btnChangePaymentMethod.Image")));
            this.btnChangePaymentMethod.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChangePaymentMethod.Location = new System.Drawing.Point(3, 66);
            this.btnChangePaymentMethod.Name = "btnChangePaymentMethod";
            this.btnChangePaymentMethod.Size = new System.Drawing.Size(216, 25);
            this.btnChangePaymentMethod.TabIndex = 19;
            this.btnChangePaymentMethod.Text = "Change Payment Method";
            this.btnChangePaymentMethod.UseVisualStyleBackColor = true;
            this.btnChangePaymentMethod.Click += new System.EventHandler(this.BtnChangePaymentMethod_Click);
            // 
            // btnManualComplete
            // 
            this.btnManualComplete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
            this.btnManualComplete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnManualComplete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
            this.btnManualComplete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManualComplete.Font = new System.Drawing.Font("Circular Std Bold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManualComplete.Location = new System.Drawing.Point(435, 354);
            this.btnManualComplete.Name = "btnManualComplete";
            this.btnManualComplete.Size = new System.Drawing.Size(176, 33);
            this.btnManualComplete.TabIndex = 18;
            this.btnManualComplete.Text = "MANUAL COMPLETE";
            this.btnManualComplete.UseVisualStyleBackColor = false;
            this.btnManualComplete.Click += new System.EventHandler(this.BtnManualComplete_Click);
            // 
            // listViewOrderPayment
            // 
            this.listViewOrderPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewOrderPayment.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewOrderPayment.HideSelection = false;
            this.listViewOrderPayment.Location = new System.Drawing.Point(435, 25);
            this.listViewOrderPayment.Name = "listViewOrderPayment";
            this.listViewOrderPayment.Size = new System.Drawing.Size(176, 301);
            this.listViewOrderPayment.TabIndex = 17;
            this.listViewOrderPayment.UseCompatibleStateImageBehavior = false;
            this.listViewOrderPayment.View = System.Windows.Forms.View.Details;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(254, 32);
            this.label4.TabIndex = 16;
            this.label4.Text = "Please follow the instructions on the\r\npayment device.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Manteka", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(66, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 23);
            this.label3.TabIndex = 15;
            this.label3.Text = "Payment";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Manteka", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 23);
            this.label2.TabIndex = 14;
            this.label2.Text = "Bill - ";
            // 
            // pnl_CompleteBill
            // 
            this.pnl_CompleteBill.Controls.Add(this.btnFinish);
            this.pnl_CompleteBill.Controls.Add(this.button2);
            this.pnl_CompleteBill.Controls.Add(this.label15);
            this.pnl_CompleteBill.Controls.Add(this.label14);
            this.pnl_CompleteBill.Controls.Add(this.label7);
            this.pnl_CompleteBill.Location = new System.Drawing.Point(152, 76);
            this.pnl_CompleteBill.Name = "pnl_CompleteBill";
            this.pnl_CompleteBill.Size = new System.Drawing.Size(590, 429);
            this.pnl_CompleteBill.TabIndex = 19;
            // 
            // btnFinish
            // 
            this.btnFinish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
            this.btnFinish.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFinish.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
            this.btnFinish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinish.Font = new System.Drawing.Font("Circular Std Bold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinish.Location = new System.Drawing.Point(128, 77);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(90, 36);
            this.btnFinish.TabIndex = 18;
            this.btnFinish.Text = "FINISH";
            this.btnFinish.UseVisualStyleBackColor = false;
            this.btnFinish.Click += new System.EventHandler(this.BtnFinish_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
            this.button2.Cursor = System.Windows.Forms.Cursors.Default;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Circular Std Bold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(8, 76);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 37);
            this.button2.TabIndex = 17;
            this.button2.Text = "PRINT BILL";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(4, 32);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(299, 32);
            this.label15.TabIndex = 16;
            this.label15.Text = "The payment was successfully completed.\r\nLeaving this screen will complete the bi" +
    "ll.";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Manteka", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(66, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(107, 23);
            this.label14.TabIndex = 15;
            this.label14.Text = "COMPLETE";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Manteka", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 23);
            this.label7.TabIndex = 14;
            this.label7.Text = "Bill - ";
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.SystemColors.Window;
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label16.Location = new System.Drawing.Point(-2, 112);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(152, 10);
            this.label16.TabIndex = 29;
            // 
            // label17
            // 
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(146)))), ((int)(((byte)(255)))));
            this.label17.Location = new System.Drawing.Point(-2, 141);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(152, 10);
            this.label17.TabIndex = 29;
            // 
            // label18
            // 
            this.label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label18.Location = new System.Drawing.Point(-2, 171);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(152, 10);
            this.label18.TabIndex = 29;
            // 
            // label19
            // 
            this.label19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label19.Location = new System.Drawing.Point(-2, 198);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(152, 10);
            this.label19.TabIndex = 29;
            // 
            // label20
            // 
            this.label20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label20.Location = new System.Drawing.Point(-2, 227);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(152, 10);
            this.label20.TabIndex = 29;
            // 
            // label21
            // 
            this.label21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label21.Location = new System.Drawing.Point(-2, 255);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(152, 10);
            this.label21.TabIndex = 29;
            // 
            // label22
            // 
            this.label22.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label22.Location = new System.Drawing.Point(-2, 283);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(152, 10);
            this.label22.TabIndex = 29;
            // 
            // pbMenu
            // 
            this.pbMenu.Image = ((System.Drawing.Image)(resources.GetObject("pbMenu.Image")));
            this.pbMenu.Location = new System.Drawing.Point(23, 72);
            this.pbMenu.Name = "pbMenu";
            this.pbMenu.Size = new System.Drawing.Size(25, 21);
            this.pbMenu.TabIndex = 26;
            this.pbMenu.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ChapeauUI.Properties.Resources.chapeau_logo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 41);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // btnUndoFeedback
            // 
            this.btnUndoFeedback.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnUndoFeedback.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnUndoFeedback.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUndoFeedback.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnUndoFeedback.FlatAppearance.BorderSize = 0;
            this.btnUndoFeedback.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUndoFeedback.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUndoFeedback.Image = ((System.Drawing.Image)(resources.GetObject("btnUndoFeedback.Image")));
            this.btnUndoFeedback.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUndoFeedback.Location = new System.Drawing.Point(-3, 413);
            this.btnUndoFeedback.Name = "btnUndoFeedback";
            this.btnUndoFeedback.Size = new System.Drawing.Size(274, 25);
            this.btnUndoFeedback.TabIndex = 24;
            this.btnUndoFeedback.Text = "Feedback added sucessfully. Undo";
            this.btnUndoFeedback.UseVisualStyleBackColor = false;
            this.btnUndoFeedback.Click += new System.EventHandler(this.BtnUndoFeedback_Click);
            // 
            // label25
            // 
            this.label25.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label25.Location = new System.Drawing.Point(-3, 311);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(152, 10);
            this.label25.TabIndex = 29;
            // 
            // label31
            // 
            this.label31.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label31.Location = new System.Drawing.Point(-2, 367);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(152, 10);
            this.label31.TabIndex = 29;
            // 
            // label32
            // 
            this.label32.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label32.Location = new System.Drawing.Point(-2, 338);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(152, 10);
            this.label32.TabIndex = 29;
            // 
            // label26
            // 
            this.label26.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label26.Location = new System.Drawing.Point(-2, 393);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(152, 10);
            this.label26.TabIndex = 29;
            // 
            // pnl_NoOrder
            // 
            this.pnl_NoOrder.Controls.Add(this.label33);
            this.pnl_NoOrder.Location = new System.Drawing.Point(152, 99);
            this.pnl_NoOrder.Name = "pnl_NoOrder";
            this.pnl_NoOrder.Size = new System.Drawing.Size(614, 383);
            this.pnl_NoOrder.TabIndex = 33;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Manteka", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(82, 128);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(410, 50);
            this.label33.TabIndex = 0;
            this.label33.Text = "Can\'t show bill\r\nNo order taken for this table yet.\r\n";
            this.label33.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Timerbtn
            // 
            this.Timerbtn.Enabled = true;
            this.Timerbtn.Interval = 3000;
            this.Timerbtn.Tick += new System.EventHandler(this.Timerbtn_Tick);
            // 
            // BillUI
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(791, 503);
            this.Controls.Add(this.btnUndoFeedback);
            this.Controls.Add(this.pnl_NoOrder);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.pnl_paymentMethod);
            this.Controls.Add(this.pnl_Payment);
            this.Controls.Add(this.pnl_CompleteBill);
            this.Controls.Add(this.pnl_Bill);
            this.Controls.Add(this.pnl_feedback);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbMenu);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.listViewTable);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblTableno);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BillUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bill";
            this.Load += new System.EventHandler(this.BillUI_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Bill_UI_Paint);
            this.pnl_Bill.ResumeLayout(false);
            this.pnl_Bill.PerformLayout();
            this.pnl_feedback.ResumeLayout(false);
            this.pnl_feedback.PerformLayout();
            this.pnl_paymentMethod.ResumeLayout(false);
            this.pnl_paymentMethod.PerformLayout();
            this.pnl_Payment.ResumeLayout(false);
            this.pnl_Payment.PerformLayout();
            this.pnl_CompleteBill.ResumeLayout(false);
            this.pnl_CompleteBill.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnl_NoOrder.ResumeLayout(false);
            this.pnl_NoOrder.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewOrder;

        private System.Windows.Forms.Button btnFeedbackM;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTableno;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListView listViewTable;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel pnl_Bill;
        private System.Windows.Forms.Button btnEditOrderM;
        private System.Windows.Forms.Button btnTipM;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTip;
        private System.Windows.Forms.Label lblVat;
        private System.Windows.Forms.Label lblOrder;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel pnl_feedback;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbFeedback;
        private System.Windows.Forms.Button btnSaveFeedback;
        private System.Windows.Forms.Button btnBackF;
        private System.Windows.Forms.Panel pnl_paymentMethod;
        private System.Windows.Forms.Button btnCash;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnCreditCard;
        private System.Windows.Forms.Button btnPin;
        private System.Windows.Forms.Button btnFeedbackPM;
        private System.Windows.Forms.Button btnOrderPM;
        private System.Windows.Forms.Button btnTipPM;
        private System.Windows.Forms.ListView listViewOrderPM;
        private System.Windows.Forms.Button btnBackPM;
        private System.Windows.Forms.PictureBox pbMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnl_Payment;
        private System.Windows.Forms.Panel pnl_CompleteBill;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnManualComplete;
        private System.Windows.Forms.ListView listViewOrderPayment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnChangePaymentMethod;
        private System.Windows.Forms.Button btnUndoFeedback;
        private System.Windows.Forms.Label lblTotalPM;
        private System.Windows.Forms.Label lblTipPM;
        private System.Windows.Forms.Label lblVatPM;
        private System.Windows.Forms.Label lblOrderPM;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label lblTotalPayment;
        private System.Windows.Forms.Label lblTipPayment;
        private System.Windows.Forms.Label lblVatPayment;
        private System.Windows.Forms.Label lblOrderPayment;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Panel pnl_NoOrder;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Timer Timerbtn;
    }
}