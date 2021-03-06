﻿using System;
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
        public int a = 0;
      //  public 我的 wo = null;
        public 登入修改()
        {
            InitializeComponent();
        }
        private void Button1_Click_1(object sender, EventArgs e)//用户登入修改  确认（按钮）
        {
            if (txtZH.Text.Trim() == "")
            {
                MessageBox.Show("请输入账号");
                return;
            }
            if (txtPwd.Text.Trim() == "")
            {
                MessageBox.Show("请输入密码");
                return;
            }
            if (txtPwd2.Text.Trim() == "")
            {
                MessageBox.Show("请输入二次密码");
                return;
            }
            if (txtPwd2.Text.Trim() != txtPwd.Text.Trim())
            {
                MessageBox.Show("密码不一致", "登录提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (a == 0)
            {
                List<Client> list = client.Login(txtZH.Text, txtPwd.Text);
                if (list.Count > 0)
                {
                    MessageBox.Show("登录成功", "登录提示", MessageBoxButtons.OK);

                    foreach (var item in list)
                    {
                        User.khID = item.Id.ToString();
                        User.user = item.Number;
                        User.pass = item.Password;
                    }
                    我的 wo = new 我的();
                    wo.list = list;
                    this.Close();
                    wo.Show();
                }
                else
                {
                    MessageBox.Show("账号或密码错误", "登录提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (a == 1)
            {
                List<Client> list = client.AddClients(txtZH.Text, txtPwd.Text);
                if (list.Count > 0)
                {
                    MessageBox.Show("注册成功", "注册提示", MessageBoxButtons.OK);
                    登录界面 dljm = new 登录界面();
                    dljm.list = list;
                    dljm.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("注册失败", "注册提示", MessageBoxButtons.OK);
                }
            }
            else
            {
                List<Client> list = client.Login(User.user, User.pass);
                int i = 0;
                foreach (var item in list)
                {
                    i = item.Id;
                }

                List<Client> lists = client.Alter(txtZH.Text, txtPwd.Text, i);
                if (lists.Count > 0)
                {
                    MessageBox.Show("修改成功", "修改提示", MessageBoxButtons.OK);
                    User.user = txtZH.Text;
                    User.pass = txtPwd.Text;
                    我的 wo = new 我的();
                    wo.list = list;
                    this.Close();
                    wo.Show();
                }
                else
                {
                    MessageBox.Show("修改失败", "修改提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            a = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (a == 1)
            {
                List<Client> list = client.Login(User.user, User.pass);
                登录界面 wd = new 登录界面();
              
                    wd.list = list;
                

                wd.Show();
                this.Close();
            }
            else
            {
                ClientManager clent = new ClientManager();
                我的 wo = new 我的();
                wo.list = clent.Login(User.user, User.pass);
                wo.Show();
                this.Close();
            }
            a = 0;
        }
        private void 登入修改_Load(object sender, EventArgs e)//加载事件
        {
            txtZH.ReadOnly = false;
            if (a == 2)
            {
                txtZH.ReadOnly = true;
                txtZH.Text = User.user;
                txtPwd.Text = User.pass;
            }
        }
        private void btncancel_Click(object sender, EventArgs e)//用户登入修改  取消（按钮）
        {

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
                MessageBox.Show("请输入确认密码");
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
    }
}
