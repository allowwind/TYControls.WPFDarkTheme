using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TYControls
{
    public class TYUserControl : UserControl
    {
        public bool IsBusy
        {
            get { return (bool)GetValue(IsBusyProperty); }
            set { SetValue(IsBusyProperty, value); }
        }

        public static readonly DependencyProperty IsBusyProperty =
            DependencyProperty.Register("IsBusy", typeof(bool), typeof(TYUserControl), new PropertyMetadata(false));

        public string BusyTitle
        {
            get { return (string)GetValue(BusyTitleProperty); }
            set { SetValue(BusyTitleProperty, value); }
        }

        public static readonly DependencyProperty BusyTitleProperty =
            DependencyProperty.Register("BusyTitle", typeof(string), typeof(TYUserControl), new PropertyMetadata(""));

        public async Task<TResult> Run<TResult>(Func<TResult> function, string busyTitle = "请稍等...")
        {
            var win = Window.GetWindow(this);
            if (win is TYWindow tyWin)
            {
                using (var busy = new BusyHelper(tyWin, busyTitle))
                {
                    //await Task.Delay(2000);
                    return await Task.Run<TResult>(function);
                }
            }
            return default(TResult);
        }

    }
}