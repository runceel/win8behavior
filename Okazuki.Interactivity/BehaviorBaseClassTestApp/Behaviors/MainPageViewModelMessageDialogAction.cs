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
