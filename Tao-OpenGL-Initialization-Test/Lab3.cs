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
    public partial class Lab3 : Form
    {
        public Lab3()
        {
            InitializeComponent();
            anT.InitializeContexts();
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnVisualize_Click(object sender, EventArgs e)
        {
            //очищаем буфер цвета
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            //очищаем текущую матрицу
            Gl.glLoadIdentity();
            //устанавливаем текущий цвет
            Gl.glColor3f(1.0f, 0, 0);
            //активируем режим рисования линий, на основе
            //последовательного соединения всех вершин в отрезки
            Gl.glBegin(Gl.GL_LINE_LOOP);
            //первая вершина будет находиться в начале координат
            Gl.glVertex2d(8, 8);
            Gl.glVertex2d(10, 8);
            Gl.glVertex2d(10, 20);
            //Gl.glVertex2d(14, 13);
            Gl.glVertex2d(15, 12);
            Gl.glVertex2d(20, 20);
            Gl.glVertex2d(20, 8);
            Gl.glVertex2d(22, 8);
            Gl.glVertex2d(22, 22);
            Gl.glVertex2d(19, 22);//-1
            Gl.glVertex2d(15, 15);
            Gl.glVertex2d(11, 22);//+1
            Gl.glVertex2d(8, 22);
            //завершаем режим рисования
            Gl.glEnd();
            //дожидаемся конца визуализации кадра
            Gl.glFlush();
            //посылаем сигнал перерисовки элемента AnT
            anT.Invalidate();

        }

        private void Lab3_Load(object sender, EventArgs e)
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
    }
}
