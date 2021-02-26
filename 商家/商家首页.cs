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
        public List<Restaurant> list = null;
        CuisineInformationsManager cIM = new CuisineInformationsManager();
        public 商家首页()
        {
            InitializeComponent();
        }
        public bool Check() //判断是否为空
        {
            if (txtCPName.Text.Trim() == "")
            {
                MessageBox.Show("请输入菜品名称");
                txtCPName.Focus();
                return false;
            }
            if (txtCPMoney.Text.Trim() == "")
            {
                MessageBox.Show("请输入菜品价格");
                txtMoney.Focus();
                return false;
            }
            if (txtCPlx.SelectedIndex == 0)
            {
                MessageBox.Show("请选择菜品类型");
                cbLX.Focus();
                return false;
            }
            //if (pbCPImage.Image == null)
            //{
            //    MessageBox.Show("请选择菜品图片");
            //    pbImage.Focus();
            //    return false;
            //}
            return true;
        }
        private void toolStripLabel2_Click(object sender, EventArgs e)//商家首页（按钮）
        {
            label3.Text = DateTime.Now.ToShortTimeString().ToString();
            panel1.Visible = true;//显示商家首页（Panel控键）
            panel3.Visible = false;//隐藏商家菜品添加（Panel控键）

        }
        private void toolStripLabel3_Click(object sender, EventArgs e)//商家我的（按钮）
        {
            panel1.Visible = false;//隐藏商家首页（Panel控键）
            panel3.Visible = false;//隐藏商家菜品添加（Panel控键）
        }

        private void button5_Click(object sender, EventArgs e)//商家已完成（按钮）
        {
            panel3.Visible = false;//隐藏商家菜品添加（Panel控键）
            panel2.Visible = false;//隐藏商家菜品添加（Panel控键）
        }

        private void button2_Click(object sender, EventArgs e)//商家菜品添加（按钮）
        {
            panel3.Visible = true;//隐藏商家菜品添加（Panel控键）
            panel2.Visible = true;//隐藏商家菜品添加（Panel控键）
        }

        private void button3_Click(object sender, EventArgs e)//商家菜品删除（按钮）
        {
            panel3.Visible = false;//隐藏商家菜品添加（Panel控键）
            panel2.Visible = false;//隐藏商家菜品添加（Panel控键）
        }

        private void button6_Click(object sender, EventArgs e)//商家菜品修改（按钮）
        {
            panel3.Visible = true;//隐藏商家菜品添加（Panel控键）
            panel2.Visible = true;//隐藏商家菜品添加（Panel控键）
        }

        private void button7_Click(object sender, EventArgs e)//商家客户打单（按钮）
        {
            panel3.Visible = false;//隐藏商家菜品添加（Panel控键）
            panel2.Visible = false;//隐藏商家菜品添加（Panel控键）
        }

        private void button4_Click(object sender, EventArgs e)//商家退单（按钮）
        {
            panel3.Visible = false;//隐藏商家菜品添加（Panel控键）
            panel2.Visible = false;//隐藏商家菜品添加（Panel控键）
        }

        private void button1_Click(object sender, EventArgs e)//商家接单（按钮）
        {
            panel3.Visible = false;//隐藏商家菜品添加（Panel控键）
            panel2.Visible = false;//隐藏商家菜品添加（Panel控键）
        }

        private void button9_Click(object sender, EventArgs e)//确定按钮
        {
            //if (Check())//判断是否为空
            //{
            //    int count=cIM.AddCuisineInformations(txtCPName.Text,int.Parse(User.restaKhID), txtCPlx.SelectedIndex,decimal.Parse(txtMoney.Text+".0"),0, ofdLJ.SafeFileName);
            //    if (count > 0)
            //    {
            //        MessageBox.Show("增加成功");
            //    }
            //    else { MessageBox.Show("增加失败"); }
            //}
        }

        private void btXZ_Click(object sender, EventArgs e)//选择按钮
        {
            //if (DialogResult.OK == ofdLJ.ShowDialog())
            //{
            //    //ofdLJ.FileName;//拿到图片的路径
            //    //string name = ofdLJ.SafeFileName;//这里是可以拿到这个菜的名称
            //    pbCPImage.Image = System.Drawing.Image.FromFile(ofdLJ.FileName);
            //}
        }

        private void 商家首页_Load(object sender, EventArgs e)//显示窗体的时候
        {
            txtCPlx.SelectedIndex = 0;
        }
        public void Inquire() //查询菜品
        {
            lvCPAdmin.Items.Clear();//清除
            Image.Images.Clear();
            List<CuisineInformations> list= cIM.CuisinelnformationsSelectManager(User.restaKhID,"", txtInquireName.Text.Trim());


            Image[] asg = new Image[list.Count];//这里是图片的多少
            int i = 0;

            
            foreach (CuisineInformations item in list)
            {
                //item.CuisineImagePath//图片路径
                string name = item.CuisineTypeId.id == 1 ? "小菜" : item.CuisineTypeId.id == 2 ? "炒菜" : "主食";


                asg[i] = System.Drawing.Image.FromFile(Temp.pathCG + item.CuisineImagePath);//已经把拿到的图片保存到了这里面

                lvCPAdmin.Items.Add(item.CuisineName + "  " + name+ "  " + item.CuisinePrice, i) ;//这里是关键!!!!!!!!!把数据倒进lv里面
                
                i++;
            }
            Image.Images.AddRange(asg);
        }
        private void Timer1_Tick_1(object sender, EventArgs e)//计时器
        {
            label16.Text = DateTime.Now.ToLongDateString().ToString();
           // label17.Text = DateTime.Now.ToLongTimeString().ToString();
            label3.Text = DateTime.Now.ToShortTimeString().ToString();
        }

        private void btInquire_Click(object sender, EventArgs e)//查询按钮
        {
            Inquire();
        }
    }
}
