namespace Donations
{
    partial class LoginView
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
            userTextBox = new TextBox();
            passTextBox = new TextBox();
            loginButton = new Button();
            userLabel = new Label();
            passLabel = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // userTextBox
            // 
            userTextBox.Location = new Point(141, 148);
            userTextBox.Margin = new Padding(4, 5, 4, 5);
            userTextBox.Name = "userTextBox";
            userTextBox.Size = new Size(124, 31);
            userTextBox.TabIndex = 0;
            // 
            // passTextBox
            // 
            passTextBox.Location = new Point(141, 192);
            passTextBox.Margin = new Padding(4, 5, 4, 5);
            passTextBox.Name = "passTextBox";
            passTextBox.Size = new Size(124, 31);
            passTextBox.TabIndex = 1;
            passTextBox.UseSystemPasswordChar = true;
            passTextBox.PasswordChar = '*';
            // 
            // loginButton
            // 
            loginButton.Location = new Point(121, 284);
            loginButton.Margin = new Padding(4, 5, 4, 5);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(94, 36);
            loginButton.TabIndex = 2;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
            // 
            // userLabel
            // 
            userLabel.AutoSize = true;
            userLabel.Enabled = false;
            userLabel.Location = new Point(50, 148);
            userLabel.Margin = new Padding(4, 0, 4, 0);
            userLabel.Name = "userLabel";
            userLabel.Size = new Size(89, 25);
            userLabel.TabIndex = 3;
            userLabel.Text = "username";
            // 
            // passLabel
            // 
            passLabel.AutoSize = true;
            passLabel.Enabled = false;
            passLabel.Location = new Point(51, 197);
            passLabel.Margin = new Padding(4, 0, 4, 0);
            passLabel.Name = "passLabel";
            passLabel.Size = new Size(89, 25);
            passLabel.TabIndex = 4;
            passLabel.Text = "password";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(138, 76);
            label1.Name = "label1";
            label1.Size = new Size(127, 25);
            label1.TabIndex = 5;
            label1.Text = "Autentification";
            // 
            // LoginView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(348, 366);
            Controls.Add(label1);
            Controls.Add(passLabel);
            Controls.Add(userLabel);
            Controls.Add(loginButton);
            Controls.Add(passTextBox);
            Controls.Add(userTextBox);
            Margin = new Padding(4, 5, 4, 5);
            Name = "LoginView";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox userTextBox;
        private System.Windows.Forms.TextBox passTextBox;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.Label passLabel;
        private Label label1;
    }
}