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

        private void toolStripLabel2_Click(object sender, EventArgs e)//商家首页（按钮）
        {
            panel1.Visible = true;//显示商家首页（Panel控键）
            panel3.Visible = false;//隐藏商家菜品添加（Panel控键）

        }
        private void toolStripLabel3_Click(object sender, EventArgs e)//商家我的（按钮）
        {
            panel1.Visible = false;//隐藏商家首页（Panel控键）
            panel3.Visible = false;//隐藏商家菜品添加（Panel控键）
        }

        private void button5_Click(object sender, EventArgs e)//商家已完成（按钮）
        {
            panel3.Visible = false;//隐藏商家菜品添加（Panel控键）
            panel2.Visible = false;//隐藏商家菜品添加（Panel控键）
        }

        private void button2_Click(object sender, EventArgs e)//商家菜品添加（按钮）
        {
            panel3.Visible = true;//隐藏商家菜品添加（Panel控键）
            panel2.Visible = true;//隐藏商家菜品添加（Panel控键）
        }

        private void button3_Click(object sender, EventArgs e)//商家菜品删除（按钮）
        {
            panel3.Visible = false;//隐藏商家菜品添加（Panel控键）
            panel2.Visible = false;//隐藏商家菜品添加（Panel控键）
        }

        private void button6_Click(object sender, EventArgs e)//商家菜品修改（按钮）
        {
            panel3.Visible = true;//隐藏商家菜品添加（Panel控键）
            panel2.Visible = true;//隐藏商家菜品添加（Panel控键）
        }

        private void button7_Click(object sender, EventArgs e)//商家客户打单（按钮）
        {
            panel3.Visible = false;//隐藏商家菜品添加（Panel控键）
            panel2.Visible = false;//隐藏商家菜品添加（Panel控键）
        }

        private void button4_Click(object sender, EventArgs e)//商家退单（按钮）
        {
            panel3.Visible = false;//隐藏商家菜品添加（Panel控键）
            panel2.Visible = false;//隐藏商家菜品添加（Panel控键）
        }

        private void button1_Click(object sender, EventArgs e)//商家接单（按钮）
        {
            panel3.Visible = false;//隐藏商家菜品添加（Panel控键）
            panel2.Visible = false;//隐藏商家菜品添加（Panel控键）
        }
    }
}
