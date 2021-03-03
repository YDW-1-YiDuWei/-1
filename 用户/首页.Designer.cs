namespace 点餐系统
{
    partial class 首页
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(首页));
            this.lblmy = new System.Windows.Forms.Label();
            this.lblindent = new System.Windows.Forms.Label();
            this.lblreturn = new System.Windows.Forms.Label();
            this.lblexit = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnbegin = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblmy
            // 
            this.lblmy.AutoSize = true;
            this.lblmy.BackColor = System.Drawing.Color.White;
            this.lblmy.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblmy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblmy.Location = new System.Drawing.Point(464, 140);
            this.lblmy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblmy.Name = "lblmy";
            this.lblmy.Size = new System.Drawing.Size(73, 30);
            this.lblmy.TabIndex = 1;
            this.lblmy.Text = "我的";
            this.lblmy.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblindent
            // 
            this.lblindent.AutoSize = true;
            this.lblindent.BackColor = System.Drawing.Color.White;
            this.lblindent.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblindent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblindent.Location = new System.Drawing.Point(249, 304);
            this.lblindent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblindent.Name = "lblindent";
            this.lblindent.Size = new System.Drawing.Size(73, 30);
            this.lblindent.TabIndex = 2;
            this.lblindent.Text = "订单";
            this.lblindent.Click += new System.EventHandler(this.Label2_Click);
            // 
            // lblreturn
            // 
            this.lblreturn.AutoSize = true;
            this.lblreturn.BackColor = System.Drawing.Color.White;
            this.lblreturn.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblreturn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblreturn.Location = new System.Drawing.Point(464, 531);
            this.lblreturn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblreturn.Name = "lblreturn";
            this.lblreturn.Size = new System.Drawing.Size(73, 30);
            this.lblreturn.TabIndex = 4;
            this.lblreturn.Text = "返回";
            this.lblreturn.Click += new System.EventHandler(this.label4_Click);
            // 
            // lblexit
            // 
            this.lblexit.AutoSize = true;
            this.lblexit.BackColor = System.Drawing.Color.White;
            this.lblexit.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblexit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblexit.Location = new System.Drawing.Point(700, 304);
            this.lblexit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblexit.Name = "lblexit";
            this.lblexit.Size = new System.Drawing.Size(73, 30);
            this.lblexit.TabIndex = 3;
            this.lblexit.Text = "退出";
            this.lblexit.Click += new System.EventHandler(this.label5_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1, -2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1008, 676);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnbegin
            // 
            this.btnbegin.BackColor = System.Drawing.Color.Transparent;
            this.btnbegin.Image = ((System.Drawing.Image)(resources.GetObject("btnbegin.Image")));
            this.btnbegin.Location = new System.Drawing.Point(391, 318);
            this.btnbegin.Margin = new System.Windows.Forms.Padding(4);
            this.btnbegin.Name = "btnbegin";
            this.btnbegin.Size = new System.Drawing.Size(240, 62);
            this.btnbegin.TabIndex = 0;
            this.btnbegin.UseVisualStyleBackColor = false;
            this.btnbegin.Click += new System.EventHandler(this.button1_Click);
            // 
            // 首页
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 676);
            this.Controls.Add(this.btnbegin);
            this.Controls.Add(this.lblexit);
            this.Controls.Add(this.lblreturn);
            this.Controls.Add(this.lblindent);
            this.Controls.Add(this.lblmy);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "首页";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "首页";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblmy;
        private System.Windows.Forms.Label lblindent;
        private System.Windows.Forms.Label lblreturn;
        private System.Windows.Forms.Label lblexit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnbegin;
    }
}