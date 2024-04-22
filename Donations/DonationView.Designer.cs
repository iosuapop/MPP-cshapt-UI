using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace Donations;

partial class DonationView
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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
        findButton = new Button();
        partTextBox = new TextBox();
        donorDataGridView = new DataGridView();
        completeButton = new Button();
        dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
        label1 = new Label();
        label2 = new Label();
        label3 = new Label();
        label4 = new Label();
        label5 = new Label();
        comboBox1 = new ComboBox();
        textBox1 = new TextBox();
        textBox2 = new TextBox();
        textBox3 = new TextBox();
        textBox4 = new TextBox();
        ((ISupportInitialize)donorDataGridView).BeginInit();
        SuspendLayout();
        // 
        // titleLabel
        // 
        titleLabel.AutoSize = true;
        titleLabel.Font = new Font("Arial", 16F);
        titleLabel.Location = new Point(576, 37);
        titleLabel.Name = "titleLabel";
        titleLabel.Size = new Size(141, 36);
        titleLabel.TabIndex = 0;
        titleLabel.Text = "Donation";
        titleLabel.Click += titleLabel_Click;
        // 
        // findButton
        // 
        findButton.Location = new Point(32, 37);
        findButton.Name = "findButton";
        findButton.Size = new Size(90, 31);
        findButton.TabIndex = 1;
        findButton.Text = "Find";
        findButton.Click += FindButton_Click;
        // 
        // partTextBox
        // 
        partTextBox.Location = new Point(139, 37);
        partTextBox.Name = "partTextBox";
        partTextBox.Size = new Size(156, 31);
        partTextBox.TabIndex = 2;
        // 
        // donorDataGridView
        // 
        donorDataGridView.AllowUserToAddRows = false;
        donorDataGridView.ColumnHeadersHeight = 34;
        donorDataGridView.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3 });
        donorDataGridView.Location = new Point(12, 83);
        donorDataGridView.MultiSelect = false;
        donorDataGridView.Name = "donorDataGridView";
        donorDataGridView.ReadOnly = true;
        donorDataGridView.RowHeadersWidth = 62;
        donorDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        donorDataGridView.Size = new Size(513, 341);
        donorDataGridView.TabIndex = 3;
        // 
        // completeButton
        // 
        completeButton.Location = new Point(645, 368);
        completeButton.Name = "completeButton";
        completeButton.Size = new Size(146, 56);
        completeButton.TabIndex = 4;
        completeButton.Text = "Complete";
        completeButton.Click += CompleteButton_Click;
        // 
        // dataGridViewTextBoxColumn1
        // 
        dataGridViewTextBoxColumn1.HeaderText = "Name";
        dataGridViewTextBoxColumn1.MinimumWidth = 8;
        dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
        dataGridViewTextBoxColumn1.ReadOnly = true;
        dataGridViewTextBoxColumn1.Width = 150;
        // 
        // dataGridViewTextBoxColumn2
        // 
        dataGridViewTextBoxColumn2.HeaderText = "Telephone";
        dataGridViewTextBoxColumn2.MinimumWidth = 8;
        dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
        dataGridViewTextBoxColumn2.ReadOnly = true;
        dataGridViewTextBoxColumn2.Width = 150;
        // 
        // dataGridViewTextBoxColumn3
        // 
        dataGridViewTextBoxColumn3.HeaderText = "Address";
        dataGridViewTextBoxColumn3.MinimumWidth = 8;
        dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
        dataGridViewTextBoxColumn3.ReadOnly = true;
        dataGridViewTextBoxColumn3.Width = 150;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(547, 126);
        label1.Name = "label1";
        label1.Size = new Size(59, 25);
        label1.TabIndex = 5;
        label1.Text = "Name";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(547, 211);
        label2.Name = "label2";
        label2.Size = new Size(66, 25);
        label2.TabIndex = 6;
        label2.Text = "Adress";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(547, 169);
        label3.Name = "label3";
        label3.Size = new Size(92, 25);
        label3.TabIndex = 7;
        label3.Text = "Telephone";
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(547, 288);
        label4.Name = "label4";
        label4.Size = new Size(77, 25);
        label4.TabIndex = 8;
        label4.Text = "Amount";
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new Point(547, 250);
        label5.Name = "label5";
        label5.Size = new Size(49, 25);
        label5.TabIndex = 9;
        label5.Text = "Case";
        // 
        // comboBox1
        // 
        comboBox1.FormattingEnabled = true;
        comboBox1.Location = new Point(645, 245);
        comboBox1.Name = "comboBox1";
        comboBox1.Size = new Size(182, 33);
        comboBox1.TabIndex = 10;
        // 
        // textBox1
        // 
        textBox1.Location = new Point(645, 126);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(182, 31);
        textBox1.TabIndex = 11;
        // 
        // textBox2
        // 
        textBox2.Location = new Point(645, 169);
        textBox2.Name = "textBox2";
        textBox2.Size = new Size(182, 31);
        textBox2.TabIndex = 12;
        // 
        // textBox3
        // 
        textBox3.Location = new Point(645, 208);
        textBox3.Name = "textBox3";
        textBox3.Size = new Size(182, 31);
        textBox3.TabIndex = 13;
        // 
        // textBox4
        // 
        textBox4.Location = new Point(645, 288);
        textBox4.Name = "textBox4";
        textBox4.Size = new Size(182, 31);
        textBox4.TabIndex = 14;
        // 
        // DonationView
        // 
        ClientSize = new Size(856, 454);
        Controls.Add(textBox4);
        Controls.Add(textBox3);
        Controls.Add(textBox2);
        Controls.Add(textBox1);
        Controls.Add(comboBox1);
        Controls.Add(label5);
        Controls.Add(label4);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(titleLabel);
        Controls.Add(findButton);
        Controls.Add(partTextBox);
        Controls.Add(donorDataGridView);
        Controls.Add(completeButton);
        Name = "DonationView";
        ((ISupportInitialize)donorDataGridView).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    // Define controls
    private Label titleLabel;
    private Button findButton;
    private TextBox partTextBox;
    private DataGridView donorDataGridView;
    private TextBox nameTextBox;
    private TextBox telephoneTextBox;
    private TextBox addressTextBox;
    private ComboBox caseComboBox;
    private TextBox amountTextBox;
    private Button completeButton;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private Label label5;
    private ComboBox comboBox1;
    private TextBox textBox1;
    private TextBox textBox2;
    private TextBox textBox3;
    private TextBox textBox4;
}
