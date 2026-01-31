using System;
using System.Data.SqlClient; // Added this to talk to DB
using System.Windows.Forms;

namespace SimpleLoginSystem
{
    public partial class LoginForm : Form
    {
        // We need the connection string here too!
        string connString = @"Server=.\SQLEXPRESS; Database=SimpleAuthDB; Integrated Security=True;";

        public LoginForm()
        {
            InitializeComponent();
        }

        // --- LOGIN LOGIC MOVED HERE ---
        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Accounts WHERE Username=@user AND Password=@pass";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@user", txtLoginUser.Text);
                    cmd.Parameters.AddWithValue("@pass", txtLoginPass.Text);

                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Login Success! Welcome to the Travel Agency.");
                        // Later, we will open the Dashboard here
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error during login: " + ex.Message);
                }
            }
        }

        // Link to go back to Registration Page
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 register = new Form1();
            register.Show();
            this.Hide();
        }
    }
}