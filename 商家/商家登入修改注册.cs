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
            if (Pbthan.Image == null)
            {
                MessageBox.Show("您没有选择图片");
                return;
            }
            /*if (RestName.Text.Trim() == "")
            {
                MessageBox.Show("请输入名称");
                RestName.Focus();
                return;
            }
            if (RestUid.Text.Trim() == "")
            {
                MessageBox.Show("请输入账号");
                RestUid.Focus();
                return;
            }
            if (RestPwd.Text.Trim() == "")
            {
                MessageBox.Show("请输入密码");
                RestPwd.Focus();
                return;
            }
            if (RestPwds.Text.Trim() == "")
            {
                MessageBox.Show("请输入确认密码");
                RestPwds.Focus();
                return;
            }
            if (RestPhone.Text.Trim() == "")
            {
                MessageBox.Show("请输入商家电话");
                RestPhone.Focus();
                return;
            }
            if (RestAddress.Text.Trim() == "")
            {
                MessageBox.Show("请输入商家地址");
                RestAddress.Focus();
                return;
            }*/
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

                int id = int.Parse(User.restaKhID);
                List<Restaurant> list = rest.Register(RestUid.Text, RestPwd.Text, RestName.Text, RestAddress.Text, RestPhone.Text, "", User.path, jurisdiction, id);
                if (list.Count > 0)
                {
                    User.restaPass = list[0].RestaurantNumberPwd;
                    string name = User.path;

                    MessageBox.Show("修改成功");
                }
                else
                {
                    MessageBox.Show("修改失败");
                }

            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                if (fd.SafeFileName != "")
                {
                    User.path = fd.SafeFileName;
                }
                Pbthan.Image = Image.FromFile(Temp.pathCG + fd.SafeFileName);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            商家登录 sjdr = new 商家登录();
            sjdr.Show();
            this.Close();

        }

        private void 商家登入修改注册_Load(object sender, EventArgs e)
        {
            if (jurisdiction == 1)
            {
                this.RestUid.ReadOnly = true;
                List<Restaurant> list = rest.Longin(User.restaUser, User.restaPass);
                RestName.Text = list[0].RestaurantName;
                Pbthan.Image = Image.FromFile(Temp.pathCG + list[0].RestaurantImage);
                RestAddress.Text = list[0].RestaurantAddress;
                RestPhone.Text = list[0].RestaurantPhone;
                RestPwd.Text = list[0].RestaurantNumberPwd;
                RestPwds.Text = list[0].RestaurantNumberPwd;
                RestUid.Text = list[0].RestaurantNumber;
            }
        }
    }
}
