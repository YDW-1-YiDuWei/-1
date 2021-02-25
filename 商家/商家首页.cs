using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 点餐系统.商家
{
    public partial class 商家首页 : Form
    {
        public 商家首页()
        {
            InitializeComponent();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)//商家首页按钮
        {
            panel1.Visible = true;//显示首页
        }
    }
}
