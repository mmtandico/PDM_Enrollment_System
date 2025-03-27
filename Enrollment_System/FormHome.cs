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
        private Image[] images;
        private int currentImageIndex = 0;

        public FormHome()
        {
            InitializeComponent();
            this.Text = "Welcome to Enrollment System";

            
            images = new Image[]
            {
                Properties.Resources.P9700277_1_1024x576,      
                Properties.Resources.Graduation_2019_1_1536x1024, 
                Properties.Resources.BGIMAGE1,
                Properties.Resources.BGIMAGE2
            };

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            
            pictureBox1.Image = images[currentImageIndex];

            
            timer1.Interval = 3000;
            timer1.Start();
        }



        private void BtnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                new FormLogin().Show();
                this.Close();
            }

        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnCourses_Click(object sender, EventArgs e)
        {
            this.Close();
            new FormCourse().Show();
        }

        private void BtnEnrollment_Click(object sender, EventArgs e)
        {
            this.Close();
            new FormEnrollment().Show();
        }

        private void BtnPI_Click(object sender, EventArgs e)
        {
            this.Close();
            new FormPersonalInfo().Show();
        }

        private void BtnDataBase_Click(object sender, EventArgs e)
        {
            this.Close();
            new FormDatabaseInfo().Show();
        }



        private void timer1_Tick_1(object sender, EventArgs e)
        {
            
            currentImageIndex++;
            if (currentImageIndex >= images.Length)
            {
                currentImageIndex = 0; 
            }
 
            pictureBox1.Image = images[currentImageIndex];
        }
    }
}