using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TYControls;

namespace WpfApp2
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : TYWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        
            pager.PageCount = 50;
            Users = new List<User>
            {
                new User {Id = 1, Name = "John", PhoneNumber = 777666880},
                new User {Id = 2, Name = "Jane", PhoneNumber = 777666881},
                new User {Id = 3, Name = "Jimmy", PhoneNumber = 777666882},
                new User {Id = 4, Name = "Mary", PhoneNumber = 777666883},
                new User {Id = 5, Name = "Simon", PhoneNumber = 777666884},
                new User {Id = 6, Name = "Ann", PhoneNumber = 777666885},
                new User {Id = 1, Name = "John", PhoneNumber = 777666880},
                new User {Id = 2, Name = "Jane", PhoneNumber = 777666881},
                new User {Id = 3, Name = "Jimmy", PhoneNumber = 777666882},
                new User {Id = 4, Name = "Mary", PhoneNumber = 777666883},
                new User {Id = 5, Name = "Simon", PhoneNumber = 777666884},
                new User {Id = 6, Name = "Ann", PhoneNumber = 777666885},
            };

            ListView.ItemsSource = Users;
            DataGrid.ItemsSource = Users;
            DataGrid1.ItemsSource = Users;

            var list = new ObservableCollection<GridViewItem>
            {
                new GridViewItem() {Title = "Title 1", Progress = 50},
                new GridViewItem() {Title = "Title 2", Progress = 20},
                new GridViewItem() {Title = "Title 3", Progress = 10},
                new GridViewItem() {Title = "Title 4", Progress = 80},
                new GridViewItem() {Title = "Title 5", Progress = 30}
            };

            ListViewWithGridView.ItemsSource = list;
        }

        public List<User> Users { get; set; }

        private async void pager_PageIndexChanged(object sender, PageIndexChangedEventArgs e)
        {
            int pageIndex = pager.PageIndex;
            int pageSize = pager.PageSize;
            
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
    }

    public class GridViewItem : INotifyPropertyChanged
    {
        private string _uniqueDownloadId;
        private string _title;
        private int _progress;
        public event PropertyChangedEventHandler PropertyChanged;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged("title");
            }
        }

        public int Progress
        {
            get { return _progress; }
            set
            {
                _progress = value;
                OnPropertyChanged("Progress");
                OnPropertyChanged("ProgressPercent");
            }
        }

        public string ProgressPercent
        {
            get { return _progress + "%"; }
        }

        protected void OnPropertyChanged(string name)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }

}
