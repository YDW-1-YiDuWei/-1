﻿using System;
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
    public partial class 商家登入修改注册 : Form
    {
        public 商家登入修改注册()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            商家登录 sjdr = new 商家登录();
            sjdr.Show();
            this.Close();
           
        }
    }
}
