namespace PlantDB
{
    partial class Home
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.检索ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.建议版面ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.物种ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.科ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出笔记ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.物种笔记ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.科笔记ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.登陆ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出登录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭程序ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.用户管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.检索ToolStripMenuItem,
            this.建议版面ToolStripMenuItem,
            this.导出笔记ToolStripMenuItem,
            this.登陆ToolStripMenuItem,
            this.退出登录ToolStripMenuItem,
            this.关闭程序ToolStripMenuItem,
            this.用户管理ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(10, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(889, 37);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 检索ToolStripMenuItem
            // 
            this.检索ToolStripMenuItem.Name = "检索ToolStripMenuItem";
            this.检索ToolStripMenuItem.Size = new System.Drawing.Size(62, 29);
            this.检索ToolStripMenuItem.Text = "检索";
            this.检索ToolStripMenuItem.Click += new System.EventHandler(this.检索ToolStripMenuItem_Click);
            // 
            // 建议版面ToolStripMenuItem
            // 
            this.建议版面ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.物种ToolStripMenuItem,
            this.科ToolStripMenuItem});
            this.建议版面ToolStripMenuItem.Name = "建议版面ToolStripMenuItem";
            this.建议版面ToolStripMenuItem.Size = new System.Drawing.Size(98, 29);
            this.建议版面ToolStripMenuItem.Text = "增加条目";
            // 
            // 物种ToolStripMenuItem
            // 
            this.物种ToolStripMenuItem.Name = "物种ToolStripMenuItem";
            this.物种ToolStripMenuItem.Size = new System.Drawing.Size(146, 34);
            this.物种ToolStripMenuItem.Text = "物种";
            this.物种ToolStripMenuItem.Click += new System.EventHandler(this.物种ToolStripMenuItem_Click);
            // 
            // 科ToolStripMenuItem
            // 
            this.科ToolStripMenuItem.Name = "科ToolStripMenuItem";
            this.科ToolStripMenuItem.Size = new System.Drawing.Size(146, 34);
            this.科ToolStripMenuItem.Text = "科";
            this.科ToolStripMenuItem.Click += new System.EventHandler(this.科ToolStripMenuItem_Click);
            // 
            // 导出笔记ToolStripMenuItem
            // 
            this.导出笔记ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.物种笔记ToolStripMenuItem,
            this.科笔记ToolStripMenuItem});
            this.导出笔记ToolStripMenuItem.Name = "导出笔记ToolStripMenuItem";
            this.导出笔记ToolStripMenuItem.Size = new System.Drawing.Size(98, 29);
            this.导出笔记ToolStripMenuItem.Text = "导出笔记";
            // 
            // 物种笔记ToolStripMenuItem
            // 
            this.物种笔记ToolStripMenuItem.Name = "物种笔记ToolStripMenuItem";
            this.物种笔记ToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.物种笔记ToolStripMenuItem.Text = "物种笔记";
            this.物种笔记ToolStripMenuItem.Click += new System.EventHandler(this.物种笔记ToolStripMenuItem_Click);
            // 
            // 科笔记ToolStripMenuItem
            // 
            this.科笔记ToolStripMenuItem.Name = "科笔记ToolStripMenuItem";
            this.科笔记ToolStripMenuItem.Size = new System.Drawing.Size(182, 34);
            this.科笔记ToolStripMenuItem.Text = "科笔记";
            this.科笔记ToolStripMenuItem.Click += new System.EventHandler(this.科笔记ToolStripMenuItem_Click);
            // 
            // 登陆ToolStripMenuItem
            // 
            this.登陆ToolStripMenuItem.Name = "登陆ToolStripMenuItem";
            this.登陆ToolStripMenuItem.Size = new System.Drawing.Size(62, 29);
            this.登陆ToolStripMenuItem.Text = "登陆";
            this.登陆ToolStripMenuItem.Click += new System.EventHandler(this.登陆ToolStripMenuItem_Click);
            // 
            // 退出登录ToolStripMenuItem
            // 
            this.退出登录ToolStripMenuItem.Name = "退出登录ToolStripMenuItem";
            this.退出登录ToolStripMenuItem.Size = new System.Drawing.Size(98, 29);
            this.退出登录ToolStripMenuItem.Text = "退出登录";
            this.退出登录ToolStripMenuItem.Click += new System.EventHandler(this.退出登录ToolStripMenuItem_Click);
            // 
            // 关闭程序ToolStripMenuItem
            // 
            this.关闭程序ToolStripMenuItem.Name = "关闭程序ToolStripMenuItem";
            this.关闭程序ToolStripMenuItem.Size = new System.Drawing.Size(98, 29);
            this.关闭程序ToolStripMenuItem.Text = "关闭程序";
            this.关闭程序ToolStripMenuItem.Click += new System.EventHandler(this.关闭程序ToolStripMenuItem_Click);
            // 
            // 用户管理ToolStripMenuItem
            // 
            this.用户管理ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.用户管理ToolStripMenuItem.Name = "用户管理ToolStripMenuItem";
            this.用户管理ToolStripMenuItem.Size = new System.Drawing.Size(136, 29);
            this.用户管理ToolStripMenuItem.Text = "用户权限管理";
            this.用户管理ToolStripMenuItem.Click += new System.EventHandler(this.用户管理ToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(0, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(876, 40);
            this.label1.TabIndex = 1;
            this.label1.Text = "Welcome, ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataGridView1.Location = new System.Drawing.Point(46, 150);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(808, 359);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(48, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(375, 28);
            this.label2.TabIndex = 11;
            this.label2.Text = "提示：选择一个物种 或 转到检索界面...";
            // 
            // Home
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(889, 528);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Home";
            this.Text = "Home - PlantDB";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 检索ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 建议版面ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出笔记ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出登录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭程序ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 登陆ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem 用户管理ToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem 物种ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 科ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 物种笔记ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 科笔记ToolStripMenuItem;
    }
}

