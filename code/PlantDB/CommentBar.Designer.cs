namespace PlantDB
{
    partial class CommentBar
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.usr = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // usr
            // 
            this.usr.AutoSize = true;
            this.usr.BackColor = System.Drawing.Color.Transparent;
            this.usr.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.usr.Location = new System.Drawing.Point(4, 4);
            this.usr.Name = "usr";
            this.usr.Size = new System.Drawing.Size(84, 27);
            this.usr.TabIndex = 0;
            this.usr.Text = "label1";
            // 
            // time
            // 
            this.time.AutoSize = true;
            this.time.BackColor = System.Drawing.Color.Transparent;
            this.time.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.time.Location = new System.Drawing.Point(6, 37);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(70, 24);
            this.time.TabIndex = 2;
            this.time.Text = "label2";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Honeydew;
            this.textBox1.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(10, 68);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(654, 81);
            this.textBox1.TabIndex = 1;
            // 
            // CommentBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.time);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.usr);
            this.Name = "CommentBar";
            this.Size = new System.Drawing.Size(680, 159);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label usr;
        private System.Windows.Forms.Label time;
        private System.Windows.Forms.TextBox textBox1;
    }
}
