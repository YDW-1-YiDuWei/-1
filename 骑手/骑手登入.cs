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
    public partial class 骑手登入 : Form
    {
        public 骑手登入()
        {
            InitializeComponent();
        }
        RiderManager rider = new RiderManager();
        private void label3_Click(object sender, EventArgs e)
        {
            骑手注册修改 qszcxg = new 骑手注册修改();
            qszcxg.Show();
        }

        private void Button1_Click(object sender, EventArgs e)//确定按钮
        {
            List<Rider> list = rider.Longin(txtnum.Text, txtpwd.Text);
            if (txtnum.Text.Trim() == "")
            {
                MessageBox.Show("请输入帐号");
                return;
            }
            if (txtpwd.Text.Trim() == "")
            {
                MessageBox.Show("请输入密码");
                return;
            }
            if (list.Count == 1)
            {
                User.riderUser = list[0].RiderNumber;
                User.riderPwd = list[0].RiderNumberPwd;
                User.restaId = list[0].RiderId.ToString();
                User.riderName = list[0].RiderName.ToString();
                MessageBox.Show("登录成功", "登录提示");
                //登录成功显示骑手首页
                骑手首页 frm = new 骑手首页();
                frm.Get = this;
                frm.list = list;
                frm.Show();
                this.Hide();//隐藏用户
            }
            else
            {
                MessageBox.Show("帐号或密码错误", "登录提示");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
