﻿namespace 点餐系统
{
    partial class 餐馆列表
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSJ = new System.Windows.Forms.TextBox();
            this.btnquery = new System.Windows.Forms.Button();
            this.lvSJXX = new System.Windows.Forms.ListView();
            this.image = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(441, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "（支持模糊查询）";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(124, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "搜索商家：";
            // 
            // txtSJ
            // 
            this.txtSJ.Location = new System.Drawing.Point(195, 9);
            this.txtSJ.Name = "txtSJ";
            this.txtSJ.Size = new System.Drawing.Size(240, 21);
            this.txtSJ.TabIndex = 5;
            // 
            // btnquery
            // 
            this.btnquery.Location = new System.Drawing.Point(552, 9);
            this.btnquery.Name = "btnquery";
            this.btnquery.Size = new System.Drawing.Size(75, 23);
            this.btnquery.TabIndex = 9;
            this.btnquery.Text = "查询";
            this.btnquery.UseVisualStyleBackColor = true;
            this.btnquery.Click += new System.EventHandler(this.button1_Click);
            // 
            // lvSJXX
            // 
            this.lvSJXX.FullRowSelect = true;
            this.lvSJXX.HideSelection = false;
            this.lvSJXX.LargeImageList = this.image;
            this.lvSJXX.Location = new System.Drawing.Point(12, 54);
            this.lvSJXX.Name = "lvSJXX";
            this.lvSJXX.Size = new System.Drawing.Size(666, 479);
            this.lvSJXX.SmallImageList = this.image;
            this.lvSJXX.StateImageList = this.image;
            this.lvSJXX.TabIndex = 10;
            this.lvSJXX.UseCompatibleStateImageBehavior = false;
            this.lvSJXX.View = System.Windows.Forms.View.List;
            this.lvSJXX.Click += new System.EventHandler(this.lvSJXX_Click);
            // 
            // image
            // 
            this.image.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.image.ImageSize = new System.Drawing.Size(90, 90);
            this.image.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // 餐馆列表
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 544);
            this.Controls.Add(this.lvSJXX);
            this.Controls.Add(this.btnquery);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSJ);
            this.MaximizeBox = false;
            this.Name = "餐馆列表";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "餐馆列表";
            this.Load += new System.EventHandler(this.餐馆列表_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSJ;
        private System.Windows.Forms.Button btnquery;
        private System.Windows.Forms.ListView lvSJXX;
        private System.Windows.Forms.ImageList image;
    }
}