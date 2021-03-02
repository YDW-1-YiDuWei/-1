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

        private void button4_Click(object sender, EventArgs e)
        {

            商家登录 sjdr = new 商家登录();
            sjdr.Show();
            this.Close();
           
        }
    }
}
