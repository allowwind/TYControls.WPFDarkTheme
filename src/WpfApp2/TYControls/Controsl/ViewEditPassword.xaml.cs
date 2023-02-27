using System.Windows;

namespace TYControls
{
    /// <summary>
    /// View_EditInt.xaml 的交互逻辑
    /// </summary>
    public partial class ViewEditPassword : Window
    {
        private string Value { get; set; }

        public ViewEditPassword(string defaultTxt = "")
        {
            InitializeComponent();
            Value = defaultTxt;
        }

        private void BtnClickOK(object sender, RoutedEventArgs e)
        {
            if (Value == txtValue.Password)
            {
                this.DialogResult = true;
            }
            else
            {
                MessageBox.Show("密码错误");
            }
        }

        private void txtValue_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                if (Value == txtValue.Password)
                {
                    this.DialogResult = true;
                }
                else
                {
                    MessageBox.Show("密码错误");
                }
            }
        }
    }
}