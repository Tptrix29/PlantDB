using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Security.Cryptography;

namespace PlantDB
{

    public partial class LogIn : Form
    {
        SqlConnection conn = new SqlConnection
            ("DataBase=PlantInfo; Data Source=(local); Integrated Security = True;");

        public LogIn()
        {
            InitializeComponent();
            this.Show();
            this.usrBox.Focus();
           
        }

        private String toHash(String passwd) {
            byte[] source = ASCIIEncoding.ASCII.GetBytes(passwd);
            byte[] hash = new MD5CryptoServiceProvider().ComputeHash(source);
            String output = "";
            for (int i = 0; i < hash.Length; i++)
                output += hash[i].ToString("X2");
            return output;
        }

        private void tosignup_Click(object sender, EventArgs e)
        {
            Form signup_page = new SignUp();
            this.Close();
        }

        private void guest_Click(object sender, EventArgs e)
        {
            Form guestHome = new Home("Guest", "Guest");
            this.Close();
            MessageBox.Show("欢迎，游客！");
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            if (check_pass()) { 
                update_loginTime();
                this.Close();
            }
        }
        
        private void update_loginTime() {
            String usrname = this.usrBox.Text.Trim();
            String passHash = toHash(this.passwdBox.Text.Trim());
            String sql = "EXEC update_loginTime '" + usrname + "', '" + passHash + "';";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private bool check_pass() { 
            String usr_input = this.usrBox.Text.Trim();
            String sql = "SELECT usrname FROM Users WHERE usrname = '" + usr_input + "';";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                conn.Close();
                String pswd_input = toHash(this.passwdBox.Text);
                sql = "SELECT usrname, passwd, accessibility FROM Users " +
                    "WHERE usrname = '" + usr_input + "' AND passwd = '" + pswd_input + "';";
                conn.Open();
                cmd = new SqlCommand(sql, conn);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    Form home = new Home(dr[2].ToString(), dr[0].ToString());
                    conn.Close();
                    this.Visible = false;
                    MessageBox.Show("欢迎！" + usr_input + "!");
                    return true;
                }
                else {
                    conn.Close();
                    MessageBox.Show("密码错误！\n请重新输入");
                    this.passwdBox.Text = "";
                    return false;
                }
            }
            else {
                conn.Close();
                MessageBox.Show("用户不存在！\n请重新输入 或 注册用户");
                clear_boxes();
                return false;
            }
        }

        private void clear_boxes() {
            this.usrBox.Text = "";
            this.passwdBox.Text = "";
        }


        private void usrBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
                if (this.passwdBox.Text == "")
                    this.passwdBox.Focus();
                else
                    confirm_Click(sender, e);
        }

        private void passwdBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
                confirm_Click(sender, e);
            
        }
    }
}
