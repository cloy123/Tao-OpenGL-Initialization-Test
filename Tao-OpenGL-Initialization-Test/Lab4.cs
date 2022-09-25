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
    public partial class Lab4 : Form
    {
        double a = 1, b = 0, c = 0;

        public Lab4()
        {
            InitializeComponent();
            anT.InitializeContexts();
        }

        private void btnVisualize_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void trackBarA_Scroll(object sender, EventArgs e)
        {
            a = (double)trackBarA.Value / 1000;
            labelA.Text = a.ToString();
        }

        private void trackBarB_Scroll(object sender, EventArgs e)
        {
            b = (double)trackBarB.Value / 1000;
            labelB.Text = b.ToString();
        }

        private void trackBarC_Scroll(object sender, EventArgs e)
        {
            c = (double)trackBarC.Value / 1000;
            labelC.Text = c.ToString();    
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Draw();
        }

        private void Lab4_Load(object sender, EventArgs e)
        {
            //инициализация Glut
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_SINGLE);
            //очистка окна
            Gl.glClearColor(255, 255, 255, 1);
            //установка порта вывода в соответствии с размерами элемента AnT
            Gl.glViewport(0, 0, anT.Width, anT.Height);
            //настройка проекции
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            //теперь необходимо корректно настроить 2D ортогональную проекцию
            //в зависимости от того, какая сторона больше
            //мы немного варьируем то, как будет сконфигурированы настройки проекции
            if ((float)anT.Width <= (float)anT.Height)
            {
                Glu.gluOrtho2D(0.0, 30.0 * (float)anT.Height / (float)anT.Width, 0.0, 30.0);
            }
            else
            {
                Glu.gluOrtho2D(0.0, 30.0 * (float)anT.Width / (float)anT.Height, 0.0, 30.0);
            }
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            //настройка параметров OpenGL для визуализации
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);
        }

        private void Draw()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glLoadIdentity();
            Gl.glBegin(Gl.GL_TRIANGLES);
            Gl.glColor3d(a, b, c);
            Gl.glVertex2d(5.0, 5.0);
            Gl.glColor3d(c, a, b);
            Gl.glVertex2d(25.0, 5.0);
            Gl.glColor3d(b, c, a);
            Gl.glVertex2d(5.0, 25.0);
            Gl.glEnd();
            Gl.glFlush();
            anT.Invalidate();
        }

    }
}
