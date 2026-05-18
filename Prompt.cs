using System.Windows.Forms;
using System.Drawing;

namespace SocietiesManagementSystem
{
    public static class Prompt
    {
        public static string ShowDialog(string text, string caption, string defaultValue = "")
        {
            Form prompt = new Form()
            {
                Width = 420,
                Height = 180,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label textLabel = new Label()
            {
                Left = 20,
                Top = 20,
                Text = text,
                Width = 360,
                Height = 25
            };

            TextBox inputBox = new TextBox()
            {
                Left = 20,
                Top = 55,
                Width = 360,
                Text = defaultValue,
                Font = new Font("Segoe UI", 10)
            };

            Button confirmation = new Button()
            {
                Text = "OK",
                Left = 200,
                Width = 90,
                Top = 100,
                DialogResult = DialogResult.OK
            };

            Button cancel = new Button()
            {
                Text = "Cancel",
                Left = 295,
                Width = 90,
                Top = 100,
                DialogResult = DialogResult.Cancel
            };

            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(inputBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancel);

            prompt.AcceptButton = confirmation;
            prompt.CancelButton = cancel;

            return prompt.ShowDialog() == DialogResult.OK ? inputBox.Text.Trim() : string.Empty;
        }
    }
}