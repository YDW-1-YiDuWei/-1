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
    public partial class 付钱 : Form
    {
        public 付钱()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            付钱成功 fqcg = new 付钱成功();
            fqcg.Show();
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            付钱成功 fqcg = new 付钱成功();
            fqcg.Show();
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            付钱成功 fqcg = new 付钱成功();
            fqcg.Show();
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            付钱成功 fqcg = new 付钱成功();
            fqcg.Show();
            MessageBox.Show("123");
            this.Close();
        }

        private void 付钱_Load(object sender, EventArgs e)
        {

        }
    }
}
