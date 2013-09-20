using Okazuki.Interactivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace BehaviorBaseClassTestApp.Behaviors
{
    public class MessageDialogBehavior : Behavior<Button>
    {
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register(
                "Message", 
                typeof(string), 
                typeof(MessageDialogBehavior), 
                new PropertyMetadata(string.Empty));

        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        protected override void OnAttached()
        {
            this.AssociatedObject.Click += this.ButtonClicked;
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.Click -= this.ButtonClicked;
        }

        private void ButtonClicked(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog(this.Message);
            var ignore = dialog.ShowAsync();
        }
    }
}
