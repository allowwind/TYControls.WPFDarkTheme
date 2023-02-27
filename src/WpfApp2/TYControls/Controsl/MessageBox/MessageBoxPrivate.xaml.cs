using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TYControls
{
    /// <summary>
    /// MessageBoxPrivate.xaml 的交互逻辑
    /// </summary>
    public partial class MessageBoxPrivate : TYWindow
    {
        public MessageBoxResult Result { get; private set; } = MessageBoxResult.None;
        public MessageBoxPrivate(string msg, string title, MessageBoxButton btns)
        {
            InitializeComponent();
            this.txtTitle.Text = title;
            this.txtContent.Text = msg;

            switch (btns)
            {
                case MessageBoxButton.OK:
                    btnOK.Visibility = Visibility.Visible;
                    break;
                case MessageBoxButton.OKCancel:
                    btnOK.Visibility = Visibility.Visible;
                    btnCancle.Visibility = Visibility.Visible;
                    break;
                case MessageBoxButton.YesNoCancel:
                    btnYES.Visibility = Visibility.Visible;
                    btnNo.Visibility = Visibility.Visible;
                    btnCancle.Visibility = Visibility.Visible;
                    break;
                case MessageBoxButton.YesNo:
                    btnYES.Visibility = Visibility.Visible;
                    btnNo.Visibility = Visibility.Visible;
                    break;
                default:
                    break;
            } 
        }

        //public static System.Drawing.Icon ApplicationIcon { get; set; } = null;
     

        private void BtnClick_OK(object sender, RoutedEventArgs e)
        {
            Result = MessageBoxResult.OK;
            this.Close();
        }

        private void BtnClick_Yes(object sender, RoutedEventArgs e)
        {
            Result = MessageBoxResult.Yes;
            this.Close();
        }

        private void BtnClick_No(object sender, RoutedEventArgs e)
        {
            Result = MessageBoxResult.No;
            this.Close();
        }

        private void BtnClick_Cancle(object sender, RoutedEventArgs e)
        {
            Result = MessageBoxResult.Cancel;
            this.Close();
        }
    }
}
