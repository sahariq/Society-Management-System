namespace SocietiesManagementSystem
{
    partial class SocietiesBrowserForm
    {
        private System.ComponentModel.IContainer components = null;
        public System.Windows.Forms.DataGridView societiesDataGridView;
        private void InitializeComponent()
        {
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.societiesDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.societiesDataGridView)).BeginInit();
            this.SuspendLayout();
            // searchTextBox
            this.searchTextBox.Location = new System.Drawing.Point(20, 20);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(200, 23);
            this.searchTextBox.TabIndex = 0;
            // societiesDataGridView
            this.societiesDataGridView.Location = new System.Drawing.Point(20, 60);
            this.societiesDataGridView.Name = "societiesDataGridView";
            this.societiesDataGridView.Size = new System.Drawing.Size(360, 120);
            this.societiesDataGridView.TabIndex = 1;
            // SocietiesBrowserForm
            this.ClientSize = new System.Drawing.Size(400, 200);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.societiesDataGridView);
            this.Name = "SocietiesBrowserForm";
            this.Text = "Societies Browser";
            ((System.ComponentModel.ISupportInitialize)(this.societiesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        public System.Windows.Forms.TextBox searchTextBox;
    }
}
