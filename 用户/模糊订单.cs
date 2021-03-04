using DianCanXiTongBLL;
using DianCanXiTongManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 点餐系统
{
    public partial class 模糊订单 : Form
    {
        private OrderFormManager of = new OrderFormManager();
        private ReservationManager rm = new ReservationManager();
        Dictionary<string, OrderForm> keyValuePairs = new Dictionary<string, OrderForm>();//保存总价格
        public List<Reservation> Li { get; set; }

        public 模糊订单()
        {
            InitializeComponent();
            Li = new List<Reservation>();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            首页 sy = new 首页();
            sy.Show();
            this.Close();
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void 模糊订单_Load(object sender, EventArgs e)
        {
            keyValuePairs.Clear();

            lVMHB.Items.Clear();
            int j = 0;

            foreach (OrderForm item in of.SelectOrderFormManager(User.khID, User.restaKhID, ""))
            {
                Image asg = System.Drawing.Image.FromFile(Temp.pathCG + item.Restaurant.RestaurantImage);//已经把拿到的图片保存到了这里面
                lVMHB.Items.Add(item.IdName.ToString(), "\t餐馆名称：" + item.Restaurant.RestaurantName + "\n\t订单状态：" + item.OrderStatus.StatusName + "\n餐馆电话：\n\t" + item.Restaurant.RestaurantPhone, j);

                keyValuePairs.Add(item.IdName.ToString(), item);
                images.Images.Add(asg);//添加图片到上面去
                j++;
            }
        }

        private void LVMHB_DoubleClick(object sender, EventArgs e)
        {
            详细订单 xxdd = new 详细订单();

            xxdd.id = lVMHB.SelectedItems[0].Name;
            xxdd.keyValuePairs = keyValuePairs[lVMHB.SelectedItems[0].Name].TotalPrices.ToString();

            
            xxdd.Show();
            this.Hide();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (lVMHB.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择你的订单");
                return;
            }
            
            付钱 fq = new 付钱();
            fq.Li = this.Li;
            fq.Show();

        }

        private void BttDelete_Click(object sender, EventArgs e)
        {
            string bianHao = lVMHB.SelectedItems[0].Name;//订单编号
            if (lVMHB.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择你要删除的订单");
                return;
            }

            if (MessageBox.Show("你确定要删除，此订单吗？", "温馨提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                of.DeleteOrderFormManager(bianHao);
                rm.DeleteReservationManager(bianHao);
                模糊订单_Load("", null);
            }

        }

        private void LVMHB_Click(object sender, EventArgs e)
        {
            User.TotalPrices = keyValuePairs[lVMHB.SelectedItems[0].Name].TotalPrices.ToString();
            User.RestaurantId = keyValuePairs[lVMHB.SelectedItems[0].Name].Restaurant.id.ToString();

            if (keyValuePairs[lVMHB.SelectedItems[0].Name].StatusId == 1002)
            {
                bttDelete.Visible = true;

            }
            else
            {
                bttDelete.Visible = false;
            }
            if (keyValuePairs[lVMHB.SelectedItems[0].Name].StatusId == 2)
            {
                bttQD.Visible = true;
            }
            else
            {
                bttQD.Visible = false;
            }

            Li.RemoveRange(0, Li.Count);
            foreach (DataRow dr in rm.InquireReservation(User.khID, lVMHB.SelectedItems[0].Name.ToString()).Rows)//循环表里的行
            {
                Reservation reservation = new Reservation
                {
                    ClientId = int.Parse(dr["ClientId"].ToString()),
                    Money = int.Parse(dr["Money"].ToString()),
                    OrderListId = int.Parse(dr["OrderListId"].ToString()),
                    VegetableQuantity = int.Parse(dr["VegetableQuantity"].ToString()),
                    CuisineInformationId = int.Parse(dr["CuisineInformationId"].ToString())
                };
                Li.Add(reservation);
            }

        }

        private void BttQD_Click(object sender, EventArgs e)
        {
            if (of.UpdateOrderFormManager("1002",lVMHB.SelectedItems[0].Name)>0)
            {
                MessageBox.Show("确定收货成功!");
                模糊订单_Load("",null);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }
    }
}
