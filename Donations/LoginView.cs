using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Donations.service;


namespace Donations
{
    public partial class LoginView : Form
    {
        Service service { get; set; }

        public LoginView(Service serv)
        {
            InitializeComponent();
            service = serv;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if(service.Login(userTextBox.Text, passTextBox.Text))
            {
                this.Visible = false;
                (new StatisticsView(service)).ShowDialog();
                this.Visible = true;
                Close();
            }
            else
            {
                MessageBox.Show("Username and password mismatch");
            }
        }
    }
}