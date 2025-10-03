using Lesson8.Domain.Interfaces;
using Lesson8.Domain.Model;
using Lesson8.Presentation.Commands;
using Microsoft.Win32;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace Lesson8.Presentation.ViewsModels
{
    public class AddProductViewModel : INotifyPropertyChanged
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        public event PropertyChangedEventHandler? PropertyChanged;
        public List<Category> Categories { get; } = new List<Category>();
        public AddProductViewModel(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            AddProductCommand = new RelayCommand(OnAddProductExecute, CanAddProductExecuted);
            SelectImageCommand = new RelayCommand(OnSelectImageExecute, CanSelectImageExecuted);
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
        private Category _selectedCategory;
        public Category SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                _selectedCategory = value;
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
        public ICommand AddProductCommand { get; }        

        private void OnAddProductExecute(object? parameter)
        {
            var window = (Window)parameter;
            var product = new Product
            {
                Name = _name,
                Price = _price,
                Category = SelectedCategory,
                CategoryId = SelectedCategory.Id,
                Image= _imagePath                
            };
            try
            {
                _productRepository.AddProductAsync(product);

                window.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении продукта: {ex.Message}");
            }
        }
        private bool CanAddProductExecuted(object? parameter)
        {
            return !string.IsNullOrEmpty(Name)
                && Price > 0
                && SelectedCategory != null
                && !string.IsNullOrEmpty(_imagePath);
        }
        public ICommand SelectImageCommand { get; }
        private void OnSelectImageExecute(object? parameter)
        {
            // string _projectDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));
            string targetDirectory = Path.Combine(/*_projectDirectory, */"Presentation", "Icons");
            var openFileDialog = new OpenFileDialog
            {
                Title = "Выберите изображение продукта",
                Filter = "Изображения (*.jpg;*.jpeg;*.png;*.bmp;*.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif|Все файлы (*.*)|*.*",
                Multiselect = false,
                CheckFileExists = true,
                CheckPathExists = true,
                InitialDirectory = targetDirectory,
                RestoreDirectory = true
            };
            if (openFileDialog.ShowDialog() == true)
            {
                string fileName=openFileDialog.SafeFileName;
                ImagePath = $"/Presetation/Icons/{fileName}";
            }
        }
        private bool CanSelectImageExecuted(object? parameter) => true;
    }
}
