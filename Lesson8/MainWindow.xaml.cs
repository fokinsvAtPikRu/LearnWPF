using Lesson8.Model;
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

namespace Lesson8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            using (ApplicationContext db = new ApplicationContext())
            {
                var product0 = new Product("apple", 1, "");
                var product1 = new Product("fridge", 10, "");
                var product2 = new Product("banana", 2, "");
                var product3 = new Product("vacuum clenear", 5, "");

                db.Products.Add(product0);
                db.Products.Add(product1);
                db.Products.Add(product2);
                db.Products.Add(product3);
                db.SaveChanges();                
            }
        }
    }
}