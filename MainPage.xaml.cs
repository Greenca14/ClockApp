using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using System;

namespace Time2
{
    public partial class MainPage : ContentPage
    {
        private DateTime currentTime;

        public MainPage()
        {
            InitializeComponent(); 
            StartClock();
        }

        private async void StartClock()
        {
            myGraphicsView.Drawable = new ClockDrawable(this);

            using (var timer = new PeriodicTimer(TimeSpan.FromSeconds(1)))
            {
                while (await timer.WaitForNextTickAsync()) 
                {
                    currentTime = DateTime.Now; 
                    myGraphicsView.Invalidate();
                }
            }
        }

        private class ClockDrawable : IDrawable
        {
            private readonly MainPage _mainPage;

            public ClockDrawable(MainPage mainPage)
            {
                _mainPage = mainPage;
            }

            public void Draw(ICanvas canvas, RectF dirtyRect)
            {
                canvas.FillColor = Colors.Black; // цвет фона
                canvas.FillRectangle(dirtyRect); // прямоугольник в области dirtyRect

                var timeString = _mainPage.currentTime.ToString("HH:mm:ss"); // текущее время с двоеточиями

                for (int i = 0; i < timeString.Length; i++)
                {
                    var currentChar = timeString[i];

                    if (currentChar == ':')
                    {
                        DrawColon(canvas, 70 + i * 70, 50, 70);
                    }
                    else
                    {
                        DrawDigit(canvas, currentChar, 50 + i * 70, 50, 60); 
                    }
                }
            }

            private void DrawColon(ICanvas canvas, float x, float y, float size)
            {
                canvas.StrokeColor = Colors.White; 
                canvas.StrokeSize = 3; 

                canvas.DrawEllipse(x, y, size / 4, size / 4); // верхняя точка


                canvas.DrawEllipse(x, y + size / 2, size / 4, size / 4); // нижняя точка
            }

            private void DrawDigit(ICanvas canvas, char digit, float x, float y, float size)
            {
                switch (digit)
                {
                    case '0': DrawZero(canvas, x, y, size); break;
                    case '1': DrawOne(canvas, x, y, size); break;
                    case '2': DrawTwo(canvas, x, y, size); break;
                    case '3': DrawThree(canvas, x, y, size); break;
                    case '4': DrawFour(canvas, x, y, size); break;
                    case '5': DrawFive(canvas, x, y, size); break;
                    case '6': DrawSix(canvas, x, y, size); break;
                    case '7': DrawSeven(canvas, x, y, size); break;
                    case '8': DrawEight(canvas, x, y, size); break;
                    case '9': DrawNine(canvas, x, y, size); break;
                }
            }

            private void DrawZero(ICanvas canvas, float x, float y, float size)
            {
                canvas.StrokeColor = Colors.White;
                canvas.StrokeSize = 3;
                canvas.DrawLine(x, y, x + size, y); // Верхняя линия
                canvas.DrawLine(x, y + size, x + size, y + size); // Нижняя линия
                canvas.DrawLine(x + size, y, x + size, y + size); // Правая линия
                canvas.DrawLine(x, y, x, y + size); // Правая линия
            }

            private void DrawOne(ICanvas canvas, float x, float y, float size)
            {
                canvas.StrokeColor = Colors.White;
                canvas.StrokeSize = 3;
                canvas.DrawLine(x + size / 2, y, x + size / 2, y + size); // Вертикальная линия
            }

            private void DrawTwo(ICanvas canvas, float x, float y, float size)
            {
                canvas.StrokeColor = Colors.White;
                canvas.StrokeSize = 3;
                canvas.DrawLine(x + size / 16, y, x + size, y); // Верхняя линия
                canvas.DrawLine(x + size, y, x + size, y + size / 2); // Правая линия
                canvas.DrawLine(x + size, y + size / 2, x, y + size / 2); // Центральная линия
                canvas.DrawLine(x, y + size / 2, x, y + size); // Левая линия
                canvas.DrawLine(x, y + size, x + size, y + size); // Нижняя линия
            }

            private void DrawThree(ICanvas canvas, float x, float y, float size)
            {
                canvas.StrokeColor = Colors.White;
                canvas.StrokeSize = 3;
                canvas.DrawLine(x, y, x + size, y); // Верхняя линия
                canvas.DrawLine(x + size, y, x + size, y + size); // Правая линия
                canvas.DrawLine(x, y + size / 2, x + size, y + size / 2); // Средняя линия
                canvas.DrawLine(x, y + size, x + size, y + size); // Нижняя линия
            }

            private void DrawFour(ICanvas canvas, float x, float y, float size)
            {
                canvas.StrokeColor = Colors.White;
                canvas.StrokeSize = 3;
                canvas.DrawLine(x, y, x, y + size / 2); // Левая линия
                canvas.DrawLine(x + size, y, x + size, y + size); // Правая линия
                canvas.DrawLine(x, y + size / 2, x + size, y + size / 2); // Средняя линия
            }

            private void DrawFive(ICanvas canvas, float x, float y, float size)
            {
                canvas.StrokeColor = Colors.White;
                canvas.StrokeSize = 3;
                canvas.DrawLine(x, y, x + size, y); // Верхняя линия
                canvas.DrawLine(x, y, x, y + size / 2); // Левая линия
                canvas.DrawLine(x, y + size / 2, x + size, y + size / 2); // Центральная линия
                canvas.DrawLine(x + size, y + size / 2, x + size, y + size); // Правая линия
                canvas.DrawLine(x, y + size, x + size, y + size); // Нижняя линия
            }

            private void DrawSix(ICanvas canvas, float x, float y, float size)
            {
                canvas.StrokeColor = Colors.White;
                canvas.StrokeSize = 3;
                canvas.DrawLine(x, y, x + size, y); // Верхняя линия
                canvas.DrawLine(x, y + size / 2, x + size, y + size / 2); // Центральная линия
                canvas.DrawLine(x + size, y + size / 2, x + size, y + size); // Правая линия
                canvas.DrawLine(x, y + size, x + size, y + size); // Нижняя линия
                canvas.DrawLine(x, y, x, y + size); // Левая линия
            }

            private void DrawSeven(ICanvas canvas, float x, float y, float size)
            {
                canvas.StrokeColor = Colors.White;
                canvas.StrokeSize = 3;
                canvas.DrawLine(x, y, x + size, y); // Верхняя линия
                canvas.DrawLine(x + size, y, x, y + size); // Диагональная линия
            }

            private void DrawEight(ICanvas canvas, float x, float y, float size)
            {
                canvas.StrokeColor = Colors.White;
                canvas.StrokeSize = 3;
                canvas.DrawLine(x, y, x + size, y); // Верхняя линия
                canvas.DrawLine(x, y + size, x + size, y + size); // Нижняя линия
                canvas.DrawLine(x, y + size / 2, x + size, y + size / 2); // Центральная линия
                canvas.DrawLine(x + size, y, x + size, y + size); // Правая линия
                canvas.DrawLine(x, y, x, y + size); // Правая линия
            }

            private void DrawNine(ICanvas canvas, float x, float y, float size)
            {
                canvas.StrokeColor = Colors.White;
                canvas.StrokeSize = 3;
                canvas.DrawLine(x, y, x + size, y); // Верхняя линия
                canvas.DrawLine(x + size, y, x + size, y + size); // Правая линия
                canvas.DrawLine(x, y + size / 2, x + size, y + size / 2); // Центральная линия
                canvas.DrawLine(x, y + size, x + size, y + size); // Нижняя линия
                canvas.DrawLine(x, y, x, y + size / 2); // Левая линия
            }
        }
    }
}
