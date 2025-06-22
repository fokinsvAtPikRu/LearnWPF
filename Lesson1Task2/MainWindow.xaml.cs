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

namespace Lesson1Task2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CircularList<(Ellipse,Brush)> colorList = new CircularList<(Ellipse, Brush)>();
        private IEnumerator<(Ellipse, Brush)> enumerator;
        public MainWindow()
        {
            InitializeComponent();
            colorList = 
                new CircularList<(Ellipse, Brush)>((Red,Brushes.Red), (Yellow, Brushes.Yellow), (Green, Brushes.Green));
            enumerator = colorList.GetEnumerator();
        }

        private void Switch_Click(object sender, RoutedEventArgs e)
        {
            // включаем следующий цвет            
            enumerator.MoveNext();
            var current = enumerator.Current;
            current.Item1.Fill=current.Item2;
            // выключаем два следующих и поп
            enumerator.MoveNext();
            current = enumerator.Current;
            current.Item1.Fill = Brushes.Gray;
            enumerator.MoveNext();
            current = enumerator.Current;
            current.Item1.Fill = Brushes.Gray;
            // возвращаемся на текущий
            enumerator.MoveNext();
        }

    }
}