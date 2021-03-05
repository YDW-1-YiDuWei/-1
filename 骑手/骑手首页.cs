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
    public partial class 骑手首页 : Form
    {
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
    }
}
