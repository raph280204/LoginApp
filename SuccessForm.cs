using System.Drawing;
using System.Windows.Forms;

namespace LoginApp
{
    public class SuccessForm : Form
    {
        public SuccessForm()
        {
            Text = "Thành công";
            ClientSize = new Size(360, 140);
            var lbl = new Label
            {
                Text = "Đăng nhập thành công 🎉",
                AutoSize = true,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(60, 50)
            };
            Controls.Add(lbl);
        }
    }
}
