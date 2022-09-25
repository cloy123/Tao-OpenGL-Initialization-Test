using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.FreeGlut;
using Tao.OpenGl;
using Tao.Platform;

namespace Tao_OpenGL_Initialization_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLab2_Click(object sender, EventArgs e)
        {
            var lab2 = new Lab2();
            lab2.ShowDialog();
        }

        private void btnLab3_Click(object sender, EventArgs e)
        {
            var lab3 = new Lab3();
            lab3.ShowDialog();
        }

        private void btnLab4_Click(object sender, EventArgs e)
        {
            var lab4 = new Lab4();
            lab4.ShowDialog();
        }

        private void btnLab5_Click(object sender, EventArgs e)
        {
            var lab5 = new Lab5();
            lab5.ShowDialog();
        }
    }
}
