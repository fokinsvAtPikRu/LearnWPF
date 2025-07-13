using System.Windows.Media;

namespace Lesson_4.Model
{
    class OffStateButton : IButtonState
    {
        public void Click(Button button)
        {
            button.SetState(new OnStateButton());
        }

        public string Context()
        {
            return "OFF";
        }

        public SolidColorBrush ColorButton()
        {
            return new SolidColorBrush(Colors.Red);
        }

    }
}
