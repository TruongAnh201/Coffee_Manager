using QuanLyCafe.Business.Component;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace QuanLyCafe.Presentation
{
    public partial class fr_reg : Form
    {

        E_tb_User thucthi = new E_tb_User();
        public fr_reg()
        {
            InitializeComponent();
        }

        private void Clear()
        {
            txtuser.Text = "";
            txtpass.Text = "";
            txtpass2.Text = "";
        }

        public string encryption(String password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt;
            UTF8Encoding encode = new UTF8Encoding();
            // Mã hóa chuỗi mật khẩu đã cho thành dữ liệu được mã hóa
            encrypt = md5.ComputeHash(encode.GetBytes(password));
            StringBuilder encryptdata = new StringBuilder();
            // Tạo một chuỗi mới bằng cách sử dụng dữ liệu được mã hóa
            for (int i = 0; i < encrypt.Length; i++)
            {
                encryptdata.Append(encrypt[i].ToString("x2"));
            }
            return encryptdata.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = txtuser.Text;
            string pass = txtpass.Text;
            string pass2 = txtpass2.Text;
            string type = radioButton1.Checked ? "Staff" : "Admin";
            if (String.IsNullOrEmpty(user) || String.IsNullOrEmpty(pass) || String.IsNullOrEmpty(pass2))
            {
                MessageBox.Show("Không được để trống các trường", "Lỗi");
            }
            else
            {
                if (pass == pass2)
                {
                    if (thucthi.kiemtralogin(user))
                    {
                        string newpass = encryption(pass);
                        try
                        {
                            thucthi.taouser(user, newpass, type);
                            MessageBox.Show("Tạo thành công", "Thành công");
                            Clear();
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show("Tạo lỗi vui lòng thử lại", "Lỗi");
                            Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Đã tồn tại tài khoản như trên", "Lỗi");
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu không khớp", "Thử lại");
                }
            }
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtpass.PasswordChar = checkBox1.Checked ? '\0' : '*';
            txtpass2.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }
    }
}
