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
    public partial class 付钱 : Form
    {
        public 点餐 name = null;
        public List<Reservation> Li = null;
        public 模糊订单 Get = null;
        public 付钱()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            付钱成功 fqcg = new 付钱成功();
            FangFa(fqcg);
            fqcg.Show();
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            付钱成功 fqcg = new 付钱成功();
            FangFa(fqcg);
            fqcg.Show();
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            付钱成功 fqcg = new 付钱成功();
            FangFa(fqcg);
            fqcg.Show();
            this.Close();
           
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            付钱成功 fqcg = new 付钱成功();
            FangFa(fqcg);
            fqcg.Show();
            
            this.Close();
        }

        private void 付钱_Load(object sender, EventArgs e)
        {

        }
        public void FangFa(付钱成功 fqcg)
        {
            fqcg.Li = Li;
            fqcg.Get = this.Get;
        }

        private void btnreturn_Click(object sender, EventArgs e)
        {
            name.Show();
            this.Close();
        }

        private void 付钱_Load_1(object sender, EventArgs e)//显示界面的时候
        {

        }
    }
}
