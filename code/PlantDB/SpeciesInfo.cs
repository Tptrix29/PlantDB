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
using System.IO;
using System.Diagnostics;


namespace PlantDB
{
    public partial class SpeciesInfo : Form
    {
        SqlConnection conn = new SqlConnection
            ("DataBase=PlantInfo; Data Source=(local); Integrated Security = True;");
        private String usr_mode, usrname, card_id;
        private String new_pic1_path = "", new_pic2_path = "";
        bool isAddition;

        public SpeciesInfo(String spname, String mode, String usrname, bool isAddition = false)
        {
            InitializeComponent();
            usr_mode = mode;
            this.usrname = usrname;
            this.label11.Text += usrname + "!";
            this.isAddition = isAddition;
            if (isAddition)
            {
                isEditable(true);
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                linkLabel1.Visible = false;
                addNote.Visible = true;
                textBox8.Text = "输入新链接";
                textBox8.ForeColor = Color.Gray;
                textBox7.Text = "不超过600字";
                textBox7.ForeColor = Color.Gray;
            }
            else {
                load_info(spname);
                load_comments(new Point(25, 450), 100);
                if (mode == "A" || mode == "R") checkBox1.Visible = true;
            }
            this.Show();
        }

        private void load_info(String name) {
            this.Text += '-' + name;
            this.label8.Text += name;
            this.label9.Text += name;

            conn.Open();
            String sql = "SELECT spid, sname, nickname, sLatin, family, env, region, specimen_img, colorful_img, sdesp, link " +
                "FROM Species WHERE sname = '" + name + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                card_id = dr["spid"].ToString();
                this.textBox1.Text = dr["sname"].ToString();
                this.textBox2.Text = dr["sLatin"].ToString();
                this.textBox3.Text = dr["env"].ToString();
                this.textBox4.Text = dr["nickname"].ToString();
                this.textBox5.Text = dr["family"].ToString();
                this.textBox6.Text = dr["region"].ToString();
                this.textBox7.Text = dr["sdesp"].ToString();
                this.linkLabel1.Tag = dr["link"].ToString();

                if (!Convert.IsDBNull(dr["specimen_img"])) {
                    byte[] img1 = (byte[])dr["specimen_img"];
                    MemoryStream stream1 = new MemoryStream(img1);
                    this.pictureBox1.Image = Image.FromStream(stream1, true);
                    stream1.Close();
                }
                if (!Convert.IsDBNull(dr["colorful_img"]))
                {
                    byte[] img2 = (byte[])dr["colorful_img"];
                    MemoryStream stream2 = new MemoryStream(img2);
                    this.pictureBox2.Image = Image.FromStream(stream2, true);
                    stream2.Close();
                }

                this.button1.Text += this.textBox5.Text;
            }
            else {
                MessageBox.Show("No such species!");
            }
            conn.Close();
        }

        private void load_comments(Point start, int height)
        {
            String sql = "SELECT usrname AS name, content AS comment, lastEditTime AS time" +
                " FROM SNotes LEFT JOIN Users ON SNotes.usrid = Users.usrid" +
                " WHERE isPublic = 1 AND spid = '" + card_id + "' ORDER BY time DESC; ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            int index = 0;
            while (reader.Read())
            {
                this.Controls.Add(new CommentBar(reader["name"].ToString(),
                                            reader["comment"].ToString(),
                                            reader["time"].ToString(), start.X, start.Y + height * index++));
            }
            conn.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form family = new FamilyInfo(this.textBox5.Text, usr_mode, usrname);
            family.Show();
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(linkLabel1.Tag.ToString());
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form home = new Home(usr_mode, usrname);
            this.Close();
        }

