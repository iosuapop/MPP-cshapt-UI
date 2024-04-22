using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Donations.domain;
using Donations.service;

namespace Donations
{
    public partial class DonationView : Form
    {
        Service service { get; set; }
        public DonationView(Service serv)
        {
            InitializeComponent();
            service = serv;
            PopulateTable("");
            donorDataGridView.CellClick += donorDataGridView_CellClick; // incearcaa sa l pui inainte
            LoadCases();
        }


        private void FindButton_Click(object sender, EventArgs e)
        {
            string part = partTextBox.Text;
            PopulateTable(part);
        }

        private void CompleteButton_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string telephone = textBox2.Text;
            string address = textBox3.Text;
            string selectedCase = comboBox1.SelectedItem as string;
            float amount = (float)Convert.ToDouble(textBox4.Text);


            Donor donor = new Donor(0, name, telephone, address);
            donor = service.AddDonor(donor);

            Charity charity = new Charity(0, selectedCase);
            charity = service.GetIdByCase(charity);

            Donation donation = new Donation(0, charity, donor, amount);

            service.AddDonation(donation);

            ClearFields();
            ReturnToStatistics();
        }

        private void PopulateTable(string part)
        {
            donorDataGridView.Rows.Clear();
            var donorsName = service.GetAllDonorsName(part);
        
            if (donorsName != null && donorsName.Count > 0)
            {
                dataGridViewTextBoxColumn1.HeaderText = "Name";
                dataGridViewTextBoxColumn2.HeaderText = "Telephone";
                dataGridViewTextBoxColumn2.HeaderText = "Adress";
            
                foreach (var donor in donorsName)
                {
                    donorDataGridView.Rows.Add(donor.Name, donor.Telephone, donor.Address);
                }
            }
            else
            {
                MessageBox.Show("No donors available.");
            }
        }

        private void ClearFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.SelectedIndex = -1;
            textBox4.Clear();
        }

        private void ReturnToStatistics()
        {
            this.Visible = false;
            (new StatisticsView(service)).ShowDialog();
            this.Visible = true;
            Close();
        }
        
        private void donorDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = donorDataGridView.Rows[e.RowIndex];
                //Console.WriteLine(row.Cells[0]);
                string name = (string)row.Cells["dataGridViewTextBoxColumn1"].Value.ToString();
                string telephone = (string)row.Cells["dataGridViewTextBoxColumn2"].Value.ToString();
                string address = (string)row.Cells["dataGridViewTextBoxColumn3"].Value.ToString();
                
                textBox1.Text = name;
                textBox2.Text = telephone;
                textBox3.Text = address;
            }
        }
        
        private void LoadCases()
        {
            try
            {
                List<string> cases = service.GetAllCase();
                
                if (cases.Count > 0)
                {
                    for(int i=0; i<cases.Count; i++)
                    {
                        comboBox1.Items.Add(cases[i]);
                    }
                }
                else
                {
                    MessageBox.Show("No cases found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading cases: " + ex.Message);
            }
        }



        private void titleLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
