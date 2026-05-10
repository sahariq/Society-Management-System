using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SocietiesManagementSystem
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();

            registerButton.Click += registerButton_Click;

            // Populate roles and departments
            cmbRole.Items.AddRange(new string[] { "student", "society_head" });
            cmbRole.SelectedIndex = 0;

            departmentComboBox.Items.AddRange(new string[] { "CS", "EE", "ME", "BBA", "SE", "AI" });
            semesterUpDown.Minimum = 1;
            semesterUpDown.Maximum = 8;
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            string fullName = fullNameTextBox.Text.Trim();
            string studentId = studentIdTextBox.Text.Trim();
            string email = emailTextBox.Text.Trim();
            string role = cmbRole.SelectedItem?.ToString() ?? "student";
            string password = passwordTextBox.Text;
            string confirmPassword = confirmPasswordTextBox.Text;

            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(studentId) || 
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill all required fields.", "Warning");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Error");
                return;
            }

            if (GetPasswordStrength(password) == "Weak")
            {
                MessageBox.Show("Password is too weak. Please use a stronger password.", "Weak Password");
                return;
            }

            try
            {
                string hashedPass = AuthService.HashPassword(password);
                
                DatabaseHelper.AddUser(studentId, hashedPass, fullName, email, role);

                MessageBox.Show($"Registration Successful as {role.ToUpper()}!\n\nYou can now login.", 
                               "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                new Form1().Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Registration failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Other methods (clear, back, password strength) remain the same...
        private void clearButton_Click(object sender, EventArgs e)
        {
            fullNameTextBox.Clear();
            studentIdTextBox.Clear();
            emailTextBox.Clear();
            departmentComboBox.SelectedIndex = -1;
            semesterUpDown.Value = 1;
            passwordTextBox.Clear();
            confirmPasswordTextBox.Clear();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            passwordStrengthLabel.Text = $"Strength: {GetPasswordStrength(passwordTextBox.Text)}";
        }

        private string GetPasswordStrength(string password)
        {
            if (password.Length < 6) return "Weak";
            if (Regex.IsMatch(password, @"[A-Z]") && Regex.IsMatch(password, @"[0-9]") && password.Length >= 8)
                return "Strong";
            return "Medium";
        }
    }
}