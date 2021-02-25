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
    public partial class 点餐 : Form
    {
        private CuisineInformationsManager cFM = new CuisineInformationsManager();
        private string cuisineInformationsLX = "";
        private string cuisineInformationsLXName = "";
        public ListView Uiop { get; set; }
        /// <summary>
        /// 餐馆ID
        /// </summary>
        public string CanGuanBianHao { get; set; }
        public List<Reservation> Li { get; set; }
        public 点餐()
        {
            InitializeComponent();
            Li = new List<Reservation>();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            首页 sy = new 首页();
            sy.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            付钱 fq = new 付钱();
            fq.Li = Li;
            fq.Show();
            //this.Close();
        }

        private void TabControl1_Click(object sender, EventArgs e)
        {      
            cuisineInformationsLX = tabControl1.SelectedTab.Text == "全部" ? "" : tabControl1.SelectedTab.Text;
            DIanCaiFangFa();
            Uiop.Items.Clear();

            int j = 0;
            Image asg = null;

            foreach (CuisineInformations dr in cFM.CuisinelnformationsSelectManager(CanGuanBianHao, cuisineInformationsLX, cuisineInformationsLXName))
            {
                asg= System.Drawing.Image.FromFile(Temp.pathCG + dr.CuisineImagePath);
                Uiop.Tag = dr;
                Uiop.Items.Add(dr.CuisineName,j);//这里是关键!!!!!!!!!倒
                
                //添加图片到上面去
                image.Images.Add(asg);
                j++;
            }
          

            Uiop = null;
        }

        private void BTSS_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            cuisineInformationsLXName = txtDishName.Text;
            TabControl1_Click("", null);
            cuisineInformationsLXName = "";
        }

        private void 加入菜篮ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DIanCaiFangFa();
            if (Uiop.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选中菜品进行点菜，谢谢^.^");
                return;
            }

            MessageBox.Show("菜品已加入菜篮，谢谢您对本店的支持^.^！");
            CuisineInformations cuisine = (CuisineInformations)Uiop.Tag;

            lblJGS.Text = (int.Parse(cuisine.CuisinePrice) + int.Parse(lblJGS.Text.ToString())).ToString();
            Reservation rv = new Reservation
            {
                ClientId = int.Parse(User.khID),
                Money = int.Parse(cuisine.CuisinePrice),
                CuisineInformationId = cuisine.id
            };
            Li.Add(rv);
            Uiop = null;
        }
        /// <summary>
        /// 判断菜品类型
        /// </summary>
        public void DIanCaiFangFa()
        {
            switch (cuisineInformationsLX)
            {
                case "":
                    Uiop = lvwQB;
                    break;
                case "冷菜":
                    Uiop = lVlC;
                    break;
                case "热菜":
                    Uiop = lVRC;
                    break;
                case "海鲜":
                    Uiop = lVHX;
                    break;
                case "主食":
                    Uiop = lVZS;
                    break;
                case "汤":
                    Uiop = lVT;
                    break;
                case "酒水":
                    Uiop = lVJS;
                    break;
                case "甜点":
                    Uiop = lVTD;
                    break;
                case "肉类":
                    Uiop = lVRL;
                    break;
            }
        }
    }
}
