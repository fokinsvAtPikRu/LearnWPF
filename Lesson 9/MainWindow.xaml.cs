using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lesson_9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static Stack<Color> colorStack = new Stack<Color>();
        
        public MainWindow()
        {
            InitializeComponent();
            SolidColorBrush brush = (SolidColorBrush)dockPanel.Background;
            colorStack.Push(brush.Color);
        }

        private void OnChangeColorExecute(object sender, ExecutedRoutedEventArgs e)
        {
            var rnd = new Random();
            byte red = (byte)rnd.Next(0, 255);
            byte green = (byte)rnd.Next(0, 255);
            byte blue = (byte)rnd.Next(0, 255);
            var newColor = Color.FromRgb(red, green, blue);
            colorStack.Push(newColor);
            dockPanel.Background = new SolidColorBrush(newColor);
            
        }

        private void CanChangeColorExecuted(object sender, CanExecuteRoutedEventArgs e)
            => _ = e.CanExecute = true;

        private void OnPreviousColorExecute(object sender, ExecutedRoutedEventArgs e)
        {
            colorStack.Pop();
            var prevColor = colorStack.Peek();
            dockPanel.Background = new SolidColorBrush(prevColor);
            
        }

        private void CanPreviousColorExecutes(object sender, CanExecuteRoutedEventArgs e)
            => _ = e.CanExecute = colorStack.Count > 1;

    }
}