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

namespace PlantDB
{
    public partial class AdminEdit : Form
    {
        SqlConnection conn = new SqlConnection
           ("DataBase=PlantInfo; Data Source=(local); Integrated Security = True;");

        String usrname, usr_mode;
        public AdminEdit(String mode, String usrname)
        {
            InitializeComponent();
            this.usrname = usrname;
            this.usr_mode = mode;
            this.Show();
            this.usrbox.Focus();
        }

        private void add_Click(object sender, EventArgs e)
        {
            String aim_usr = this.usrbox.Text.Trim();
            if (!is_usrname_exist(aim_usr))
                MessageBox.Show("该用户不存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (aim_usr == "ROOT")
                MessageBox.Show("不可对ROOT进行操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                update_accessibility('A');
                MessageBox.Show("成功添加！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.usrbox.Text = "";
            this.usrbox.Focus();
        }

        private void remove_Click(object sender, EventArgs e)
        {
            String aim_usr = this.usrbox.Text.Trim();
            if (!is_usrname_exist(aim_usr))
                MessageBox.Show("该用户不存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if(aim_usr == "ROOT")
                MessageBox.Show("不可对ROOT进行操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                update_accessibility('C');
                MessageBox.Show("成功移除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.usrbox.Text = "";
            this.usrbox.Focus();
        }

        private void update_accessibility(char mode) {
            String aim_usr = this.usrbox.Text.Trim();
            String sql = "UPDATE Users SET accessibility = '" + mode + "' WHERE usrname = '" + aim_usr + "';";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private bool is_usrname_exist(String name)
        {
            String sql = "SELECT usrname FROM Users WHERE usrname = '" + name + "';";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                conn.Close();
                return true;
            }
            else
            {
                conn.Close();
                return false;
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            Form home = new Home(usr_mode, usrname);
            this.Close();
        }
    }
}
