﻿using System;
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
            List<Rider> list = rider.Longin(textBox1.Text, textBox2.Text);
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
                MessageBox.Show("登录失败", "登录提示");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void 骑手登入_Load(object sender, EventArgs e)
        {
            User.riderName = "";
            User.riderKhId = "";
            User.riderPwd = "";
            User.riderUser = "";
        }
    }
}
