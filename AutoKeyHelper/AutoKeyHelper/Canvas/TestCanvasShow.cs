using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace AutoKeyHelper.Canvas
{
    internal class TestCanvasShow
    {

        public void CanvasRectAddTest(System.Windows.Controls.Canvas mainCanvas)
        {


            double canvasWidth = mainCanvas.ActualWidth;
            double canvasHeight = mainCanvas.ActualHeight;

            Rectangle rect = new Rectangle();
            rect.Width = 100;
            rect.Height = 100;
            rect.Fill = Brushes.Red;
            rect.Tag = "z";


            // 避免 Canvas 還沒 render 出來
            if (canvasWidth == 0 || canvasHeight == 0)
            {
                mainCanvas.UpdateLayout(); // 強制刷新 Layout
                canvasWidth = mainCanvas.ActualWidth;
                canvasHeight = mainCanvas.ActualHeight;
            }

            double posX = canvasWidth * 0.1;  // 50% 寬
            double posY = canvasHeight * 0.1; // 30% 高

            System.Windows.Controls.Canvas.SetLeft(rect, posX);
            System.Windows.Controls.Canvas.SetTop(rect, posY);

            mainCanvas.Children.Add(rect);
        }



        public void CanvasScrollTest(System.Windows.Controls.Canvas mainCanvas1)
        {
            for (int i = 0; i < 4; i++)
            {
                Rectangle rect = new Rectangle
                {
                    Width = 100,
                    Height = 100,
                    Fill = Brushes.LightBlue,
                    Stroke = Brushes.Black,
                    StrokeThickness = 1
                };

                System.Windows.Controls.Canvas.SetLeft(rect, (double)(i * 110)); // 每個方塊之間間隔 10px
                System.Windows.Controls.Canvas.SetTop(rect, 50);

                mainCanvas1.Children.Add(rect);
            }
        }
    }
}
