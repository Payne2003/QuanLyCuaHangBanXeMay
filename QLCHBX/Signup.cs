using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCHBX
{
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
            txtuser.GotFocus += TextBox_GotFocus;
            txtuser.LostFocus += TextBox_LostFocus;
            txtpassword.GotFocus += TextBox_GotFocus;
            txtpassword.LostFocus += TextBox_LostFocus;
            txtreconfirmpassword.GotFocus += TextBox_GotFocus;
            txtreconfirmpassword.LostFocus += TextBox_LostFocus;

            // Đặt màu in mờ mặc định cho các TextBox
            SetPlaceholderText(txtuser, "Username");
            SetPlaceholderText(txtpassword, "Password");
            SetPlaceholderText(txtreconfirmpassword, "Reconfirm password");
        }
        private void TextBox_GotFocus(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            // Khi TextBox nhận focus, xóa in mờ và đặt màu chữ mặc định
            if (textBox.ForeColor == Color.Gray)
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black;
            }
        }

        private void TextBox_LostFocus(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            // Khi TextBox mất focus và trống, đặt in mờ và màu chữ xám
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                SetPlaceholderText(textBox, textBox.Tag.ToString());
            }
        }

        private void SetPlaceholderText(TextBox textBox, string placeholderText)
        {
            textBox.Text = placeholderText;
            textBox.ForeColor = Color.Gray;
            textBox.Tag = placeholderText;
        }

        private void btlogin_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu người dùng đã nhập thông tin đăng nhập
            if (txtuser.Text == "Username" || txtpassword.Text == "Password")
            {
                MessageBox.Show("Vui lòng nhập tên người dùng và mật khẩu.");
            }
            else
            {
                // Xử lý đăng nhập ở đây
                // Ví dụ: Kiểm tra tên người dùng và mật khẩu và thực hiện đăng nhập
            }
        }

        private void btsignup_Click(object sender, EventArgs e)
        {

        }

        private void linkdangnhap_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }
    }
}