        private void 关闭程序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form note;
            if (usr_mode == "Guest") {
                DialogResult re = MessageBox.Show("当前为游客登录，请先创建账号！\n是否转到注册界面？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (re == DialogResult.Yes)
                    note = new SignUp();
                else return;
            }
            else note = new NoteEdit(usr_mode, usrname, this.textBox1.Text, 'S', '0');
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form note;
            if (usr_mode == "Guest")
            {
                DialogResult re = MessageBox.Show("当前为游客登录，请先创建账号！\n是否转到注册界面？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (re == DialogResult.Yes)
                    note = new SignUp();
                else return;
            }
            else note = new NoteEdit(usr_mode, usrname, this.textBox1.Text, 'S', '1');
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            isEditable(checkBox1.Checked);
        }

        private void isEditable(bool tick) {
            textBox1.ReadOnly = !tick;
            textBox2.ReadOnly = !tick;
            textBox3.ReadOnly = !tick;
            textBox4.ReadOnly = !tick;
            textBox5.ReadOnly = !tick;
            textBox6.ReadOnly = !tick;
            textBox7.ReadOnly = !tick;

            textBox8.Visible = tick;
            textBox8.Text = linkLabel1.Tag.ToString();
            button4.Visible = tick;
            button5.Visible = tick;
            save.Visible = tick;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog pic2 = new OpenFileDialog();
            pic2.Filter = "Pictures (*.jpg;*.png)|*.jpg;*.png";
            pic2.FilterIndex = 0;
            if (pic2.ShowDialog() == DialogResult.OK)
                this.pictureBox2.Load(this.new_pic2_path = pic2.FileName);
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (isAddition)
                insertNewInfo();
            else
                updateInfo();
        }

        private void updateInfo() {
            String sql = "UPDATE Species " +
                "SET sname = '" + textBox1.Text + "', " +
                "sLatin = '" + textBox2.Text + "', " +
                "env = '" + textBox3.Text + "', " +
                "nickname = '" + textBox4.Text + "', " +
                "family = '" + textBox5.Text + "', " +
                "region = '" + textBox6.Text + "', " +
                "sdesp = '" + textBox7.Text + "', " +
                "link = '" + textBox8.Text + "', " +
                "lastEditTime = GETDATE()";
            if (new_pic1_path != "")
                sql += ", specimen_img = " +
                    "(SELECT * FROM OPENROWSET(BULK '" + new_pic1_path + "', SINGLE_BLOB) AS img1)";
            if (new_pic2_path != "")
                sql += ", colorful_img = " +
                    "(SELECT * FROM OPENROWSET(BULK '" + new_pic2_path + "', SINGLE_BLOB) AS img2)";
            sql += " WHERE spid = '" + card_id + "';";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("数据更新成功！");
        }

        private void insertNewInfo() {
            if (textBox1.Text == "")
            {
                MessageBox.Show("物种名必须填写！");
                textBox1.Focus();
                return;
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("学名必须填写！");
                textBox2.Focus();
                return;
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("生长环境必须填写！");
                textBox3.Focus();
                return;
            }
            else if (textBox7.Text == "")
            {
                MessageBox.Show("基本描述必须填写！");
                textBox7.Focus();
                return;
            }
            else if (textBox3.Text.Trim().Length > 600)
            {
                MessageBox.Show("基本描述不应超过600字！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("科必须填写！");
                textBox5.Focus();
                return;
            }
            else if (isNewFamily(textBox5.Text.Trim())) {
                DialogResult re = MessageBox.Show("检测到新的科！\n请先添加该科相关条目，是否跳转？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question); ;
                Form add;
                if (re == DialogResult.Yes) {
                    add = new FamilyInfo("new", usr_mode, usrname, true);
                    this.Close();
                }
                return;
            }
            else if (textBox6.Text == "")
            {
                MessageBox.Show("分布地域必须填写！");
                textBox6.Focus();
                return;
            }
            else;
            String pic1_val, pic2_val, link_val, nickname_val;
            if (new_pic1_path == "") pic1_val = "NULL"; else pic1_val = "(SELECT * FROM OPENROWSET(BULK '" + new_pic1_path + "', SINGLE_BLOB) AS img1)";
            if (new_pic2_path == "") pic2_val = "NULL"; else pic2_val = "(SELECT * FROM OPENROWSET(BULK '" + new_pic2_path + "', SINGLE_BLOB) AS img1)";
            if (textBox4.Text == "") nickname_val = "NULL"; else nickname_val = "'" + textBox4.Text + "'";
            if (textBox8.Text == "" || textBox8.Text == "输入新链接") link_val = "NULL"; else link_val = "'" + textBox8.Text + "'";
            String sql = "INSERT INTO Species(sname, sLatin, family, env, region, sdesp, nickname, link, specimen_img, colorful_img) " +
                "VALUES('" + textBox1.Text.Trim() + "', '" +
                textBox2.Text.Trim() + "', '" +
                textBox5.Text.Trim() + "', '" +
                textBox3.Text.Trim() + "', '" +
                textBox6.Text.Trim() + "', '" +
                textBox7.Text.Trim() + "', " + nickname_val + ", " + link_val + ", " + pic1_val + ", " + pic2_val + ");";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("添加成功！");
            Form home = new Home(usr_mode, usrname);
            this.Close();
        }

        private void textBox8_MouseClick(object sender, MouseEventArgs e)
        {
            if (isAddition)
            {
                textBox8.ForeColor = Color.Black;
                textBox8.Text = "";
            }
        }

        private void textBox7_Click(object sender, EventArgs e)
        {
            if (isAddition)
            {
                textBox7.ForeColor = Color.Black;
                textBox7.Text = "";
            }
        }

        private bool isNewFamily(String fname) {
            String sql = "SELECT fname FROM Family WHERE fname = '" + fname + "';";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            bool re = !rd.HasRows;
            conn.Close();
            return re;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog pic1 = new OpenFileDialog();
            pic1.Filter = "Pictures (*.jpg;*.png)|*.jpg;*.png";
            pic1.FilterIndex = 0;
            if (pic1.ShowDialog() == DialogResult.OK)
                this.pictureBox1.Load(this.new_pic1_path = pic1.FileName);
        }

        private void 检索ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form search = new Retrieve(usr_mode, usrname);
            this.Close();
        }
    }
}
