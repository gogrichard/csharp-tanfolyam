using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media;

namespace AnimatedButtonDemo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AnimatedButton_MouseEnter(object sender, MouseEventArgs e)
        {
            var animation = new ThicknessAnimation
            {
                To = new Thickness(6),
                Duration = TimeSpan.FromMilliseconds(200)
            };
            AnimatedButton.BeginAnimation(Button.BorderThicknessProperty, animation);
        }

        private void AnimatedButton_MouseLeave(object sender, MouseEventArgs e)
        {
            var animation = new ThicknessAnimation
            {
                To = new Thickness(2),
                Duration = TimeSpan.FromMilliseconds(200)
            };
            AnimatedButton.BeginAnimation(Button.BorderThicknessProperty, animation);
        }

        private void AnimatedButton_Click(object sender, RoutedEventArgs e)
        {
            var rotateAnimation = new DoubleAnimation
            {
                By = 15,
                Duration = TimeSpan.FromMilliseconds(300),
                FillBehavior = FillBehavior.HoldEnd
            };

            ButtonRotateTransform.BeginAnimation(RotateTransform.AngleProperty, rotateAnimation);
        }
    }
}