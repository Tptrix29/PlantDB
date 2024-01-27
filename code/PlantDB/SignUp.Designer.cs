namespace PlantDB
{
    partial class SignUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignUp));
            this.passwdbox1 = new System.Windows.Forms.TextBox();
            this.usrbox = new System.Windows.Forms.TextBox();
            this.passwd = new System.Windows.Forms.Label();
            this.usrname = new System.Windows.Forms.Label();
            this.passwdbox2 = new System.Windows.Forms.TextBox();
            this.confirm = new System.Windows.Forms.Label();
            this.comfirmbtn = new System.Windows.Forms.Button();
            this.back = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.back)).BeginInit();
            this.SuspendLayout();
            // 
            // passwdbox1
            // 
            this.passwdbox1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.passwdbox1.Location = new System.Drawing.Point(214, 179);
            this.passwdbox1.Name = "passwdbox1";
            this.passwdbox1.PasswordChar = '*';
            this.passwdbox1.Size = new System.Drawing.Size(285, 35);
            this.passwdbox1.TabIndex = 7;
            this.passwdbox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passwdbox1_KeyDown);
            // 
            // usrbox
            // 
            this.usrbox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.usrbox.Location = new System.Drawing.Point(214, 93);
            this.usrbox.Name = "usrbox";
            this.usrbox.Size = new System.Drawing.Size(285, 35);
            this.usrbox.TabIndex = 6;
            this.usrbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.usrbox_KeyDown);
            // 
            // passwd
            // 
            this.passwd.AutoSize = true;
            this.passwd.BackColor = System.Drawing.Color.Transparent;
            this.passwd.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.passwd.Location = new System.Drawing.Point(123, 186);
            this.passwd.Name = "passwd";
            this.passwd.Size = new System.Drawing.Size(75, 28);
            this.passwd.TabIndex = 5;
            this.passwd.Text = "密码：";
            // 
            // usrname
            // 
            this.usrname.AutoSize = true;
            this.usrname.BackColor = System.Drawing.Color.Transparent;
            this.usrname.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.usrname.Location = new System.Drawing.Point(102, 96);
            this.usrname.Name = "usrname";
            this.usrname.Size = new System.Drawing.Size(96, 28);
            this.usrname.TabIndex = 4;
            this.usrname.Text = "用户名：";
            // 
            // passwdbox2
            // 
            this.passwdbox2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.passwdbox2.Location = new System.Drawing.Point(214, 272);
            this.passwdbox2.Name = "passwdbox2";
            this.passwdbox2.PasswordChar = '*';
            this.passwdbox2.Size = new System.Drawing.Size(285, 35);
            this.passwdbox2.TabIndex = 9;
            this.passwdbox2.TextChanged += new System.EventHandler(this.passwdbox2_TextChanged);
            this.passwdbox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passwdbox2_KeyDown);
            // 
            // confirm
            // 
            this.confirm.AutoSize = true;
            this.confirm.BackColor = System.Drawing.Color.Transparent;
            this.confirm.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.confirm.Location = new System.Drawing.Point(81, 272);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(117, 28);
            this.confirm.TabIndex = 8;
            this.confirm.Text = "确认密码：";
            // 
            // comfirmbtn
            // 
            this.comfirmbtn.BackColor = System.Drawing.Color.Honeydew;
            this.comfirmbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comfirmbtn.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comfirmbtn.Location = new System.Drawing.Point(236, 334);
            this.comfirmbtn.Name = "comfirmbtn";
            this.comfirmbtn.Size = new System.Drawing.Size(136, 42);
            this.comfirmbtn.TabIndex = 10;
            this.comfirmbtn.Text = "确认";
            this.comfirmbtn.UseVisualStyleBackColor = false;
            this.comfirmbtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // back
            // 
            this.back.BackColor = System.Drawing.Color.Transparent;
            this.back.ErrorImage = null;
            this.back.Image = ((System.Drawing.Image)(resources.GetObject("back.Image")));
            this.back.InitialImage = null;
            this.back.Location = new System.Drawing.Point(0, 0);
            this.back.Margin = new System.Windows.Forms.Padding(0);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(40, 40);
            this.back.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.back.TabIndex = 11;
            this.back.TabStop = false;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(521, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 59);
            this.label1.TabIndex = 12;
            this.label1.Text = "请输入4~50字的字符串，可包含字母、数字和下划线";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(521, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(322, 58);
            this.label2.TabIndex = 13;
            this.label2.Text = "请输入6~30字的英文字符串，包含字母、数字、特殊符号中的至少两种";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.IndianRed;
            this.label3.Location = new System.Drawing.Point(216, 242);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(280, 24);
            this.label3.TabIndex = 14;
            this.label3.Text = "两次密码输入不一致，请重新输入";
            this.label3.Visible = false;
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.BackColor = System.Drawing.Color.Transparent;
            this.title.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.title.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.title.Location = new System.Drawing.Point(209, 22);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(485, 42);
            this.title.TabIndex = 15;
            this.title.Text = "注册你的 PlantDB 账号——";
            // 
            // SignUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(866, 446);
            this.ControlBox = false;
            this.Controls.Add(this.title);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.back);
            this.Controls.Add(this.comfirmbtn);
            this.Controls.Add(this.passwdbox2);
            this.Controls.Add(this.confirm);
            this.Controls.Add(this.passwdbox1);
            this.Controls.Add(this.usrbox);
            this.Controls.Add(this.passwd);
            this.Controls.Add(this.usrname);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SignUp";
            this.Text = "Sign Up - PlantDB";
            ((System.ComponentModel.ISupportInitialize)(this.back)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox passwdbox1;
        private System.Windows.Forms.TextBox usrbox;
        private System.Windows.Forms.Label passwd;
        private System.Windows.Forms.Label usrname;
        private System.Windows.Forms.TextBox passwdbox2;
        private System.Windows.Forms.Label confirm;
        private System.Windows.Forms.Button comfirmbtn;
        private System.Windows.Forms.PictureBox back;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label title;
    }
}