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
using System.Diagnostics;

namespace PlantDB
{
    public partial class FamilyInfo : Form
    {
        SqlConnection conn = new SqlConnection
            ("DataBase=PlantInfo; Data Source=(local); Integrated Security = True;");
        private String usr_mode, usrname, card_id;
        bool isAddition;

        public FamilyInfo(String fname, String mode, String usrname, bool isAddition = false)
        {
            InitializeComponent();
            usr_mode = mode;
            this.usrname = usrname;
            this.label5.Text += usrname + "!";
            this.isAddition = isAddition;
            if (isAddition)
            {
                isEditable(true);
                button1.Visible = false;
                button2.Visible = false;
                linkLabel1.Visible = false;
                dataGridView1.Visible = false;
                label4.Visible = false;
                addNote.Visible = true;
                textBox4.Text = "输入新链接";
                textBox3.Text = "不超过500字";
                textBox4.ForeColor = Color.Gray;
                textBox3.ForeColor = Color.Gray;
            }
            else {
                load_info(fname);
                load_comments(new Point(25, 380), 100);
                if (mode == "R" || mode == "A") checkBox1.Visible = true;
            }
            this.Show();
        }

        private void load_comments(Point start, int height) {
            String sql = "SELECT usrname AS name, content AS comment, lastEditTime AS time" +
                " FROM FNotes LEFT JOIN Users ON FNotes.usrid = Users.usrid" + 
                " WHERE isPublic = 1 AND fid = '" + card_id + "' ORDER BY time DESC; ";
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

        private void load_info(String name) {
            this.Text += '-' + name;

            conn.Open();
            String sql = "SELECT fid, fname, fLatin, fdesp, link " +
                "FROM Family WHERE fname = '" + name + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                card_id = dr["fid"].ToString();
                this.textBox1.Text = dr["fname"].ToString();
                this.textBox2.Text = dr["fLatin"].ToString();
                this.textBox3.Text = dr["fdesp"].ToString();
                this.linkLabel1.Tag = dr["link"].ToString();

                conn.Close();

                String related_species = "SELECT sname AS '物种名' FROM Species " +
                "WHERE family = '" + textBox1.Text + "';";
                SqlDataAdapter adapter = new SqlDataAdapter(related_species, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    DataTable dt = ds.Tables[0].DefaultView.ToTable(false, new String[] { "物种名" });
                    dataGridView1.DataSource = dt.DefaultView;
                }
            }
            else
            {
                MessageBox.Show("No such Family!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form note;
            if (usr_mode == "Guest")
            {
                DialogResult re = MessageBox.Show("当前为游客登录，请先创建账号！\n是否转到注册界面？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (re == DialogResult.Yes)
                    note = new SignUp();
                else return;
            }
            else note = new NoteEdit(usr_mode, usrname, this.textBox1.Text, 'F', '0');
            this.Close();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form home = new Home(usr_mode, usrname);
            this.Close();
        }

        private void 检索ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form search = new Retrieve(usr_mode, usrname);
            this.Close();
        }

        private void 关闭程序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                String spname = this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                Form species = new SpeciesInfo(spname, usr_mode, usrname);
                this.Close();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            isEditable(checkBox1.Checked);
        }

        private void isEditable(bool tick) {
            textBox1.ReadOnly = !tick;
            textBox2.ReadOnly = !tick;
            textBox3.ReadOnly = !tick;
            textBox4.Visible = tick;
            textBox4.Text = linkLabel1.Tag.ToString();
            save.Visible = tick;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form note;
            if (usr_mode == "Guest")
            {
                DialogResult re = MessageBox.Show("当前为游客登录，请先创建账号！\n是否转到注册界面？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (re == DialogResult.Yes)
                    note = new SignUp();
                else return;
            }
            else note = new NoteEdit(usr_mode, usrname, this.textBox1.Text, 'F', '1');
            this.Close();
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (isAddition)
                insertInfo();
            else
                updateInfo();
        }

        private void updateInfo() {
            
            linkLabel1.Tag = textBox4.Text;
            String sql = "UPDATE Family " +
                "SET fname = '" + textBox1.Text + "', link = '" + textBox4.Text + "', " +
                "fLatin = '" + textBox2.Text + "', fdesp = '" + textBox3.Text + "', lastEditTime = GETDATE() " +
                "WHERE fid = '" + card_id + "';";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            Form card = new FamilyInfo(textBox1.Text, usr_mode, usrname);
            this.Close();
        }


        private void textBox4_Click(object sender, EventArgs e)
        {
            if (isAddition)
            {
                textBox4.ForeColor = Color.Black;
                textBox4.Text = "";
            }
        }

       

        private void textBox3_Click(object sender, EventArgs e)
        {
            if (isAddition)
            {
                textBox3.ForeColor = Color.Black;
                textBox3.Text = "";
            }
        }

        private void insertInfo() {
            if (textBox3.Text.Trim().Length > 500)
            {
                MessageBox.Show("基本描述不应超过500字！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
                return;
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("科名必须填写！");
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
                MessageBox.Show("基本描述必须填写！");
                textBox3.Focus();
                return;
            }
            else;
            String link_val;
            if (textBox4.Text == "" || textBox4.Text == "输入新链接") link_val = "NULL"; else link_val = "'" + textBox4.Text.Trim() + "'";
            String sql = "INSERT INTO Family(fname, fLatin, fdesp, link) " +
                "VALUES('" + textBox1.Text.Trim() + "', '" +
                textBox2.Text.Trim() + "', '" +
                textBox3.Text.Trim() + "', " + link_val + ");";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("添加成功！");
            Form home = new Home(usr_mode, usrname);
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(linkLabel1.Tag.ToString());
        }
    }
        
}
