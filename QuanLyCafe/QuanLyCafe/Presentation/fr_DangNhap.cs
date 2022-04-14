using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Data.SqlClient;
using QuanLyCafe.DataAccess;
using QuanLyCafe.Business.EntitiesClass;
using QuanLyCafe.Business.Component;
using System.Security.Cryptography;
using System.IO;
using MultiFaceRec;

namespace QuanLyCafe.Presentation
{
    public partial class fr_DangNhap : Form
    {
        public fr_DangNhap()
        {
            InitializeComponent();
        }
        ConnectDB cn = new ConnectDB();
        E_tb_User thucthi = new E_tb_User();
        EC_tb_User ck = new EC_tb_User();

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

        private void cmddn_Click(object sender, EventArgs e)
        {
            string user = txtuser.Text;
            string pass = encryption(txtpass.Text);
            try
            {
                ck.USERNAME = user;
                ck.PASSWORD = pass;
                if (!thucthi.kiemtrauser(user, pass))
                {
                    MessageBox.Show("Đăng Nhập Thành Công", "Chúc Mừng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fr_Main fr = new fr_Main();
                    fr.SetUser = user;
                    fr.SetPermission = thucthi.getType(user);
                   // 
                    fr.Show();
                    fr.Focus();
                   this.Dispose();
                }
                else
                {
                    MessageBox.Show("Tài khoản đăng nhập chưa đúng. Vui lòng kiểm tra lại.", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    txtuser.Text = "";
                    txtpass.Text = "";
                    txtuser.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdthoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void txtuser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                SendKeys.Send("{TAB}");
        }

        private void txtpass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                cmddn.Enabled = false;
                cmddn_Click(sender, e);
            }
        }

        private void fr_DangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void btn_detect_Click(object sender, EventArgs e)
        {
            try { 
                 FrmPrincipal frm = new FrmPrincipal();
                 frm.ReturnMode = "Login";
                 var result = frm.ShowDialog();
                 if (result == DialogResult.OK)
                 {
                    var user = frm.ReturnId;
                    if(user != "")
                    {
                        MessageBox.Show("Đối tượng là chủ tài khoản: " + user, "Nhận diện thành công");
                    }
                    if (!thucthi.kiemtralogin(user))
                    {
                        MessageBox.Show("Đăng Nhập Thành Công", "Chúc Mừng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        fr_Main fr = new fr_Main();
                        fr.SetUser = user;
                        fr.SetPermission = thucthi.getType(user);
                        this.Dispose();
                        fr.Show();
                    }
                    else
                    {
                        MessageBox.Show("Chưa tốn tại tài khoản tương ứng trong csdl. Vui lòng kiểm tra lại. Hoặc thử bằng đăng nhập bằng cách bình thường", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtuser.Text = "";
                        txtpass.Text = "";
                        txtuser.Focus();
                    }
                 }
                frm.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtpass.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

        private void fr_DangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
