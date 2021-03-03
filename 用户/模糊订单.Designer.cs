namespace 点餐系统
{
    partial class 模糊订单
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(模糊订单));
            this.lVMHB = new System.Windows.Forms.ListView();
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.bttZaiLeiYiDan = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.bttDelete = new System.Windows.Forms.Button();
            this.bttQD = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // lVMHB
            // 
            this.lVMHB.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lVMHB.HideSelection = false;
            this.lVMHB.LargeImageList = this.images;
            this.lVMHB.Location = new System.Drawing.Point(3, 34);
            this.lVMHB.Name = "lVMHB";
            this.lVMHB.Size = new System.Drawing.Size(743, 484);
            this.lVMHB.TabIndex = 0;
            this.lVMHB.UseCompatibleStateImageBehavior = false;
            this.lVMHB.View = System.Windows.Forms.View.Tile;
            this.lVMHB.Click += new System.EventHandler(this.LVMHB_Click);
            this.lVMHB.DoubleClick += new System.EventHandler(this.LVMHB_DoubleClick);
            // 
            // images
            // 
            this.images.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.images.ImageSize = new System.Drawing.Size(130, 120);
            this.images.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // button3
            // 
            this.btnreturn.BackColor = System.Drawing.Color.Transparent;
            this.btnreturn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnreturn.Location = new System.Drawing.Point(25, 0);
            this.btnreturn.Margin = new System.Windows.Forms.Padding(4);
            this.btnreturn.Name = "btnreturn";
            this.btnreturn.Size = new System.Drawing.Size(67, 35);
            this.btnreturn.TabIndex = 21;
            this.btnreturn.Text = "返回";
            this.btnreturn.UseVisualStyleBackColor = false;
            this.btnreturn.Click += new System.EventHandler(this.button3_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(4, 0);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(88, 35);
            this.pictureBox3.TabIndex = 20;
            this.pictureBox3.TabStop = false;
            // 
            // bttZaiLeiYiDan
            // 
            this.bttZaiLeiYiDan.ForeColor = System.Drawing.Color.Red;
            this.bttZaiLeiYiDan.Location = new System.Drawing.Point(658, 482);
            this.bttZaiLeiYiDan.Name = "bttZaiLeiYiDan";
            this.bttZaiLeiYiDan.Size = new System.Drawing.Size(75, 23);
            this.bttZaiLeiYiDan.TabIndex = 4;
            this.bttZaiLeiYiDan.Text = "再来一单";
            this.bttZaiLeiYiDan.UseVisualStyleBackColor = true;
            this.bttZaiLeiYiDan.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(323, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 21);
            this.label1.TabIndex = 22;
            this.label1.Text = "我的订单";
            // 
            // bttDelete
            // 
            this.bttDelete.ForeColor = System.Drawing.Color.Red;
            this.bttDelete.Location = new System.Drawing.Point(577, 482);
            this.bttDelete.Name = "bttDelete";
            this.bttDelete.Size = new System.Drawing.Size(75, 23);
            this.bttDelete.TabIndex = 4;
            this.bttDelete.Text = "删除订单";
            this.bttDelete.UseVisualStyleBackColor = true;
            this.bttDelete.Visible = false;
            this.bttDelete.Click += new System.EventHandler(this.BttDelete_Click);
            // 
            // bttQD
            // 
            this.bttQD.ForeColor = System.Drawing.Color.Red;
            this.bttQD.Location = new System.Drawing.Point(577, 482);
            this.bttQD.Name = "bttQD";
            this.bttQD.Size = new System.Drawing.Size(75, 23);
            this.bttQD.TabIndex = 4;
            this.bttQD.Text = "确定到餐";
            this.bttQD.UseVisualStyleBackColor = true;
            this.bttQD.Visible = false;
            this.bttQD.Click += new System.EventHandler(this.BttQD_Click);
            // 
            // 模糊订单
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 517);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bttQD);
            this.Controls.Add(this.bttDelete);
            this.Controls.Add(this.bttZaiLeiYiDan);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.lVMHB);
            this.MaximizeBox = false;
            this.Name = "模糊订单";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "模糊订单";
            this.Load += new System.EventHandler(this.模糊订单_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lVMHB;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button bttZaiLeiYiDan;
        private System.Windows.Forms.ImageList images;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bttDelete;
        private System.Windows.Forms.Button bttQD;
    }
}