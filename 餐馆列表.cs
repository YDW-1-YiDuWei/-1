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
    public partial class 餐馆列表 : Form
    {
        ClientManager cm = new ClientManager();
        RestaurantManager restaurantManager = new RestaurantManager();
        public 餐馆列表()
        {
            InitializeComponent();
        }

        private void 餐馆列表_Load(object sender, EventArgs e)//显示窗体的时候
        {
            List<Client> list = cm.Login(User.user, User.pass);//测试拿到登录用户的id

            int count= list[0].Id;//这里是拿到登录的用户id
        }

        private void button1_Click(object sender, EventArgs e)//查询按钮
        {
            lvSJXX.Clear();
            image.Images.Clear();
            Inquire();
        }
        public void Inquire() //查询餐馆
        {
            DataTable dt = restaurantManager.InquireRestaurantName(txtSJ.Text.Trim());//餐馆信息
            int count = restaurantManager.InquireRestaurantNameCount(txtSJ.Text.Trim());//餐馆数量

            Image[] asg = new Image[count];//这里是图片的多少
            int i = 0;
            /*for (int i = 0; i < 1; i++)
            {
                lvSJXX.Items.Add("餐馆名字：" + "    餐馆地址：" + "     餐馆电话：", i);

                asg[ima++] = System.Drawing.Image.FromFile(@"C:\菜谱\FQ1WE53SGCNQ@64[P_94UHP.png");//这里是把空白图片丢到第一行因为不能丢null的
            }*/

           
            foreach (DataRow dr in dt.Rows)//循环表里的行
            {
                string name = dr[0].ToString();//餐馆id
                string gsName = dr[3].ToString();//餐馆名字
                string gsName2 = dr[4].ToString();//餐馆地址
                string gsName3 = dr[5].ToString();//餐馆电话
                string gsName4 = dr[7].ToString();//餐馆图片

                asg[i] = System.Drawing.Image.FromFile(Temp.pathCG + gsName4);//已经把拿到的图片保存到了这里面
                
                lvSJXX.Items.Add(gsName + "       " + gsName2 + "        " + gsName3, i);//这里是关键!!!!!!!!!把数据倒进lv里面
                lvSJXX.Items[i].Tag = name;//把餐馆id保存到Tag里面去

                i++;
            }
            image.Images.AddRange(asg);//这里是把图片增加进去

        }

        private void lvSJXX_Click(object sender, EventArgs e)//单击里面的餐馆的时候
        {
            if (lvSJXX.SelectedItems.Count != 0)
            {

                点餐 frm = new 点餐();
                frm.CanGuanBianHao = (string)lvSJXX.SelectedItems[0].Tag;
                frm.Show();
                this.Hide();
            }
        }
    }
}
