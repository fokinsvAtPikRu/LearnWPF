using System.ComponentModel;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Lesson8.Domain.Interfaces;
using Lesson8.Domain.Model;
using System.Runtime.CompilerServices;
using Lesson8.Presentation.Commands;

namespace Lesson8.Presentation.ViewsModels
{
    public class ProductViewModel : INotifyPropertyChanged
    {

        private readonly IProductRepository _productRepository;
        private Product _selectedProduct;

        public ProductViewModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ObservableCollection<Product> Products { get; } = new ObservableCollection<Product>();
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
