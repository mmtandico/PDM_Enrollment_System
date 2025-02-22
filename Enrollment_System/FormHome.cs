using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Enrollment_System
{
    public partial class FormHome : Form
    {
        public FormHome()
        {
            InitializeComponent();
            this.Text = "Welcome to Enrollment System";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
