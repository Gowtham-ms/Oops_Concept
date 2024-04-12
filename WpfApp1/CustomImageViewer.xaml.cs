using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfApp1
{
    public partial class CustomImageViewer : UserControl
    {
        private bool isExpanded = false;
        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register(
              "Source", typeof(BitmapImage), typeof(CustomImageViewer), new PropertyMetadata(OnSourceChanged));
        private Point lastMousePosition;
        private bool isDragging = false;
        public BitmapImage Source
        {
            get { return (BitmapImage)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        private static void OnSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is CustomImageViewer customImageViewer && e.NewValue is BitmapImage newSource)
            {
                customImageViewer.image.Source = newSource;
            }
        }

        public CustomImageViewer()
        {
            InitializeComponent();
            image.Width = double.NaN;
        }

        private void CustomImageViewer_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (isExpanded)
            {
                Width = 521;
                Height = 300;
                isExpanded = false;

                ZoomInButton.Visibility = Visibility.Collapsed;
                ZoomOutButton.Visibility = Visibility.Collapsed;
                CloseButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                Width = 800;
                Height = 600;
                isExpanded = true;

                ZoomInButton.Visibility = Visibility.Visible;
                ZoomOutButton.Visibility = Visibility.Visible;
                CloseButton.Visibility = Visibility.Visible;
            }
        }

        private void image_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && e.LeftButton == MouseButtonState.Pressed)
            {
                Point currentMousePosition = e.GetPosition(this);
                double offsetX = currentMousePosition.X - lastMousePosition.X;
                double offsetY = currentMousePosition.Y - lastMousePosition.Y;

                TranslateTransform transform = image.RenderTransform as TranslateTransform;
                if (transform != null)
                {
                    transform.X += offsetX;
                    transform.Y += offsetY;
                }

                lastMousePosition = currentMousePosition;
            }
        }

        private void image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isDragging = true;
            lastMousePosition = e.GetPosition(this);
            image.CaptureMouse();
        }

        private void image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
            image.ReleaseMouseCapture();
        }



        private void ZoomInButton_Click(object sender, RoutedEventArgs e)
        {
            var currentTransform = image.RenderTransform as ScaleTransform;
            if (currentTransform == null)
            {
                currentTransform = new ScaleTransform(1.0, 1.0);
                image.RenderTransform = currentTransform;
            }

            currentTransform.ScaleX *= 1.2;
            currentTransform.ScaleY *= 1.2;
        }

        private void ZoomOutButton_Click(object sender, RoutedEventArgs e)
        {
            var currentTransform = image.RenderTransform as ScaleTransform;
            if (currentTransform == null)
            {
                currentTransform = new ScaleTransform(1.0, 1.0);
                image.RenderTransform = currentTransform;
            }

            currentTransform.ScaleX /= 1.2;
            currentTransform.ScaleY /= 1.2;
        }


        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Width = 521;
            Height = 300;
            isExpanded = false;
            ZoomInButton.Visibility = Visibility.Collapsed;
            ZoomOutButton.Visibility = Visibility.Collapsed;
            CloseButton.Visibility = Visibility.Collapsed;
            image.RenderTransform = Transform.Identity;
        }
    }
}
