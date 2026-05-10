using System;
using System.Windows.Forms;

namespace SocietiesManagementSystem
{
    partial class EventsForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView eventsDataGridView;
        private DateTimePicker fromDatePicker;
        private DateTimePicker toDatePicker;
        private Button filterButton;
        private Button registerButton;

        private void InitializeComponent()
        {
            this.eventsDataGridView = new System.Windows.Forms.DataGridView();
            this.fromDatePicker = new System.Windows.Forms.DateTimePicker();
            this.toDatePicker = new System.Windows.Forms.DateTimePicker();
            this.filterButton = new System.Windows.Forms.Button();
            this.registerButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.eventsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // eventsDataGridView
            // 
            this.eventsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eventsDataGridView.Location = new System.Drawing.Point(20, 60);
            this.eventsDataGridView.Name = "eventsDataGridView";
            this.eventsDataGridView.Size = new System.Drawing.Size(760, 250);
            this.eventsDataGridView.TabIndex = 0;
            // 
            // fromDatePicker
            // 
            this.fromDatePicker.Location = new System.Drawing.Point(20, 20);
            this.fromDatePicker.Name = "fromDatePicker";
            this.fromDatePicker.Size = new System.Drawing.Size(200, 23);
            this.fromDatePicker.TabIndex = 1;
            // 
            // toDatePicker
            // 
            this.toDatePicker.Location = new System.Drawing.Point(240, 20);
            this.toDatePicker.Name = "toDatePicker";
            this.toDatePicker.Size = new System.Drawing.Size(200, 23);
            this.toDatePicker.TabIndex = 2;
            // 
            // filterButton
            // 
            this.filterButton.Location = new System.Drawing.Point(460, 20);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(100, 23);
            this.filterButton.TabIndex = 3;
            this.filterButton.Text = "Filter";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // registerButton
            // 
            this.registerButton.Location = new System.Drawing.Point(680, 20);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(100, 23);
            this.registerButton.TabIndex = 4;
            this.registerButton.Text = "Register";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // EventsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 350);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.filterButton);
            this.Controls.Add(this.toDatePicker);
            this.Controls.Add(this.fromDatePicker);
            this.Controls.Add(this.eventsDataGridView);
            this.Name = "EventsForm";
            this.Text = "Events";
            ((System.ComponentModel.ISupportInitialize)(this.eventsDataGridView)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
