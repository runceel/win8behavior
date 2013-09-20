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
