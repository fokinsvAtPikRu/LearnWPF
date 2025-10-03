using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lesson8.Infrastructure.Factories
{
    internal class WindowFactory : IWindowFactory
    {
        private readonly IServiceProvider _serviceProvider;
        public WindowFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public T CreateWindow<T>() where T : Window
        {
            return _serviceProvider.GetRequiredService<T>();
        }

        public T CreateWindow<T>(object dataContext) where T : Window
        {
            var window = _serviceProvider.GetRequiredService<T>();
            window.DataContext = dataContext;
            return window;
        }
    }
}
