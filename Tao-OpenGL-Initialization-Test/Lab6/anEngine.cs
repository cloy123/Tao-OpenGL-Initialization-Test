using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tao_OpenGL_Initialization_Test
{
    public class anEngine
    {
        int picture_size_x;
        int picture_size_y;
        int screen_width;
        int screen_height;
        int scroll_x;
        int scroll_y;
        int ActiveLayerNom;
        anBrush standartBrush;
        List<anLayer> Layers = new List<anLayer>();
        private Color LastColorInUse;


        // конструктор класса 
        public anEngine(int size_x, int size_y, int screen_w, int screen_h)
        {

            // при инициализации экземпляра класса сохраним настройки 
            // размеров элементов и изображения в локальных переменных 

            picture_size_x = size_x;
            picture_size_y = size_y;

            screen_width = screen_w;
            screen_height = screen_h;

            // полосы прокрутки у нас пока отсутствуют, поэтому просто обнулим значение переменных 
            scroll_x = 0;
            scroll_y = 0;

            // добавим новый слой для работы, пока он будет единственным 
            Layers.Add(new anLayer(picture_size_x, picture_size_y));

            // номер активного слоя - 0 
            ActiveLayerNom = 0;

            // и создадим стандартную кисть 
            standartBrush = new anBrush(3, false);

        }

        public void AddLayer()
        {
            Layers.Add(new anLayer(picture_size_x, picture_size_y));
            int AddingLayer = Layers.Count - 1;
            SetActiveLayerNom(AddingLayer);
        }

        public void RemoveLayer(int nom)
        {
            if (nom < Layers.Count && nom >= 0)
            {
                SetActiveLayerNom(0);
                Layers.RemoveAt(nom);
            }
        }
        public void SetStandartBrush(int SizeB)
        {
            standartBrush = new anBrush(SizeB, false);
        }

        public void SetSpecialBrush(int Nom)
        {
            standartBrush = new anBrush(Nom, true);
        }

        public void SetBrushFromFile(string FileName)
        {
            standartBrush = new anBrush(FileName);
        }

        public void SetColor(Color NewColor)
        {
            ((anLayer)Layers[ActiveLayerNom]).SetColor(NewColor);
            LastColorInUse = NewColor;
        }

        // функция для установки номера активного слоя 
        public void SetActiveLayerNom(int nom)
        {
            ((anLayer)Layers[ActiveLayerNom]).CreateNewList();
            ((anLayer)Layers[nom]).SetColor(((anLayer)Layers[ActiveLayerNom]).GetColor());
            ActiveLayerNom = nom;
        }

        // рисование текущей кистью 
        public void Drawing(int x, int y)
        {
            // транслируем координаты, в которых проходит рисование, стандартной кистью 
            ((anLayer)Layers[ActiveLayerNom]).Draw(standartBrush, x, y);
        }

        // визуализация 
        public void SwapImage()
        {
            // вызываем функцию визуализации в нашем слое 
            for (int ax = 0; ax < Layers.Count; ax++)
            {
                if (ax == ActiveLayerNom)
                {
                    ((anLayer)Layers[ax]).RenderImage(false);
                } 
                else
                {
                    ((anLayer)Layers[ax]).RenderImage(true);
                } 
            }
        }

        public Bitmap GetFinalImage()
        {
            Bitmap resultBitmap = new Bitmap(picture_size_x, picture_size_y);
            for (int ax = 0; ax < Layers.Count; ax++)
            {
                int[,,] tmp_layer_data = ((anLayer)Layers[ax]).GetDrawingPlae();
                for (int a = 0; a < picture_size_x; a++)
                {
                    for (int b = 0; b < picture_size_y; b++)
                    {
                        if (tmp_layer_data[a, b, 3] != 1)
                        {
                            resultBitmap.SetPixel(a, b, Color.FromArgb(tmp_layer_data[a, b, 0], tmp_layer_data[a, b, 1], tmp_layer_data[a, b, 2]));
                        }
                        else
                        {
                            if (ax == 0)
                            {
                                resultBitmap.SetPixel(a, b, Color.FromArgb(255, 255, 255));
                            }
                        }
                    }
                }
            }
            resultBitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
            return resultBitmap;
        }
        public void SetImageToMainLayer(Bitmap layer)
        {
            layer.RotateFlip(RotateFlipType.Rotate180FlipX);
            for (int ax = 0; ax < layer.Width; ax++)
            {
                for (int bx = 0; bx < layer.Height; bx++)
                {
                    SetColor(layer.GetPixel(ax, bx));
                    Drawing(ax, bx);
                }
            }
        }
    }
}
