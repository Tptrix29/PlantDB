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
using Excel = Microsoft.Office.Interop.Excel;

namespace PlantDB
{
    public partial class Retrieve : Form
    {
        SqlConnection conn = new SqlConnection
           ("DataBase=PlantInfo; Data Source=(local); Integrated Security = True;");
        String usr_mode, usrname;
        public Retrieve(String mode, String usrname)
        {
            InitializeComponent();
            usr_mode = mode;
            this.usrname = usrname;
            this.label7.Text += usrname + "!";
            switch (mode)
            {
                case "Guest": loadAsGuest(); break;
                case "C": loadAsUser(usrname); break;
                case "A": loadAsAdmin(usrname); break;
                case "R": loadAsRoot(); break;
                default: break;
            }
            this.Show();
        }

        private void loadAsGuest()
        {
            this.menuStrip1.Items[2].Visible = false;
            this.menuStrip1.Items[4].Visible = false;
            this.menuStrip1.Items[6].Visible = false;
        }
        private void loadAsRoot()
        {
            this.menuStrip1.Items[3].Visible = false;
        }

        private void loadAsAdmin(String name)
        {
            this.menuStrip1.Items[3].Visible = false;
            this.menuStrip1.Items[6].Visible = false;
        }

        private void loadAsUser(String name)
        {
            this.menuStrip1.Items[3].Visible = false;
            this.menuStrip1.Items[6].Visible = false;
        }


        private void Retrieve_Load(object sender, EventArgs e)
        {
            String sql1 = "SELECT TOP 10 sname AS '中文名', sLatin AS '学名' FROM Species";
            SqlDataAdapter adapter = new SqlDataAdapter(sql1, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataTable dt = ds.Tables[0].DefaultView.ToTable(false, new String[] { "中文名", "学名" });
            dataGridView1.DataSource = dt.DefaultView;
            
            String sql2 = "SELECT TOP 10 fname AS '中文名', fLatin AS '学名' FROM Family";
            ds = new DataSet();
            adapter = new SqlDataAdapter(sql2, conn);
            adapter.Fill(ds);
            dt = ds.Tables[0].DefaultView.ToTable(false, new String[] { "中文名", "学名" });
            dataGridView2.DataSource = dt.DefaultView;

            conn.Open();
            String summary = "SELECT COUNT(S.spid) AS SP_NUM FROM Species AS S;";
            SqlCommand cmd = new SqlCommand(summary, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            this.label5.Text = "共 " + reader["SP_NUM"].ToString() + " 条数据";
            reader.Close();

            summary = "SELECT COUNT(F.fid) AS FM_NUM FROM Family AS F;";
            cmd = new SqlCommand(summary, conn);
            reader = cmd.ExecuteReader();
            reader.Read();
            this.label6.Text = "共 " + reader["FM_NUM"].ToString() + " 条数据";
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String name = this.textBox1.Text.Trim();
            String latin = this.textBox3.Text.Trim();
            if (name == "") name = "NONE";
            if (latin == "") latin = "NONE";
            String sql = "SELECT sname AS '中文名', nickname AS '别称', sLatin AS '学名' FROM Species " +
                "WHERE sname LIKE '%" + name + "%' OR nickname LIKE '%" + name + "%' OR sLatin LIKE '%" + latin + "%';";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            if (ds.Tables[0].Rows.Count != 0)
            {   
                DataTable dt = ds.Tables[0].DefaultView.ToTable(false, new String[] { "中文名", "别称", "学名" });
                dataGridView1.DataSource = dt.DefaultView;
                dataGridView1.ScrollBars = ScrollBars.Both;
                this.label5.Text = "共 " + dt.Rows.Count.ToString() + " 条数据";
            }
            else {
                MessageBox.Show("物种 检索失败！\n请重新输入词条 或 申请创建词条");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String name = this.textBox2.Text.Trim();
            String latin = this.textBox4.Text.Trim();
            if (name == "") name = "NONE";
            if (latin == "") latin = "NONE";
            String sql = "SELECT fname AS '中文名', fLatin AS '学名' FROM Family " +
                "WHERE fname LIKE '%" + name + "%' OR fLatin LIKE '%" + latin + "%';";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            if (ds.Tables[0].Rows.Count != 0)
            {
                DataTable dt = ds.Tables[0].DefaultView.ToTable(false, new String[] { "中文名", "学名" });
                dataGridView2.DataSource = dt.DefaultView;
                this.label6.Text = "共 " + dt.Rows.Count.ToString() + " 条数据";
            }
            else
            {
                MessageBox.Show("科 检索失败！\n请重新输入词条 或 申请创建词条");
            }
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

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                String fname = this.dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                Form family = new FamilyInfo(fname, usr_mode, usrname);
                this.Close();
            }
        }

        private void 登陆ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form login = new LogIn();
            login.Show();
            this.Close();
        }

        private void 退出登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult re = MessageBox.Show("确认要退出登录吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (re == DialogResult.OK)
            {
                Form login = new LogIn();
                this.Close();
            }
        }

        private void 关闭程序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void HomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form home = new Home(usr_mode, usrname);
            this.Close();
        }

