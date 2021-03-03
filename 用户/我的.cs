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
    public partial class 我的 : Form
    {
        public List<Client> list = null;
        public 我的()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)//登入
        {
            登入修改 drxg = new 登入修改();
            drxg.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)//修改
        {
            登入修改 drxg = new 登入修改();
            drxg.a = 2;
            drxg.Show();
            this.Close();
        }

        private void 我的_Load(object sender, EventArgs e)//我的加载事件
        {
            //没有登录账号修改控件就关了
            btnupdate.Enabled = false;
            btncut.Enabled = true;
            buttonBjgrxx.Enabled = false;

            //判断登录集合是否为空（不为空肯定是已经登录储存了）
            if (list.Count != 0)
            {
                foreach (var item in list)
                {
                    label1.Text = "名称:" + item.Name;
                    label2.Text = "电话号码:" + item.Phone;
                }
                if (label1.Text.Length > 4 || label2.Text.Length > 6)
                {
                    btncut.Enabled = false;
                    btnupdate.Enabled = true;
                    buttonBjgrxx.Enabled = true;
                }
            }
        }

        private void Button3_Click(object sender, EventArgs e)//退出登录
        {
            if (label1.Text.Length < 4 && label2.Text.Length < 6)
            {
                MessageBox.Show("您还未登录账号", "登录提示", MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("请问是否退出登录？", "登录提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                label1.Text = "名称:";
                label2.Text = "电话号码:";
                btncut.Enabled = true;
                buttonBjgrxx.Enabled = false;
                btnupdate.Enabled = false;
                User.user = "";
                User.pass = "";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            首页 sy = new 首页();
            sy.Show();
            this.Close();
        }

        private void buttonBjgrxx_Click(object sender, EventArgs e)
        {
            编辑个人信息 bjgrxx = new 编辑个人信息();
            bjgrxx.Show();
            this.Close();
        }
    }
}
