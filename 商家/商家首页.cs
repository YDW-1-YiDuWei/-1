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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void 商家首页_Load(object sender, EventArgs e)
        {
            if (list != null)
            {
                label1.Text="商家的名称"+ list[0].RestaurantName;
                pictureBox3.Image = Image.FromFile(list[0].RestaurantImage);
            }
        }
    }
}
