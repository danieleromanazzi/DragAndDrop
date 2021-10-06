using System.Windows;
using System.Windows.Input;

namespace DragAndDrop.Behaviors
{
    public class DropBehavior
    {
        protected DropBehavior()
        {

        }

        public static ICommand GetExecute(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(ExecuteProperty);
        }

        public static void SetExecute(DependencyObject obj, ICommand value)
        {
            obj.SetValue(ExecuteProperty, value);
        }

        // Using a DependencyProperty as the backing store for Execute.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ExecuteProperty =
            DependencyProperty.RegisterAttached("Execute", typeof(ICommand), typeof(DropBehavior), new PropertyMetadata(null, OnExecute));

        private static void OnExecute(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UIElement control)
            {
                control.Drop += (sender, args) =>
                {
                    GetExecute(control).Execute(args.Data);
                    args.Handled = true;
                };
            }
        }
    }
}
