using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace TradingCardTracker
{
    class DecimalTextBox : TextBox
    {
        protected override void OnPreviewTextInput(TextCompositionEventArgs e)
        {
            e.Handled = !AreAllValidNumericChars(e.Text);
            base.OnPreviewTextInput(e);
        }

        private bool AreAllValidNumericChars(string str)
        {
            bool result = true;

            foreach (char c in str)
            {
                if (!(char.IsNumber(c) || (c == '.')))
                    result = false;
            }

            return result;
        }
    }
}
