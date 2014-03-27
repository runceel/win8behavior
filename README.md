win8behavior
============

Windows 8のIBehaviorやIActionを拡張してなるべく今までのBehviorと同じノリで新しいビヘイビアを追加できるようにしたもの.

```cs
// Behavior
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

```

```cs
// Trigger
using Microsoft.Xaml.Interactivity;
using Okazuki.Interactivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace BehaviorBaseClassTestApp.Behaviors
{
    public class ClickEventTriggerBehavior : TriggerBase<Button>
    {
        public ActionCollection Actions { get { return this.ActionsImpl; } }

        protected override void OnAttached()
        {
            this.AssociatedObject.Click += this.ButtonClick;
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.Click -= this.ButtonClick;
        }
        
        private void ButtonClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.InvokeActions(null);
        }
    }
}
```

```cs
// TriggerAction
using Okazuki.Interactivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace BehaviorBaseClassTestApp.Behaviors
{
    public class MainPageViewModelMessageDialogAction : TargetedTriggerAction<MainPageViewModel>
    {
        protected override object Invoke(object sender, object parameter)
        {
            var dialog = new MessageDialog(this.Target.InputMessage);
            var ignore = dialog.ShowAsync();
            return null;
        }
    }
}
```
