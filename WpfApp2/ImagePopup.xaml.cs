using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfApp2
{
    public partial class ImagePopup : Window
    {
        private Point startPoint;
        private Point origin;
        private double scale = 1.0;
        private bool isDragging = false;

        public ImageSource ImageSource
        {
            get { return popupImage.Source; }
            set { popupImage.Source = value; }
        }

        public ImagePopup()
        {
            InitializeComponent();
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            try
            {
                e.Handled = true;
                double zoom = e.Delta > 0 ? 0.1 : -0.1;
                scale += zoom;
                if (scale < 0.1)
                    scale = 0.1;
                if (scale > 4.0)
                    scale = 4.0;
                ApplyZoom();
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while zooming the image, please try after sometime");
            }
        }

        private void ApplyZoom()
        {
            try
            {
                ScaleTransform scaleTransform = new ScaleTransform(scale, scale);
                popupImage.LayoutTransform = scaleTransform;
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while zooming the image, please try after sometime");
            }
        }

        private void scrollViewer_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                isDragging = true;
                startPoint = e.GetPosition(scrollViewer);
                origin.X = popupImage.RenderTransform.Value.OffsetX;
                origin.Y = popupImage.RenderTransform.Value.OffsetY;
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while zooming the image, please try after sometime");
            }
        }

        private void scrollViewer_PreviewMouseMove(object sender, MouseEventArgs e)
        {

            try
            {
                if (isDragging)
                {
                    Point p = e.GetPosition(scrollViewer);
                    popupImage.RenderTransform = new TranslateTransform(origin.X + p.X - startPoint.X, origin.Y + p.Y - startPoint.Y);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while zooming the image, please try after sometime");
            }
        }

        private void scrollViewer_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
        }
    }
}
