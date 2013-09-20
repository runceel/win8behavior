using Microsoft.Xaml.Interactivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Okazuki.Interactivity
{
    public abstract class TriggerAction : Behavior, IAction
    {
        public static readonly DependencyProperty IsEnabledProperty =
            DependencyProperty.Register(
                "IsEnabled", 
                typeof(bool), 
                typeof(TriggerAction), 
                new PropertyMetadata(true));

        public bool IsEnabled
        {
            get { return (bool)GetValue(IsEnabledProperty); }
            set { SetValue(IsEnabledProperty, value); }
        }

        internal TriggerAction(Type associatedType) : base(associatedType)
        {
        }

        public object Execute(object sender, object parameter)
        {
            if (!this.IsEnabled)
            {
                return null;
            }

            return this.Invoke(sender, parameter);
        }

        protected abstract object Invoke(object sender, object parameter);
    }
}
