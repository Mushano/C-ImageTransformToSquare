using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToSquareImage2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Image ima_;
        int pixelSize;
        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "请选择图片|*.GIF;*.BMP;*.JPG;*.PNG";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                string path = fd.FileName;
                Image ima = Image.FromFile(path);
                ima_ = ima;
                pictureBox1.Image = ima;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool canBeParsed = int.TryParse(textBox1.Text, out pixelSize);
            if (canBeParsed)
            {
                pixelSize = int.Parse(textBox1.Text);
                SaveFileDialog sf = new SaveFileDialog();
                sf.Filter = ".jpg|*.JPG";
                if (sf.ShowDialog() == DialogResult.OK)
                {
                    string path = sf.FileName;
                    Transform.Class3.MakeSquareImage(ima_, path, pixelSize);
                    if (path != "")
                    {
                        MessageBox.Show("保存成功");
                    }
                    else
                    {
                        MessageBox.Show("保存失败");
                    }
                }
            }
            else
            {
                MessageBox.Show("边长设置有误!");
            }
        }
    }
}
