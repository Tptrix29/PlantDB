using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlantDB
{
    public partial class CommentBar : UserControl
    {
        public CommentBar(String name, String content, String date, int X, int Y)
        {   
            InitializeComponent();
            usr.Text = name;
            textBox1.Text = content;
            time.Text = date;
            this.Location = new Point(X, Y);
        }
    }
}
