using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLyCafe.Business.Component;
using QuanLyCafe.Business.EntitiesClass;
using QuanLyCafe.DataAccess;
using System.IO;
using System.Drawing.Imaging;

namespace QuanLyCafe.Presentation
{
    public partial class fr_Sanpham : Form
    {
        public fr_Sanpham()
        {
            InitializeComponent();
        }
        E_tb_Sanpham thucthi = new E_tb_Sanpham();
        ConnectDB cn = new ConnectDB();
        EC_tb_Sanpham ck = new EC_tb_Sanpham();
        bool themmoi;
        int dong = 0;

        private byte[] hinhanh;
        public byte[] HINHANH
        {
            get
            {
                return hinhanh;
            }
            set
            {
                hinhanh = value;
            }
        }


        public void setnull()
        {
            txtma.Text = "";
            txtten.Text = "";
            txtdgb.Text = "0";
            txtdgn.Text = "0";
            txtsl.Text = "0";
            imghinhanh.InitialImage = null;
            txtdgn.Enabled = true;
            txtdgb.Enabled = true;
            txtsl.Enabled = true;
            lbimgpath.Text = "C:\\temp.jpg";
        }
        public void locktext()
        {
            txtma.Enabled = false;
            txtten.Enabled = false;

            btmoi.Enabled = true;
            btluu.Enabled = false;
            btsua.Enabled = true;
            btxoa.Enabled = true;
        }
        public void un_locktext()
        {
            txtma.Enabled = true;
            txtten.Enabled = true;

            btmoi.Enabled = false;
            btluu.Enabled = true;
            btsua.Enabled = false;
            btxoa.Enabled = false;
        }
        public void khoitaoluoi()
        {
            msds.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            msds.Columns[0].HeaderText = "Mã Sản Phẩm";
            msds.Columns[0].Frozen = true;
            msds.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            msds.Columns[0].Width = 200;

            msds.Columns[1].HeaderText = "Tên Sản Phẩm";
            msds.Columns[1].Width = 200;

            msds.Columns[2].HeaderText = "Loại";
            msds.Columns[2].Width = 200;

            msds.Columns[3].HeaderText = "Giá Nhập";
            msds.Columns[3].Width = 200;

            msds.Columns[4].HeaderText = "Giá Bán";
            msds.Columns[4].Width = 200;

            msds.Columns[5].HeaderText = "Số Lượng";
            msds.Columns[5].Width = 200;

            msds.Columns[6].HeaderText = "Công Dụng";
            msds.Columns[6].Width = 200;

            msds.Columns[7].HeaderText = "Ảnh";
            msds.Columns[7].Width = 200;


        }
        public void hienthi()
        {
            string sql = @"SELECT masp, tensp, tenloai, gianhap, giaban, soluong, tencongdung, hinhanh 
                        FROM tb_Sanpham
                        inner join tb_Congdung on tb_Congdung.macongdung = tb_Sanpham.macongdung
                        inner join tb_Loai on tb_Loai.maloai = tb_Sanpham.maloai";
            msds.DataSource = cn.taobang(sql);
            SqlConnection con = cn.getcon();
            con.Open();
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }
        private void btmoi_Click(object sender, EventArgs e)
        {
            themmoi = true;
            un_locktext();
            setnull();
            txtma.Enabled = true;
            txtma.Focus();
        }
        private void btluu_Click(object sender, EventArgs e)
        {
            if (txtma.Text != "")
            {
                if (cbloai.SelectedValue.ToString() != "")
                {
                    if (cbcd.SelectedValue.ToString() != "")
                    {
                            if (themmoi == true)
                            {
                                try
                                {
                                    var bmp = new Bitmap(QuanLyCafe.Properties.Resources.temp);
                                    byte[] bytes = (byte[])(new ImageConverter()).ConvertTo(bmp, typeof(byte[]));
                                    byte[] imageData = File.Exists(lbimgpath.Text) ? ReadFile(lbimgpath.Text) : bytes;
                                    ck.MASP = txtma.Text;
                                    ck.TENSP = txtten.Text;
                                    ck.MALOAI = cbloai.SelectedValue.ToString();
                                    ck.GIABAN = txtdgb.Text;
                                    ck.GIANHAP = txtdgn.Text;
                                    ck.SOLUONG = txtsl.Text;
                                    ck.MACONGDUNG = cbcd.SelectedValue.ToString();
                                    ck.HINHANH = imageData;

                                    thucthi.themoi(ck);
                                    locktext();
                                    hienthi();
                                    MessageBox.Show("Đã Lưu Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                                try
                                {
                                    byte[] bytes = (byte[])(new ImageConverter()).ConvertTo(imghinhanh.Image, typeof(byte[]));
                                    byte[] imageData = File.Exists(lbimgpath.Text) ? ReadFile(lbimgpath.Text) : bytes;                       
                                    ck.MASP = txtma.Text;
                                    ck.TENSP = txtten.Text;
                                    ck.MALOAI = cbloai.SelectedValue.ToString();
                                    ck.GIABAN = txtdgb.Text;
                                    ck.GIANHAP = txtdgn.Text;
                                    ck.SOLUONG = txtsl.Text;
                                    ck.MACONGDUNG = cbcd.SelectedValue.ToString();
                                    ck.HINHANH = imageData;

                                thucthi.sua(ck);
                                    MessageBox.Show("Đã Sửa Thành Công Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            txtma.Enabled = true;
                            locktext();
                            hienthi();
                    }
                    else
                    {
                        MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        cbcd.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                    cbloai.Focus();
                }
            }
            else
            {
                MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                txtma.Focus();
            }
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            themmoi = false;
            lbimgpath.Text = "D:\\anh\\images.jpg"; 
            un_locktext();
            txtma.Enabled = false;
            txtten.Focus();
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa dữ liệu này?", "Chú Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    ck.MASP = txtma.Text;

                    thucthi.xoa(ck);
                    MessageBox.Show("Đã Xóa Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    hienthi();
                    setnull();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi");
                }
            }
        }
        private void fr_Sanpham_Load(object sender, EventArgs e)
        {
            imghinhanh.SizeMode = PictureBoxSizeMode.StretchImage;
            try
            {
                //Get image data from gridview column.
                byte[] imageData = hinhanh;

                if (imageData != null)
                {
                    //Initialize image variable
                    Image newImage;
                    //Read image data into a memory stream
                    using (MemoryStream ms = new MemoryStream(imageData, 0, imageData.Length))
                    {
                        ms.Write(imageData, 0, imageData.Length);

                        //Set image variable value using memory stream.
                        newImage = Image.FromStream(ms, true);
                    }

                    //set picture
                    imghinhanh.Image = newImage;
                }
            }
            catch
            {

            }
            thucthi.loadmal(cbloai);
            thucthi.loadmacd(cbcd);
            locktext();
            hienthi();
            khoitaoluoi();
        }

        private void msds_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;
            if (dong != -1) { 
                txtma.Text = msds.Rows[dong].Cells[0].Value.ToString();
                txtten.Text = msds.Rows[dong].Cells[1].Value.ToString();
                cbloai.Text = msds.Rows[dong].Cells[2].Value.ToString();            
                txtdgn.Text = msds.Rows[dong].Cells[3].Value.ToString();
                txtdgb.Text = msds.Rows[dong].Cells[4].Value.ToString();
                txtsl.Text = msds.Rows[dong].Cells[5].Value.ToString();
                cbcd.Text = msds.Rows[dong].Cells[6].Value.ToString();               
                MemoryStream ms = new MemoryStream((byte[])msds.Rows[dong].Cells[7].Value);          
                imghinhanh.Image = Image.FromStream(ms);
                locktext();
            }
        }
        byte[] ReadFile(string sPath)
        {

            byte[] data = null;

            //sử dụng FileInfo để lấy kích thước file.
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;

            //Đọc file
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);

            //Sử dụng BinaryReader để đọc file vào mảng byte.
            BinaryReader br = new BinaryReader(fStream);
            data = br.ReadBytes((int)numBytes);
            return data;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();

                dlg.Filter = "Image File (*.jpg;*.jpeg;*.bmp;*.gif;*.png)|*.jpg;*.jpeg;*.bmp;*.gif;*.png";
                dlg.Title = "Chọn Hình";

                DialogResult dlgRes = dlg.ShowDialog();
                if (dlgRes != DialogResult.Cancel)
                {
                    //Gán hình vào Picture box
                    imghinhanh.ImageLocation = dlg.FileName;
                    imghinhanh.SizeMode = PictureBoxSizeMode.StretchImage;
                    //Gán đường dẫn ảnh vào lbimgpath
                    lbimgpath.Text = dlg.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btn_lmml_Click(object sender, EventArgs e)
        {

            thucthi.loadmal(cbloai);
        }
                
        private void btn_lmcd_Click(object sender, EventArgs e)
        {

            thucthi.loadmacd(cbcd);
        }

        private void btn_ref_Click(object sender, EventArgs e)
        {
            thucthi.loadmal(cbloai);
            thucthi.loadmacd(cbcd);
        }
    }
}
