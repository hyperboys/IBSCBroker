using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace IBSC.WindowApp
{
    public static class CommonControl
    {
        public static void KeyUp(object sender, KeyEventArgs e)
        {
            if (!e.Key.Equals(Key.Enter) || !e.Key.Equals(Key.Return)) return;

            var element = sender as UIElement;
            if (element != null) element.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
        }

        public static void NumericTextBoxInput(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
            if (regex.IsMatch(e.Text) && !(e.Text == "." && ((TextBox)sender).Text.Contains(e.Text)))
                e.Handled = false;
            else
                e.Handled = true;
        }
    }
}
