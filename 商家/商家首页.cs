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
    public partial class 商家首页 : Form
    {
        CuisineInformationsManager cIM = new CuisineInformationsManager();
        public 商家首页()
        {
            InitializeComponent();
        }
        public bool Check() //判断是否为空
        {
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("请输入菜品名称");
                txtName.Focus();
                return false;
            }
            if (txtMoney.Text.Trim() == "")
            {
                MessageBox.Show("请输入菜品价格");
                txtMoney.Focus();
                return false;
            }
            if (cbLX.SelectedIndex == 0)
            {
                MessageBox.Show("请选择菜品类型");
                cbLX.Focus();
                return false;
            }
            if (pbImage.Image == null)
            {
                MessageBox.Show("请加入菜品图片");
                pbImage.Focus();
                return false;
            }
            return true;
        }
        private void toolStripLabel2_Click(object sender, EventArgs e)//商家首页（按钮）
        {
            label3.Text = DateTime.Now.ToShortTimeString().ToString();
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

        private void button9_Click(object sender, EventArgs e)//确定按钮
        {

        }

        private void 商家首页_Load(object sender, EventArgs e)
        {
           label16.Text = DateTime.Now.ToLongDateString().ToString();
           label17.Text = DateTime.Now.ToLongTimeString().ToString();
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            label16.Text = DateTime.Now.ToLongDateString().ToString();
            label17.Text = DateTime.Now.ToLongTimeString().ToString();
            label3.Text = DateTime.Now.ToShortTimeString().ToString();
        }
    }
}
