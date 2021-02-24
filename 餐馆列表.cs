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
        RestaurantManager restaurantManager = new RestaurantManager();
        public 餐馆列表()
        {
            InitializeComponent();
        }

        private void 餐馆列表_Load(object sender, EventArgs e)//显示窗体的时候
        {

        }

        private void button1_Click(object sender, EventArgs e)//查询按钮
        {
            lvSJXX.Clear();
            Inquire();
        }
        public void Inquire() //查询餐馆
        {
            DataTable dt = restaurantManager.InquireRestaurantName(txtSJ.Text.Trim());


            int j = 1;
            Image[] asg = new Image[5];
            int ima = 0;
            for (int i = 0; i < 1; i++)
            {
                lvSJXX.Items.Add("餐馆名字：" + "    餐馆地址：" + "     餐馆电话：", i);

                asg[ima++] = System.Drawing.Image.FromFile(@"C:\Users\Administrator\Desktop\图片超清\FQ1WE53SGCNQ@64[P_94UHP.png");//已经把拿到的图片保存到了这里面
            }

           
            foreach (DataRow dr in dt.Rows)//循环表里的行
            {
                string gsName = dr[3].ToString();//餐馆名字
                string gsName2 = dr[4].ToString();//餐馆地址
                string gsName3 = dr[5].ToString();//餐馆电话
                string gsName4 = dr[7].ToString();//餐馆图片

                asg[ima++] = System.Drawing.Image.FromFile(Temp.pathCG + gsName4);//已经把拿到的图片保存到了这里面
                lvSJXX.Items.Add(gsName + "       " + gsName2 + "        " + gsName3, j);//这里是关键!!!!!!!!!倒

                j++;
            }
            image.Images.AddRange(asg);
        }

        private void lvSJXX_Click(object sender, EventArgs e)//单击里面的餐馆的时候
        {
            if (lvSJXX.SelectedItems.Count != 0&&lvSJXX.SelectedItems.ToString()!= "餐馆名字：" + "    餐馆地址：" + "     餐馆电话：")
            {
                MessageBox.Show("1");
            }
        }
    }
}