        private void 物种ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form species;
            if (usr_mode == "A" || usr_mode == "R") { 
                species = new SpeciesInfo("new", usr_mode, usrname, true);
                this.Close();
            }
            else MessageBox.Show("对不起！\n您不具有管理权限，不能进行该操作", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void 科ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form family;
            if (usr_mode == "A" || usr_mode == "R") { 
                family = new FamilyInfo("new", usr_mode, usrname, true);
                this.Close();
            }
            else MessageBox.Show("对不起！\n您不具有管理权限，不能进行该操作", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void 导出笔记ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 物种笔记ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet ws;
            app.SheetsInNewWorkbook = 1;
            app.Caption = "Species_Info.xlsx";
            ws = wb.Worksheets[1];
            ws.Cells.Item[1, 1] = "物种名";
            ws.Cells.Item[1, 2] = "学名";
            ws.Cells.Item[1, 3] = "科名";
            ws.Cells.Item[1, 4] = "生长环境";
            ws.Cells.Item[1, 5] = "分布地域";
            ws.Cells.Item[1, 6] = "描述";
            ws.Cells.Item[1, 7] = "笔记";
            String sql = "SELECT sname, sLatin, family, env, region, sdesp, content " +
                    "FROM Species RIGHT JOIN SNotes ON Species.spid = SNotes.spid " +
                    "RIGHT JOIN Users ON Users.usrid = SNotes.usrid " +
                    "WHERE SNotes.isPublic = 0 AND Users.usrname ='" + usrname + "'; ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            int i = 1;
            while (reader.Read())
            {
                ws.Cells.Item[++i, 1] = reader[0].ToString();
                ws.Cells.Item[i, 2] = reader[1].ToString();
                ws.Cells.Item[i, 3] = reader[2].ToString();
                ws.Cells.Item[i, 4] = reader[3].ToString();
                ws.Cells.Item[i, 5] = reader[4].ToString();
                ws.Cells.Item[i, 6] = reader[5].ToString();
                ws.Cells.Item[i, 7] = reader[6].ToString();
            }
            conn.Close();
            app.Visible = true;

        }

        private void 科笔记ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet ws;
            app.SheetsInNewWorkbook = 1;
            app.Caption = "Species_Info.xlsx";
            ws = wb.Worksheets[1];
            ws.Cells.Item[1, 1] = "科名";
            ws.Cells.Item[1, 2] = "学名";
            ws.Cells.Item[1, 3] = "描述";
            ws.Cells.Item[1, 4] = "笔记";
            String sql = "SELECT fname, fLatin, fdesp, content " +
                    "FROM Family RIGHT JOIN FNotes ON Family.fid = FNotes.fid " +
                    "RIGHT JOIN Users ON Users.usrid = FNotes.usrid " +
                    "WHERE FNotes.isPublic = 0 AND Users.usrname ='" + usrname + "'; ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            int i = 1;
            while (reader.Read())
            {
                ws.Cells.Item[++i, 1] = reader[0].ToString();
                ws.Cells.Item[i, 2] = reader[1].ToString();
                ws.Cells.Item[i, 3] = reader[2].ToString();
                ws.Cells.Item[i, 4] = reader[3].ToString();
            }
            conn.Close();
            app.Visible = true;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1_Click(sender, e);
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1_Click(sender, e);
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1_Click(sender, e);
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1_Click(sender, e);
        }

        private void 用户管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form edit = new AdminEdit(usr_mode, usrname);
            this.Close();
        }
    }
}
