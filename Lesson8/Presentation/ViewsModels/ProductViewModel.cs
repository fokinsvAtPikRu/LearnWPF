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
        #region Fields
        private readonly IWindowFactory _windowFactory;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private Product _selectedProduct;
        #endregion
        #region Properties
        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();
        public ObservableCollection<Category> Categorys { get; } = new ObservableCollection<Category>();
        public Product SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged();
                RemoveProductCommand.RaiseCanExecuteChanged();
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #region Constructor
        public ProductViewModel(IProductRepository productRepository, ICategoryRepository categoryRepository, IWindowFactory windowFactory)
        {
            _windowFactory = windowFactory;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            ShowAddProductWindowCommand = new AsyncRelayCommand(ShowAddPoductWindowExecute, CanShowAddProductWindowExecuted);
            ShowEditProductWindowCommand = new RelayCommand(OnEditShowEditProductWindowExecute, CanEditProductShowWindowExecuted);
            RemoveProductCommand = new AsyncRelayCommand(OnRemoveProuctExecute, CanRemoveProductExecuted);

            _ = InitializeAsync();
        }
        #endregion
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

        
        private async Task LoadProductAsync()
        {
            var products = await _productRepository.GetAllProductAsync();
            Products.Clear();
            foreach (var product in products)
            {
                Products.Add(product);
            }
        }
        
        
        #region Commands
        public AsyncRelayCommand ShowAddProductWindowCommand { get; }
        private async Task ShowAddPoductWindowExecute(object? parameter)
        {
            var addProductViewModel = new AddProductViewModel(_productRepository, _categoryRepository);
            var addProductWindow = _windowFactory.CreateWindow<AddProductWindow>(addProductViewModel);
            addProductWindow.Owner = Application.Current.MainWindow;
            addProductWindow.ShowDialog();
            await LoadProductAsync();
        }
        private bool CanShowAddProductWindowExecuted(object? parameter) => true;
        
        public AsyncRelayCommand RemoveProductCommand { get; }
        private async Task OnRemoveProuctExecute(object? parameter)
        {
            if (_selectedProduct != null)
            {
                var id = _selectedProduct.Id;
                await _productRepository.DeleteProductAsync(id);
                MessageBox.Show($"{_selectedProduct.Name} удален");
                await LoadProductAsync();                
            }
        }
        private bool CanRemoveProductExecuted(object? parameter) => _selectedProduct != null;
        public RelayCommand ShowEditProductWindowCommand { get; }
        private void OnEditShowEditProductWindowExecute(object? parameter)
        {
            var editProductViewModel=new EditProductsViewModel(_productRepository, _categoryRepository,_selectedProduct);
            var editProductWindow=_windowFactory.CreateWindow<EditProductWindow>(editProductViewModel);
            editProductWindow.Owner = Application.Current.MainWindow;
            editProductWindow.ShowDialog();
        }
        private bool CanEditProductShowWindowExecuted(object? parameter) => _selectedProduct!=null;


        #endregion

    }
}
