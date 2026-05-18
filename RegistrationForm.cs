using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SocietiesManagementSystem
{
    public partial class RegistrationForm : Form
    {
        public string RegisteredUsername { get; private set; } = "";

        public RegistrationForm()
        {
            InitializeComponent();

            // Wire up events
            registerButton.Click += registerButton_Click;
            clearButton.Click += clearButton_Click;
            backButton.Click += backButton_Click;
            passwordTextBox.TextChanged += passwordTextBox_TextChanged;

            // Populate controls
            cmbRole.Items.Clear();
            cmbRole.Items.AddRange(new string[] { "student", "society_head" });
            cmbRole.SelectedIndex = 0;

            departmentComboBox.Items.Clear();
            departmentComboBox.Items.AddRange(new string[] { "CS", "EE", "ME", "BBA", "SE", "AI" });

            semesterUpDown.Minimum = 1;
            semesterUpDown.Maximum = 8;
            semesterUpDown.Value = 1;

            passwordStrengthLabel.Text = "Strength: ";
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            string fullName = fullNameTextBox.Text.Trim();
            string username = studentIdTextBox.Text.Trim();   // Using as Username
            string email = emailTextBox.Text.Trim();
            string role = cmbRole.SelectedItem?.ToString() ?? "student";
            string password = passwordTextBox.Text;
            string confirmPassword = confirmPasswordTextBox.Text;

            // Validation
            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill all required fields.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (GetPasswordStrength(password) == "Weak")
            {
                MessageBox.Show("Password is too weak.\n\nUse at least 8 characters with uppercase and numbers.", 
                    "Weak Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                AuthService authService = new AuthService();
                bool success = authService.Register(username, email, password, fullName, role);

                if (success)
                {
                    RegisteredUsername = username;

                    MessageBox.Show($"Registration Successful!\n\nYou are registered as: {role.ToUpper()}\n\nYou can now login with your credentials.", 
                                   "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Registration failed. Username or Email already exists.", 
                                   "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Registration failed: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            fullNameTextBox.Clear();
            studentIdTextBox.Clear();
            emailTextBox.Clear();
            passwordTextBox.Clear();
            confirmPasswordTextBox.Clear();
            departmentComboBox.SelectedIndex = -1;
            semesterUpDown.Value = 1;
            passwordStrengthLabel.Text = "Strength: ";
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            passwordStrengthLabel.Text = $"Strength: {GetPasswordStrength(passwordTextBox.Text)}";
        }

        private string GetPasswordStrength(string password)
        {
            if (string.IsNullOrEmpty(password)) return "Empty";

            if (password.Length < 6) return "Weak";
            if (password.Length >= 8 && 
                Regex.IsMatch(password, @"[A-Z]") && 
                Regex.IsMatch(password, @"[0-9]"))
                return "Strong";

            return "Medium";
        }
    }
}