using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BANK_MANAGEMENT_SYSTEM
{
    public partial class Account : Form
    {
        public Account()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
       
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=BankingDB;Integrated Security=True";

            

            private void AccountsForm_Load(object sender, EventArgs e)
            {
                LoadCustomers();
                LoadAccounts();
                cmbType.Items.AddRange(new string[] { "Savings", "Current" });
            }

            private void LoadCustomers()
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT CustomerID, Name FROM Customers", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbCustomer.DataSource = dt;
                    cmbCustomer.DisplayMember = "Name";
v
                }


            using System;
            using System.Data;
            using System.Data.SqlClient;
            using System.Windows.Forms;

namespace BankingSystem
    {
        public partial class AccountsForm : Form
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=BankingDB;Integrated Security=True";

            public AccountsForm()
            {
                InitializeComponent();
            }

            private void AccountsForm_Load(object sender, EventArgs e)
            {
                LoadCustomers();
                LoadAccounts();
                cmbType.Items.AddRange(new string[] { "Savings", "Current" });
            }

            private void LoadCustomers()
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT CustomerID, Name FROM Customers", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbCustomer.DataSource = dt;
                    cmbCustomer.DisplayMember = "Name";
                    cmbCustomer.ValueMember = "CustomerID";
                }
            }

            private void LoadAccounts()
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Accounts", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvAccounts.DataSource = dt;
                }
            }

            private void btnAdd_Click(object sender, EventArgs e)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Accounts (CustomerID, AccountNumber, AccountType, Balance) VALUES (@CustomerID, @AccountNumber, @AccountType, @Balance)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CustomerID", cmbCustomer.SelectedValue);
                    cmd.Parameters.AddWithValue("@AccountNumber", txtAccountNum.Text);
                    cmd.Parameters.AddWithValue("@AccountType", cmbType.Text);
                    cmd.Parameters.AddWithValue("@Balance", Convert.ToDecimal(txtBalance.Text));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Account added successfully.");
                    LoadAccounts();
                }
            }

            private void btnUpdate_Click(object sender, EventArgs e)
            {
                if (dgvAccounts.CurrentRow != null)
                {
                    int accountId = Convert.ToInt32(dgvAccounts.CurrentRow.Cells["AccountID"].Value);

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        string query = "UPDATE Accounts SET CustomerID=@CustomerID, AccountNumber=@AccountNumber, AccountType=@AccountType, Balance=@Balance WHERE AccountID=@AccountID";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@AccountID", accountId);
                        cmd.Parameters.AddWithValue("@CustomerID", cmbCustomer.SelectedValue);
                        cmd.Parameters.AddWithValue("@AccountNumber", txtAccountNum.Text);
                        cmd.Parameters.AddWithValue("@AccountType", cmbType.Text);
                        cmd.Parameters.AddWithValue("@Balance", Convert.ToDecimal(txtBalance.Text));

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Account updated successfully.");
                        LoadAccounts();
                    }
                }
            }

            private void btnDelete_Click(object sender, EventArgs e)
            {
                if (dgvAccounts.CurrentRow != null)
                {
                    int accountId = Convert.ToInt32(dgvAccounts.CurrentRow.Cells["AccountID"].Value);

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        string query = "DELETE FROM Accounts WHERE AccountID=@AccountID";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@AccountID", accountId);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Account deleted successfully.");
                        LoadAccounts();
                    }
                }
            }

            private void dgvAccounts_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvAccounts.Rows[e.RowIndex];
                    cmbCustomer.SelectedValue = row.Cells["CustomerID"].Value;
                    txtAccountNum.Text = row.Cells["AccountNumber"].Value.ToString();
                    cmbType.Text = row.Cells["AccountType"].Value.ToString();
                    txtBalance.Text = row.Cells["Balance"].Value.ToString();
                }
            }
        }
    }

}
}
