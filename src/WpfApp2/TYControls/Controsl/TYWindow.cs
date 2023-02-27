using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TYControls
{
    public class TYWindow : Window
    {
        public bool CloseWithPwd
        {
            get { return (bool)GetValue(CloseWithPwdProperty); }
            set { SetValue(CloseWithPwdProperty, value); }
        }         
        public static readonly DependencyProperty CloseWithPwdProperty =
            DependencyProperty.Register("CloseWithPwd", typeof(bool), typeof(TYWindow), new PropertyMetadata(false));

        public string ClosePWD
        {
            get { return (string)GetValue(ClosePWDProperty); }
            set { SetValue(ClosePWDProperty, value); }
        }
        
        public static readonly DependencyProperty ClosePWDProperty =
            DependencyProperty.Register("ClosePWD", typeof(string), typeof(TYWindow), new PropertyMetadata(""));

        public TYWindow()
        {
            ClosePWD = "1234";
            this.Closing += WindowT_Closing;
        }

        private void WindowT_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (CloseWithPwd == true)
            {
                //ViewEditPassword viewEditPassword = new ViewEditPassword(ClosePWD);
                //if (viewEditPassword.ShowDialog() != true)
                //{
                //    e.Cancel = true;
                //}
            }
            else
            {
                e.Cancel = false;
            }
        }

        public bool IsBusy
        {
            get { return (bool)GetValue(IsBusyProperty); }
            set { SetValue(IsBusyProperty, value); }
        }

        public static readonly DependencyProperty IsBusyProperty =
            DependencyProperty.Register("IsBusy", typeof(bool), typeof(TYWindow), new PropertyMetadata(false));

        public string BusyTitle
        {
            get { return (string)GetValue(BusyTitleProperty); }
            set { SetValue(BusyTitleProperty, value); }
        }

        public static readonly DependencyProperty BusyTitleProperty =
            DependencyProperty.Register("BusyTitle", typeof(string), typeof(TYWindow), new PropertyMetadata(""));

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

    public class BusyHelper : IDisposable
    {
        private TYWindow m_window;
        private TYUserControl m_control;
        private TYPage mPage;

        public BusyHelper(TYWindow window, string busyTitle)
        {
            if (window != null)
            {
                m_window = window;
                m_window.BusyTitle = busyTitle;
                m_window.IsBusy = true;
            }
        }

        public BusyHelper(TYUserControl window, string busyTitle)
        {
            if (window != null)
            {
                m_control = window;
                m_control.BusyTitle = busyTitle;
                m_control.IsBusy = true;
            }
        }

        public BusyHelper(TYPage paeg, string busyTitle)
        {
            if (mPage != null)
            {
                mPage = paeg;
                mPage.BusyTitle = busyTitle;
                mPage.IsBusy = true;
            }
        }

        public void Dispose()
        {
            if (m_window != null)
            {
                m_window.IsBusy = false;
            }
            if (m_control != null)
            {
                m_control.IsBusy = false;
            }
            if (mPage != null)
            {
                mPage.IsBusy = false;
            }
        }
    }

    public static class BusyExtend
    {
        public static async Task<TResult> Run<TResult>(this TYWindow t, Func<TResult> function, string busyTitle = "请稍等...")
        {
            using (var busy = new BusyHelper(t, busyTitle))
            {
                //await Task.Delay(2000);
                return await Task.Run<TResult>(function);
            }
        }

        public static async Task<TResult> Run<TResult>(this TYWindow t, Func<TResult> function, int delayTime, string busyTitle = "请稍等...")
        {
            using (var busy = new BusyHelper(t, busyTitle))
            {
                await Task.Delay(delayTime);
                return await Task.Run<TResult>(function);
            }
        }

        public static async Task Run(this TYWindow t, Action function, string busyTitle = "请稍等...")
        {
            using (var busy = new BusyHelper(t, busyTitle))
            {
                await Task.Run(function);
            }
        }

        public static async Task Run(this TYWindow t, Action function, int delayTime, string busyTitle = "请稍等...")
        {
            using (var busy = new BusyHelper(t, busyTitle))
            {
                await Task.Delay(delayTime);
                await Task.Run(function);
            }
        }

        public static void SetBusy(this TYWindow t, bool isBusy, string title = "请稍等..")
        {
            t.BusyTitle = title;
            t.IsBusy = isBusy;
        }

        public static async Task<TResult> RunEx<TResult>(this TYUserControl t, Func<TResult> function, string busyTitle = "请稍等...")
        {
            using (var busy = new BusyHelper(t, busyTitle))
            {
                //await Task.Delay(2000);
                return await Task.Run<TResult>(function);
            }
        }

        public static async Task<TResult> RunEx<TResult>(this TYUserControl t, Func<TResult> function, int delayTime, string busyTitle = "请稍等...")
        {
            using (var busy = new BusyHelper(t, busyTitle))
            {
                await Task.Delay(delayTime);
                return await Task.Run<TResult>(function);
            }
        }

        public static async Task RunEx(this TYUserControl t, Action function, string busyTitle = "请稍等...")
        {
            using (var busy = new BusyHelper(t, busyTitle))
            {
                await Task.Run(function);
            }
        }

        public static async Task RunEx(this TYUserControl t, Action function, int delayTime, string busyTitle = "请稍等...")
        {
            using (var busy = new BusyHelper(t, busyTitle))
            {
                await Task.Delay(delayTime);
                await Task.Run(function);
            }
        }

        public static void SetBusy(this TYUserControl t, bool isBusy, string title = "请稍等..")
        {
            t.BusyTitle = title;
            t.IsBusy = isBusy;
        }
    }
}