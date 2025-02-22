using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Enrollment_System
{
    public partial class FormLogin : Form
    {
        private string connectionString = "server=localhost;database=PDM_Enrollment_DB;user=root;password=;";

        public FormLogin()
        {
            InitializeComponent();
        }

        private void ChkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            TxtPass.PasswordChar = ChkShowPass.Checked ? '\0' : '*';
        }

        private void Btn_Login_Click(object sender, EventArgs e)
        {
            string email = TxtEmail.Text.Trim();
            string password = TxtPass.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter Email and Password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT * FROM Users WHERE email = @Email AND password_hash = SHA2(@Password, 256)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                this.Hide();
                                FormHome home = new FormHome();
                                home.Show();
                            }
                            else
                            {
                                MessageBox.Show("Invalid Email or Password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnReg_Click(object sender, EventArgs e)
        {
            new FormRegister().Show();
            this.Hide();
        }
    }
}
