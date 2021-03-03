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
    public partial class 商家首页1 : Form
    {
        public int i = 1;
        int count = 0;
        public CuisineInformationsManager cIM = new CuisineInformationsManager();
        public List<Restaurant> list = null;
        public 商家首页1()
        {
            InitializeComponent();
        }
        private void toolStripLabel2_Click_1(object sender, EventArgs e)//商家首页
        {
            i = 1;
            Temp.index = 0;
            btnSerach.Visible = true;
            #region 隐藏窗口
            panel1.Visible = true;//商家首页显示（panel1）
            panel2.Visible = true;//商家的菜品查询（panel2）
            panel3.Visible = true;//商家的菜品增加/修改（panel3）
            panel7.Visible = false;
            //panel4.Visible = false;//商家模糊接单查询
            //panel5.Visible = false;//商家详细接单查询
            #endregion
        }

        private void toolStripLabel3_Click_1(object sender, EventArgs e)//商家我的
        {
            i = 1;
            btnSerach.Visible = false;
            #region 隐藏窗口
            panel7.Visible = true;
            //panel1.Visible = false;//商家首页显示（panel1）
            /*panel2.Visible = false;//商家的菜品查询（panel2）
            panel3.Visible = false;//商家的菜品增加/修改（panel3）
            panel4.Visible = false;//商家模糊接单查询
            panel5.Visible = false;//商家详细接单查询*/
            #endregion
        }

        private void button5_Click(object sender, EventArgs e)//商家已完成
        {
            i = 1;
            Temp.index = 0;
            #region 隐藏窗口
            panel2.Visible = false;//商家的菜品查询（panel2）
            panel3.Visible = false;//商家的菜品增加/修改（panel3）
            panel4.Visible = false;//商家模糊接单查询
            panel5.Visible = false;//商家详细接单查询
            #endregion
        }

        private void button2_Click(object sender, EventArgs e)//商家菜品增加
        {
            i = 1; count = 0;
            Temp.index = 0;
            #region 隐藏窗口
            panel2.Visible = true;//商家的菜品查询（panel2）
            panel3.Visible = true;//商家的菜品增加/修改（panel3）
            panel4.Visible = false;//商家模糊接单查询
            panel5.Visible = false;//商家详细接单查询
            #endregion
        }

        private void button3_Click(object sender, EventArgs e)//商家菜品删除
        {
            #region 隐藏窗口
            panel2.Visible = true;//商家的菜品查询（panel2）
            panel3.Visible = false;//商家的菜品增加/修改（panel3）
            panel4.Visible = false;//商家模糊接单查询
            panel5.Visible = false;//商家详细接单查询
            #endregion
            Temp.index = 0;
            i = 0;
            if (lvCPMessage.SelectedIndices.Count == 0)
            {
                return;
            }
            Cmlist.Enabled = true;
            lvCPMessage.ContextMenuStrip = Cmlist;
        }

        private void button6_Click(object sender, EventArgs e)//商家修改
        {
            i = 1;
            count = 1;
            #region 隐藏窗口
            panel2.Visible = true;//商家的菜品查询（panel2）
            panel3.Visible = true;//商家的菜品增加/修改（panel3）
            panel4.Visible = false;//商家模糊接单查询
            panel5.Visible = false;//商家详细接单查询
            #endregion

            if (lvCPMessage.SelectedItems.Count == 0)//判断有没有选中菜品
            {
                MessageBox.Show("请选择你要修改的菜品");
                return;
            }

            List<CuisineInformations> list = cIM.CuisinelnformationsAmend(User.restaKhID, (int)lvCPMessage.SelectedItems[0].Tag);
            foreach (CuisineInformations item in list)
            {
                txtName.Text = item.CuisineName;//菜品名称
                txtMoney.Text = item.CuisinePrice;//菜品价格
                cbLX.SelectedIndex = item.CuisineTypeId.id;//下拉列表的选择
                pbImage.Image = System.Drawing.Image.FromFile(Temp.pathCG + item.CuisineImagePath);//图片的地址
            }
        }

        private void button7_Click(object sender, EventArgs e)//商家客户打单
        {
            i = 1;
            #region 隐藏窗口
            panel2.Visible = true;//商家的菜品查询（panel2）
            panel3.Visible = true;//商家的菜品增加/修改（panel3）

            ReservationManager rese = new ReservationManager();
            int count = rese.PrintReservationService();
            if (count > 0)
            {
                MessageBox.Show("打单成功 数量:" + count);
            }
            else
            {
                MessageBox.Show("你还没有订单哦~~~~~~");
            }
            #endregion
        }

        private void button4_Click(object sender, EventArgs e)//商家退单
        {
            #region 隐藏窗口
            panel2.Visible = false;//商家的菜品查询（panel2）
            panel3.Visible = false;//商家的菜品增加/修改（panel3）
            panel4.Visible = false;//商家模糊接单查询
            panel5.Visible = false;//商家详细接单查询
            #endregion
            i = 1;
        }

        private void button1_Click(object sender, EventArgs e)//商家接单
        {
            #region 隐藏窗口
            //panel2.Visible = false;//商家的菜品查询（panel2）
            //panel3.Visible = false;//商家的菜品增加/修改（panel3）
            panel4.Visible = true;//商家模糊接单查询
            panel5.Visible = true;//商家详细接单查询
            #endregion


            i = 1;
        }

        private void btQD_Click(object sender, EventArgs e)//确定按钮
        {
            if (Check())//判断是否为空
            {
                if (count == 0)
                {
                    int count = cIM.AddCuisineInformations(txtName.Text, int.Parse(User.restaKhID), cbLX.SelectedIndex, decimal.Parse(txtMoney.Text + ".0"), 0, ofdLJ.SafeFileName);
                    if (count > 0)
                    {
                        MessageBox.Show("增加成功");
                        Inquire(); //刷新菜品信息
                        Delete();//删除输入框里面的值
                    }
                    else { MessageBox.Show("增加失败"); }
                }
                else
                {
                    if (Temp.index == 1)//判断有没有重新选择图片
                    {
                        int index = cIM.AmendCuisineInformations((int)lvCPMessage.SelectedItems[0].Tag, txtName.Text, cbLX.SelectedIndex, decimal.Parse(txtMoney.Text), ofdLJ.SafeFileName);
                        if (index > 0)
                        {
                            Temp.index = 0;//把这个重新变成0好以后判断用
                            MessageBox.Show("修改成功");
                            Inquire(); //刷新菜品信息
                            Delete();//删除输入框里面的值
                        }
                        else { MessageBox.Show("修改失败"); }
                    }
                    else
                    {
                        MessageBox.Show("请重新选择图片");
                    }
                }
            }
        }
        public void Inquire() //查询菜品图片
        {

            lvCPMessage.Items.Clear();//清除
            imageList1.Images.Clear();//清楚图片
            List<CuisineInformations> list = cIM.CuisinelnformationsSelectManager(User.restaKhID, "", txtCPName.Text.Trim());

            Image[] asg = new Image[list.Count];//这里是图片的多少
            int i = 0;

            foreach (CuisineInformations item in list)//这里是吧数据库里面的图片和信息循环出来
            {

                //item.CuisineImagePath//图片路径
                string name = item.CuisineTypeId.id == 1 ? "小菜" : item.CuisineTypeId.id == 2 ? "炒菜" : "主食";

                asg[i] = System.Drawing.Image.FromFile(Temp.pathCG + item.CuisineImagePath);//已经把拿到的图片保存到了这里面

                lvCPMessage.Items.Add(item.CuisineName + "    " + name + "    " + item.CuisinePrice, i);//这里是关键!!!!!!!!!把数据倒进lv里面
                lvCPMessage.Items[i].Tag = item.id;
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
        public void Delete() //清楚输入框里面的值
        {
            txtName.Text = "";
            txtMoney.Text = "";
            cbLX.SelectedIndex = 0;
            pbImage.Image = null;
        }

        private void 商家首页1_Load(object sender, EventArgs e)//显示窗体的时候
        {
            label2.Text = DateTime.Now.ToLongDateString().ToString();
            if (list != null)
            {
                User.restaKhID = list[0].id.ToString();
                pbSJLJ.Image = Image.FromFile(Temp.pathCG + list[0].RestaurantImage);
                lbSJName.Text = "商家的名称：" + list[0].RestaurantName;
                pbpath.Image = Image.FromFile(Temp.pathCG + list[0].RestaurantImage);
                txtCGname.Text = list[0].RestaurantName;
                txtCGnum.Text = User.restaUser;

            }
            Inquire();
            cbLX.SelectedIndex = 0;
        }

        private void btXZ_Click(object sender, EventArgs e)//商家的  菜品选择
        {
            i = 1;
            if (DialogResult.OK == ofdLJ.ShowDialog())
            {
                //    //ofdLJ.FileName;//拿到图片的路径
                //    //string name = ofdLJ.SafeFileName;//这里是可以拿到这个菜的名称
                pbImage.Image = System.Drawing.Image.FromFile(ofdLJ.FileName);
                Temp.index = 1;
            }
        }

        private void button8_Click(object sender, EventArgs e)//商家查询按钮
        {
            i = 1;
            Inquire();
        }


        private void timer1_Tick(object sender, EventArgs e)//计时器
        {
            if (i == 1)
            {
                lvCPMessage.ContextMenuStrip = null;
            }
            label3.Text = DateTime.Now.ToString("t");
            label2.Text = DateTime.Now.ToString("g");
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)//右击出现的删除选项
        {
            int a = (int)lvCPMessage.SelectedItems[0].Tag;
            int count = cIM.DeleteCuisinelnformationsAmend(a);
            if (count > 0)
            {
                MessageBox.Show("删除成功");
                Inquire();//刷新界面
            }
            else
            {
                MessageBox.Show("删除失败");
            }
        }

        private void button8_Click_1(object sender, EventArgs e)//查询按钮
        {
            i = 1;
            Inquire();
        }

        private void btnUpdate_Click(object sender, EventArgs e)//商家我的修改（按钮）
        {
            商家登入修改注册 sjdlxgzc = new 商家登入修改注册();
            sjdlxgzc.jurisdiction = 1;
            sjdlxgzc.Show();
        }

        private void btnHandover_Click(object sender, EventArgs e)//商家我的切换（按钮）
        {
            商家登录 sjdl = new 商家登录();
            sjdl.Show();
            this.Close();
        }

        private void btnSerach_Click(object sender, EventArgs e)//商家首页1 搜索（按钮）
        {
            i = 1;
            Inquire();
        }

    }
}