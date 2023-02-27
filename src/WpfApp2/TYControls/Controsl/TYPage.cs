using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TYControls
{
    public class TYPage : Page
    {
        public bool IsBusy
        {
            get { return (bool)GetValue(IsBusyProperty); }
            set { SetValue(IsBusyProperty, value); }
        }

        public static readonly DependencyProperty IsBusyProperty =
            DependencyProperty.Register("IsBusy", typeof(bool), typeof(TYPage), new PropertyMetadata(false));

        public string BusyTitle
        {
            get { return (string)GetValue(BusyTitleProperty); }
            set { SetValue(BusyTitleProperty, value); }
        }

        public static readonly DependencyProperty BusyTitleProperty =
            DependencyProperty.Register("BusyTitle", typeof(string), typeof(TYPage), new PropertyMetadata(""));

        public async Task<TResult> Run<TResult>(Func<TResult> function, string busyTitle = "请稍等...")
        {
            using (var busy = new BusyHelper(this, busyTitle))
            { 
                return await Task.Run<TResult>(function);
            }
        }

        public async Task<TResult> Run<TResult>(Func<TResult> function, int delayTime, string busyTitle = "请稍等...")
        {
            using (var busy = new BusyHelper(this, busyTitle))
            {
                await Task.Delay(delayTime);
                return await Task.Run<TResult>(function);
            }
        }

        public async Task Run(Action function, string busyTitle = "请稍等...")
        {
            using (var busy = new BusyHelper(this, busyTitle))
            {
                await Task.Run(function);
            }
        }

        public async Task Run(Action function, int delayTime, string busyTitle = "请稍等...")
        {
            using (var busy = new BusyHelper(this, busyTitle))
            {
                await Task.Delay(delayTime);
                await Task.Run(function);
            }
        }

        public void SetBusy(bool isBusy, string title = "请稍等..")
        {
            BusyTitle = title;
            IsBusy = isBusy;
        }
    }
}
