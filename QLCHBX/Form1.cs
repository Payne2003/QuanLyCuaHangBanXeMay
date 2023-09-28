using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCHBX
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Khởi tạo và cấu hình đổ bóng
            guna2ShadowForm1.SetShadowForm(this);
            guna2ShadowForm1.ShadowColor = Color.Gray; // Màu sắc của đổ bóng
            txtpassword.UseSystemPasswordChar = true;

        }

        private void linkdangky_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Signup signup = new Signup();
            signup.Show();
        }

        private void btlogin_Click(object sender, EventArgs e)
        {
                if (txtuser.Text.Trim() == string.Empty || txtpassword.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please fill out all field.", "Required field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string username = txtuser.Text.Trim();
                    string password = txtpassword.Text.Trim();

                    // Chuỗi kết nối
                    string connectionString = "Data Source=Payne;Initial Catalog=Motorcycle_shop_manager;Integrated Security=True";


                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Tạo câu truy vấn
                        string query = "SELECT COUNT(*) FROM TaiKhoan WHERE Username = @Username AND Password = @Password";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Username", username);
                            command.Parameters.AddWithValue("@Password", password);

                            int count = (int)command.ExecuteScalar();

                            if (count > 0)
                            {
                                FormDashboard db = new FormDashboard();
                                db.Show();
                            }
                            else
                            {
                                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
        }

        private void ptminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ptthoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?","Cảnh báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void lkquenmk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            FormForgotPassword formForgotPassword = new FormForgotPassword();
            formForgotPassword.ShowDialog();
        }
    }
}
