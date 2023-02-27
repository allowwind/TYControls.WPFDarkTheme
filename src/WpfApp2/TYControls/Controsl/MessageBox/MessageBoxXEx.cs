using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows;
using WPFX.Controls;
using System.Windows.Controls;
using System.Windows.Interop;

namespace TYControls
{
    public static class MessageBoxXEx
    {
        public static bool ShowYesNo(this Window win, string msg, string title)
        {
            MessageBoxPrivate message = new MessageBoxPrivate(msg, title, MessageBoxButton.YesNo);
            message.Owner = win;
            message.ShowDialog();
            var ret = message.Result;
            return ret == MessageBoxResult.Yes;


        }
        public static bool ShowYesNo(this Window win, string msg)
        {
            MessageBoxPrivate message = new MessageBoxPrivate(msg, "Info", MessageBoxButton.YesNo);
            message.Owner = win;
            message.ShowDialog();
            var ret = message.Result;
            return ret == MessageBoxResult.Yes;

        }
        public static void ShowMsg(this Window win, string message)
        {
            MessageBoxPrivate mbox = new MessageBoxPrivate(message, "Info", MessageBoxButton.OK);
            if (win != null)
            {
                mbox.Owner = win;
                mbox.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            }
            mbox.Show();
        }

        public static void ShowMsg(this Window win, string message, string title = "Info")
        {
            MessageBoxPrivate mbox = new MessageBoxPrivate(message, title, MessageBoxButton.OK);
            if (win != null)
            {
                mbox.Owner = win;
                mbox.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            }
            mbox.Show();
        }

        public static bool ShowYesNo(this UserControl win, string msg, string title)
        {
            return ShowYesNo(Window.GetWindow(win), msg, title);

        }
        public static bool ShowYesNo(this UserControl win, string msg)
        {
            return ShowYesNo(Window.GetWindow(win), msg);

        }
        public static void ShowMsg(this UserControl win, string message)
        {
            ShowMsg(Window.GetWindow(win), message);
        }

        public static void ShowMsg(this UserControl win, string message, string title = "Info")
        {
            ShowMsg(Window.GetWindow(win), message, title);
        }
    }
}
