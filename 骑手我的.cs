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
    public partial class 骑手我的 : Form
    {
        public 骑手我的()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)//切换
        {
            骑手登入 qsdr = new 骑手登入();
            qsdr.Show();
        }
    }
}
