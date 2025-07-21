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

namespace Lesson1Task3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Random rnd;
        private double maxMarginValue1;
        private double maxMarginValue2;
        public MainWindow()
        {
            InitializeComponent();
            rnd=new Random();
            

        }

        private void RuningBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            Button btn=(Button)sender;
            maxMarginValue2 = Grid.ActualHeight - RuningBtn.Height;
            maxMarginValue1 = Grid.ActualWidth - RuningBtn.Width;
            double value1Margin=rnd.NextDouble()*maxMarginValue1;
            double value2Margin=rnd.NextDouble()*maxMarginValue2;
            btn.Margin=new Thickness(value1Margin,value2Margin,0,0);
        }
    }
}