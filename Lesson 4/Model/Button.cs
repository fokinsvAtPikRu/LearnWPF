using System.Windows.Media;

namespace Lesson_4.Model
{
    class Button
    {
        private IButtonState _state;
        public Button()
        {
            _state=new OffStateButton();                
        }
        public void SetState(IButtonState state)
        {
            _state = state;
        }
        public void Click()
        {
            _state.Click(this);
        }
        public string GetContext()
        {
            return _state.Context();
        }
        public SolidColorBrush GetColor()
        {
            return _state.ColorButton();
        }
    }
}
