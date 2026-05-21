using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SocietiesManagementSystem
{
    /// <summary>
    /// Modal dialog for creating a new user or editing an existing one.
    /// Pass userId = 0 (or use the parameterless constructor) for "new user" mode.
    /// </summary>
    public class UserEditDialog : Form
    {
        // ── Controls ──────────────────────────────────────────────────────────
        private Label lblTitle;
        private Label lblUsername, lblFullName, lblEmail, lblRole, lblStatus, lblPassword;
        private TextBox txtUsername, txtFullName, txtEmail, txtPassword;
        private ComboBox cmbRole, cmbStatus;
        private Button btnSave, btnCancel;
        private Panel pnlPassword;
        private ErrorProvider errorProvider;

        // ── State ─────────────────────────────────────────────────────────────
        private readonly int _userId;      // 0 = new user
        private readonly int _adminId;
        private bool _isNewUser => _userId == 0;

        // ── Public result ──────────────────────────────────────────────────────
        /// <summary>Filled after a successful save so the caller can inspect values.</summary>
        public string ResultUsername  { get; private set; }
        public string ResultFullName  { get; private set; }
        public string ResultEmail     { get; private set; }
        public string ResultRole      { get; private set; }
        public string ResultStatus    { get; private set; }

        // ─────────────────────────────────────────────────────────────────────
        //  Constructors
        // ─────────────────────────────────────────────────────────────────────

        /// <summary>Create-new-user mode.</summary>
        public UserEditDialog(int adminId)
            : this(adminId, 0) { }

        /// <summary>Edit-existing-user mode when userId > 0.</summary>
        public UserEditDialog(int adminId, int userId)
        {
            _adminId = adminId;
            _userId  = userId;
            InitializeComponent();
            if (!_isNewUser) LoadUser();
        }

        // ─────────────────────────────────────────────────────────────────────
        //  Designer-equivalent setup (code-only, no .Designer.cs needed)
        // ─────────────────────────────────────────────────────────────────────

        private void InitializeComponent()
        {
            errorProvider = new ErrorProvider { BlinkStyle = ErrorBlinkStyle.NeverBlink };

            // ── Form ──────────────────────────────────────────────────────────
            Text            = _isNewUser ? "Add New User" : "Edit User";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox     = false;
            MinimizeBox     = false;
            StartPosition   = FormStartPosition.CenterParent;
            ClientSize      = new Size(420, _isNewUser ? 480 : 420);
            Padding         = new Padding(20);
            Font            = new Font("Segoe UI", 9.5f);
            BackColor       = Color.White;

            // ── Title label ───────────────────────────────────────────────────
            lblTitle = new Label
            {
                Text      = _isNewUser ? "Add New User" : "Edit User",
                Font      = new Font("Segoe UI Semibold", 14f),
                ForeColor = Color.FromArgb(30, 80, 160),
                AutoSize  = true,
                Location  = new Point(20, 20)
            };

            // ── Username ──────────────────────────────────────────────────────
            lblUsername  = MakeLabel("Username *", 65);
            txtUsername  = MakeTextBox(90, _isNewUser ? 300 : 300);
            if (!_isNewUser)
            {
                txtUsername.ReadOnly  = true;
                txtUsername.BackColor = Color.FromArgb(240, 240, 240);
                txtUsername.ForeColor = Color.Gray;
                ToolTip tt = new ToolTip();
                tt.SetToolTip(txtUsername, "Username cannot be changed after creation.");
            }

            // ── Full Name ─────────────────────────────────────────────────────
            lblFullName  = MakeLabel("Full Name *", 130);
            txtFullName  = MakeTextBox(155, 300);

            // ── Email ─────────────────────────────────────────────────────────
            lblEmail     = MakeLabel("Email *", 195);
            txtEmail     = MakeTextBox(220, 300);

            // ── Role ──────────────────────────────────────────────────────────
            lblRole = MakeLabel("Role *", 260);
            cmbRole = new ComboBox
            {
                Location      = new Point(120, 258),
                Width         = 200,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbRole.Items.AddRange(new object[] { "student", "society_head", "admin" });
            cmbRole.SelectedIndex = 0;

            // ── Status ────────────────────────────────────────────────────────
            lblStatus = MakeLabel("Status *", 300);
            cmbStatus = new ComboBox
            {
                Location      = new Point(120, 298),
                Width         = 200,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbStatus.Items.AddRange(new object[] { "active", "suspended", "inactive" });
            cmbStatus.SelectedIndex = 0;

            // ── Password (new-user only) ───────────────────────────────────────
            pnlPassword = new Panel
            {
                Location = new Point(0, 340),
                Size     = new Size(420, 60),
                Visible  = _isNewUser
            };
            lblPassword = new Label
            {
                Text     = "Password *",
                AutoSize = true,
                Location = new Point(20, 8)
            };
            txtPassword = new TextBox
            {
                Location     = new Point(120, 5),
                Width        = 200,
                UseSystemPasswordChar = true
            };
            pnlPassword.Controls.AddRange(new Control[] { lblPassword, txtPassword });

            // ── Buttons ───────────────────────────────────────────────────────
            int btnY = _isNewUser ? 415 : 368;

            btnSave = new Button
            {
                Text      = "Save",
                Location  = new Point(220, btnY),
                Size      = new Size(80, 32),
                BackColor = Color.FromArgb(30, 80, 160),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font      = new Font("Segoe UI Semibold", 9.5f)
            };
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Click += BtnSave_Click;

            btnCancel = new Button
            {
                Text      = "Cancel",
                Location  = new Point(310, btnY),
                Size      = new Size(80, 32),
                BackColor = Color.FromArgb(240, 240, 240),
                FlatStyle = FlatStyle.Flat
            };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };

            // ── Add to form ───────────────────────────────────────────────────
            Controls.AddRange(new Control[]
            {
                lblTitle,
                lblUsername,  txtUsername,
                lblFullName,  txtFullName,
                lblEmail,     txtEmail,
                lblRole,      cmbRole,
                lblStatus,    cmbStatus,
                pnlPassword,
                btnSave, btnCancel
            });

            AcceptButton = btnSave;
            CancelButton = btnCancel;
        }

        // ─────────────────────────────────────────────────────────────────────
        //  Helper factories
        // ─────────────────────────────────────────────────────────────────────

        private Label MakeLabel(string text, int y) => new Label
        {
            Text     = text,
            AutoSize = true,
            Location = new Point(20, y + 3)
        };

        private TextBox MakeTextBox(int y, int width) => new TextBox
        {
            Location = new Point(120, y),
            Width    = width
        };

        // ─────────────────────────────────────────────────────────────────────
        //  Load existing user
        // ─────────────────────────────────────────────────────────────────────

        private void LoadUser()
        {
            // FIX CS0021: GetUserById returns a User object — access named properties,
            // not row["field"] indexing which only works on DataRow.
            User? user = DatabaseHelper.GetUserById(_userId);
            if (user == null)
            {
                MessageBox.Show("User not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            txtUsername.Text = user.Username;
            txtFullName.Text = user.FullName;
            txtEmail.Text    = user.Email;

            string role   = user.Role;
            string status = user.Status;

            int roleIdx   = cmbRole.Items.IndexOf(role);
            int statusIdx = cmbStatus.Items.IndexOf(status);
            cmbRole.SelectedIndex   = roleIdx   >= 0 ? roleIdx   : 0;
            cmbStatus.SelectedIndex = statusIdx >= 0 ? statusIdx : 0;
        }

        // ─────────────────────────────────────────────────────────────────────
        //  Validation
        // ─────────────────────────────────────────────────────────────────────

        private bool ValidateInputs()
        {
            bool valid = true;
            errorProvider.Clear();

            if (_isNewUser && string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                errorProvider.SetError(txtUsername, "Username is required.");
                valid = false;
            }
            else if (_isNewUser && txtUsername.Text.Trim().Length < 3)
            {
                errorProvider.SetError(txtUsername, "Username must be at least 3 characters.");
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                errorProvider.SetError(txtFullName, "Full name is required.");
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider.SetError(txtEmail, "Email is required.");
                valid = false;
            }
            else if (!IsValidEmail(txtEmail.Text.Trim()))
            {
                errorProvider.SetError(txtEmail, "Enter a valid email address.");
                valid = false;
            }

            if (_isNewUser && string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorProvider.SetError(txtPassword, "Password is required for new users.");
                valid = false;
            }
            else if (_isNewUser && txtPassword.Text.Length < 6)
            {
                errorProvider.SetError(txtPassword, "Password must be at least 6 characters.");
                valid = false;
            }

            return valid;
        }

        private static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                RegexOptions.IgnoreCase);
        }

        // ─────────────────────────────────────────────────────────────────────
        //  Save
        // ─────────────────────────────────────────────────────────────────────

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            btnSave.Enabled = false;
            btnSave.Text    = "Saving…";

            try
            {
                string username = txtUsername.Text.Trim();
                string fullName = txtFullName.Text.Trim();
                string email    = txtEmail.Text.Trim();
                string role     = cmbRole.SelectedItem?.ToString() ?? "student";
                string status   = cmbStatus.SelectedItem?.ToString() ?? "active";

                if (_isNewUser)
                {
                    // FIX CS0117 / CS8130: CreateUser now exists in DatabaseHelper
                    // with signature (username, fullName, email, role, password, adminId)
                    var (success, message, newId) = DatabaseHelper.CreateUser(
                        username, fullName, email, role, txtPassword.Text);

                    if (!success)
                    {
                        MessageBox.Show(message, "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // FIX CS0117: UpdateUser now exists in DatabaseHelper
                    // with signature (userId, fullName, email, role, status)
                    var result = DatabaseHelper.UpdateUser(_userId, fullName, email, role, status);
                    if (result.success)
                    {
                        MessageBox.Show("No changes were saved.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    MessageBox.Show("User updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Expose results to caller
                ResultUsername = username;
                ResultFullName = fullName;
                ResultEmail    = email;
                ResultRole     = role;
                ResultStatus   = status;

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSave.Enabled = true;
                btnSave.Text    = "Save";
            }
        }
    }
}