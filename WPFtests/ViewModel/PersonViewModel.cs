using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using WPFtests.Model;

namespace WPFtests.ViewModel
{
    internal class PersonViewModel:DependencyObject
    {
        public ICollectionView Items
        {
            get { return (ICollectionView)GetValue(ItemspertyProperty); }
            set { SetValue(ItemspertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Itemsperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemspertyProperty =
            DependencyProperty.Register("Items", typeof(ICollectionView), typeof(PersonViewModel), new PropertyMetadata(null));
        public PersonViewModel()
        {
            Items=CollectionViewSource.GetDefaultView(Person.GetItems());
        }

    }
}
