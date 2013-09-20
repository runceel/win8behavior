using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okazuki.Interactivity
{
    public class PreviewInvokeEventArgs : EventArgs
    {
        public bool Cancelling { get; set; }
    }
}
