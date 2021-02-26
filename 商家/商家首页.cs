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
