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
    public partial class 编辑个人信息 : Form
    {
        public 编辑个人信息()
        {
            InitializeComponent();
        }

        ClientManager client = new ClientManager();
        private void Button1_Click(object sender, EventArgs e)
        {
            if (UserName.Text.Trim() == "")//
            {
                MessageBox.Show("请输入姓名");
                UserName.Focus();
                return;
            }
            if (UserPhone.Text.Trim() == "")
            {
                MessageBox.Show("请输入电话号码");
                UserPhone.Focus();
                return;
            }
            if (UserAdders.Text.Trim() == "")
            {
                MessageBox.Show("请输入地址");
                UserAdders.Focus();
                return;
            }
            int count = client.CompileClientsMessage(UserName.Text, rbnan.Checked == true ? "男" : "女", UserPhone.Text, UserAdders.Text, User.khID);
            if (count > 0)
            {
                MessageBox.Show("信息提交成功");
                List<Client> list = client.Login(User.user, User.pass);
                我的 wo = new 我的();
                wo.list = list;
                wo.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("信息提交失败");
            }
        }
    }
}
