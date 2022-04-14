using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLyCafe.DataAccess;
using System.Data.SqlClient;

namespace QuanLyCafe.Presentation
{
    public partial class fr_TK_SP : Form
    {
        public fr_TK_SP()
        {
            InitializeComponent();
        }
        ConnectDB cn = new ConnectDB();
        public void khoitaoluoi()
        {
            try
            {
                msds.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                msds.Columns[0].HeaderText = "Mã Sản Phẩm";
                msds.Columns[0].Frozen = true;
                msds.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                msds.Columns[0].Width = 200;

                msds.Columns[1].HeaderText = "Tên Sản Phẩm";
                msds.Columns[1].Width = 200;

                msds.Columns[2].HeaderText = "Mã Loại";
                msds.Columns[2].Width = 200;

                msds.Columns[3].HeaderText = "Giá Nhập";
                msds.Columns[3].Width = 200;

                msds.Columns[4].HeaderText = "Giá Bán";
                msds.Columns[4].Width = 200;

                msds.Columns[5].HeaderText = "số Lượng";
                msds.Columns[5].Width = 200;

                msds.Columns[6].HeaderText = "Công Dụng";
                msds.Columns[6].Width = 200;

                msds.Columns[7].HeaderText = "Ảnh";
                msds.Columns[7].Width = 200;
            }catch(Exception ex){
                Console.WriteLine(ex.Message);
            }
        }
        public void hienthi()
        {           
            try
            {
                string sql = @"SELECT masp, tensp, tenloai, gianhap, giaban, soluong, tencongdung, hinhanh 
                            FROM tb_Sanpham 
                            INNER JOIN tb_congdung ON tb_sanpham.macongdung=tb_congdung.macongdung 
                            INNER JOIN tb_loai ON tb_sanpham.maloai=tb_loai.maloai;";
                msds.DataSource = cn.taobang(sql);
                SqlConnection con = cn.getcon();
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void reload()
        {
            if (txtthongtin.Text.Length == 0)
            {
                hienthi();
            }
            else
            {
                if (op1.Checked)
                {
                    string sql = @"SELECT masp, tensp, tenloai, gianhap, giaban, soluong, tencongdung, hinhanh 
                                FROM tb_Sanpham 
                                INNER JOIN tb_congdung ON tb_sanpham.macongdung=tb_congdung.macongdung 
                                INNER JOIN tb_loai ON tb_sanpham.maloai=tb_loai.maloai 
                                WHERE tenloai like N'%" + txtthongtin.Text + "%'";
                    msds.DataSource = cn.taobang(sql);
                    SqlConnection con = cn.getcon();
                    con.Open();
                }
                if (op2.Checked)
                {
                    string sql = @"SELECT masp, tensp, tenloai, gianhap, giaban, soluong, tencongdung, hinhanh 
                                FROM tb_Sanpham 
                                INNER JOIN tb_congdung ON tb_sanpham.macongdung=tb_congdung.macongdung 
                                INNER JOIN tb_loai ON tb_sanpham.maloai=tb_loai.maloai 
                                WHERE gianhap= '" + txtthongtin.Text + "'";
                    msds.DataSource = cn.taobang(sql);
                    SqlConnection con = cn.getcon();
                    con.Open();
                }
                if (op3.Checked)
                {
                    string sql = @"SELECT masp, tensp, tenloai, gianhap, giaban, soluong, tencongdung, hinhanh 
                                FROM tb_Sanpham 
                                INNER JOIN tb_congdung ON tb_sanpham.macongdung=tb_congdung.macongdung 
                                INNER JOIN tb_loai ON tb_sanpham.maloai=tb_loai.maloai 
                                WHERE tencongdung like N'%" + txtthongtin.Text + "%'";
                    msds.DataSource = cn.taobang(sql);
                    SqlConnection con = cn.getcon();
                    con.Open();
                }
                if (op4.Checked)
                {
                    string sql = @"SELECT masp, tensp, tenloai, gianhap, giaban, soluong, tencongdung, hinhanh 
                                FROM tb_Sanpham 
                                INNER JOIN tb_congdung ON tb_sanpham.macongdung=tb_congdung.macongdung 
                                INNER JOIN tb_loai ON tb_sanpham.maloai=tb_loai.maloai 
                                where tensp  like N'%" + txtthongtin.Text + "%'";
                    msds.DataSource = cn.taobang(sql);
                    SqlConnection con = cn.getcon();
                    con.Open();
                }
            }
            khoitaoluoi();
        }

        private void txtthongtin_TextChanged(object sender, EventArgs e)
        {
            reload();
        }

        private void fr_TK_SP_Load(object sender, EventArgs e)
        {
            hienthi();
            khoitaoluoi();
        }

        private void op1_CheckedChanged(object sender, EventArgs e)
        {
            reload();
        }

        private void op2_CheckedChanged(object sender, EventArgs e)
        {
            reload();
        }

        private void op3_CheckedChanged(object sender, EventArgs e)
        {
            reload();
        }

        private void op4_CheckedChanged(object sender, EventArgs e)
        {
            reload();
        }
    }
}
