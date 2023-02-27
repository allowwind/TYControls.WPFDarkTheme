using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TYControls
{

    public class PageIndexChangedEventArgs : RoutedEventArgs
    {
        public PageIndexChangedEventArgs(int currentIndex, RoutedEvent routedEvent) : base(routedEvent)
        {
            CurrentIndex = currentIndex;
        }

        public int CurrentIndex { get; set; }
    }

    public delegate void PageIndexChangedEventHandler(object sender, PageIndexChangedEventArgs e);
    /// 
    public partial class TYPager : UserControl
    {
        public TYPager()
        {
            InitializeComponent();
            if (PageCount == 0)
                PageCount = 1;
            if (PageIndex == 0)
                PageIndex = 1;
        }

        #region Routed Event
        public static readonly RoutedEvent PageIndexChangedEvent = EventManager.RegisterRoutedEvent("PageIndexChanged", RoutingStrategy.Bubble, typeof(PageIndexChangedEventHandler), typeof(TYPager));
        public event PageIndexChangedEventHandler PageIndexChanged
        {
            add { AddHandler(PageIndexChangedEvent, value); }
            remove { RemoveHandler(PageIndexChangedEvent, value); }
        }
        internal void RaisePageIndexChanged(int index)
        {
            var arg = new PageIndexChangedEventArgs(index, PageIndexChangedEvent);
            RaiseEvent(arg);
        }
        #endregion     
        public int PageIndex
        {
            get { return (int)GetValue(PageIndexProperty); }
            set { SetValue(PageIndexProperty, value); }
        }

        public static readonly DependencyProperty PageIndexProperty =
            DependencyProperty.Register("PageIndex", typeof(int), typeof(TYPager), new PropertyMetadata(OnPageIndexChanged));


        public int PageCount
        {
            get { return (int)GetValue(PageCountProperty); }
            set { SetValue(PageCountProperty, value); }
        }

        public static readonly DependencyProperty PageCountProperty =
            DependencyProperty.Register("PageCount", typeof(int), typeof(TYPager), new PropertyMetadata(OnPageCountChanged));



        public int DataCount
        {
            get { return (int)GetValue(DataCountProperty); }
            set { SetValue(DataCountProperty, value); }
        }



        public int PageSize
        {
            get { return (int)GetValue(PageSizeProperty); }
            set { SetValue(PageSizeProperty, value); }
        }

        public static readonly DependencyProperty PageSizeProperty =
            DependencyProperty.Register("PageSize", typeof(int), typeof(TYPager), new PropertyMetadata(30));


        public static readonly DependencyProperty DataCountProperty =
            DependencyProperty.Register("DataCount", typeof(int), typeof(TYPager), new PropertyMetadata(onDataCountChanged));

        private static void onDataCountChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var pagination = d as TYPager;
            pagination.PageCount = (pagination.DataCount + pagination.PageSize - 1) / pagination.PageSize;
        }




        internal ObservableCollection<PagerItem> PagerItems
        {
            get { return (ObservableCollection<PagerItem>)GetValue(PaginationItemsProperty); }
            set { SetValue(PaginationItemsProperty, value); }
        }

        internal static readonly DependencyProperty PaginationItemsProperty =
            DependencyProperty.Register("PagerItems", typeof(ObservableCollection<PagerItem>), typeof(TYPager));



        #region EventHandler

        public void FireOnIndedChanged(int index)
        {
            RaisePageIndexChanged(index);
        }
        private static void OnPageIndexChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var pagination = d as TYPager;

            if (pagination.PageIndex > pagination.PageCount)
            {
                pagination.PageIndex = pagination.PageCount;
                return;
            }
            else if (pagination.PageIndex < 1)
            {
                pagination.PageIndex = 1;
                return;
            }

            pagination.UpdatePagerItems();
        }

        private static void OnPageCountChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var pagination = d as TYPager;

            if (pagination.PageCount < 1)
            {
                pagination.PageCount = 1;
                return;
            }

            if (pagination.PageIndex > pagination.PageCount)
            {
                pagination.PageIndex = pagination.PageCount;
            }

            pagination.UpdatePagerItems();
        }
        #endregion

        #region Function
        private void UpdatePagerItems()
        {
            if (PagerItems == null)
                PagerItems = new ObservableCollection<PagerItem>();

            PagerItems.Clear();

            if (PageCount <= 7)
            {
                for (var i = 1; i <= PageCount; i++)
                {
                    PagerItems.Add(new PagerItem(i, PageIndex == i));
                }
            }
            else
            {
                PagerItems.Add(new PagerItem(1, PageIndex == 1));
                PagerItems.Add(new PagerItem(2, PageIndex == 2));


                if (PageIndex == 1 || PageIndex == 2 || PageIndex == 3 || PageIndex == 4)
                {
                    PagerItems.Add(new PagerItem(3, PageIndex == 3));
                    PagerItems.Add(new PagerItem(4, PageIndex == 4));
                    PagerItems.Add(new PagerItem(5, PageIndex == 5));
                }

                PagerItems.Add(new PagerItem(null));

                if (PageIndex >= PageCount - 3)
                {
                    PagerItems.Add(new PagerItem(null));

                    for (var i = PageCount - 4; i <= PageCount; i++)
                    {
                        PagerItems.Add(new PagerItem(i, PageIndex == i));
                    }
                    return;
                }
                if (PageIndex != 1 && PageIndex != 2 && PageIndex != 3 && PageIndex != 4)
                {
                    for (var i = PageIndex - 1; i <= (PageIndex + 1); i++)
                    {
                        PagerItems.Add(new PagerItem(i, PageIndex == i));
                    }
                }
                PagerItems.Add(new PagerItem(null));
                for (var i = PageCount - 1; i <= PageCount; i++)
                {
                    PagerItems.Add(new PagerItem(i, PageIndex == i));
                }
            }
        }
        #endregion

        private void BtnClickIndex(object sender, RoutedEventArgs e)
        {
            var dx = (sender as ToggleButton).DataContext as PagerItem;
            if (dx == null || dx.Value == null)
                return;
            dx.IsSelected = true;

            foreach (var item in PagerItems)
            {
                if (item != dx)
                {
                    item.IsSelected = false;
                }
            }

            FireOnIndedChanged(dx.Value.Value);

        }
    }

    internal class PagerItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public PagerItem(int? value)
        {
            Value = value;
        }

        public PagerItem(int? value, bool isSelected)
        {
            Value = value;
            IsSelected = isSelected;
        }

        private int? _Value;

        public int? Value
        {
            get { return _Value; }
            set { _Value = value; }
        }


        private bool _IsSelected;

        public bool IsSelected
        {
            get { return _IsSelected; }
            set
            {
                _IsSelected = value;
                OnPropertyChanged();
            }
        }

    }
}
