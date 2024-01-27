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
using Excel =  Microsoft.Office.Interop.Excel;

namespace PlantDB
{
    public partial class Home : Form
    {
        SqlConnection conn = new SqlConnection
           ("DataBase=PlantInfo; Data Source=(local); Integrated Security = True;");

        private String usr_mode, usrname;
        public Home(String mode, String usrname)
        {
            InitializeComponent();
            usr_mode = mode;
            this.usrname = usrname;
            this.label1.Text += usrname + "!";
            switch (mode) { 
                case "Guest": loadAsGuest(); break;
                case "C": loadAsUser(); break;
                case "A": loadAsAdmin(); break;
                case "R": loadAsRoot(); break;
                default: break;
            }

            String sql1 = "SELECT TOP 25 sname AS '中文名', sLatin AS '学名', family AS '科' FROM Species";
            SqlDataAdapter adapter = new SqlDataAdapter(sql1, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataTable dt = ds.Tables[0].DefaultView.ToTable(false, new String[] { "中文名", "学名", "科" });
            dataGridView1.DataSource = dt.DefaultView;

            this.Show();
        }

        private void loadAsGuest() {
            this.menuStrip1.Items[2].Visible = false;
            this.menuStrip1.Items[4].Visible = false;
            this.menuStrip1.Items[6].Visible = false;

        }
        private void loadAsRoot() {
            this.menuStrip1.Items[3].Visible = false;

        }

        private void loadAsAdmin() {
            this.menuStrip1.Items[3].Visible = false;
            this.menuStrip1.Items[6].Visible = false;
        }

        private void loadAsUser() { 
            this.menuStrip1.Items[3].Visible = false;
            this.menuStrip1.Items[6].Visible = false;
        }


        private void 检索ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form search = new Retrieve(usr_mode, usrname);
            this.Close();
        }

        private void 登陆ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form login = new LogIn();
            this.Close();
        }

        private void 退出登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult re = MessageBox.Show("确认要退出登录吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (re == DialogResult.OK) {
                Form login = new LogIn();
                this.Close();
            }
        }

        private void 关闭程序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 用户管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form edit = new AdminEdit(usr_mode, usrname);
            this.Close();
        }

        private void 物种ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form species;
            if (usr_mode == "A" || usr_mode == "R")
            {
                species = new SpeciesInfo("new", usr_mode, usrname, true);
                this.Close();
            }
            else MessageBox.Show("对不起！\n您不具有管理权限，不能进行该操作", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void 科ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form family;
            if (usr_mode == "A" || usr_mode == "R")
            {
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
            while (reader.Read()) {
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) { 
                String spname = this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                Form species = new SpeciesInfo(spname, usr_mode, usrname);
                this.Close();
            }
        }
    }
}
