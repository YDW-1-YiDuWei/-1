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
    public partial class 商家登录 : Form
    {
        public 商家登录()
        {
            InitializeComponent();
        }

        private void 商家登录_Load(object sender, EventArgs e)//显示窗体的时候
        {
           
        }

        private void button1_Click(object sender, EventArgs e)//登录按钮
        {
            商家首页 a = new 商家首页();
            a.Show();
            this.Close();
        }
    }
    }
}
