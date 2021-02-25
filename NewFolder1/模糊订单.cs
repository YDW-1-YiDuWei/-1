using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 点餐系统
{
    public partial class 模糊订单 : Form
    {
        public 模糊订单()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            首页 sy = new 首页();
            sy.Show();
            this.Close();
        }

        private void PictureBox2_Click_1(object sender, EventArgs e)
        {
            详细订单 xxdd = new 详细订单();
            xxdd.Show();
            this.Hide();
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
