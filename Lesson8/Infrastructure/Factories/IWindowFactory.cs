using System.Windows;

namespace Lesson8.Infrastructure.Factories
{
    public interface IWindowFactory
    {
        T CreateWindow<T>() where T : Window;
        T CreateWindow<T>(object dataContext) where T : Window;
    }
}
