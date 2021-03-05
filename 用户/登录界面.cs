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
    public partial class 登录界面 : Form
    {
        public List<Client> list = null;
        public 登录界面()
        {
            InitializeComponent();
        }
        RestaurantManager restaurantManager = new RestaurantManager();

        ClientManager client = new ClientManager();
        private void button1_Click(object sender, EventArgs e)//用户登入界面  登入（按钮）
        {
            if (txtZH.Text.Trim() == "")
            {
                MessageBox.Show("请你输入账号后再登录");
                txtZH.Focus();
                return;
            }
            if (txtPwd.Text.Trim() == "")
            {
                MessageBox.Show("请你输入密码后再登录");
                txtPwd.Focus();
                return;
            }
            //调用业务层的登录方法
            List<Client> list = client.Login(txtZH.Text, txtPwd.Text);
            if (list.Count > 0)
            {
                Client avv = list[0];
                a();
                //记录账号密码
                User.user = txtZH.Text;
                User.pass = txtPwd.Text;
                User.khID = avv.Id.ToString();
            }
            else
            {
                MessageBox.Show("账号或密码错误", "登录提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void Label3_Click(object sender, EventArgs e)//用户登入界面 注册（按钮）
        {
            登入修改 drsg = new 登入修改();
            drsg.a = 1;
            drsg.Show();
            this.Hide();
        }

        private void 登录界面_Load(object sender, EventArgs e)////用户登入界面
        {
            if (list!= null&&list.Count==1)
            {
                if (MessageBox.Show("是否登录该账号", "登录提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    foreach (var item in list)
                    {
                        txtZH.Text = item.Number;
                        txtPwd.Text = item.Password;
                    }
                    MessageBox.Show("请您点击登录即可进入点餐", "登录提示", MessageBoxButtons.OK);
                }
            }
        }
        public void a()
        {
            用户首页 sy = new 用户首页();

            sy.Show();
            this.Hide();
        }

        private void linkLabel1_MouseClick(object sender, MouseEventArgs e)
        {
            登入修改 drsg = new 登入修改();
            drsg.Show();
        }
    }
}
