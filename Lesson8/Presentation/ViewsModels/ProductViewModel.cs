using System.ComponentModel;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Lesson8.Domain.Interfaces;
using Lesson8.Domain.Model;
using System.Runtime.CompilerServices;
using Lesson8.Presentation.Commands;
using Lesson8.Presentation.Views;
using System.ComponentModel.DataAnnotations;
using Lesson8.Infrastructure.Factories;
using System.Windows;

namespace Lesson8.Presentation.ViewsModels
{
    public class ProductViewModel : INotifyPropertyChanged
    {
        private readonly IWindowFactory _windowFactory;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private Product _selectedProduct;
        public RelayCommand ShowAddProductWindowCommand { get; }

        public ProductViewModel(IProductRepository productRepository, ICategoryRepository categoryRepository, IWindowFactory windowFactory)
        {
            _windowFactory = windowFactory;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            ShowAddProductWindowCommand = new RelayCommand(ShowAddPoductWindowExecute, CanShowAddProductWindowExecuted);
            _ = InitializeAsync();
        }
        public async Task InitializeAsync()
        {
            try
            {
                await LoadProductAsync();
                var categorys = await _categoryRepository.GetAllCategoryAsync();
                foreach (var category in categorys)
                {
                    Categorys.Add(category);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка инициализации: {ex.Message}");
            }
        }
        

        // Commands


        private async void ShowAddPoductWindowExecute(object? parameter)
        {
            var addProductViewModel = new AddProductViewModel(_productRepository, _categoryRepository);
            var addProductWindow = _windowFactory.CreateWindow<AddProductWindow>(addProductViewModel);
            addProductWindow.Owner = Application.Current.MainWindow;
            addProductWindow.ShowDialog();
            await LoadProductAsync();
        }
        private bool CanShowAddProductWindowExecuted(object? parameter) => true;

        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();
        public ObservableCollection<Category> Categorys { get; } = new ObservableCollection<Category>();
        private async Task LoadProductAsync()
        {
            var products = await _productRepository.GetAllProductAsync();
            Products.Clear();
            foreach (var product in products)
            {
                Products.Add(product);
            }
        }
        public Product SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged();
            }
        }
        public string NewProductName { get; set; }
        public int NewProductPrice { get; set; }
        public Category NewProductCategory { get; set; }

        public RelayCommand LoadProductCommand { get; }
        public RelayCommand AddProductCommand { get; }



        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
