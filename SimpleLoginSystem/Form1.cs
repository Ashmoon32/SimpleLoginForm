using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SimpleLoginSystem
{
    public partial class Form1 : Form
    {
        // Connection string stays here for registration
        string connString = @"Server=.\SQLEXPRESS; Database=SimpleAuthDB; Integrated Security=True;";

        public Form1()
        {
            InitializeComponent();
        }

        // --- REGISTRATION LOGIC ONLY ---
        private void btnRegister_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Accounts (Username, Email, Password) VALUES (@user, @email, @pass)";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@user", txtRegUser.Text);
                    cmd.Parameters.AddWithValue("@email", txtRegEmail.Text);
                    cmd.Parameters.AddWithValue("@pass", txtRegPass.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Registration Successful!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error during registration: " + ex.Message);
                }
            }
        }

        // Link to go to Login Page
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e) { }

        // This is a placeholder to stop the designer from crashing
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Leave this empty
        }
    }


}