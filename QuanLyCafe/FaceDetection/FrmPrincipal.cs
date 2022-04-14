using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.IO;

namespace MultiFaceRec
{
    public partial class FrmPrincipal : Form
    {
        // Khai báo các biến, vectors và haarcascades
        Image<Bgr, Byte> currentFrame;
        Capture grabber;
        HaarCascade face;
        MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);
        Image<Gray, byte> result, TrainedFace = null;
        Image<Gray, byte> gray = null;
        List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        List<string> labels= new List<string>();
        List<string> NamePersons = new List<string>();
        int ContTrain, NumLabels, t;
        string name, names = null;

        public string ReturnMode { get; set; }
        public string ReturnId { get; set; }
        public string ReturnPermission { get; set; }
        public string ReturnUserName { get; set; }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            if(ReturnMode == "Login")
            {
                groupBox1.Dispose();
                groupBox2.Dispose();
                this.Text = "Đăng nhập bằng khuôn mặt";                
                this.Width = 350;
                RunDetect();
            }
            else
            {
                btn_try.Dispose();
                if(ReturnPermission != "Admin")
                {
                    textBox1.Text = ReturnUserName;
                    textBox1.Enabled = false;
                }
            }
            button2.Enabled = false;
        }

        public FrmPrincipal()
        {
            InitializeComponent();
            // Tải haarcascades để nhận diện khuôn mặt
            face = new HaarCascade("haarcascade_frontalface_default.xml");
            try
            {
                // Tải các khuôn mặt và nhãn được đào tạo trước cho mỗi hình ảnh
                string Labelsinfo = File.ReadAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt");
                string[] Labels = Labelsinfo.Split('%');
                NumLabels = Convert.ToInt16(Labels[0]);
                ContTrain = NumLabels;
                string LoadFaces;
                for (int tf = 1; tf < NumLabels+1; tf++)
                {
                    LoadFaces = "face" + tf + ".bmp";
                    trainingImages.Add(new Image<Gray, byte>(Application.StartupPath + "/TrainedFaces/" + LoadFaces));
                    labels.Add(Labels[tf]);
                }            
            }
            catch(Exception e)
            {
                if(ReturnMode == "Login")
                {
                    MessageBox.Show("Chưa có dữ liệu vui lòng đăng nhập bằng cách thông thường");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không có gì trong cơ sở dữ liệu nhị phân, vui lòng thêm ít nhất một khuôn mặt", "Tải dữ liệu sẵn có", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btn_try_Click(object sender, EventArgs e)
        {
            RunDetect();
        }

        private void RunDetect()
        {
            try
            {
                // Khởi tạo thiết bị chụp ảnh (mở webcam)
                grabber = new Capture();
                grabber.QueryFrame();
                // Khởi tạo sự kiện FrameGraber
                Application.Idle += new EventHandler(FrameGrabber);
                button1.Enabled = false;
                btn_try.Enabled = false;
            }
            catch(Exception e)
            {
                MessageBox.Show("Xảy ra lỗi vui lòng thử lại sau");
                if (ReturnMode == "Login")
                {
                    btn_try.Enabled = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RunDetect();
            button2.Enabled = true;
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            try
            {
                // Đếm khuôn mặt được đào tạo
                ContTrain = ContTrain + 1;
                // Lấy hình ảnh khuôn mặt đen trắng từ webcam
                gray = grabber.QueryGrayFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                // Nhận dạng khuôn mặt
                MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
                face,
                1.2,
                10,
                Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                new Size(20, 20));
                // Hành động cho từng phần tử được phát hiện
                foreach (MCvAvgComp f in facesDetected[0])
                {
                    TrainedFace = currentFrame.Copy(f.rect).Convert<Gray, byte>();
                    break;
                }
                // Thay đổi kích thước hình ảnh phát hiện khuôn mặt để buộc so sánh cùng kích thước với
                // Kiểm tra hình ảnh với phương pháp loại nội suy khối
                TrainedFace = result.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                trainingImages.Add(TrainedFace);
                labels.Add(textBox1.Text);
                // Hiển thị khuôn mặt dưới dạng đen trắng
                imageBox1.Image = TrainedFace;
                // Viết số mặt được đánh dấu vào tệp tin
                File.WriteAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", trainingImages.ToArray().Length.ToString() + "%");
                // Viết nhãn của các khuôn mặt được đánh dấu vào tệp tin
                for (int i = 1; i < trainingImages.ToArray().Length + 1; i++)
                {
                    trainingImages.ToArray()[i - 1].Save(Application.StartupPath + "/TrainedFaces/face" + i + ".bmp");
                    File.AppendAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", labels.ToArray()[i - 1] + "%");
                }
                MessageBox.Show("Thêm thành công khuôn mặt của "+textBox1.Text, "Huấn luyện thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Bật tính năng nhận diện khuôn mặt trước tiên", "Huấn luyện thất bại", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        void FrameGrabber(object sender, EventArgs e)
        {
            try {
                label3.Text = "0";
                NamePersons.Add("");
                // Nhận thiết bị chụp hình dạng khung hiện tại
                currentFrame = grabber.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                // Chuyển đổi sang đen trắng
                gray = currentFrame.Convert<Gray, Byte>();
                // Nhận diện khuôn mặt
                MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
                      face,
                      1.2,
                      10,
                      Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                      new Size(20, 20));
                // Hành động cho từng phần tử được phát hiện
                foreach (MCvAvgComp f in facesDetected[0])
                {
                    t = t + 1;
                    result = currentFrame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                    // Vẽ khuôn mặt được phát hiện trong kênh thứ 0 (xám) với màu xanh lam
                    currentFrame.Draw(f.rect, new Bgr(Color.Red), 2);
                    if (trainingImages.ToArray().Length != 0)
                    {
                        // Thuật ngữ Tiêu chí nhận dạng khuôn mặt với số lượng hình ảnh được đào tạo như maxIteration
                        MCvTermCriteria termCrit = new MCvTermCriteria(ContTrain, 0.001);
                        // Eigen    
                        EigenObjectRecognizer recognizer = new EigenObjectRecognizer(
                           trainingImages.ToArray(),
                           labels.ToArray(),
                           3000,
                           ref termCrit);
                        name = recognizer.Recognize(result);
                        // Vẽ nhãn cho từng khuôn mặt được phát hiện và nhận dạng
                        currentFrame.Draw(name, ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.LightGreen));
                    }
                    NamePersons[t - 1] = name;
                    NamePersons.Add("");
                    // Đặt số lượng khuôn mặt được phát hiện trên hiện trường
                    label3.Text = facesDetected[0].Length.ToString();
                }
                t = 0;
                // Tên ghép nối của những người được công nhận
                for (int nnn = 0; nnn < facesDetected[0].Length; nnn++)
                {
                    names = names + NamePersons[nnn] + ", ";
                    // Trả luôn về cái tên đầu tiên khi ở chế độ login
                    if (ReturnMode == "Login")
                    {
                        if (facesDetected[0].Length == 1 && NamePersons[nnn] != null)
                        {
                            this.ReturnId = NamePersons[nnn];
                            this.DialogResult = DialogResult.OK;
                            this.Dispose();
                        }
                    }
                }
                // Hiển thị các khuôn mặt được xử lý và nhận dạng
                imageBoxFrameGrabber.Image = currentFrame;
                label4.Text = names;
                names = "";
                // Dọn dẹp list(vector) của names
                NamePersons.Clear();
            }
            catch
            {

            }            
        }    
    }
}