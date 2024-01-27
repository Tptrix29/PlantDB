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
    public partial class NoteEdit : Form
    {
        SqlConnection conn = new SqlConnection
              ("DataBase=PlantInfo; Data Source=(local); Integrated Security = True;");

        private String usr_mode, usrname, obj; char obj_type, status, note_type;
        public NoteEdit(String mode, String usrname, String obj_name, char obj_type, char note_type)
        {
            InitializeComponent();
            this.usr_mode = mode;
            this.usrname = usrname;
            this.obj = obj_name;
            this.obj_type = obj_type;
            this.note_type = note_type;

            this.Text += (note_type == '0' ? "笔记" : "评论") + "——";
            this.textBox1.Text = this.obj;
            this.label1.Text += usrname;
            this.Show();
            this.textBox3.Focus();
        }

        private void NoteEdit_Load(object sender, EventArgs e)
        {
            if (obj_type == 'F')
                loadFamily();
            else if (obj_type == 'S')
                loadSpecies();
            else;
        }
        private void loadFamily() {
            this.Text += "科：" + obj;
            this.textBox2.Text = "科";
            String sql = "SELECT content FROM FNotes " +
                "WHERE fid = (SELECT fid FROM Family WHERE fname = '" + this.obj + "')" +
                "AND usrid = (SELECT usrid FROM Users WHERE usrname = '" + this.usrname + "') " +
                "AND isPublic = " + note_type + ";";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                this.textBox3.Text = reader[0].ToString();
                this.status = 'E';
                this.status_label.Text += "编辑中";
            }
            else
            {
                this.status = 'A';
                this.status_label.Text += "新建中";
            } 
            conn.Close();
        }

        private void back_Click(object sender, EventArgs e)
        {
            Form info;
            if (obj_type == 'S')
                info = new SpeciesInfo(obj, usr_mode, usrname);
            else
                info = new FamilyInfo(obj, usr_mode, usrname);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (status == 'A')
                MessageBox.Show("删除失败！\n笔记还未创建！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                if (obj_type == 'S')
                    run_sql("DELETE FROM SNotes " + 
                        "WHERE spid = (SELECT spid FROM Species WHERE sname = '" + obj + "') " + 
                        "AND usrid = (SELECT usrid FROM Users WHERE usrname = '" + usrname + "');");
                else
                    run_sql("DELETE FROM FNotes " +
                        "WHERE fid = (SELECT fid FROM Family WHERE fname = '" + obj + "') " +
                        "AND usrid = (SELECT usrid FROM Users WHERE usrname = '" + usrname + "');");
                MessageBox.Show("删除成功！");
                this.status_label.Text = "Status: 新建中";
                this.status = 'A';
                this.textBox3.Text = "";
            }
        }


        private void loadSpecies() {
            this.Text += "物种：" + obj;
            this.textBox2.Text = "物种";
            String sql = "SELECT content FROM SNotes " +
                "WHERE spid = (SELECT spid FROM Species WHERE sname = '" + this.obj + "')" +
                "AND usrid = (SELECT usrid FROM Users WHERE usrname = '" + this.usrname + "') " +
                "AND isPublic = " + note_type + ";";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                this.textBox3.Text = reader[0].ToString();
                this.status = 'E';
                this.status_label.Text += "编辑中";
            }
            else {
                this.status = 'A';
                this.status_label.Text += "新建中";
            }
            conn.Close();   
        }

        private void button1_Click(object sender, EventArgs e)
        {
                if (this.textBox3.Text.Length > 0 && this.textBox3.Text.Length <= 200)
                {
                    String content = this.textBox3.Text.Trim();
                    if (status == 'E')
                        if (obj_type == 'S')
                        {
                            run_sql("UPDATE SNotes" +
                                " SET content = '" + content + "', lastEditTime = GETDATE()" +
                                " WHERE usrid = (SELECT usrid FROM Users WHERE usrname = '" + usrname + "') " +
                                " AND spid = (SELECT spid FROM Species WHERE sname = '" + obj + "')" +
                                " AND isPublic = "+ note_type +"; ");
                        }
                        else
                        {
                            run_sql("UPDATE FNotes" +
                                " SET content = '" + content + "', lastEditTime = GETDATE()" +
                                " WHERE usrid = (SELECT usrid FROM Users WHERE usrname = '" + usrname + "') " +
                                " AND fid = (SELECT fid FROM Family WHERE fname = '" + obj + "')" +
                                " AND isPublic = " + note_type + "; ");
                        }
                    else
                    {
                        if (obj_type == 'S')
                        {
                            run_sql("INSERT INTO SNotes(spid, usrid, isPublic, content) " +
                                    "VALUES(" +
                                        "(SELECT spid FROM Species WHERE sname = '" + obj + "'), " +
                                        "(SELECT usrid FROM Users WHERE usrname = '" + usrname + "'), " + note_type + ", '" + content + "');");
                        }
                        else
                        {
                            run_sql("INSERT INTO FNotes(fid, usrid, isPublic, content) " +
                                    "VALUES(" +
                                    "(SELECT fid FROM Family WHERE fname = '" + obj + "'), " +
                                    "(SELECT usrid FROM Users WHERE usrname = '" + usrname + "'), " + note_type + ", '" + content + "');");
                        }
                        this.status_label.Text = "Status: 编辑中";
                        this.status = 'E';
                    }
                    MessageBox.Show("保存成功！");
                }
                else { 
                    MessageBox.Show("笔记内容应为1~200字！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.textBox3.Focus();
                }
        }
        private void run_sql(String sql) {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
