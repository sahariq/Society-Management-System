using System;
using System.Windows.Forms;

namespace SocietiesManagementSystem
{
    public partial class Form1 : Form
    {
        private readonly AuthService _authService = new AuthService();

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Populate Role ComboBox
            cmbRole.Items.Clear();
            cmbRole.Items.Add("student");
            cmbRole.Items.Add("society_head");
            cmbRole.Items.Add("admin");
            cmbRole.SelectedIndex = 0;   // Default to Student

            lblError.Text = "";
            txtPassword.PasswordChar = '●';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usernameOrEmail = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string role = cmbRole.SelectedItem?.ToString() ?? "student";

            if (string.IsNullOrEmpty(usernameOrEmail) || string.IsNullOrEmpty(password))
            {
                lblError.Text = "Please enter username/email and password.";
                return;
            }

            if (_authService.Login(usernameOrEmail, password, role))
            {
                this.Hide();

                Form dashboard = SessionManagement.CurrentRole switch
                {
                    "student" => new StudentDashboard(),
                    "society_head" => new SocietyHeadDashboard(),
                    "admin" => new AdminDashboard(),
                    _ => new StudentDashboard()
                };

                dashboard.Show();
                dashboard.FormClosed += (s, args) => this.Show();
            }
            else
            {
                lblError.Text = "Invalid credentials or role mismatch.";
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            using (var regForm = new RegistrationForm())
            {
                regForm.ShowDialog();
            }
        }

        private void linkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Please contact the administrator for password recovery.", 
                "Forgot Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowLogin()
        {
            this.Show();
            txtPassword.Clear();
            lblError.Text = "";
        }
    }
}