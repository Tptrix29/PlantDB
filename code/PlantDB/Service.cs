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
    public partial class Service : Form
    {
        public Service()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
        }

        private void Service_Load(object sender, EventArgs e)
        {
            Form login = new LogIn();
            login.Show();
        }
    }
}
