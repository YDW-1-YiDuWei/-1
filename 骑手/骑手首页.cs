using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DianCanXiTongBLL;
using DianCanXiTongManager;

namespace 点餐系统
{
    public partial class 骑手首页 : Form
    {
        public List<Rider> list = null;
        public 骑手首页()
        {
            InitializeComponent();
        }
        private void button4_Click(object sender, EventArgs e)//骑手首页 接单（按钮）
        {
            panel3.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)//骑手首页 已接单（按钮）
        {
            panel4.Visible = true;
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)//骑手首页 我的（按键）
        {
            panel2.Visible = true;
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)//骑手首页 首页（按键）
        {
            panel1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)//骑手首页 切换（按钮）
        {
            骑手登入 qsdr = new 骑手登入();
            qsdr.Show();
        }

        private void button3_Click(object sender, EventArgs e)//骑手首页 修改（按钮）
        {
            骑手注册修改 qsdrxg = new 骑手注册修改();
            qsdrxg.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确认退出登录", "退出提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                button3.Enabled = false;
                label2.Text = "";
                label4.Text = "";
            }
        }

        private void 骑手首页_Load(object sender, EventArgs e)
        {
            button3.Enabled = true;
            if (list.Count == 1)
            {
                label2.Text = list[0].RiderName;
                label4.Text = list[0].RiderNumber;
            }
        }
    }
}
