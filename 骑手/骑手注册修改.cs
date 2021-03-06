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
            txtnumber.ReadOnly = false;
            if (i == 1)
            {
                txtnumber.ReadOnly = true;
                List<Rider> list = rider.Longin(User.riderUser, User.riderPwd);

                txtname.Text = list[0].RiderName;
                txtnumber.Text = list[0].RiderNumber;
                txtpwd.Text = list[0].RiderNumberPwd;
                txtrepwd.Text = list[0].RiderNumberPwd;
                txtphone.Text = list[0].RiderPhone;
            }
        }

        private void Button1_Click(object sender, EventArgs e)//确认按钮
        {
            if (txtname.Text.Trim() == "")
            {
                MessageBox.Show("请输入姓名");
                return;
            }
            if (txtnumber.Text.Trim() == "")
            {
                MessageBox.Show("请输入帐号");
            }
            if (txtpwd.Text.Trim() == "")
            {
                MessageBox.Show("请输入密码");
                return;
            }
            if (txtrepwd.Text.Trim() == "")
            {
                MessageBox.Show("请输入二次密码");
                return;
            }
            if (txtphone.Text.Trim() == "")
            {
                MessageBox.Show("请输入电话号码");
                return;
            }
            if (txtrepwd.Text.Trim() != txtpwd.Text.Trim())
            {
                MessageBox.Show("密码不一致", "登录提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (i == 1)
            {
                List<Rider> list = rider.AddAlter(txtname.Text, txtnumber.Text, txtpwd.Text, txtphone.Text, i, int.Parse(User.riderKhId));
                if (list.Count == 1)
                {
                    User.riderPwd = list[0].RiderNumberPwd;
                    MessageBox.Show("修改成功");

                }
                else
                {
                    MessageBox.Show("修改失败");
                    this.Close();
                }

            }
            else
            {
                List<Rider> list = rider.AddAlter(txtname.Text, txtnumber.Text, txtpwd.Text, txtphone.Text);
                if (list.Count == 1)
                {
                    MessageBox.Show("注册成功");
                }
                else
                {
                    MessageBox.Show("注册失败");
                }
            }
            i = 0;
        }
    }
}
