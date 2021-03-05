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
    public partial class 骑手注册修改 : Form
    {
        public int i = 0;
        public 骑手注册修改()
        {
            InitializeComponent();
        }

        RiderManager rider = new RiderManager();
        private void 骑手注册修改_Load(object sender, EventArgs e)//显示窗体的时候
        {
            textBox2.ReadOnly = false;
            if (i == 1)
            {
                textBox2.ReadOnly = true;
                List<Rider> list = rider.Longin(User.riderUser, User.riderPwd);

                textBox1.Text = list[0].RiderName;
                textBox2.Text = list[0].RiderNumber;
                textBox3.Text = list[0].RiderNumberPwd;
                textBox4.Text = list[0].RiderNumberPwd;
                textBox5.Text = list[0].RiderPhone;
            }
        }

        private void Button1_Click(object sender, EventArgs e)//确认按钮
        {
            if (i == 1)
            {
                List<Rider> list = rider.AddAlter(textBox1.Text, textBox2.Text, textBox3.Text, textBox5.Text, i, int.Parse(User.riderKhId));
                if (list.Count == 1)
                {
                    User.riderPwd = list[0].RiderNumberPwd;
                    MessageBox.Show("修改成功");
                }
                else
                {
                    MessageBox.Show("修改失败");
                }

            }
            else
            {
                List<Rider> list = rider.AddAlter(textBox1.Text, textBox2.Text, textBox3.Text, textBox5.Text);
                if (list.Count == 1)
                {
                    MessageBox.Show("注册成功");
                }
                else
                {
                    MessageBox.Show("注册失败");
                }
            }
        }
    }
}
