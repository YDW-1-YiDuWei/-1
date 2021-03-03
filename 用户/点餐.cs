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

        //零售订单集合
        public List<Reservation> Li { get; set; }
        //临时菜品集合
        public List<CuisineInformations> cC { get; set; }
        public 点餐()
        {
            InitializeComponent();
            Li = new List<Reservation>();
            cC = new List<CuisineInformations>();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            首页 sy = new 首页();
            sy.Show();
        }

        /// <summary>
        /// 下单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (cC.Count == 0)
            {
                MessageBox.Show("尊敬的用户您没有点餐，请您点菜之后在进行下单");
                return;
            }
               
            
            付钱 fq = new 付钱();
            foreach (CuisineInformations item in cC)
            {
                Reservation rv = new Reservation
                {
                    ClientId = int.Parse(User.khID),
                    Money = int.Parse(item.CuisinePrice),
                    CuisineInformationId = item.id
                };
                Li.Add(rv);
            }

            fq.Li = Li;
            fq.Show();
            Li = null;
            //this.Close();
        }

        private void TabControl1_Click(object sender, EventArgs e)
        {      
            cuisineInformationsLX = tabControl1.SelectedTab.Text == "全部" ? "" : tabControl1.SelectedTab.Text;
            DIanCaiFangFa();
            Uiop.Items.Clear();//清除项
            image.Images.Clear();//清除图片

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
            cC.Add(cuisine);

            lblJGS.Text = (int.Parse(cuisine.CuisinePrice) + int.Parse(lblJGS.Text.ToString())).ToString();
           
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

        private void Button1_Click(object sender, EventArgs e)
        {
            cMSDC.Items[1].Visible = true;
            cMSDC.Items[0].Visible = false;

            if (cC.Count==0)
            {
                dGVYDCP.Visible = false;
                label3.Visible = false;
            }


            dGVYDCP.DataSource = new BindingList<CuisineInformations>(cC);
            dGVYDCP.Tag = new BindingList<CuisineInformations>(cC);

            peCPQD.Visible = true;
        }

        private void 点餐_Load(object sender, EventArgs e)
        {
            dGVYDCP.AutoGenerateColumns = false;
        }

        private void TSMDelete_Click(object sender, EventArgs e)
        {
            BindingList <CuisineInformations> a= (BindingList<CuisineInformations>)dGVYDCP.Tag;
            foreach (CuisineInformations item in a)
            {
                if (item.id== int.Parse(dGVYDCP.SelectedRows[0].Cells[1].Value.ToString()))
                {
                    if (MessageBox.Show("尊敬的客户您确定要删除此菜品吗？", "温馨提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) {
                        cC.Remove(item);
                       // Li.Remove(item);
                        Button1_Click("", null);
                        break;
                    } else if (MessageBox.Show("尊敬的客户您确定要删除此菜品吗？", "温馨提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information)==DialogResult.No)
                    {
                        break;
                    }
                }
            }
            
        }

        private void Button4_Click_1(object sender, EventArgs e)
        {
            cMSDC.Items[1].Visible = false;
            cMSDC.Items[0].Visible = true;


            dGVYDCP.Visible = true;
            label3.Visible = true;
            peCPQD.Visible = false;
        }
    }
}
