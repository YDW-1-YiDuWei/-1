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
        private void button1_Click(object sender, EventArgs e)//登录按钮
        {
            if (!LoninCheck())
            {
                return;
            }
            List<Restaurant> list = restaurant.Longin(textBox1.Text, textBox2.Text);
            if (list.Count > 0)
            {
                MessageBox.Show("登录成功", "登录提示", MessageBoxButtons.OK);
                User.restaUser = list[0].RestaurantNumber;
                User.restaPass = list[0].RestaurantNumberPwd;
                User.restaKhID = list[0].id.ToString();
                商家首页 a = new 商家首页();
                a.list = list;
                a.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("登录失败", "登录提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public bool LoninCheck()
        {
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("请您输入账号", "登录提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (textBox2.Text.Trim() == "")
            {
                MessageBox.Show("请您输入密码", "登录提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (textBox1.Text.Length < 5|| textBox1.Text.Length > 15)
            {
                MessageBox.Show("请您输入正确的账号""登录提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (textBox2.Text.Length<5)
            {
                MessageBox.Show("请您输入正确的密码""登录提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return true;
        }
    }
}

