namespace ChapeauUI
{
    partial class BarKitchenUI
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
            this.Lst_Orders = new System.Windows.Forms.ListView();
            this.Quantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Item = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Comments = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TakenAt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Worker_UpdateData = new System.ComponentModel.BackgroundWorker();
            this.Btn_MarkAsReady = new System.Windows.Forms.Button();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.navigation1 = new ChapeauUI.Navigation();
            this.Lbl_PageTitle = new System.Windows.Forms.Label();
            this.Btn_ToggleView = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Lst_Orders
            // 
            this.Lst_Orders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Quantity,
            this.Item,
            this.Comments,
            this.Status,
            this.TakenAt});
            this.Lst_Orders.FullRowSelect = true;
            this.Lst_Orders.GridLines = true;
            this.Lst_Orders.HideSelection = false;
            this.Lst_Orders.Location = new System.Drawing.Point(12, 164);
            this.Lst_Orders.MultiSelect = false;
            this.Lst_Orders.Name = "Lst_Orders";
            this.Lst_Orders.Size = new System.Drawing.Size(1060, 562);
            this.Lst_Orders.TabIndex = 1;
            this.Lst_Orders.UseCompatibleStateImageBehavior = false;
            this.Lst_Orders.View = System.Windows.Forms.View.Details;
            // 
            // Quantity
            // 
            this.Quantity.Text = "Quantity";
            this.Quantity.Width = 100;
            // 
            // Item
            // 
            this.Item.Text = "Item";
            this.Item.Width = 459;
            // 
            // Comments
            // 
            this.Comments.Text = "Comments";
            this.Comments.Width = 213;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            this.Status.Width = 150;
            // 
            // TakenAt
            // 
            this.TakenAt.Text = "Time";
            this.TakenAt.Width = 120;
            // 
            // Worker_UpdateData
            // 
            this.Worker_UpdateData.WorkerSupportsCancellation = true;
            this.Worker_UpdateData.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Worker_UpdateOrders_DoWork);
            this.Worker_UpdateData.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Worker_UpdateOrders_RunWorkerCompleted);
            // 
            // Btn_MarkAsReady
            // 
            this.Btn_MarkAsReady.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
            this.Btn_MarkAsReady.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
            this.Btn_MarkAsReady.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(126)))), ((int)(((byte)(255)))));
            this.Btn_MarkAsReady.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(146)))), ((int)(((byte)(255)))));
            this.Btn_MarkAsReady.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_MarkAsReady.Font = new System.Drawing.Font("Circular Std Bold", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_MarkAsReady.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(65)))), ((int)(((byte)(77)))));
            this.Btn_MarkAsReady.Location = new System.Drawing.Point(1078, 164);
            this.Btn_MarkAsReady.Name = "Btn_MarkAsReady";
            this.Btn_MarkAsReady.Size = new System.Drawing.Size(174, 51);
            this.Btn_MarkAsReady.TabIndex = 2;
            this.Btn_MarkAsReady.Text = "MARK ORDER AS READY";
            this.Btn_MarkAsReady.UseVisualStyleBackColor = false;
            this.Btn_MarkAsReady.Click += new System.EventHandler(this.Btn_MarkAsReady_Click);
            // 
            // elementHost1
            // 
            this.elementHost1.Dock = System.Windows.Forms.DockStyle.Top;
            this.elementHost1.Location = new System.Drawing.Point(0, 0);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(1264, 71);
            this.elementHost1.TabIndex = 0;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.navigation1;
            // 
            // Lbl_PageTitle
            // 
            this.Lbl_PageTitle.AutoSize = true;
            this.Lbl_PageTitle.Font = new System.Drawing.Font("Manteka", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_PageTitle.Location = new System.Drawing.Point(12, 96);
            this.Lbl_PageTitle.Name = "Lbl_PageTitle";
            this.Lbl_PageTitle.Size = new System.Drawing.Size(502, 44);
            this.Lbl_PageTitle.TabIndex = 3;
            this.Lbl_PageTitle.Text = "KITCHEN - ACTIVE ORDERS";
            // 
            // Btn_ToggleView
            // 
            this.Btn_ToggleView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
            this.Btn_ToggleView.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
            this.Btn_ToggleView.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(126)))), ((int)(((byte)(255)))));
            this.Btn_ToggleView.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(146)))), ((int)(((byte)(255)))));
            this.Btn_ToggleView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_ToggleView.Font = new System.Drawing.Font("Circular Std Bold", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_ToggleView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(65)))), ((int)(((byte)(77)))));
            this.Btn_ToggleView.Location = new System.Drawing.Point(1078, 221);
            this.Btn_ToggleView.Name = "Btn_ToggleView";
            this.Btn_ToggleView.Size = new System.Drawing.Size(174, 51);
            this.Btn_ToggleView.TabIndex = 4;
            this.Btn_ToggleView.Text = "VIEW FINISHED ORDERS";
            this.Btn_ToggleView.UseVisualStyleBackColor = false;
            this.Btn_ToggleView.Click += new System.EventHandler(this.Btn_ToggleView_Click);
            // 
            // BarKitchenUI
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1264, 761);
            this.Controls.Add(this.Btn_ToggleView);
            this.Controls.Add(this.Lbl_PageTitle);
            this.Controls.Add(this.Btn_MarkAsReady);
            this.Controls.Add(this.Lst_Orders);
            this.Controls.Add(this.elementHost1);
            this.Font = new System.Drawing.Font("Circular Std Book", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BarKitchenUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bar & Kitchen";
            this.Load += new System.EventHandler(this.BarKitchenUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private Navigation navigation1;
        private System.Windows.Forms.ListView Lst_Orders;
        private System.Windows.Forms.ColumnHeader Item;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.ColumnHeader TakenAt;
        private System.ComponentModel.BackgroundWorker Worker_UpdateData;
        private System.Windows.Forms.ColumnHeader Quantity;
        private System.Windows.Forms.ColumnHeader Comments;
        private System.Windows.Forms.Button Btn_MarkAsReady;
        private System.Windows.Forms.Label Lbl_PageTitle;
        private System.Windows.Forms.Button Btn_ToggleView;
    }
}