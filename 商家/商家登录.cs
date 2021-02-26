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
            List<Restaurant> list = restaurant.Longin(textBox1.Text, textBox2.Text);
            if (list.Count > 0)
            {
                MessageBox.Show("登录成功", "登录提示", MessageBoxButtons.OK);
                User.restaUser = list[0].RestaurantNumber;
                User.restaPass = list[0].RestaurantNumberPwd;
                User.restaKhID = list[0].id.ToString();
                商家首页 a = new 商家首页();
            }
            else
            {
                MessageBox.Show("登录失败", "登录提示", MessageBoxButtons.OK);
            }
        }


    }
}

