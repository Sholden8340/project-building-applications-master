namespace ChapeauUI
{
    partial class LoginUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginUI));
            this.Btn_Login = new System.Windows.Forms.Button();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.PasswordField = new System.Windows.Forms.TextBox();
            this.EmployeeNameField = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // Btn_Login
            // 
            this.Btn_Login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
            this.Btn_Login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Login.FlatAppearance.BorderSize = 0;
            this.Btn_Login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Login.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Login.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(65)))), ((int)(((byte)(77)))));
            this.Btn_Login.Location = new System.Drawing.Point(513, 363);
            this.Btn_Login.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_Login.Name = "Btn_Login";
            this.Btn_Login.Size = new System.Drawing.Size(177, 59);
            this.Btn_Login.TabIndex = 2;
            this.Btn_Login.Text = "LOGIN";
            this.Btn_Login.UseVisualStyleBackColor = false;
            this.Btn_Login.Click += new System.EventHandler(this.Btn_Login_Click);
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.BackColor = System.Drawing.Color.White;
            this.Btn_Cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Cancel.FlatAppearance.BorderSize = 0;
            this.Btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Cancel.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Cancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(65)))), ((int)(((byte)(77)))));
            this.Btn_Cancel.Location = new System.Drawing.Point(341, 363);
            this.Btn_Cancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(166, 59);
            this.Btn_Cancel.TabIndex = 3;
            this.Btn_Cancel.Text = "CANCEL";
            this.Btn_Cancel.UseVisualStyleBackColor = false;
            this.Btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(338, 289);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Password";
            // 
            // PasswordField
            // 
            this.PasswordField.BackColor = System.Drawing.SystemColors.HighlightText;
            this.PasswordField.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordField.ForeColor = System.Drawing.Color.Black;
            this.PasswordField.HideSelection = false;
            this.PasswordField.Location = new System.Drawing.Point(342, 313);
            this.PasswordField.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PasswordField.MaxLength = 4;
            this.PasswordField.Name = "PasswordField";
            this.PasswordField.PasswordChar = '*';
            this.PasswordField.Size = new System.Drawing.Size(348, 35);
            this.PasswordField.TabIndex = 1;
            this.PasswordField.UseSystemPasswordChar = true;
            // 
            // EmployeeNameField
            // 
            this.EmployeeNameField.BackColor = System.Drawing.SystemColors.HighlightText;
            this.EmployeeNameField.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmployeeNameField.ForeColor = System.Drawing.Color.Black;
            this.EmployeeNameField.HideSelection = false;
            this.EmployeeNameField.Location = new System.Drawing.Point(341, 233);
            this.EmployeeNameField.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EmployeeNameField.MaxLength = 60;
            this.EmployeeNameField.Name = "EmployeeNameField";
            this.EmployeeNameField.Size = new System.Drawing.Size(348, 35);
            this.EmployeeNameField.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(339, 208);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Employee Name";
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 595);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1008, 6);
            this.progressBar1.Step = 20;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 6;
            // 
            // LoginUI
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1008, 601);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.EmployeeNameField);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PasswordField);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Btn_Cancel);
            this.Controls.Add(this.Btn_Login);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Circular Std Book", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "LoginUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TransparencyKey = System.Drawing.Color.Red;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LoginUI_FormClosed);
            this.Load += new System.EventHandler(this.LoginUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_Login;
        private System.Windows.Forms.Button Btn_Cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PasswordField;
        private System.Windows.Forms.TextBox EmployeeNameField;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}