using System;
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
    public partial class 付钱成功 : Form
    {
        public 付钱成功()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//提交按钮
        {
            
            提交 tj = new 提交();
            tj.Show();
            this.Close();
        }

        private void radioButton4_Click(object sender, EventArgs e)
        {
           
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (btYX.BackColor.Name.Equals("Red"))
            {
                FangFa();
                return;
            }
            FangFa();
            btYX.BackColor = Color.Red;
        }
        public void FangFa() 
        {
            btYX.BackColor = Color.White;
            button3.BackColor = Color.White;
            btSan.BackColor = Color.White;
            btSr.BackColor = Color.White;
            btW.BackColor = Color.White;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FangFa();
            btYX.BackColor = Color.Red;
            button3.BackColor = Color.Red;
        }

        private void btSan_Click(object sender, EventArgs e)
        {
            FangFa();
            btYX.BackColor = Color.Red;
            button3.BackColor = Color.Red;
            btSan.BackColor = Color.Red;
        }

        private void btSr_Click(object sender, EventArgs e)
        {
            FangFa();
            btYX.BackColor = Color.Red;
            button3.BackColor = Color.Red;
            btSan.BackColor = Color.Red;
            btSr.BackColor = Color.Red;
        }

        private void btW_Click(object sender, EventArgs e)
        {
            FangFa();
            btYX.BackColor = Color.Red;
            button3.BackColor = Color.Red;
            btSan.BackColor = Color.Red;
            btSr.BackColor = Color.Red;
            btW.BackColor = Color.Red;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            付钱 fq = new 付钱();
            fq.Show();
            this.Close();
        }
    }
}
