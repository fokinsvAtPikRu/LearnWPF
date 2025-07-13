using System.Windows.Media;

namespace Lesson_4.Model
{
    class OnStateButton : IButtonState
    {
        public void Click(Button button)
        {
            button.SetState(new OnStateButton());           
        }

        public string Context()
        {
            return "ON";
        }

        public SolidColorBrush ColorButton()
        {
            return new SolidColorBrush(Colors.Green);
        }
    }
}
