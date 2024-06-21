namespace Final_Proyect_CSharp
{
    partial class Login
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
            btnLogin = new Button();
            txtName = new TextBox();
            txtPassword = new TextBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(64, 147);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(151, 44);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtName
            // 
            txtName.Location = new Point(31, 31);
            txtName.Name = "txtName";
            txtName.Size = new Size(212, 27);
            txtName.TabIndex = 7;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(31, 102);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(212, 27);
            txtPassword.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 8);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 9;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 79);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 10;
            label2.Text = "Password";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(273, 225);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtPassword);
            Controls.Add(txtName);
            Controls.Add(btnLogin);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Enter Credentials";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin;
        private TextBox txtName;
        private TextBox txtPassword;
        private Label label1;
        private Label label2;
    }
}