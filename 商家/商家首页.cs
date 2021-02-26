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

        public 商家首页()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)//确定按钮
        {

        }
        public void Inquire() //查询菜品的图片
        {
        
        }
        public bool Check() //判断是否为空
        {
            if (txtName.Text.Trim()=="")
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
            if (cbLX.SelectedIndex==0)
            {
                MessageBox.Show("请选择菜品类型");
                cbLX.Focus();
                return false;
            }
            if (pbImage.Image==null)
            {
                MessageBox.Show("请选择菜品图片");
                pbImage.Focus();
                return false;
            }
            return true;
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)//商家首页（按钮）
        {
            panel1.Visible = true;//商家首页显示（panel1）
            panel2.Visible = false;//商家的菜品查询（panel2）
            panel3.Visible = false;//商家的菜品增加/修改（panel3）

        }

        private void toolStripLabel3_Click(object sender, EventArgs e)//商家我的（按钮）
        {
            panel1.Visible = false;//商家首页显示（panel1）
            panel2.Visible = false;//商家的菜品查询（panel2）
            panel3.Visible = false;//商家的菜品增加/修改（panel3）
        }
        private void 商家首页_Load(object sender, EventArgs e)
        {
            if (list != null)
            {
                lbSJName.Text="商家的名称"+ list[0].RestaurantName;
                pbSJLJ.Image = Image.FromFile(list[0].RestaurantImage);
            }
        }
    }
}
