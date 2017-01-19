using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace IBSC.WindowApp
{
    public static class FocusAdvancement
    {
        public static void KeyUp(object sender, KeyEventArgs e)
        {
            if (!e.Key.Equals(Key.Enter) || !e.Key.Equals(Key.Return)) return;

            var element = sender as UIElement;
            if (element != null) element.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
        }
    }
}
