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
    public partial class Lab6 : Form
    {
        private anEngine ProgramDrawingEngine;

        private int ActiveLayer = 0;

        private int LayersCount = 1;
        private int AllLayersCount = 1;

        public Lab6()
        {
            InitializeComponent();
            anT.InitializeContexts();
        }

        private void RenderTimer_Tick(object sender, EventArgs e)
        {
            Drawing();
        }

        private void Lab6_Load(object sender, EventArgs e)
        {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);
            Gl.glClearColor(255, 255, 255, 1);
            Gl.glViewport(0, 0, anT.Width, anT.Height);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluOrtho2D(0.0, anT.Width, 0.0, anT.Height);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            ProgramDrawingEngine = new anEngine(anT.Width, anT.Height, anT.Width, anT.Height);
            RenderTimer.Start();
            LayersControl.Items.Add("Главный слой", true);
        }

        private void Drawing()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glLoadIdentity();
            Gl.glColor3f(0, 0, 0);
            ProgramDrawingEngine.SwapImage();
            Gl.glFlush();
            anT.Invalidate();
        }

        private void anT_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ProgramDrawingEngine.Drawing(e.X, anT.Height - e.Y);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ProgramDrawingEngine.SetStandartBrush(4);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ProgramDrawingEngine.SetSpecialBrush(0);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ProgramDrawingEngine.SetBrushFromFile("brush-1.bmp");
        }

        private void color1_MouseClick(object sender, MouseEventArgs e)
        {
            if (changeColor.ShowDialog() == DialogResult.OK)
            {
                color1.BackColor = changeColor.Color;
                ProgramDrawingEngine.SetColor(color1.BackColor);
            }
        }

        private void linkLabel1_MouseClick(object sender, MouseEventArgs e)
        {
            Color tmp = color1.BackColor;
            color1.BackColor = color2.BackColor;
            color2.BackColor = tmp;
            ProgramDrawingEngine.SetColor(color1.BackColor);
        }

        private void добавитьСлойToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayersCount++;
            ProgramDrawingEngine.AddLayer();
            int AddingLayerNom = LayersControl.Items.Add("Слой" + LayersCount.ToString(), false);
            LayersControl.SelectedIndex = AddingLayerNom;
            ActiveLayer = AddingLayerNom;
        }

        private void удалитьСлойToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Будет удалён текущий активный слой, действительно продолжить?",
                "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                if (ActiveLayer == 0)
                {
                    MessageBox.Show("Вы не можете удалить нулевой слой.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    LayersCount--;
                    int LayerNomForDel = LayersControl.SelectedIndex;
                    LayersControl.Items.RemoveAt(LayerNomForDel);
                    LayersControl.SelectedIndex = 0;
                    ActiveLayer = 0;
                    LayersControl.SetItemCheckState(0, CheckState.Checked);
                    ProgramDrawingEngine.RemoveLayer(LayerNomForDel);
                }
            }
        }

        private void LayersControl_SelectedValueChanged(object sender, EventArgs e)
        {
            if (LayersControl.SelectedIndex != ActiveLayer)
            {
                if (LayersControl.SelectedIndex != -1 && ActiveLayer < LayersControl.Items.Count)
                {
                    LayersControl.SetItemCheckState(ActiveLayer, CheckState.Unchecked);
                    ActiveLayer = LayersControl.SelectedIndex;
                    LayersControl.SetItemCheckState(LayersControl.SelectedIndex, CheckState.Checked);
                    ProgramDrawingEngine.SetActiveLayerNom(ActiveLayer);
                }
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            добавитьСлойToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            удалитьСлойToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            ProgramDrawingEngine.SetSpecialBrush(1);
        }

        private void карандашToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton1_Click(sender, e);
        }

        private void кистьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton3_Click(sender, e);
        }

        private void стеркаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton6_Click(sender, e);
        }

        private void чистыйПроектToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult reslt = MessageBox.Show("В данный момент проект уже начат, сохранить изменение перед закрытием проекта?",
                "Внимание!", MessageBoxButtons.YesNoCancel);
            switch (reslt)
            {
                case DialogResult.No:
                    {
                        ProgramDrawingEngine = new anEngine(anT.Width, anT.Height, anT.Width, anT.Height);
                        LayersControl.Items.Clear();
                        ActiveLayer = 0;
                        LayersCount = 1;
                        AllLayersCount = 1;
                        LayersControl.Items.Add("Главный слой", true);
                        break;
                    }
                case DialogResult.Cancel:
                    {
                        return;
                    }
                case DialogResult.Yes:
                    {
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            Bitmap ToSave = ProgramDrawingEngine.GetFinalImage();
                            ToSave.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                            ProgramDrawingEngine = new anEngine(anT.Width, anT.Height, anT.Width, anT.Height);
                            LayersControl.Items.Clear();
                            ActiveLayer = 0;
                            LayersCount = 1;
                            AllLayersCount = 1;
                            LayersControl.Items.Add("Главный слой", true);
                        }
                        else
                        {
                            return;
                        }
                        break;
                    }
            }

        }

        private void изФайлаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult reslt = MessageBox.Show("В данный момент проект уже начат, сохранить изменение перед закрытием проекта?",
    "Внимание!", MessageBoxButtons.YesNoCancel);
            switch (reslt)
            {
                case DialogResult.No:
                    {
                        if (openFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            if (System.IO.File.Exists(openFileDialog1.FileName))
                            {
                                Bitmap ToLoad = new Bitmap(openFileDialog1.FileName);
                                if (ToLoad.Width > anT.Width || ToLoad.Height > anT.Height)
                                {
                                    MessageBox.Show("Извините, но размер изображения превышает размеры области рисования",
                                        "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    return;
                                }
                                ProgramDrawingEngine = new anEngine(anT.Width, anT.Height, anT.Width, anT.Height);
                                ProgramDrawingEngine.SetImageToMainLayer(ToLoad);
                                LayersControl.Items.Clear();
                                ActiveLayer = 0;
                                LayersCount = 1;
                                AllLayersCount = 1;
                                LayersControl.Items.Add("Главный слой", true);
                            }
                        }
                        break;
                    }
                case DialogResult.Cancel:
                    {
                        return;
                    }
                case DialogResult.Yes:
                    {
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            Bitmap ToSave = ProgramDrawingEngine.GetFinalImage();
                            ToSave.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                            {
                                if (System.IO.File.Exists(openFileDialog1.FileName))
                                {
                                    Bitmap ToLoad = new Bitmap(openFileDialog1.FileName);
                                    if (ToLoad.Width > anT.Width || ToLoad.Height > anT.Height)
                                    {
                                        MessageBox.Show("Извините, но размер изображения превышает размеры области рисования",
                                            "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                        return;
                                    }
                                    ProgramDrawingEngine = new anEngine(anT.Width, anT.Height, anT.Width, anT.Height);
                                    ProgramDrawingEngine.SetImageToMainLayer(ToLoad);
                                    LayersControl.Items.Clear();
                                    ActiveLayer = 0;
                                    LayersCount = 1;
                                    AllLayersCount = 1;
                                    LayersControl.Items.Add("Главный слой", true);
                                }
                            }
                        }
                        else
                        {
                            return;
                        }
                        break;
                    }
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Bitmap ToSave = ProgramDrawingEngine.GetFinalImage();
                ToSave.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
