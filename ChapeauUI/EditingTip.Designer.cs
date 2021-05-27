namespace ChapeauUI
{
    partial class EditingTip
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbTip = new System.Windows.Forms.TextBox();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnSaveTip = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tip Amount";
            // 
            // tbTip
            // 
            this.tbTip.Location = new System.Drawing.Point(16, 34);
            this.tbTip.Name = "tbTip";
            this.tbTip.Size = new System.Drawing.Size(188, 23);
            this.tbTip.TabIndex = 1;
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.White;
            this.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
            this.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancel.Font = new System.Drawing.Font("Circular Std Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancel.Location = new System.Drawing.Point(12, 72);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(87, 32);
            this.BtnCancel.TabIndex = 2;
            this.BtnCancel.Text = "CANCEL";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnSaveTip
            // 
            this.BtnSaveTip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
            this.BtnSaveTip.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
            this.BtnSaveTip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSaveTip.Font = new System.Drawing.Font("Circular Std Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSaveTip.Location = new System.Drawing.Point(107, 73);
            this.BtnSaveTip.Name = "BtnSaveTip";
            this.BtnSaveTip.Size = new System.Drawing.Size(97, 32);
            this.BtnSaveTip.TabIndex = 2;
            this.BtnSaveTip.Text = "SAVE TIP";
            this.BtnSaveTip.UseVisualStyleBackColor = false;
            this.BtnSaveTip.Click += new System.EventHandler(this.BtnSaveTip_Click);
            // 
            // EditingTip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(216, 117);
            this.Controls.Add(this.BtnSaveTip);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.tbTip);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Circular Std Bold", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = new System.Drawing.Point(800, 800);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "EditingTip";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit tip";
            this.Load += new System.EventHandler(this.EditingTip_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTip;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnSaveTip;
    }
}