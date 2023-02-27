using System.Windows;

namespace TYControls
{
    /// <summary>
    /// View_EditInt.xaml 的交互逻辑
    /// </summary>
    public partial class ViewEditString : Window
    {
        public bool CanEmpty;

        public string Data { get; set; }

        public ViewEditString(string defaultTxt = "", bool canEmpty = false)
        {
            InitializeComponent();
            Data = txtValue.Text = defaultTxt;
            CanEmpty = canEmpty;
        }

        private void BtnClickOK(object sender, RoutedEventArgs e)
        {
            if (CanEmpty == true)
            {
                Data = txtValue.Text;
                this.DialogResult = true;
            }
            else
            {
                if (txtValue.Text.NotNull())
                {
                    Data = txtValue.Text;
                    this.DialogResult = true;
                }
            }
        }
    }
}