﻿using DianCanXiTongBLL;
using DianCanXiTongManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

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
            用户首页 sy = new 用户首页();
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

            User.TotalPrices = lblJGS.Text;
            付钱 fq = new 付钱();
            foreach (CuisineInformations item in cC)
            {
                Reservation rv = new Reservation
                {
                    ClientId = int.Parse(User.khID),
                    Money = int.Parse(item.CuisinePrice),
                    CuisineInformationId = item.id,
                    VegetableQuantity = item.VegetableQuantity
                };
                Li.Add(rv);
            }
            fq.cC = this.cC;
            fq.Li = Li;
            fq.Show();
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

            string abb = Uiop.SelectedItems[0].Name;
            List<CuisineInformations> cm = cFM.CuisinelnformationsSelectManager(CanGuanBianHao, "", "", abb);
            CuisineInformations cfo = cm[0];

            lblJGS.Text = (int.Parse(cfo.CuisinePrice) + int.Parse(lblJGS.Text.ToString())).ToString();

            foreach (CuisineInformations item in cC)
            {
                if (int.Parse(abb) == item.id)
                {
                    item.VegetableQuantity++;
                    item.CuisinePrice = (int.Parse(item.CuisinePrice) + int.Parse(cfo.CuisinePrice)).ToString();
                    cm.Remove(cfo);
                    return;
                }
            }

            cC.Add(cfo);


            cm.Remove(cfo);
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
                    Uiop = lvWQB;
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

            if (cC.Count == 0)
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
            Inquire();//查询这个餐馆的菜品
        }

        private void TSMDelete_Click(object sender, EventArgs e)
        {
            BindingList<CuisineInformations> a = (BindingList<CuisineInformations>)dGVYDCP.Tag;
            foreach (CuisineInformations item in a)
            {
                if (item.id == int.Parse(dGVYDCP.SelectedRows[0].Cells[1].Value.ToString()))
                {
                    if (MessageBox.Show("尊敬的客户您确定要删除此菜品吗？", "温馨提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        int add = int.Parse(dGVYDCP.SelectedRows[0].Cells[3].Value.ToString());
                        int shdna = int.Parse(dGVYDCP.SelectedRows[0].Cells[2].Value.ToString()) / add;
                        if (add > 1)
                        {
                            dGVYDCP.SelectedRows[0].Cells[3].Value = add - 1;

                            dGVYDCP.SelectedRows[0].Cells[2].Value = shdna * int.Parse(dGVYDCP.SelectedRows[0].Cells[3].Value.ToString());
                            FangFa(int.Parse(lblJGS.Text), shdna);

                            Button1_Click("", null);
                            return;
                        }
                        FangFa(int.Parse(lblJGS.Text), shdna);
                        cC.Remove(item);

                        Button1_Click("", null);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 订单计算
        /// </summary>
        public void FangFa(int yuanJia, int jianJian)
        {
            lblJGS.Text = (yuanJia - jianJian).ToString();
        }
        private void Button4_Click_1(object sender, EventArgs e)
        {
            cMSDC.Items[1].Visible = false;
            cMSDC.Items[0].Visible = true;


            dGVYDCP.Visible = true;
            label3.Visible = true;
            peCPQD.Visible = false;
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button5_Click_1(object sender, EventArgs e)
        {
            peCPQD.Visible = false;
            tSMDelete.Visible = false;
            加入菜篮ToolStripMenuItem.Visible = true;
            bttXD.Visible = true;
        }

        private void TabControl1_Click_1(object sender, EventArgs e)
        {
            cuisineInformationsLX = tabControl1.SelectedTab.Text == "全部" ? "" : tabControl1.SelectedTab.Text;
            DIanCaiFangFa();//判断菜品类型
            Uiop.Items.Clear();//清除项
            image.Images.Clear();//清除图片

            int j = 0;
            Image asg = null;

            foreach (CuisineInformations dr in cFM.CuisinelnformationsSelectManager(CanGuanBianHao, cuisineInformationsLX, cuisineInformationsLXName, ""))
            {
                asg = System.Drawing.Image.FromFile(Temp.pathCG + dr.CuisineImagePath);
                Uiop.Items.Add(dr.id.ToString(), dr.CuisineName, j);//这里是关键!!!!!!!!!倒

                Uiop.Tag = dr;
                //添加图片到上面去
                image.Images.Add(asg);
                j++;
            }


            Uiop = null;
        }
        /// <summary>
        ///已点菜品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button4_Click_2(object sender, EventArgs e)
        {
            if (cC.Count == 0)
            {
                dGVYDCP.Visible = false;
            }
            bttXD.Visible = false;
            加入菜篮ToolStripMenuItem.Visible = false;
            tSMDelete.Visible = true;

            peCPQD.Visible = true;
            dGVYDCP.DataSource = new BindingList<CuisineInformations>(cC);
            dGVYDCP.Tag = new BindingList<CuisineInformations>(cC);
        }
       
        private void BTSS_Click_1(object sender, EventArgs e)//搜索按钮
        {
            Inquire();
        }
        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Inquire() 
        {
            tabControl1.SelectedIndex = 0;
            cuisineInformationsLXName = txtDishName.Text;
            TabControl1_Click_1("", null);
            cuisineInformationsLXName = "";
        }
        /// <summary>
        /// 下单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BttXD_Click(object sender, EventArgs e)
        {

            if (cC.Count == 0)
            {
                MessageBox.Show("尊敬的用户您没有点餐，请您点菜之后在进行下单");
                return;
            }

            User.TotalPrices = lblJGS.Text;
            付钱 fq = new 付钱();
            foreach (CuisineInformations item in cC)
            {
                Reservation rv = new Reservation
                {
                    ClientId = int.Parse(User.khID),
                    Money = int.Parse(item.CuisinePrice),
                    CuisineInformationId = item.id,
                    VegetableQuantity = item.VegetableQuantity
                };
                Li.Add(rv);
            }
            fq.name = this;
            fq.Li = Li;
            fq.cC = this.cC;
            fq.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            餐馆列表 cglp = new 餐馆列表();
            cglp.Show();
            this.Close();
        }
        public void FQCG()
        {
            lblJGS.Text = "0";
        }
    }
}
