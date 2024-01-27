namespace PlantDB
{
    partial class LogIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogIn));
            this.usrname = new System.Windows.Forms.Label();
            this.passwd = new System.Windows.Forms.Label();
            this.usrBox = new System.Windows.Forms.TextBox();
            this.passwdBox = new System.Windows.Forms.TextBox();
            this.confirm = new System.Windows.Forms.Button();
            this.tosignup = new System.Windows.Forms.Button();
            this.guest = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.slogan = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // usrname
            // 
            this.usrname.AutoSize = true;
            this.usrname.BackColor = System.Drawing.Color.Transparent;
            this.usrname.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.usrname.Location = new System.Drawing.Point(52, 82);
            this.usrname.Name = "usrname";
            this.usrname.Size = new System.Drawing.Size(96, 28);
            this.usrname.TabIndex = 0;
            this.usrname.Text = "用户名：";
            // 
            // passwd
            // 
            this.passwd.AutoSize = true;
            this.passwd.BackColor = System.Drawing.Color.Transparent;
            this.passwd.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.passwd.Location = new System.Drawing.Point(52, 148);
            this.passwd.Name = "passwd";
            this.passwd.Size = new System.Drawing.Size(75, 28);
            this.passwd.TabIndex = 1;
            this.passwd.Text = "密码：";
            // 
            // usrBox
            // 
            this.usrBox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.usrBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.usrBox.Location = new System.Drawing.Point(155, 79);
            this.usrBox.Name = "usrBox";
            this.usrBox.Size = new System.Drawing.Size(211, 35);
            this.usrBox.TabIndex = 2;
            this.usrBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.usrBox_KeyDown);
            // 
            // passwdBox
            // 
            this.passwdBox.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.passwdBox.Location = new System.Drawing.Point(155, 144);
            this.passwdBox.Name = "passwdBox";
            this.passwdBox.PasswordChar = '*';
            this.passwdBox.Size = new System.Drawing.Size(211, 35);
            this.passwdBox.TabIndex = 3;
            this.passwdBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passwdBox_KeyDown);
            // 
            // confirm
            // 
            this.confirm.BackColor = System.Drawing.Color.Honeydew;
            this.confirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.confirm.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.confirm.Location = new System.Drawing.Point(155, 207);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(136, 42);
            this.confirm.TabIndex = 4;
            this.confirm.Text = "确认登录";
            this.confirm.UseVisualStyleBackColor = false;
            this.confirm.Click += new System.EventHandler(this.confirm_Click);
            // 
            // tosignup
            // 
            this.tosignup.BackColor = System.Drawing.Color.Honeydew;
            this.tosignup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tosignup.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tosignup.Location = new System.Drawing.Point(403, 72);
            this.tosignup.Name = "tosignup";
            this.tosignup.Size = new System.Drawing.Size(85, 42);
            this.tosignup.TabIndex = 5;
            this.tosignup.Text = "注册";
            this.tosignup.UseVisualStyleBackColor = true;
            this.tosignup.Click += new System.EventHandler(this.tosignup_Click);
            // 
            // guest
            // 
            this.guest.BackColor = System.Drawing.Color.Honeydew;
            this.guest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.guest.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.guest.Location = new System.Drawing.Point(403, 143);
            this.guest.Name = "guest";
            this.guest.Size = new System.Drawing.Size(128, 42);
            this.guest.TabIndex = 6;
            this.guest.Text = "游客模式";
            this.guest.UseVisualStyleBackColor = false;
            this.guest.Click += new System.EventHandler(this.guest_Click);
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.Color.Honeydew;
            this.exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.exit.Location = new System.Drawing.Point(403, 207);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(136, 42);
            this.exit.TabIndex = 7;
            this.exit.Text = "退出";
            this.exit.UseVisualStyleBackColor = false;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // slogan
            // 
            this.slogan.AutoSize = true;
            this.slogan.BackColor = System.Drawing.Color.Transparent;
            this.slogan.Font = new System.Drawing.Font("Stencil", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slogan.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.slogan.Location = new System.Drawing.Point(119, 19);
            this.slogan.Name = "slogan";
            this.slogan.Size = new System.Drawing.Size(329, 33);
            this.slogan.TabIndex = 8;
            this.slogan.Text = "Welcome to PlantDB !";
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(593, 286);
            this.ControlBox = false;
            this.Controls.Add(this.slogan);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.guest);
            this.Controls.Add(this.tosignup);
            this.Controls.Add(this.confirm);
            this.Controls.Add(this.passwdBox);
            this.Controls.Add(this.usrBox);
            this.Controls.Add(this.passwd);
            this.Controls.Add(this.usrname);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Name = "LogIn";
            this.Text = "Log In - PlantDB";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label usrname;
        private System.Windows.Forms.Label passwd;
        private System.Windows.Forms.TextBox usrBox;
        private System.Windows.Forms.TextBox passwdBox;
        private System.Windows.Forms.Button confirm;
        private System.Windows.Forms.Button tosignup;
        private System.Windows.Forms.Button guest;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Label slogan;
    }
}