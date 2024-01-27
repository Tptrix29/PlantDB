using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace PlantDB
{
    public partial class SignUp : Form
    {
        SqlConnection conn = new SqlConnection
           ("DataBase=PlantInfo; Data Source=(local); Integrated Security = True;");

        public SignUp()
        {
            InitializeComponent();
            this.Show();
            this.usrbox.Focus();
        }

        private String toHash(String passwd)
        {
            byte[] source = ASCIIEncoding.ASCII.GetBytes(passwd);
            byte[] hash = new MD5CryptoServiceProvider().ComputeHash(source);
            String output = "";
            for (int i = 0; i < hash.Length; i++)
                output += hash[i].ToString("X2");
            return output;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!check_usrname())
            {
                this.usrbox.Text = "";
                this.usrbox.Focus();
            }
            else {
                if (!check_passwd())
                {
                    this.passwdbox1.Text = "";
                    this.passwdbox2.Text = "";
                    this.passwdbox1.Focus();
                }
                else {
                    if (!check_repeatPasswd()) {
                        this.label3.Visible = true;
                        this.passwdbox2.Text = "";
                        this.passwdbox2.Focus();
                        return;
                    }
                    else
                        createAccount();
                }
            }
            this.label3.Visible = false;
        }

        private void clear_inputs() {
            this.usrbox.Text = "";
            this.passwdbox1.Text = "";
            this.passwdbox2.Text = "";
            this.usrbox.Focus();
        }

        private bool check_usrname() {
            String usrname = this.usrbox.Text.Trim();
            if (usrname.Length <= 50 && usrname.Length >= 4)
            {
                Match match = Regex.Match(usrname, @"^[_0-9a-zA-Z]+$");
                if (match.Success)
                    if (!is_usrname_exist(usrname))
                        return true;
                    else {
                        MessageBox.Show("用户名已存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                else
                {
                    MessageBox.Show("用户名包含非法字符！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else {
                MessageBox.Show("用户名长度应为4~50！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool is_usrname_exist(String name) {
            String sql = "SELECT usrname FROM Users WHERE usrname = '" + name + "';";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                conn.Close();
                return true;
            }
            else {
                conn.Close();
                return false;
            }
        }

        private bool check_passwd() {
            String passwd = this.passwdbox1.Text;
            if (passwd.Length >= 6 && passwd.Length <= 30)
            {
                Match match = Regex.Match(passwd, @"^[\d\w\W]+$");
                if (match.Success) {
                    int char_types = Convert.ToInt32(Regex.Match(passwd, @"\d").Success) +
                        Convert.ToInt32(Regex.Match(passwd, @"\w").Success) +
                        Convert.ToInt32(Regex.Match(passwd, @"\W").Success);
                    if (char_types >= 2)
                        return true;
                    else {
                        MessageBox.Show("密码应包含数字、字母、特殊符号中的至少两种！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("密码含有非法字符！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else { 
                MessageBox.Show("密码长度应为6~30！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool check_repeatPasswd() {
            String pass1 = this.passwdbox1.Text;
            String pass2 = this.passwdbox2.Text;
            if (pass1 == pass2)
                return true;
            else
                return false;
        }


        private void createAccount() {
            String usrname = this.usrbox.Text.Trim();
            String pswd = this.passwdbox1.Text;
            SqlConnection conn = new SqlConnection
                ("DataBase=PlantInfo; Data Source=(local); Integrated Security = True;");
            String sql = "INSERT INTO Users(usrname, passwd) " + 
                         "VALUES('" + usrname + "', '" + toHash(pswd) + "'); ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            DialogResult re =  MessageBox.Show("用户创建成功！\n是否返回登录界面？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (re == DialogResult.Yes)
                backToLogin();
            else
                clear_inputs();
        }

        private void back_Click(object sender, EventArgs e)
        {
            backToLogin();   
        }

        private void backToLogin() {
            Form login = new LogIn();
            this.Close();
        }
        private void usrbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (this.passwdbox1.Text == "")
                    this.passwdbox1.Focus();
                else
                    button1_Click(sender, e);
            else if (e.KeyCode == Keys.Down)
                this.passwdbox1.Focus();
            else;
        }

        private void passwdbox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (this.passwdbox2.Text == "")
                    this.passwdbox2.Focus();
                else
                    button1_Click(sender, e);
            else if (e.KeyCode == Keys.Up)
                this.usrbox.Focus();
            else if (e.KeyCode == Keys.Down)
                this.passwdbox2.Focus();
            else;
        }
        private void passwdbox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1_Click(sender, e);
            else if (e.KeyCode == Keys.Up)
                this.passwdbox1.Focus();
            else;
        }

        private void passwdbox2_TextChanged(object sender, EventArgs e)
        {
            if (!check_repeatPasswd())
                this.label3.Visible = true;
            else
                this.label3.Visible = false;
        }
    }
}
