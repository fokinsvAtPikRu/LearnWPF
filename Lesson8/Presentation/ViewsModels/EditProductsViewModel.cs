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
        public List<Category> Categories { get; set; } =new List<Category>();

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
                SaveChangedProductCommand.RaiseCanExecuteChanged();
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
                SaveChangedProductCommand.RaiseCanExecuteChanged();
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
                SaveChangedProductCommand.RaiseCanExecuteChanged();
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
                SaveChangedProductCommand.RaiseCanExecuteChanged();
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
            SaveChangedProductCommand = new AsyncRelayCommand(OnSaveChangedProductExecute, CanSaveChangedProductExecuted);
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
                var findingCategory=categories.FirstOrDefault(c=>c.Id==_product.Category.Id);
                if (findingCategory != null)
                {
                    Category = findingCategory;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка инициализации: {ex.Message}");
            }
        }
        
        public AsyncRelayCommand SaveChangedProductCommand { get; }
        private async Task OnSaveChangedProductExecute(object? parameter)
        {
            var window = (Window)parameter;
            _product.Name = Name;
            _product.Price = Price;
            _product.Category = Category;
            try
            {
                await _productRepository.UpdateProductAsync(_product);
                window.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении продукта: {ex.Message}");
            }
        }
        private bool CanSaveChangedProductExecuted(object? parameter)
        {
            if(_product.Category != null)
                return true;
            else
                return false;
        }
    }
}
