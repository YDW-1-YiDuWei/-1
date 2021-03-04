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
    public partial class 骑手登入 : Form
    {
        public 骑手登入()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            骑手注册修改 qszcxg = new 骑手注册修改();
            qszcxg.Show();
        }
    }
}
