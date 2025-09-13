using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lesson_9
{
    public class ChangeColorCommands
    {
        public static RoutedCommand ChangeColor { get; }
        public static RoutedCommand PreviousColor { get; }
        static ChangeColorCommands()
        {
            InputGestureCollection changeColorInputGestureCollection = new InputGestureCollection();
            changeColorInputGestureCollection.Add(new KeyGesture(Key.C,ModifierKeys.Control,"Ctrl+C"));
            ChangeColor = new RoutedCommand("ChangeColor",typeof(ChangeColorCommands),changeColorInputGestureCollection);
            InputGestureCollection prevColorInputGestureCollection = new InputGestureCollection();
            prevColorInputGestureCollection.Add(new KeyGesture(Key.Z, ModifierKeys.Control, "Ctrl+C"));
            PreviousColor = new RoutedCommand("PreviousColor", typeof(ChangeColorCommands), prevColorInputGestureCollection);
        }
    }
}
 