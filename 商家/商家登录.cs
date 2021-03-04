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
    public partial class 商家登录 : Form
    {
        public 商家登录()
        {
            InitializeComponent();
        }

        private void 商家登录_Load(object sender, EventArgs e)//显示窗体的时候
        {

        }

        RestaurantManager restaurant = new RestaurantManager();

        public bool LoninCheck()//商家登录判断
        {
          /*  if (txtNum.Text.Trim() == "")
            {
                MessageBox.Show("请您输入账号", "登录提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (txtPwd.Text.Trim() == "")
            {
                MessageBox.Show("请您输入密码", "登录提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
           /* else if (txtNum.Text.Length < 5 || txtNum.Text.Length > 15)
            {
                MessageBox.Show("请您输入正确的账号", "登录提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (txtPwd.Text.Length < 5 || txtPwd.Text.Length > 15)
            {
                MessageBox.Show("请您输入正确的密码", "登录提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }*/
            return true;
        }

        private void btnLogin_Click(object sender, EventArgs e)//商家登录按钮
        {
            if (!LoninCheck())
            {
                return;
            }
            List<Restaurant> list = restaurant.Longin(txtNum.Text, txtPwd.Text);
            if (list.Count > 0)
            {
                MessageBox.Show("登录成功", "登录提示", MessageBoxButtons.OK);
                User.restaUser = list[0].RestaurantNumber;
                User.restaPass = list[0].RestaurantNumberPwd;
                User.restaKhID = list[0].id.ToString();
                User.path = list[0].RestaurantImage;
                商家首页2 a = new 商家首页2();
                a.list = list;
                a.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("账号或密码错误", "登录提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnquit_Click(object sender, EventArgs e)//商家登录   退出（按钮）
        {
            if (MessageBox.Show("是否退出", "退出提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void lblZC_Click(object sender, EventArgs e)//商家登录界面  注册（按钮）
        {
            商家登入修改注册 sjdrxgzc = new 商家登入修改注册();
            sjdrxgzc.Show();
        }

    }
}

