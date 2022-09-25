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
    public partial class Lab2 : Form
    {
        public Lab2()
        {
            InitializeComponent();
            anT.InitializeContexts();
        }

        private void btnVisualize_Click(object sender, EventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            Gl.glLoadIdentity();
            Gl.glColor3f(1.0f, 0, 0);

            Gl.glPushMatrix();
            Gl.glTranslated(0, 0, -6);
            Gl.glRotated(45, 1, 1, 0);

            //рисуем сферу с помощью библиотеки FreeGLUT
            Glut.glutWireSphere(2, 32, 32);

            Gl.glPopMatrix();
            Gl.glFlush();
            anT.Invalidate();
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Lab2_Load(object sender, EventArgs e)
        {
            // инициализация Glut
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);
            // очистка окна
            Gl.glClearColor(255, 255, 255, 1);
            // установка порта вывода в соответствии с размерами элемента anT
            Gl.glViewport(0, 0, anT.Width, anT.Height);
            // настройка проекции
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(45, (float)anT.Width / (float)anT.Height, 0.1, 200);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            // настройка параметров OpenGL для визуализации
            Gl.glEnable(Gl.GL_DEPTH_TEST);
        }
    }
}
