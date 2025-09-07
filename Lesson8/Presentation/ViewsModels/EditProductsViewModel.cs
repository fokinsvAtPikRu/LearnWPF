using Lesson8.Domain.Interfaces;
using Lesson8.Domain.Model;
using Lesson8.Presentation.Commands;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;


namespace Lesson8.Presentation.ViewsModels
{
    public class EditProductsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private Product _product;
        public List<Category> Categories { get; } =new List<Category>();

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        private int _price;
        public int Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged();
            }
        }
        private Category _category;
        public Category Category
        {
            get => _category;
            set
            {
                _category = value;
                OnPropertyChanged();
            }
        }
        private string _imagePath;
        public string ImagePath
        {
            get => _imagePath;
            set
            {
                _imagePath = value;
                OnPropertyChanged();
            }
        }
        public EditProductsViewModel
            (IProductRepository productRepository, 
            ICategoryRepository categoryRepository,             
            Product product)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _product = product;
            _name = _product.Name;
            _price=_product.Price;
            _category = _product.Category;
            _imagePath = _product.Image;
            _ = InitializeAsync();
        }
        public async Task InitializeAsync()
        {
            try
            {
                var categories = await _categoryRepository.GetAllCategoryAsync();
                foreach (var category in categories)
                {
                    Categories.Add(category);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка инициализации: {ex.Message}");
            }
        }
        public readonly AsyncRelayCommand SaveChangedProductCommand;
        private async Task OnSaveChangedProductExecute(object? parameter)
        {
            
        }

    }
}
