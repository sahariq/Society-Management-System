using System;
using System.Windows.Forms;

namespace SocietiesManagementSystem
{
    public partial class Form1 : Form
    {
        private readonly AuthService authService = new AuthService();

        // Simple remember me (in-memory)
        private string rememberedUsername = "";
        private string rememberedRole = "";

        public Form1()
        {
            InitializeComponent();

            this.Load += Form1_Load;
            btnLogin.Click += btnLogin_Click;
            btnRegister.Click += btnRegister_Click;
            linkForgotPassword.LinkClicked += linkForgotPassword_LinkClicked;

            // Initialize controls
            cmbRole.Items.AddRange(new string[] { "student", "society_head", "admin" });
            cmbRole.SelectedIndex = 0;
            chkRememberMe.Checked = false;
            lblError.Text = "";
            lblError.ForeColor = System.Drawing.Color.Red;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(rememberedUsername))
            {
                txtUsername.Text = rememberedUsername;
                if (!string.IsNullOrEmpty(rememberedRole) && cmbRole.Items.Contains(rememberedRole))
                {
                    cmbRole.SelectedItem = rememberedRole;
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usernameOrEmail = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string role = cmbRole.SelectedItem?.ToString() ?? "";

            if (string.IsNullOrEmpty(usernameOrEmail) || string.IsNullOrEmpty(password))
            {
                lblError.Text = "Please enter username/email and password.";
                return;
            }

            bool success = authService.Login(usernameOrEmail, password, role);

            if (success)
            {
                // Remember credentials if checkbox is checked
                if (chkRememberMe.Checked)
                {
                    rememberedUsername = usernameOrEmail;
                    rememberedRole = role;
                }

                this.Hide(); // Hide login form

                // Open the correct dashboard
                if (role == "student")
                {
                    new StudentDashboard().Show();
                }
                else if (role == "society_head")
                {
                    new SocietyHeadDashboard().Show();
                }
                else if (role == "admin")
                {
                    new AdminDashboard().Show();
                }
            }
            else
            {
                lblError.Text = "Invalid username, password, or role.";
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            using (var regForm = new RegistrationForm())
            {
                regForm.ShowDialog();

                // Optional: Clear login fields after successful registration
                // txtUsername.Clear();
                // txtPassword.Clear();
            }
        }

        private void linkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Forgot Password feature is not implemented yet.\n\nPlease contact the administrator.", 
                          "Forgot Password", 
                          MessageBoxButtons.OK, 
                          MessageBoxIcon.Information);
        }

                // Public method to show login form again
        public void ShowLogin()
        {
            this.Show();
            txtPassword.Clear();
            lblError.Text = "";
        }
    }
}