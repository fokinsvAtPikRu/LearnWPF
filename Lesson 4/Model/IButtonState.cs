using System.Windows.Media;

namespace Lesson_4.Model
{
    interface IButtonState
    {
        void Click(Button button);
        string Context();
        SolidColorBrush ColorButton();
    }
}
