using Donations;
using Donations.service;

namespace Donations;

public partial class StatisticsView : Form
{
    Service service { get; set; }

    public StatisticsView(Service serv)
    {
        InitializeComponent();
        service = serv;
        PopulateTable();
    }
    
    private void LogoutButton_Click(object sender, EventArgs e)
    {
        // Handle logout button click
        DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Log Out", MessageBoxButtons.YesNo);
        if (result == DialogResult.Yes)
        {
            // Navigate to the login screen
            Hide();
            LoginView loginView = new LoginView(service);
            loginView.ShowDialog();
            Close();
        }
    }

    private void DonationButton_Click(object sender, EventArgs e)
    {
        // Handle donation button click
        this.Visible = false;
        (new DonationView(service)).ShowDialog();
        this.Visible = true;
        Close();
    }
    
    private void PopulateTable()
    {
        var charityFunds = service.GetCharityFunds();
        
        if (charityFunds != null && charityFunds.Count > 0)
        {
            dataGridViewTextBoxColumn1.HeaderText = "Charity Name";
            dataGridViewTextBoxColumn2.HeaderText = "Funds";
            
            foreach (var charityFund in charityFunds)
            {
                dataGridView.Rows.Add(charityFund.Item1.Description, charityFund.Item2);
            }
        }
        else
        {
            MessageBox.Show("No charity funds available.");
        }
    }
}