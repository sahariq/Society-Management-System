namespace SocietiesManagementSystem
{
    partial class RegistrationForm
    {
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.lblTitle = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblStudentId = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblSemester = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblConfirmPassword = new System.Windows.Forms.Label();

            this.fullNameTextBox = new System.Windows.Forms.TextBox();
            this.studentIdTextBox = new System.Windows.Forms.TextBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.departmentComboBox = new System.Windows.Forms.ComboBox();
            this.semesterUpDown = new System.Windows.Forms.NumericUpDown();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.confirmPasswordTextBox = new System.Windows.Forms.TextBox();
            this.phoneMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.passwordStrengthLabel = new System.Windows.Forms.Label();

            this.registerButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.semesterUpDown)).BeginInit();
            this.SuspendLayout();

            // Title
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(40, 20);
            this.lblTitle.Size = new System.Drawing.Size(320, 40);
            this.lblTitle.Text = "Create New Account";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Controls layout (simplified but clean)
            int startY = 80;
            SetupControl(this.lblFullName, "Full Name:", 40, startY);
            SetupControl(this.fullNameTextBox, "", 180, startY); startY += 40;

            SetupControl(this.lblStudentId, "Student ID:", 40, startY);
            SetupControl(this.studentIdTextBox, "", 180, startY); startY += 40;

            SetupControl(this.lblEmail, "Email:", 40, startY);
            SetupControl(this.emailTextBox, "", 180, startY); startY += 40;

            SetupControl(this.lblRole, "Register As:", 40, startY);
            SetupControl(this.cmbRole, "", 180, startY); startY += 40;

            SetupControl(this.lblDepartment, "Department:", 40, startY);
            SetupControl(this.departmentComboBox, "", 180, startY); startY += 40;

            SetupControl(this.lblSemester, "Semester:", 40, startY);
            SetupControl(this.semesterUpDown, "", 180, startY); startY += 40;

            SetupControl(this.lblPassword, "Password:", 40, startY);
            SetupControl(this.passwordTextBox, "", 180, startY); startY += 40;

            SetupControl(this.lblConfirmPassword, "Confirm Password:", 40, startY);
            SetupControl(this.confirmPasswordTextBox, "", 180, startY); startY += 40;

            // Buttons
            this.registerButton.Location = new System.Drawing.Point(70, startY + 20);
            this.registerButton.Size = new System.Drawing.Size(110, 38);
            this.registerButton.Text = "Register";
            this.registerButton.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.registerButton.ForeColor = System.Drawing.Color.White;

            this.clearButton.Location = new System.Drawing.Point(200, startY + 20);
            this.clearButton.Size = new System.Drawing.Size(90, 38);
            this.clearButton.Text = "Clear";

            this.backButton.Location = new System.Drawing.Point(150, startY + 70);
            this.backButton.Size = new System.Drawing.Size(100, 35);
            this.backButton.Text = "Back";

            this.ClientSize = new System.Drawing.Size(420, 520);
            this.Text = "Registration - Societies Management System";
            this.StartPosition = FormStartPosition.CenterScreen;

            this.Controls.AddRange(new Control[] {
                lblTitle, lblFullName, fullNameTextBox, lblStudentId, studentIdTextBox,
                lblEmail, emailTextBox, lblRole, cmbRole, lblDepartment, departmentComboBox,
                lblSemester, semesterUpDown, lblPassword, passwordTextBox, lblConfirmPassword,
                confirmPasswordTextBox, registerButton, clearButton, backButton, passwordStrengthLabel
            });

            ((System.ComponentModel.ISupportInitialize)(this.semesterUpDown)).EndInit();
            this.ResumeLayout(false);
        }

        private void SetupControl(Control ctrl, string text, int x, int y)
        {
            ctrl.Location = new System.Drawing.Point(x, y);
            if (ctrl is Label lbl) lbl.Text = text;
            if (ctrl is TextBox tb) tb.Size = new System.Drawing.Size(200, 23);
            if (ctrl is ComboBox cb) cb.Size = new System.Drawing.Size(200, 23);
        }

        #endregion

        public System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.Label lblFullName;
        public System.Windows.Forms.Label lblStudentId;
        public System.Windows.Forms.Label lblEmail;
        public System.Windows.Forms.Label lblRole;
        public System.Windows.Forms.Label lblDepartment;
        public System.Windows.Forms.Label lblSemester;
        public System.Windows.Forms.Label lblPassword;
        public System.Windows.Forms.Label lblConfirmPassword;

        public System.Windows.Forms.TextBox fullNameTextBox;
        public System.Windows.Forms.TextBox studentIdTextBox;
        public System.Windows.Forms.TextBox emailTextBox;
        public System.Windows.Forms.ComboBox cmbRole;
        public System.Windows.Forms.ComboBox departmentComboBox;
        public System.Windows.Forms.NumericUpDown semesterUpDown;
        public System.Windows.Forms.TextBox passwordTextBox;
        public System.Windows.Forms.TextBox confirmPasswordTextBox;
        public System.Windows.Forms.MaskedTextBox phoneMaskedTextBox;
        public System.Windows.Forms.Label passwordStrengthLabel;

        public System.Windows.Forms.Button registerButton;
        public System.Windows.Forms.Button clearButton;
        public System.Windows.Forms.Button backButton;
    }
}