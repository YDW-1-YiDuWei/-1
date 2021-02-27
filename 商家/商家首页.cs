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
    public partial class 商家首页 : Form
    {

        public int i = 0;
        CuisineInformationsManager cIM = new CuisineInformationsManager();
        public List<Restaurant> list = null;
        int count = 0;
        public 商家首页()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)//确定按钮
        {
            if (count == 0)
            {
                if (Check())//判断是否为空
                {
                    int count = cIM.AddCuisineInformations(txtName.Text, int.Parse(User.restaKhID), cbLX.SelectedIndex, decimal.Parse(txtMoney.Text + ".0"), 0, ofdLJ.SafeFileName);
                    if (count > 0)
                    {
                        MessageBox.Show("增加成功");
                        Inquire();
                    }
                    else { MessageBox.Show("增加失败"); }
                }
            }
            else 
            {
                int index = cIM.AmendCuisineInformations((int)listView2.SelectedItems[0].Tag,txtName.Text,cbLX.SelectedIndex,decimal.Parse(txtMoney.Text), ofdLJ.SafeFileName);
                if (index > 0)
                {
                    MessageBox.Show("修改成功");
                    Inquire();
                }
                else { MessageBox.Show("修改失败"); }
            }
        }
        public void Inquire() //查询菜品图片
        {
            
            listView2.Items.Clear();//清除
            imageList1.Images.Clear();
            List<CuisineInformations> list = cIM.CuisinelnformationsSelectManager(User.restaKhID, "", txtCPName.Text.Trim());

            Image[] asg = new Image[list.Count];//这里是图片的多少
            int i = 0;

            //这个项目真的是多灾多难
            foreach (CuisineInformations item in list)
            {
                
                //item.CuisineImagePath//图片路径
                string name = item.CuisineTypeId.id == 1 ? "小菜" : item.CuisineTypeId.id == 2 ? "炒菜" : "主食";


                asg[i] = System.Drawing.Image.FromFile(Temp.pathCG + item.CuisineImagePath);//已经把拿到的图片保存到了这里面

                listView2.Items.Add(item.CuisineName + "  " + name + "  " + item.CuisinePrice, i);//这里是关键!!!!!!!!!把数据倒进lv里面
                listView2.Items[i].Tag = item.id;
                i++;
            }
            imageList1.Images.AddRange(asg);
        }
        public bool Check() //判断是否为空
        {
            i = 1;
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("请输入菜品名称");
                txtName.Focus();
                return false;
            }
            if (txtMoney.Text.Trim() == "")
            {
                MessageBox.Show("请输入菜品价格");
                txtMoney.Focus();
                return false;
            }
            if (cbLX.SelectedIndex == 0)
            {
                MessageBox.Show("请选择菜品类型");
                cbLX.Focus();
                return false;
            }
            if (pbImage.Image == null)
            {
                MessageBox.Show("请选择菜品图片");
                pbImage.Focus();
                return false;
            }
            return true;
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)//商家首页（按钮）
        {
            i = 1;
            panel1.Visible = true;//商家首页显示（panel1）
            panel2.Visible = true;//商家的菜品查询（panel2）
            panel3.Visible = true;//商家的菜品增加/修改（panel3）

        }

        private void toolStripLabel3_Click(object sender, EventArgs e)//商家我的（按钮）
        {
            i = 1;
            panel1.Visible = false;//商家首页显示（panel1）
            panel2.Visible = false;//商家的菜品查询（panel2）
            panel3.Visible = false;//商家的菜品增加/修改（panel3）
        }
        private void button5_Click(object sender, EventArgs e)//商家已完成（按钮）
        {
            i = 1;
            panel2.Visible = false;//商家的菜品查询（panel2）
            panel3.Visible = false;//商家的菜品增加/修改（panel3）
        }

        private void 商家首页_Load(object sender, EventArgs e)//商家首页（窗口）
        {
            label2.Text = DateTime.Now.ToLongDateString().ToString();
            if (list != null)
            {
                pbSJLJ.Image = Image.FromFile(@"C:\菜谱\" + list[0].RestaurantImage);
                lbSJName.Text = "商家的名称：" + list[0].RestaurantName;
            }
           
        }

        private void button2_Click(object sender, EventArgs e)//商家的菜品增加(按钮)
        {
            i = 1; count = 0;
            panel2.Visible = true;//商家的菜品查询（panel2）
            panel3.Visible = true;//商家的菜品增加/修改（panel3）
        }

        private void button3_Click(object sender, EventArgs e)//商家的菜品删除(按钮)
        {
            i = 0;
            if (listView2.SelectedIndices.Count == 0)
            {
                return;
            }
            Cmlist.Enabled = true;
            panel2.Visible = true;//商家的菜品查询（panel2）
            panel3.Visible = false;//商家的菜品增加/修改（panel3）

            listView2.ContextMenuStrip = Cmlist;
            int a = (int)listView2.SelectedItems[0].Tag;

        }

        private void button6_Click(object sender, EventArgs e)//商家的   菜品修改按钮
        {
            i = 1;
            count = 1;
            panel2.Visible = true;//商家的菜品查询（panel2）
            panel3.Visible = true;//商家的菜品增加/修改（panel3）

            List<CuisineInformations> list = cIM.CuisinelnformationsAmend(User.restaKhID,(int)listView2.SelectedItems[0].Tag);
            foreach (CuisineInformations item in list)
            {
                txtName.Text = item.CuisineName;
                txtMoney.Text = item.CuisinePrice;
                cbLX.SelectedIndex = item.CuisineTypeId.id;
                pbImage.Image= System.Drawing.Image.FromFile(Temp.pathCG+item.CuisineImagePath);
            }
        }

        private void button7_Click(object sender, EventArgs e)//商家客户打单
        {
            i = 1; 
            panel2.Visible = true;//商家的菜品查询（panel2）
            panel3.Visible = true;//商家的菜品增加/修改（panel3）
        }

        private void button4_Click(object sender, EventArgs e)//商家退单
        {
            i = 1;
            panel2.Visible = true;//商家的菜品查询（panel2）
            panel3.Visible = true;//商家的菜品增加/修改（panel3）
        }

        private void button1_Click(object sender, EventArgs e)//商家接单
        {
            i = 1;
            panel2.Visible = true;//商家的菜品查询（panel2）
            panel3.Visible = true;//商家的菜品增加/修改（panel3）
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            i = 1; 
            label3.Text = DateTime.Now.ToShortTimeString().ToString();
            label2.Text = DateTime.Now.ToLongDateString().ToString();
        }

        private void btXZ_Click(object sender, EventArgs e)//选择按钮
        {
            i = 1;
            if (DialogResult.OK == ofdLJ.ShowDialog())
            {
                //    //ofdLJ.FileName;//拿到图片的路径
                //    //string name = ofdLJ.SafeFileName;//这里是可以拿到这个菜的名称
                pbImage.Image = System.Drawing.Image.FromFile(ofdLJ.FileName);
            }
        }

        private void button8_Click(object sender, EventArgs e)//查询按钮
        {
            i = 1;
            Inquire();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            i = 1;
            label3.Text = DateTime.Now.ToString("t");
            label2.Text = DateTime.Now.ToString();
        }

        private void Timer1_Tick_1(object sender, EventArgs e)
        {
            if (i==1)
            {
                listView2.ContextMenuStrip = null;
            }
            label3.Text = DateTime.Now.ToString("t");
            label2.Text = DateTime.Now.ToString("g");
        }
    }
}
