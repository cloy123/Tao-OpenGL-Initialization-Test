using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;

namespace Tao_OpenGL_Initialization_Test
{
    public class anLayer
    {
        public int Width, Height;
        private int[,,] DrawPlace;
        public int[,,] GetDrawingPlae()
        {
            return DrawPlace;
        }
        private bool isVisible;
        private Color ActiveColor;
        private int ListNom;
        public void ClearList()
        {
            if (Gl.glIsList(ListNom) == Gl.GL_TRUE)
            {
                Gl.glDeleteLists(ListNom, 1);
            }
        }
        public void CreateNewList()
        {
            if (Gl.glIsList(ListNom) == Gl.GL_TRUE)
            {
                Gl.glDeleteLists(ListNom, 1);
                ListNom = Gl.glGenLists(1);
            }
            Gl.glNewList(ListNom, Gl.GL_COMPILE);
            RenderImage(false);
            Gl.glEndList();
        }
        public anLayer(int s_W, int s_H)
        {
            Width = s_W;
            Height = s_H;
            DrawPlace = new int[Width, Height, 4];
            for (int ax = 0; ax < Width; ax++)
            {
                for (int bx = 0; bx < Height; bx++)
                {
                    DrawPlace[ax, bx, 3] = 1;
                }
            }
            isVisible = true;
            ActiveColor = Color.Black;
        }

        public void SetColor(Color NewColor)
        {
            ActiveColor = NewColor;
        }
        public Color GetColor()
        {
            return ActiveColor;
        }

        public void SetVisibility(bool visibilityState)
        {
            isVisible = visibilityState;
        }
        public bool GetVisibility()
        {
            return isVisible;
        }
        public void Draw(anBrush BR, int x, int y)
        {
            int real_pos_draw_start_x = x - BR.myBrush.Width / 2;
            int real_pos_draw_start_y = y - BR.myBrush.Height / 2;
            if (real_pos_draw_start_x < 0) real_pos_draw_start_x = 0;
            if (real_pos_draw_start_y < 0) real_pos_draw_start_y = 0;
            int boundary_x = real_pos_draw_start_x + BR.myBrush.Width;
            int boundary_y = real_pos_draw_start_y + BR.myBrush.Height;
            if (boundary_x > Width) boundary_x = Width;
            if (boundary_y > Height) boundary_y = Height;
            int count_x = 0, count_y = 0;
            for (int ax = real_pos_draw_start_x; ax < boundary_x; ax++, count_x++)
            {
                count_y = 0;
                for (int bx = real_pos_draw_start_y; bx < boundary_y; bx++, count_y++)
                {
                    // проверяем, не является ли данная кисть стеркой 
                    if (BR.IsBrushErase())
                    {
                        // данная кисть - стерка. 
                        // помечаем данный пиксель как не закрашенный // получаем текущий цвет пикселя маски 
                        Color ret = BR.myBrush.GetPixel(count_x, count_y);

                        // цвет не красный 
                        if (!(ret.R == 255 && ret.G == 0 && ret.B == 0))
                        {
                            // заполняем данный пиксель соответствующим из маски, используя активный цвет 
                            DrawPlace[ax, bx, 3] = 1;
                        }

                    }
                    else
                    {

                        // получаем текущий цвет пикселя маски 
                        Color ret = BR.myBrush.GetPixel(count_x, count_y);

                        // цвет не красный 
                        if (!(ret.R == 255 && ret.G == 0 && ret.B == 0))
                        {
                            // заполняем данный пиксель соответствующим из маски, используя активный цвет 
                            DrawPlace[ax, bx, 0] = ActiveColor.R;
                            DrawPlace[ax, bx, 1] = ActiveColor.G;
                            DrawPlace[ax, bx, 2] = ActiveColor.B;
                            DrawPlace[ax, bx, 3] = 0;
                        }
                    }

                }
            }
        }
        public void RenderImage(bool FromList)
        {
            if (FromList)
            {
                Gl.glCallList(ListNom);
            }
            else
            {
                int count = 0;
                for (int ax = 0; ax < Width; ax++)
                {
                    for (int bx = 0; bx < Height; bx++)
                    {
                        if (DrawPlace[ax, bx, 3] != 1) count++;
                    }
                }
                int[] arr_date_vertex = new int[count * 2];
                float[] arr_date_colors = new float[count * 3];
                int now_element = 0;
                for (int ax = 0; ax < Width; ax++)
                {
                    for (int bx = 0; bx < Height; bx++)
                    {
                        if (DrawPlace[ax, bx, 3] != 1)
                        {
                            arr_date_vertex[now_element * 2] = ax;
                            arr_date_vertex[now_element * 2 + 1] = bx;
                            arr_date_colors[now_element * 3] = (float)DrawPlace[ax, bx, 0] / 255.0f;
                            arr_date_colors[now_element * 3 + 1] = (float)DrawPlace[ax, bx, 1] / 255.0f;
                            arr_date_colors[now_element * 3 + 2] = (float)DrawPlace[ax, bx, 2] / 255.0f;
                            now_element++;
                        }
                    }
                }
                Gl.glEnableClientState(Gl.GL_VERTEX_ARRAY);
                Gl.glEnableClientState(Gl.GL_COLOR_ARRAY);
                Gl.glColorPointer(3, Gl.GL_FLOAT, 0, arr_date_colors);
                Gl.glVertexPointer(2, Gl.GL_INT, 0, arr_date_vertex);
                Gl.glDrawArrays(Gl.GL_POINTS, 0, count);
                Gl.glDisableClientState(Gl.GL_VERTEX_ARRAY);
                Gl.glDisableClientState(Gl.GL_COLOR_ARRAY);
            }
        }
    }
}
