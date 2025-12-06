using System;
using System.Drawing;
using System.Windows.Forms;

namespace LoginApp
{
    public partial class Form1 : Form
    {
        // Khai báo control ở mức class để dùng lại
        private Label lblUserName;
        private TextBox txtUserName;
        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnLogin;

        public Form1()
        {
            InitializeComponent();
            BuildUi();
        }

        private void BuildUi()
        {
            // Thuộc tính form
            Text = "Đăng nhập";
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(420, 210);
            MaximizeBox = false;
            // B4 
            // Label: Tên đăng nhập
            lblUserName = new Label
            {
                Text = "Tên đăng nhập",
                Location = new Point(30, 30),
                AutoSize = true,
                Name = "lblUserName"
            };

            // TextBox: txtUserName
            txtUserName = new TextBox
            {
                Name = "txtUserName",
                Location = new Point(160, 25),
                Width = 210,
                TabIndex = 0
            };
            // B3: thêm Label Mật khẩu, textbox: txtPassword
            // Label: Mật khẩu
            lblPassword = new Label
            {
                Text = "Password",
                Location = new Point(30, 75),
                AutoSize = true,
                Name = "lblPassword"
            };

            // TextBox: txtPassword (ẩn ký tự)
            txtPassword = new TextBox
            {
                Name = "txtPassword", // B4: đổi nhãn sang tiếng Anh
                Location = new Point(160, 70),
                Width = 210,
                UseSystemPasswordChar = true,
                TabIndex = 1
            };

            // Button: Đăng nhập
            btnLogin = new Button
            {
                Text = "Đăng nhập",
                Name = "btnLogin",
                Location = new Point(160, 120),
                Size = new Size(120, 32),
                TabIndex = 2
            };
            btnLogin.Click += BtnLogin_Click;

            // Cho phép bấm Enter để login
            AcceptButton = btnLogin;

            // Thêm control lên form
            Controls.AddRange(new Control[]
            {
                lblUserName, txtUserName,
                lblPassword, txtPassword,
                btnLogin
            });
        }

        private void BtnLogin_Click(object? sender, EventArgs e)
        {
            var user = txtUserName.Text.Trim();
            var pass = txtPassword.Text;

            if (string.Equals(user, "admin", StringComparison.OrdinalIgnoreCase) && pass == "admin")
            {
                // Mở form thành công
                var success = new SuccessForm();
                success.StartPosition = FormStartPosition.CenterScreen;

                Hide();
                success.FormClosed += (_, __) =>
                {
                    // Khi đóng form thành công quay lại form login
                    txtPassword.Clear();
                    Show();
                    Activate();
                    txtUserName.Focus();
                };
                success.Show();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.SelectAll();
                txtPassword.Focus();
            }
        }
    }
}
