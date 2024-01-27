namespace PlantDB
{
    partial class AdminEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminEdit));
            this.back = new System.Windows.Forms.PictureBox();
            this.usrbox = new System.Windows.Forms.TextBox();
            this.usr = new System.Windows.Forms.Label();
            this.add = new System.Windows.Forms.Button();
            this.remove = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.back)).BeginInit();
            this.SuspendLayout();
            // 
            // back
            // 
            this.back.BackColor = System.Drawing.Color.Transparent;
            this.back.ErrorImage = ((System.Drawing.Image)(resources.GetObject("back.ErrorImage")));
            this.back.Image = ((System.Drawing.Image)(resources.GetObject("back.Image")));
            this.back.InitialImage = null;
            this.back.Location = new System.Drawing.Point(0, -1);
            this.back.Margin = new System.Windows.Forms.Padding(0);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(40, 40);
            this.back.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.back.TabIndex = 12;
            this.back.TabStop = false;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // usrbox
            // 
            this.usrbox.BackColor = System.Drawing.Color.Honeydew;
            this.usrbox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.usrbox.Location = new System.Drawing.Point(285, 91);
            this.usrbox.Name = "usrbox";
            this.usrbox.Size = new System.Drawing.Size(285, 35);
            this.usrbox.TabIndex = 14;
            // 
            // usr
            // 
            this.usr.AutoSize = true;
            this.usr.BackColor = System.Drawing.Color.Transparent;
            this.usr.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.usr.Location = new System.Drawing.Point(173, 94);
            this.usr.Name = "usr";
            this.usr.Size = new System.Drawing.Size(96, 28);
            this.usr.TabIndex = 13;
            this.usr.Text = "用户名：";
            // 
            // add
            // 
            this.add.BackColor = System.Drawing.Color.Honeydew;
            this.add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.add.Location = new System.Drawing.Point(213, 165);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(136, 91);
            this.add.TabIndex = 15;
            this.add.Text = "给予\r\n管理员权限";
            this.add.UseVisualStyleBackColor = false;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // remove
            // 
            this.remove.BackColor = System.Drawing.Color.Honeydew;
            this.remove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.remove.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.remove.Location = new System.Drawing.Point(403, 165);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(141, 91);
            this.remove.TabIndex = 16;
            this.remove.Text = "删除\r\n管理员权限";
            this.remove.UseVisualStyleBackColor = false;
            this.remove.Click += new System.EventHandler(this.remove_Click);
            // 
            // AdminEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(745, 321);
            this.ControlBox = false;
            this.Controls.Add(this.remove);
            this.Controls.Add(this.add);
            this.Controls.Add(this.usrbox);
            this.Controls.Add(this.usr);
            this.Controls.Add(this.back);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminEdit";
            this.Text = "管理员权限操作";
            ((System.ComponentModel.ISupportInitialize)(this.back)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox back;
        private System.Windows.Forms.TextBox usrbox;
        private System.Windows.Forms.Label usr;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button remove;
    }
}