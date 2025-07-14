using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Lesson_4.ViewModel
{
    class MainWindowViewModel : DependencyObject
    {
        private Model.Button _button;
        public string ContextButton
        {
            get { return (string)GetValue(ContextButtonProperty); }
            set { SetValue(ContextButtonProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ContextButton.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContextButtonProperty =
            DependencyProperty.Register(
                nameof(ContextButton),
                typeof(string),
                typeof(MainWindowViewModel),
                new FrameworkPropertyMetadata(string.Empty));
        

        public SolidColorBrush ColorButton
        {
            get { return (SolidColorBrush)GetValue(ColorButtonProperty); }
            set { SetValue(ColorButtonProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ColorButton.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColorButtonProperty =
            DependencyProperty.Register(nameof(ColorButton), typeof(SolidColorBrush), typeof(MainWindowViewModel), new PropertyMetadata(new SolidColorBrush()));

        public ICommand OnClickCommand { get; }

        private void Execute()
        {                 

            this._button.Click();
            this.ContextButton = this._button.GetContext();
            this.ColorButton = this._button.GetColor();
        }
        public MainWindowViewModel()
        {
            OnClickCommand = new RelayCommand(Execute, () => true);
            _button=new Model.Button();
            ContextButton = _button.GetContext();
            ColorButton = _button.GetColor();
        }

    }
}
