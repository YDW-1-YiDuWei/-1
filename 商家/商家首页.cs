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
    public partial class 商家首页 : Form
    {
        public 商家首页()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)//商家首页（按钮）
        {
            panel1.Visible = true;//商家首页显示（panel1）
            panel2.Visible = false;//商家的菜品查询（panel2）
            panel3.Visible = false;//商家的菜品增加/修改（panel3）
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)//商家我的（按钮）
        {
            panel1.Visible = false;//商家首页显示（panel1）
            panel2.Visible = false;//商家的菜品查询（panel2）
            panel3.Visible = false;//商家的菜品增加/修改（panel3）
        }

    }
}
