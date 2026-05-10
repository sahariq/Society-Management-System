using System.Windows.Forms;

namespace SocietiesManagementSystem
{
    public partial class Form1 : Form
    {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>

    public System.Windows.Forms.Label lblTitle;
    public System.Windows.Forms.Label lblUsername;
    public System.Windows.Forms.TextBox txtUsername;
    public System.Windows.Forms.Label lblPassword;
    public System.Windows.Forms.TextBox txtPassword;
    public System.Windows.Forms.Label lblRole;
    public System.Windows.Forms.ComboBox cmbRole;
    public System.Windows.Forms.CheckBox chkRememberMe;
    public System.Windows.Forms.Button btnLogin;
    public System.Windows.Forms.Button btnRegister;
    public System.Windows.Forms.LinkLabel linkForgotPassword;
    public System.Windows.Forms.Label lblError;

    private void InitializeComponent()
    {
        this.lblTitle = new System.Windows.Forms.Label();
        this.lblUsername = new System.Windows.Forms.Label();
        this.txtUsername = new System.Windows.Forms.TextBox();
        this.lblPassword = new System.Windows.Forms.Label();
        this.txtPassword = new System.Windows.Forms.TextBox();
        this.lblRole = new System.Windows.Forms.Label();
        this.cmbRole = new System.Windows.Forms.ComboBox();
        this.chkRememberMe = new System.Windows.Forms.CheckBox();
        this.btnLogin = new System.Windows.Forms.Button();
        this.btnRegister = new System.Windows.Forms.Button();
        this.linkForgotPassword = new System.Windows.Forms.LinkLabel();
        this.lblError = new System.Windows.Forms.Label();
        this.SuspendLayout();

        // lblTitle
        this.lblTitle.AutoSize = true;
        this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.lblTitle.Location = new System.Drawing.Point(270, 30);
        this.lblTitle.Name = "lblTitle";
        this.lblTitle.Size = new System.Drawing.Size(260, 32);
        this.lblTitle.Text = "Societies Management";

        // lblUsername
        this.lblUsername.AutoSize = true;
        this.lblUsername.Location = new System.Drawing.Point(200, 100);
        this.lblUsername.Name = "lblUsername";
        this.lblUsername.Size = new System.Drawing.Size(95, 15);
        this.lblUsername.Text = "Username/Email:";

        // txtUsername
        this.txtUsername.Location = new System.Drawing.Point(320, 97);
        this.txtUsername.Name = "txtUsername";
        this.txtUsername.Size = new System.Drawing.Size(220, 23);

        // lblPassword
        this.lblPassword.AutoSize = true;
        this.lblPassword.Location = new System.Drawing.Point(200, 140);
        this.lblPassword.Name = "lblPassword";
        this.lblPassword.Size = new System.Drawing.Size(60, 15);
        this.lblPassword.Text = "Password:";

        // txtPassword
        this.txtPassword.Location = new System.Drawing.Point(320, 137);
        this.txtPassword.Name = "txtPassword";
        this.txtPassword.Size = new System.Drawing.Size(220, 23);
        this.txtPassword.PasswordChar = '*';

        // lblRole
        this.lblRole.AutoSize = true;
        this.lblRole.Location = new System.Drawing.Point(200, 180);
        this.lblRole.Name = "lblRole";
        this.lblRole.Size = new System.Drawing.Size(34, 15);
        this.lblRole.Text = "Role:";

        // cmbRole
        this.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cmbRole.Location = new System.Drawing.Point(320, 177);
        this.cmbRole.Name = "cmbRole";
        this.cmbRole.Size = new System.Drawing.Size(220, 23);

        // chkRememberMe
        this.chkRememberMe.AutoSize = true;
        this.chkRememberMe.Location = new System.Drawing.Point(320, 210);
        this.chkRememberMe.Name = "chkRememberMe";
        this.chkRememberMe.Size = new System.Drawing.Size(102, 19);
        this.chkRememberMe.Text = "Remember Me";

        // btnLogin
        this.btnLogin.Location = new System.Drawing.Point(320, 250);
        this.btnLogin.Name = "btnLogin";
        this.btnLogin.Size = new System.Drawing.Size(100, 30);
        this.btnLogin.Text = "Login";
        this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

        // btnRegister
        this.btnRegister.Location = new System.Drawing.Point(440, 250);
        this.btnRegister.Name = "btnRegister";
        this.btnRegister.Size = new System.Drawing.Size(100, 30);
        this.btnRegister.Text = "Register";
        this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);

        // linkForgotPassword
        this.linkForgotPassword.AutoSize = true;
        this.linkForgotPassword.Location = new System.Drawing.Point(320, 290);
        this.linkForgotPassword.Name = "linkForgotPassword";
        this.linkForgotPassword.Size = new System.Drawing.Size(99, 15);
        this.linkForgotPassword.TabStop = true;
        this.linkForgotPassword.Text = "Forgot Password?";
        this.linkForgotPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkForgotPassword_LinkClicked);

        // lblError
        this.lblError.AutoSize = true;
        this.lblError.ForeColor = System.Drawing.Color.Red;
        this.lblError.Location = new System.Drawing.Point(320, 320);
        this.lblError.Name = "lblError";
        this.lblError.Size = new System.Drawing.Size(0, 15);

        // Form1
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 400);
        this.Controls.Add(this.lblTitle);
        this.Controls.Add(this.lblUsername);
        this.Controls.Add(this.txtUsername);
        this.Controls.Add(this.lblPassword);
        this.Controls.Add(this.txtPassword);
        this.Controls.Add(this.lblRole);
        this.Controls.Add(this.cmbRole);
        this.Controls.Add(this.chkRememberMe);
        this.Controls.Add(this.btnLogin);
        this.Controls.Add(this.btnRegister);
        this.Controls.Add(this.linkForgotPassword);
        this.Controls.Add(this.lblError);
        this.Name = "Form1";
        this.Text = "Login - Societies Management System";
        this.Load += new System.EventHandler(this.Form1_Load);
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion
    }
}
