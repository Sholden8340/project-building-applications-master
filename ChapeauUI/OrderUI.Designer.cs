namespace ChapeauUI
{
    partial class OrderUI
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
            this.FlowLayoutMenuItems = new System.Windows.Forms.FlowLayoutPanel();
            this.Lbl_MenuTitle = new System.Windows.Forms.Label();
            this.btn_OpenCart = new System.Windows.Forms.PictureBox();
            this.Elem_AddWithCommentHost = new System.Windows.Forms.Integration.ElementHost();
            this.Elem_CheckoutOverview = new System.Windows.Forms.Integration.ElementHost();
            this.orderCheckout1 = new ChapeauUI.OrderCheckout();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.navigation1 = new ChapeauUI.Navigation();
            this.SidebarnavWrapper = new System.Windows.Forms.Integration.ElementHost();
            this.sidebarNav1 = new ChapeauUI.SidebarNav();
            this.Lbl_OrderTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btn_OpenCart)).BeginInit();
            this.SuspendLayout();
            // 
            // FlowLayoutMenuItems
            // 
            this.FlowLayoutMenuItems.AutoScroll = true;
            this.FlowLayoutMenuItems.AutoScrollMinSize = new System.Drawing.Size(0, 500);
            this.FlowLayoutMenuItems.BackColor = System.Drawing.Color.White;
            this.FlowLayoutMenuItems.Location = new System.Drawing.Point(222, 138);
            this.FlowLayoutMenuItems.Margin = new System.Windows.Forms.Padding(0);
            this.FlowLayoutMenuItems.MaximumSize = new System.Drawing.Size(790, 500);
            this.FlowLayoutMenuItems.Name = "FlowLayoutMenuItems";
            this.FlowLayoutMenuItems.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.FlowLayoutMenuItems.Size = new System.Drawing.Size(790, 500);
            this.FlowLayoutMenuItems.TabIndex = 3;
            this.FlowLayoutMenuItems.Scroll += new System.Windows.Forms.ScrollEventHandler(this.FlowLayoutMenuItems_Scroll);
            // 
            // Lbl_MenuTitle
            // 
            this.Lbl_MenuTitle.AutoSize = true;
            this.Lbl_MenuTitle.Font = new System.Drawing.Font("Manteka", 32.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_MenuTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(19)))));
            this.Lbl_MenuTitle.Location = new System.Drawing.Point(223, 79);
            this.Lbl_MenuTitle.Name = "Lbl_MenuTitle";
            this.Lbl_MenuTitle.Size = new System.Drawing.Size(55, 51);
            this.Lbl_MenuTitle.TabIndex = 7;
            this.Lbl_MenuTitle.Text = "...";
            // 
            // btn_OpenCart
            // 
            this.btn_OpenCart.BackgroundImage = global::ChapeauUI.Properties.Resources.order_icon_3x;
            this.btn_OpenCart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_OpenCart.Location = new System.Drawing.Point(962, 85);
            this.btn_OpenCart.Name = "btn_OpenCart";
            this.btn_OpenCart.Size = new System.Drawing.Size(50, 50);
            this.btn_OpenCart.TabIndex = 8;
            this.btn_OpenCart.TabStop = false;
            this.btn_OpenCart.Click += new System.EventHandler(this.Btn_OpenCart_Click);
            // 
            // Elem_AddWithCommentHost
            // 
            this.Elem_AddWithCommentHost.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Elem_AddWithCommentHost.BackColor = System.Drawing.Color.Transparent;
            this.Elem_AddWithCommentHost.Location = new System.Drawing.Point(325, 250);
            this.Elem_AddWithCommentHost.Name = "Elem_AddWithCommentHost";
            this.Elem_AddWithCommentHost.Size = new System.Drawing.Size(580, 220);
            this.Elem_AddWithCommentHost.TabIndex = 11;
            this.Elem_AddWithCommentHost.Text = "AddWithCommentHost";
            this.Elem_AddWithCommentHost.Visible = false;
            this.Elem_AddWithCommentHost.Child = null;
            // 
            // Elem_CheckoutOverview
            // 
            this.Elem_CheckoutOverview.BackColor = System.Drawing.Color.Transparent;
            this.Elem_CheckoutOverview.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Elem_CheckoutOverview.Location = new System.Drawing.Point(0, 639);
            this.Elem_CheckoutOverview.Name = "Elem_CheckoutOverview";
            this.Elem_CheckoutOverview.Size = new System.Drawing.Size(1024, 1);
            this.Elem_CheckoutOverview.TabIndex = 9;
            this.Elem_CheckoutOverview.Text = "elementHost2";
            this.Elem_CheckoutOverview.Visible = false;
            this.Elem_CheckoutOverview.Child = this.orderCheckout1;
            // 
            // elementHost1
            // 
            this.elementHost1.Dock = System.Windows.Forms.DockStyle.Top;
            this.elementHost1.Location = new System.Drawing.Point(0, 0);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(1024, 67);
            this.elementHost1.TabIndex = 6;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.navigation1;
            // 
            // SidebarnavWrapper
            // 
            this.SidebarnavWrapper.Location = new System.Drawing.Point(0, 85);
            this.SidebarnavWrapper.Name = "SidebarnavWrapper";
            this.SidebarnavWrapper.Size = new System.Drawing.Size(205, 553);
            this.SidebarnavWrapper.TabIndex = 5;
            this.SidebarnavWrapper.Text = "elementHost1";
            this.SidebarnavWrapper.Child = this.sidebarNav1;
            // 
            // Lbl_OrderTotal
            // 
            this.Lbl_OrderTotal.AutoSize = true;
            this.Lbl_OrderTotal.BackColor = System.Drawing.Color.Transparent;
            this.Lbl_OrderTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(20)))), ((int)(((byte)(84)))));
            this.Lbl_OrderTotal.Location = new System.Drawing.Point(996, 77);
            this.Lbl_OrderTotal.Name = "Lbl_OrderTotal";
            this.Lbl_OrderTotal.Size = new System.Drawing.Size(17, 16);
            this.Lbl_OrderTotal.TabIndex = 12;
            this.Lbl_OrderTotal.Text = "0";
            // 
            // OrderUI
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1024, 640);
            this.Controls.Add(this.Elem_AddWithCommentHost);
            this.Controls.Add(this.Elem_CheckoutOverview);
            this.Controls.Add(this.Lbl_MenuTitle);
            this.Controls.Add(this.elementHost1);
            this.Controls.Add(this.SidebarnavWrapper);
            this.Controls.Add(this.FlowLayoutMenuItems);
            this.Controls.Add(this.Lbl_OrderTotal);
            this.Controls.Add(this.btn_OpenCart);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Circular Std Book", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "OrderUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New order";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.OrderUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btn_OpenCart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel FlowLayoutMenuItems;
        private System.Windows.Forms.Integration.ElementHost SidebarnavWrapper;
        private SidebarNav sidebarNav1;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private Navigation navigation1;
        private System.Windows.Forms.Label Lbl_MenuTitle;
        private System.Windows.Forms.PictureBox btn_OpenCart;
        private System.Windows.Forms.Integration.ElementHost Elem_CheckoutOverview;
        private OrderCheckout orderCheckout1;
        private System.Windows.Forms.Integration.ElementHost Elem_AddWithCommentHost;
        private System.Windows.Forms.Label Lbl_OrderTotal;
    }
}

