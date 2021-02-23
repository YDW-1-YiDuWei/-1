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
    public partial class 登入修改 : Form
    {
        public 登入修改()
        {
            InitializeComponent();
        }
        public bool Check() //判断输入的
        {
            if (txtZH.Text.Trim()=="")
            {
                MessageBox.Show("请输入账号");
                txtZH.Focus();
                return false;
            }
            if (txtPwd.Text.Trim() == "")
            {
                MessageBox.Show("请输入新密码");
                txtPwd.Focus();
                return false;
            }
            if (txtPwd2.Text.Trim() == "")
            {
                MessageBox.Show("请输入请输入确认密码");
                txtPwd2.Focus();
                return false;
            }
            if (txtPwd.Text.Trim()!=txtPwd2.Text.Trim())
            {
                MessageBox.Show("新密码跟确认密码不正确");
                txtPwd2.Focus();
                return false;
            }
            return true;
        }
        private void button1_Click(object sender, EventArgs e)//确认按钮
        {
            if (Check())
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            我的 wd = new 我的();
            wd.Show();
            this.Close();
        }
    }
}
