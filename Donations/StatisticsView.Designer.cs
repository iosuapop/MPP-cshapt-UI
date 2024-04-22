using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Donations.service;

namespace Donations
{
    public partial class StatisticsView : Form
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
            titleLabel = new Label();
            dataGridView = new DataGridView();
            logoutButton = new Button();
            donationButton = new Button();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Arial", 16F);
            titleLabel.Location = new Point(164, 21);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(142, 36);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Statistics";
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.ColumnHeadersHeight = 34;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2 });
            dataGridView.Location = new Point(12, 72);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersWidth = 62;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Size = new Size(465, 292);
            dataGridView.TabIndex = 1;
            // 
            // logoutButton
            // 
            logoutButton.Location = new Point(72, 388);
            logoutButton.Name = "logoutButton";
            logoutButton.Size = new Size(111, 37);
            logoutButton.TabIndex = 2;
            logoutButton.Text = "Log Out";
            logoutButton.Click += LogoutButton_Click;
            // 
            // donationButton
            // 
            donationButton.Location = new Point(240, 388);
            donationButton.Name = "donationButton";
            donationButton.Size = new Size(166, 37);
            donationButton.TabIndex = 3;
            donationButton.Text = "Make a Donation";
            donationButton.Click += DonationButton_Click;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Case";
            dataGridViewTextBoxColumn1.MinimumWidth = 8;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Width = 250;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Amount";
            dataGridViewTextBoxColumn2.MinimumWidth = 8;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            dataGridViewTextBoxColumn2.Width = 150;
            // 
            // StatisticsView
            // 
            ClientSize = new Size(496, 476);
            Controls.Add(titleLabel);
            Controls.Add(dataGridView);
            Controls.Add(logoutButton);
            Controls.Add(donationButton);
            Name = "StatisticsView";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        // Define controls
        private Label titleLabel;
        private DataGridView dataGridView;
        private Button logoutButton;
        private Button donationButton;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        
    }
}
