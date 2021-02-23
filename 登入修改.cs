using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DianCanXiTongManager;
using DianCanXiTongBLL;

namespace 点餐系统
{
    public partial class 登入修改 : Form
    {
        ClientManager client = new ClientManager();

        public 登入修改()
        {
            InitializeComponent();
        }
        public bool Check() //判断输入的
        {
            if (txtZH.Text.Trim() == "")
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
            if (txtPwd.Text.Trim() != txtPwd2.Text.Trim())
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

        private void Button1_Click_1(object sender, EventArgs e)
        {
            if (txtPwd2.Text.Trim() != txtPwd.Text.Trim())
            {
                MessageBox.Show("密码不一致", "登录提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            List<Client> list = client.Login(txtZH.Text, txtPwd.Text);
            if (list.Count > 0)
            {
                MessageBox.Show("登录成功", "登录提示", MessageBoxButtons.OK);
                我的 wo = new 我的();
                wo.list = list;
                this.Close();
                wo.Show();
            }
            else
            {
                MessageBox.Show("登录失败", "登录提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
