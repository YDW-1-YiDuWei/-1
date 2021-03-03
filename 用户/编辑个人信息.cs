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
    public partial class 编辑个人信息 : Form
    {
        public 编辑个人信息()
        {
            InitializeComponent();
        }

        ClientManager client = new ClientManager();
        private void Button1_Click(object sender, EventArgs e)
        {
            int count = client.CompileClientsMessage(UserName.Text,rbnan.Checked==true?"男":"女",UserPhone.Text,UserAdders.Text,User.khID);
            if (count > 0)
            {
                MessageBox.Show("信息提交成功");
            }
            else
            {
                MessageBox.Show("信息提交失败");
            }
        }
    }
}
