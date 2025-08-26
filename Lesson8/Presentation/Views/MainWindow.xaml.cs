using System.Windows;
using Lesson8.Presentation.ViewsModels;

namespace Lesson8.Presentation.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(ProductViewModel productViewModel)
        {
            InitializeComponent();
            DataContext = productViewModel;
            _ = InitializeViewModelAsync(productViewModel);
        }

        private async Task InitializeViewModelAsync(ProductViewModel viewModel)
        {
            try
            {
                await viewModel.InitializeAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка инициализации: {ex.Message}");
            }
        }
    }
}