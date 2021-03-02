using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DianCanXiTongManager;
using DianCanXiTongBLL;

namespace 点餐系统
{
    public partial class 商家登入修改注册 : Form
    {

        public int jurisdiction = 0; //判断是修改还是删除
        public 商家登入修改注册()
        {
            InitializeComponent();
        }
        RestaurantManager rest = new RestaurantManager();
        private void Button1_Click(object sender, EventArgs e)
        {
            if (!RestCheck())
            {
                return;
            }

            if (jurisdiction == 0)
            {
                List<Restaurant> list = rest.Register(RestUid.Text, RestPwd.Text, RestName.Text, RestAddress.Text, RestPhone.Text, "", User.path);
                if (MessageBox.Show("是否登录该账号", "登录提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    User.restaUser = RestUid.Text;
                    User.restaPass = RestPwd.Text;

                    商家首页1 resta = new 商家首页1();
                    resta.list = rest.Longin(User.restaUser, User.restaPass);
                    resta.Show();
                    this.Close();
                }
            }
            else
            {
                RestUid.ReadOnly = true;
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                User.path = fd.SafeFileName;
                Pbthan.Image = Image.FromFile(Temp.pathCG + fd.SafeFileName);
            }
        }

        private void 商家登入修改注册_Load(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public bool RestCheck()
        {
            if (Pbthan.Image == null)
            {
                MessageBox.Show("请选择商家图片");
                return false;
            }
            else if (RestName.Text == "")
            {
                MessageBox.Show("商家名称不可为空，快给你的店铺取个好名字吧");
                return false;
            }
            else if (RestUid.Text == "")
            {
                MessageBox.Show("账号不可以为空哦");
                return false;
            }
            else if (RestPwd.Text == "")
            {
                MessageBox.Show("密码不可为空哦");
                return false;
            }
            else if (RestPwds.Text == "" || RestPwd.Text != RestPwds.Text)
            {
                MessageBox.Show("密码不一致");
                return false;
            }
            else if (RestPhone.Text==""||RestPhone.Text.Length<11||RestPhone.Text.Length>11)
            {
                MessageBox.Show("请输入正确的电话");
                return false;
            }
            return true;
        }
    }
}
